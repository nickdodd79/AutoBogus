using AutoBogus.Generators;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Xunit;
using Xunit.Sdk;

namespace AutoBogus.Tests
{
  partial class AutoGeneratorsFixture
  {
    public class DataSetGeneratorFacet
      : AutoGeneratorsFixture
    {
      public static IEnumerable<object[]> GetTryCreateGeneratorTestCases()
      {
        yield return new object[] { typeof(DataSet), true };
        yield return new object[] { typeof(TypedDataSet), true };
        yield return new object[] { typeof(object), false };
      }

      [Theory]
      [MemberData(nameof(GetTryCreateGeneratorTestCases))]
      public void TryCreateGenerator_Should_Create_Generator(Type dataSetType, bool shouldSucceed)
      {
        // Act
        bool success = DataSetGenerator.TryCreateGenerator(dataSetType, out var generator);

        // Assert
        if (shouldSucceed)
        {
          success.Should().BeTrue();
          generator.Should().NotBeNull();
        }
        else
          success.Should().BeFalse();
      }

      public static IEnumerable<object[]> GetGenerateTestCases()
      {
        yield return new object[] { typeof(DataSet) };
        yield return new object[] { typeof(TypedDataSet) };
        yield return new object[] { typeof(TypedDataSetWithRelations) };
        yield return new object[] { typeof(TypedDataSetWithSelfReferencingTable) };
      }

      [SkippableTheory]
      [MemberData(nameof(GetGenerateTestCases))]
      public void Generate_Should_Return_DataSet(Type dataSetType)
      {
        // Arrange
        var context = CreateContext(dataSetType);

        bool success = DataSetGenerator.TryCreateGenerator(context.GenerateType, out var generator);

        Skip.IfNot(success, $"couldn't create generator for {dataSetType.Name}");

        // Act
        var result = generator.Generate(context);

        // Assert
        result.Should().BeOfType(dataSetType);

        var dataSet = (DataSet)result;

        dataSet.Tables.Should().NotBeEmpty();

        foreach (var table in dataSet.Tables.OfType<DataTable>())
        {
          table.Columns.Should().NotBeEmpty();
          table.Rows.Should().NotBeEmpty();
        }
      }

      [SkippableTheory]
      [MemberData(nameof(GetGenerateTestCases))]
      public void Generate_Should_Return_DataSet_With_Specified_DataTable_Row_Counts(Type dataSetType)
      {
        // Arrange
        var rowCountByTable = new Dictionary<DataTable, int>();

        Func<AutoGenerateContext, int> rowCountFunctor =
          (AutoGenerateContext ctx) =>
          {
            var dataTable = (DataTable)ctx.Instance;

            if (!rowCountByTable.TryGetValue(dataTable, out var count))
            {
              // Because Table2.RecordID is a Primary Key and this Unique, Table2
              // must not have more records than Table1 otherwise it is impossible
              // to have unique values. So, assuming that the dependent tables
              // come last in the DataSet, we have a decreasing count as we progress
              // through the list.

              count = 100 - (rowCountByTable.Count + 1) * 10;

              rowCountByTable[dataTable] = count;
            }

            return count;
          };

        var context = CreateContext(dataSetType, dataTableRowCountFunctor: rowCountFunctor);

        bool success = DataSetGenerator.TryCreateGenerator(context.GenerateType, out var generator);

        Skip.IfNot(success, $"couldn't create generator for {dataSetType.Name}");

        // Act
        var result = generator.Generate(context);

        // Assert
        result.Should().BeOfType(dataSetType);

        var dataSet = (DataSet)result;

        dataSet.Tables.Should().NotBeEmpty();

        foreach (var table in dataSet.Tables.OfType<DataTable>())
        {
          table.Columns.Should().NotBeEmpty();

          table.Rows.Should().HaveCount(rowCountByTable[table]);
        }
      }

      [SkippableFact]
      public void Generate_Should_Fail_If_Requested_Row_Count_Is_Impossible_Due_To_Foreign_Key_Constraint()
      {
        // Arrange
        var dataSetType = typeof(TypedDataSetWithRelations);

        var rowCountByTable = new Dictionary<DataTable, int>();

        Func<AutoGenerateContext, int> rowCountFunctor =
          (AutoGenerateContext ctx) =>
          {
            var dataTable = (DataTable)ctx.Instance;

            if (!rowCountByTable.TryGetValue(dataTable, out var count))
            {
              // Because Table2.RecordID is a Primary Key and this Unique, Table2
              // must not have more records than Table1 otherwise it is impossible
              // to have unique values. So, assuming that the dependent tables
              // come last in the DataSet, having an increasing count creates an
              // impossible situation where there aren't enough related records
              // to produce unique values.

              count = 100 + (rowCountByTable.Count + 1) * 10;

              rowCountByTable[dataTable] = count;
            }

            return count;
          };

        var context = CreateContext(dataSetType, dataTableRowCountFunctor: rowCountFunctor);

        bool success = DataSetGenerator.TryCreateGenerator(context.GenerateType, out var generator);

        Skip.IfNot(success, $"couldn't create generator for {dataSetType.Name}");

        // Act
        Action action =
          () => generator.Generate(context);

        // Assert
        action.Should().Throw<ArgumentException>()
          .Which.Message.Should().StartWith("Unable to satisfy the requested row count");
      }

      internal class TypedDataSet : DataSet
      {
        public TypedDataSet()
        {
          Tables.Add(new DataTableGeneratorFacet.TypedDataTable1());
          Tables.Add(new DataTableGeneratorFacet.TypedDataTable2());
        }
      }

      internal class TypedDataSetWithRelations : DataSet
      {
        public TypedDataSetWithRelations()
        {
          var table1 = new DataTableGeneratorFacet.TypedDataTable1();
          var table2 = new DataTableGeneratorFacet.TypedDataTable2();
          var table3 = new DataTableGeneratorFacet.TypedDataTable3();

          Tables.Add(table3);
          Tables.Add(table2);
          Tables.Add(table1);

          Relations.Add(
            new DataRelation(relationName: "Relation1", parentColumn: table1.Columns["RecordID"], childColumn: table2.Columns["RecordID"], createConstraints: true));
          Relations.Add(
            new DataRelation(relationName: "Relation2", parentColumn: table2.Columns["IntColumn"], childColumn: table3.Columns["ParentIntColumn"], createConstraints: true));
        }
      }

      internal class TypedDataSetWithSelfReferencingTable : DataSet
      {
        public TypedDataSetWithSelfReferencingTable()
        {
          var table = new DataTableGeneratorFacet.TypedDataTable3();

          Tables.Add(table);

          Relations.Add(
            new DataRelation(relationName: "Relation", parentColumn: table.Columns["RecordID"], childColumn: table.Columns["ParentIntColumn"], createConstraints: true));
        }
      }
    }

