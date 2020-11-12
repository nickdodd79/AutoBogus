#if !NETSTANDARD1_3
using System;
using System.Data;
using System.Linq;

namespace AutoBogus.Generators
{
  internal abstract class DataSetGenerator
    : IAutoGenerator
  {
    public static bool TryCreateGenerator(Type dataSetType, out DataSetGenerator generator)
    {
      generator = default;

      if (dataSetType == typeof(DataSet))
        generator = new UntypedDataSetGenerator();
      else if (typeof(DataSet).IsAssignableFrom(dataSetType))
        generator = new TypedDataSetGenerator(dataSetType);

      return (generator != null);
    }

    public abstract object Generate(AutoGenerateContext context);

    class UntypedDataSetGenerator : DataSetGenerator
    {
      public override object Generate(AutoGenerateContext context)
      {
        var dataSet = new DataSet();

        if (!DataTableGenerator.TryCreateGenerator(typeof(DataTable), out var tableGenerator))
          throw new Exception("Internal error: Couldn't create generator for DataTable");

        for (int tableCount = context.Faker.Random.Int(2, 6); tableCount > 0; tableCount--)
          dataSet.Tables.Add((DataTable)tableGenerator.Generate(context));

        return dataSet;
      }
    }

    class TypedDataSetGenerator : DataSetGenerator
    {
      Type _dataSetType;

      public TypedDataSetGenerator(Type dataSetType)
      {
        _dataSetType = dataSetType;
      }

      public override object Generate(AutoGenerateContext context)
      {
        var dataSet = (DataSet)Activator.CreateInstance(_dataSetType);

        foreach (var table in dataSet.Tables.OfType<DataTable>())
        {
          if (!DataTableGenerator.TryCreateGenerator(table.GetType(), out var tableGenerator))
            throw new Exception($"Couldn't create generator for typed table type {table.GetType()}");

          context.Instance = table;

          tableGenerator.PopulateRows(table, context);
        }

        return dataSet;
      }
    }
  }
}
#endif
