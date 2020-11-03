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

      internal class TypedDataSet : DataSet
      {
        public TypedDataSet()
        {
          Tables.Add(new DataTableGeneratorFacet.TypedDataTable1());
          Tables.Add(new DataTableGeneratorFacet.TypedDataTable2());
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
          Columns.Add(new DataColumn("TimeSpanColumn", typeof(TimeSpan)));
          Columns.Add(new DataColumn("StringColumn", typeof(string)));
        }
      }

      internal class TypedDataRow2 : DataRow
      {
        public TypedDataRow2(DataRowBuilder builder)
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
