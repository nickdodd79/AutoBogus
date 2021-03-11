#if !NETSTANDARD1_3
using System;
using System.Data;
using System.Linq;
using System.Threading;

namespace AutoBogus.Generators
{
  internal abstract class DataTableGenerator
    : IAutoGenerator
  {
    public static bool IsTypedDataTableType(Type type, out Type rowType)
    {
      rowType = default;

      while (type != null)
      {
        if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(TypedTableBase<>)))
        {
          rowType = type.GetGenericArguments()[0];
          return true;
        }

        type = type.BaseType;
      }

      return false;
    }

    public static bool TryCreateGenerator(Type tableType, out DataTableGenerator generator)
    {
      generator = default;

      if (tableType == typeof(DataTable))
        generator = new UntypedDataTableGenerator();
      else if (IsTypedDataTableType(tableType, out var rowType))
      {
        var generatorType = typeof(TypedDataTableGenerator<,>).MakeGenericType(tableType, rowType);

        generator = (DataTableGenerator)Activator.CreateInstance(generatorType);
      }

      return (generator != null);
    }

    public object Generate(AutoGenerateContext context)
    {
      var table = CreateTable(context);

      context.Instance = table;

      PopulateRows(table, context);

      return table;
    }

    public void PopulateRows(DataTable table, AutoGenerateContext context)
    {
      int rowCount = -1;

      if (context.Config.DataTableRowCount != null)
        rowCount = context.Config.DataTableRowCount(context);

      if (rowCount < 0)
        rowCount = context.Faker.Random.Number(1, 20);

      while (rowCount > 0)
      {
        object[] columnValues = new object[table.Columns.Count];

        for (int i = 0; i < table.Columns.Count; i++)
          columnValues[i] = GenerateColumnValue(table.Columns[i], context);

        table.Rows.Add(columnValues);

        rowCount--;
      }
    }

    private object GenerateColumnValue(DataColumn dataColumn, AutoGenerateContext context)
    {
      switch (Type.GetTypeCode(dataColumn.DataType))
      {
        case TypeCode.Empty:
        case TypeCode.DBNull: return null;
        case TypeCode.Boolean: return context.Faker.Random.Bool();
        case TypeCode.Char: return context.Faker.Lorem.Letter().Single();
        case TypeCode.SByte: return context.Faker.Random.SByte();
        case TypeCode.Byte: return context.Faker.Random.Byte();
        case TypeCode.Int16: return context.Faker.Random.Short();
        case TypeCode.UInt16: return context.Faker.Random.UShort();
        case TypeCode.Int32:
        {
          if (dataColumn.ColumnName.EndsWith("ID", StringComparison.OrdinalIgnoreCase))
            return Interlocked.Increment(ref context.Faker.IndexFaker);
          else
            return context.Faker.Random.Int();
        }
        case TypeCode.UInt32: return context.Faker.Random.UInt();
        case TypeCode.Int64: return context.Faker.Random.Long();
        case TypeCode.UInt64: return context.Faker.Random.ULong();
        case TypeCode.Single: return context.Faker.Random.Float();
        case TypeCode.Double: return context.Faker.Random.Double();
        case TypeCode.Decimal: return context.Faker.Random.Decimal();
        case TypeCode.DateTime: return context.Faker.Date.Between(DateTime.UtcNow.AddDays(-30), DateTime.UtcNow.AddDays(+30));
        case TypeCode.String: return context.Faker.Lorem.Lines(1);

        default:
          if (dataColumn.DataType == typeof(TimeSpan))
            return context.Faker.Date.Future() - context.Faker.Date.Future();
          else if (dataColumn.DataType == typeof(Guid))
            return context.Faker.Random.Guid();
          else
          {
            var proxy = (Proxy)Activator.CreateInstance(typeof(Proxy<>).MakeGenericType(dataColumn.DataType));

            return proxy.Generate(context);
          }
      }
    }

    abstract class Proxy
    {
      public abstract object Generate(AutoGenerateContext context);
    }

    class Proxy<T> : Proxy
    {
      public override object Generate(AutoGenerateContext context)
        => context.Generate<T>();
    }

    protected abstract DataTable CreateTable(AutoGenerateContext context);

    class UntypedDataTableGenerator
      : DataTableGenerator
    {
      protected override DataTable CreateTable(AutoGenerateContext context)
      {
        var table = new DataTable();

        for (int i = context.Faker.Random.Int(3, 10); i >= 0; i--)
        {
          table.Columns.Add(
            new DataColumn()
            {
              ColumnName = context.Faker.Database.Column() + i,
              DataType = Type.GetType("System." + context.Faker.PickRandom(
                ((TypeCode[])Enum.GetValues(typeof(TypeCode)))
                .Except(new[] { TypeCode.Empty, TypeCode.Object, TypeCode.DBNull })
                .ToArray())),
            });
        }

        return table;
      }
    }

    class TypedDataTableGenerator<TTable, TRow>
      : DataTableGenerator
      where TTable : DataTable, new()
    {
      protected override DataTable CreateTable(AutoGenerateContext context)
        => new TTable();
    }
  }
}
#endif
