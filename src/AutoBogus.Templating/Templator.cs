using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using AutoBogus;
using Bogus;

namespace AutoBogus.Templating
{
  internal class Templator<T> where T : class
  {
    private readonly AutoFaker<T> autoFaker;
    private List<Func<Type, string, (bool handled, object result)>> typeConverters = new List<Func<Type, string, (bool handled, object result)>>();

    private bool isConfigured = false;
    //if false will treat missing as empty
    private bool treatMissingAsNull = true;
    private string propertyNameSpaceDelimiter = null;
      
    public Templator(AutoFaker<T> autoFaker)
    {
      this.autoFaker = autoFaker;
    }

    /// <summary>
    /// Configure the templator from the binder
    /// </summary>
    private void ConfigureTemplator()
    {
      if (!isConfigured)
      {
        if (autoFaker.Binder is TemplateBinder templateBinder)
        {
          typeConverters = templateBinder.TypeConverters;
          treatMissingAsNull = templateBinder.TreatMissingAsNull;
          propertyNameSpaceDelimiter = templateBinder.PropertyNameSpaceDelimiter;
        }

        isConfigured = true;
      }

    }

    //public TemplateExtensions.DataGenerator SetPropertyNameSpaceDelimiter(string delimiter)
    //{
    //  PropertyNameSpaceDelimiter = delimiter;
    //  return this;
    //}


    /// <summary>
    /// Creates a set of test data with number of rows matching testItems but only using the headers in the headers list in the template
    /// Properties not in the headers list will use AutoFaker rules
    /// </summary>
    /// <param name="headers">List of headers matching testItems. Defines what properties in testItems we will set the value for</param>
    /// <param name="testItems"></param>
    /// <returns></returns>
    public List<T> GenerateFromTemplate(List<string> headers, List<T> testItems)
    {
      //note: Not the most efficient as it gets converted to a template string and then that gets parsed.
      var headersAsString = string.Join("|", headers);
      var stringBuilder = new StringBuilder();
      stringBuilder.AppendLine(headersAsString);

      var fieldNames = headersAsString.Split('|');
      foreach (var testItem in testItems)
      {
        var rowBuilder = new StringBuilder();
        for (var i = 0; i < fieldNames.Length; i++)
        {
          var testItemValue = ReflectionHelper.GetPropValue(testItem, fieldNames[i].Trim());
          if (i < fieldNames.Length - 1)
            rowBuilder.Append($"{testItemValue}|");
          else
            rowBuilder.Append(testItemValue);
        }

        //remove trailing |
        var row = rowBuilder.ToString();
        stringBuilder.AppendLine(row);
      }

      var testData = stringBuilder.ToString();
      return GenerateFromTemplate(testData);

    }

    /// <summary>
    /// Creates a set of test data with number of rows matching that in the dataAsString data set
    /// With fake values used unless the field is in the template
    /// </summary>
    /// <param name="template">Should be of form
    /// var testData  =
    ///     "EmployeeId | DateOfBirth     \r\n" +
    ///     "1          | 2000-01-01      \r\n" 
    ///        ;
    ///</param>
    /// <returns></returns>
    public List<T> GenerateFromTemplate(string template)
    {
      ConfigureTemplator();
      var allRows = ParseTemplate(template);

      //Faker.GlobalUniqueIndex = -1;
      //first generate some data
      var generatedData = autoFaker.Generate(allRows.Count).ToList();

      //now go through and set values as they are in the test data
      for (int i = 0; i < allRows.Count; i++)
      {
        var transaction = generatedData[i];
        var testRow = allRows[i];

        var properties = transaction.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).ToDictionary(k => k.Name);

        foreach (var fieldName in testRow.Keys)
        {
          var fieldNameTrim = fieldName.Trim();
          var fieldNameWithDelim = fieldNameTrim;
          if (propertyNameSpaceDelimiter != null)
          {
            fieldNameWithDelim = fieldNameTrim.Replace(" ", propertyNameSpaceDelimiter);
          }

          PropertyInfo prop = transaction.GetType()
            .GetProperty(fieldNameWithDelim, BindingFlags.Public | BindingFlags.Instance);
          if (null != prop && prop.CanWrite)
          {
            var value = testRow[fieldNameTrim].Trim();
            //now need to parse value as correct type
            var concretePropertyType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

            properties.Remove(prop.Name);

            SetPropertyValue(value, prop, transaction, concretePropertyType);

          }

        }
      }

      return generatedData;
    }

    public static object GetDefault(Type type)
    {
      if (type.IsValueType)
      {
        return Activator.CreateInstance(type);
      }
      return null;
    }

    private void SetPropertyValue(string value, PropertyInfo prop, T transaction, Type concretePropertyType)
    {
      //set nullable to null if string null
      if (string.IsNullOrEmpty(value) && prop.PropertyType.IsGenericType &&
          prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
      {
        prop.SetValue(transaction, null, null);
      }
      else if (concretePropertyType == typeof(decimal))
      {
        prop.SetValue(transaction, decimal.Parse(value), null);
      }
      else if (concretePropertyType == typeof(long))
      {
        prop.SetValue(transaction, long.Parse(value), null);
      }
      else if (concretePropertyType == typeof(DateTime))
      {
        //prop.SetValue(transaction, DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal), null);
        prop.SetValue(transaction, DateTime.Parse(value), null);
      }
      else if (concretePropertyType == typeof(bool))
      {
        prop.SetValue(transaction, bool.Parse(value), null);
      }
      else if (concretePropertyType == typeof(int))
      {
        prop.SetValue(transaction, int.Parse(value), null);
      }
      else if (concretePropertyType.IsEnum)
      {
        if (string.IsNullOrEmpty(value))
          prop.SetValue(transaction, 0, null);
        else
          prop.SetValue(transaction, Enum.Parse(concretePropertyType, value), null);
      }
      else
      {
        //see if we have custom converts specified for this type
        var handled = false;
        if (typeConverters!.Any())
        {
          foreach (var typeConvert in typeConverters!)
          {
            var result = typeConvert(concretePropertyType, value);
            if (result.handled)
            {
              prop.SetValue(transaction, result.result, null);
              handled = true;
            }
          }
        }

        //pretty much has to be a string if not then we may have a complex type with no converter
        if (!handled)
        {
          if (value == TemplateValues.NullToken)
          {
            prop.SetValue(transaction, null, null);
          }
          else if (value == TemplateValues.EmptyToken)
          {
            prop.SetValue(transaction, string.Empty, null);
          }
          else if (treatMissingAsNull && string.IsNullOrEmpty(value))
          {
            prop.SetValue(transaction, null, null);
          }
          else
          {
            prop.SetValue(transaction, value, null);
          }
        }
      }
    }

    private static List<Dictionary<string, string>> ParseTemplate(string testData)
    {
      //split on | and new line
      var stringReader = new StringReader(testData.Trim());

      var headers = stringReader.ReadLine()!.Split('|');

      var allRows = new List<Dictionary<string, string>>();

      string line;
      do
      {
        line = stringReader.ReadLine();

        if (line != null)
        {
          var thisRowDict = new Dictionary<string, string>();
          var thisLine = line.Split('|');

          //ignore lines of wrong length
          if (headers.Length != thisLine.Length) continue;

          for (int index = 0; index < headers.Length; index++)
          {
            
            var value = thisLine[index]!.Trim();
            thisRowDict[headers[index].Trim()] = value;
          }

          allRows.Add(thisRowDict);
        }
      } while (line != null);

      return allRows;
    }

    public static TCast Cast<TCast>(object o)
    {
      return (TCast)o;
    }

  }
}