    public class DataTableGeneratorFacet
      : AutoGeneratorsFixture
    {
      public static IEnumerable<object[]> GetTryCreateGeneratorTestCases()
      {
        yield return new object[] { typeof(DataTable), true };
        yield return new object[] { typeof(TypedDataTable1), true };
        yield return new object[] { typeof(TypedDataTable2), true };
        yield return new object[] { typeof(object), false };
      }

      [Theory]
      [MemberData(nameof(GetTryCreateGeneratorTestCases))]
      public void TryCreateGenerator_Should_Create_Generator(Type dataTableType, bool shouldSucceed)
      {
        // Act
        bool success = DataTableGenerator.TryCreateGenerator(dataTableType, out var generator);

        // Assert
        if (shouldSucceed)
        {
          success.Should().BeTrue();
          generator.Should().NotBeNull();
        }
        else
          success.Should().BeFalse();
      }

      public static IEnumerable<object[]> GetGenerateTestCases()
      {
        yield return new object[] { typeof(DataTable) };
        yield return new object[] { typeof(TypedDataTable1) };
        yield return new object[] { typeof(TypedDataTable2) };
      }

      [SkippableTheory]
      [MemberData(nameof(GetGenerateTestCases))]
      public void Generate_Should_Return_DataTable(Type dataTableType)
      {
        // Arrange
        var context = CreateContext(dataTableType);

        bool success = DataTableGenerator.TryCreateGenerator(context.GenerateType, out var generator);

        Skip.IfNot(success, $"couldn't create generator for {dataTableType.Name}");

        // Act
        var result = generator.Generate(context);

        // Assert
        result.Should().BeOfType(dataTableType);

        var dataTable = (DataTable)result;

        dataTable.Columns.Should().NotBeEmpty();
        dataTable.Rows.Should().NotBeEmpty();
      }

      [SkippableTheory]
      [MemberData(nameof(GetGenerateTestCases))]
      public void Generate_Should_Return_DataTable_With_Specified_Row_Count(Type dataTableType)
      {
        // Arrange
        const int RowCount = 100;

        Func<AutoGenerateContext, int> rowCountFunctor =
          _ => RowCount;

        var context = CreateContext(dataTableType, dataTableRowCountFunctor: rowCountFunctor);

        bool success = DataTableGenerator.TryCreateGenerator(context.GenerateType, out var generator);

        Skip.IfNot(success, $"couldn't create generator for {dataTableType.Name}");

        // Act
        var result = generator.Generate(context);

        // Assert
        result.Should().BeOfType(dataTableType);

        var dataTable = (DataTable)result;

        dataTable.Columns.Should().NotBeEmpty();
        dataTable.Rows.Should().HaveCount(RowCount);
      }
      internal class TypedDataTable1 : TypedTableBase<TypedDataRow1>
      {
        public TypedDataTable1()
        {
          TableName = "TypedDataTable1";

          Columns.Add(new DataColumn("RecordID", typeof(int)));
          Columns.Add(new DataColumn("BoolColumn", typeof(bool)));
          Columns.Add(new DataColumn("CharColumn", typeof(char)));
          Columns.Add(new DataColumn("SignedByteColumn", typeof(sbyte)));
          Columns.Add(new DataColumn("ByteColumn", typeof(byte)));
          Columns.Add(new DataColumn("ShortColumn", typeof(short)));
          Columns.Add(new DataColumn("UnsignedShortColumn", typeof(ushort)));
          Columns.Add(new DataColumn("IntColumn", typeof(int)));
          Columns.Add(new DataColumn("GuidColumn", typeof(Guid)));

          PrimaryKey = new[] { Columns[0] };
        }
      }

      internal class TypedDataRow1 : DataRow
      {
        public TypedDataRow1(DataRowBuilder builder)
          : base(builder)
        {
        }
      }

      internal class TypedDataTable2 : TypedTableBase<TypedDataRow2>
      {
        public TypedDataTable2()
        {
          TableName = "TypedDataTable2";

          Columns.Add(new DataColumn("RecordID", typeof(int)));
          Columns.Add(new DataColumn("IntColumn", typeof(int)));
          Columns.Add(new DataColumn("UnsignedIntColumn", typeof(uint)));
          Columns.Add(new DataColumn("LongColumn", typeof(long)));
          Columns.Add(new DataColumn("UnsignedLongColumn", typeof(ulong)));
          Columns.Add(new DataColumn("SingleColumn", typeof(float)));
          Columns.Add(new DataColumn("DoubleColumn", typeof(double)));
          Columns.Add(new DataColumn("DecimalColumn", typeof(decimal)));
          Columns.Add(new DataColumn("DateTimeColumn", typeof(DateTime)));
          Columns.Add(new DataColumn("DateTimeOffsetColumn", typeof(DateTimeOffset)));
          Columns.Add(new DataColumn("TimeSpanColumn", typeof(TimeSpan)));
          Columns.Add(new DataColumn("StringColumn", typeof(string)));

          PrimaryKey = new[] { Columns[0] };
        }
      }

      internal class TypedDataRow2 : DataRow
      {
        public TypedDataRow2(DataRowBuilder builder)
          : base(builder)
        {
        }
      }

      internal class TypedDataTable3 : TypedTableBase<TypedDataRow3>
      {
        public TypedDataTable3()
        {
          TableName = "TypedDataTable3";

          Columns.Add(new DataColumn("RecordID", typeof(int)));
          Columns.Add(new DataColumn("ParentIntColumn", typeof(int)));
          Columns.Add(new DataColumn("Value", typeof(string)));
        }
      }

      internal class TypedDataRow3 : DataRow
      {
        public TypedDataRow3(DataRowBuilder builder)
          : base(builder)
        {
        }
      }
    }

    static internal Type ResolveType(string fullTypeName, bool throwOnError)
    {
      foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        if (assembly.GetType(fullTypeName) is Type type)
          return type;

      if (throwOnError)
        throw new XunitException($"Unable to resolve type: {fullTypeName}");

      return null;
    }
  }
}
