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

namespace AutoBogus.Template
{
  internal class Templator<T> where T : class
  {
    private readonly AutoFaker<T> autoFaker;
    private readonly List<Func<Type, string, object>> typeConverters = new List<Func<Type, string, object>>();

    private string? outputDatesAsStringFormat = null;
    //if false will treat missing as empty
    private bool treatMissingAsNull = true;
      
    public Templator(AutoFaker<T> autoFaker)
    {
      this.autoFaker = autoFaker;
    }

    /// <summary>
    /// Set if we need to translate a string in the property name to space (e.g. AE_Date -> AE Date (tpp))
    /// </summary>
    public string? PropertyNameSpaceDelimiter { get; set; }

    //public TemplateExtensions.DataGenerator SetTypeConverter(Func<Type, string, object> typeConverter)
    //{
    //  typeConverters.Add(typeConverter);
    //  return this;
    //}

    /// <summary>
    /// override the default date format used by methods that translate dates back to string/object (currently GetRowsObjectArray)
    /// </summary>
    /// <param name="format"></param>
    /// <returns></returns>
    //public TemplateExtensions.DataGenerator SetOutputDatesAsStringWithFormat(string format)
    //{
    //  outputDatesAsStringFormat = format;
    //  return this;
    //}

    /// <summary>
    /// With ExpectedFieldsBehaviour enabled any string properties that start with Expected will be set to DataGenerator.UnspecifiedStringValue 
    /// </summary>
    /// <returns></returns>
    //public TemplateExtensions.DataGenerator ExpectedFieldsBehaviour(bool enable = true)
    //{
    //  enabledExpectedFields = enable;

    //  return this;
    //}

    /// <summary>
    /// With treatMissingAsNull enabled any empty string values in the input will be set to null in the output
    /// </summary>
    /// <returns></returns>
    //public TemplateExtensions.DataGenerator SetTreatMissingAsNull(bool enable = true)
    //{
    //  treatMissingAsNull = enable;

    //  return this;
    //}

    //public TemplateExtensions.DataGenerator SetPropertyNameSpaceDelimiter(string delimiter)
    //{
    //  PropertyNameSpaceDelimiter = delimiter;
    //  return this;
    //}


    /// <summary>
    /// Creates a set of test data with number of rows matching testItems and using the fields direct from testItems
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
          if (PropertyNameSpaceDelimiter != null)
          {
            fieldNameWithDelim = fieldNameTrim.Replace(" ", PropertyNameSpaceDelimiter);
          }

          PropertyInfo? prop = transaction.GetType()
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

    public static object? GetDefault(Type type)
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
        if (typeConverters.Any())
        {
          foreach (var typeConvert in typeConverters)
          {
            var converted = typeConvert(concretePropertyType, value);
            if (converted != null)
            {
              prop.SetValue(transaction, converted, null);
              handled = true;
            }
          }
        }


        //pretty much has to be a string
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
      string[] lines = testData.Split(new string[] {"\n", "\r\n"}, StringSplitOptions.RemoveEmptyEntries);

      if (lines.Length == 0)
        throw new ArgumentException($"{nameof(testData)} must contain a header line and 1 or more data lines");

      //read line 0 - headers
      var headers = lines[0]!.Split('|');
      var allRows = new List<Dictionary<string, string>>();

      for (int i = 1; i < lines.Length; i++)
      {
        var thisRowDict = new Dictionary<string, string>();
        var thisLine = lines[i].Split('|');

        for (int index = 0; index < headers.Length; index++)
        {
          var value = thisLine[index]!.Trim();
          thisRowDict[headers[index].Trim()] = value;
        }
        allRows.Add(thisRowDict);
      }

      return allRows;
    }



    public static TCast Cast<TCast>(object o)
    {
      return (TCast)o;
    }



    /// <summary>
    /// Gets the property value but allows types to be translated as strings (e.g. dates)
    /// </summary>
    /// <param name="src"></param>
    /// <param name="propName"></param>
    /// <returns></returns>
    public object? GetPropValueWithTranslate(object src, string propName)
    {
      if (outputDatesAsStringFormat == null)
      {
        return ReflectionHelper.GetPropValue(src, propName);
      }

      var propertyInfo = src.GetType().GetProperty(propName);
      if (propertyInfo?.PropertyType != typeof(DateTime) && propertyInfo?.PropertyType != typeof(DateTime?))
      {
        return ReflectionHelper.GetPropValue(src, propName);
      }

      var value = propertyInfo.GetValue(src, null);
      if (value == null)
        return null;

      var dateValue = (DateTime) value;

      return dateValue.ToString(outputDatesAsStringFormat);
    }

    

    /// <summary>
    /// Returns the proeprties in T as a list
    /// </summary>
    /// <returns></returns>
    public List<string> GetFieldList()
    {
      var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).ToDictionary(k => 
        PropertyNameSpaceDelimiter != null ? k.Name.Replace(PropertyNameSpaceDelimiter, " "): k.Name
      );

      return properties.Keys.ToList();
    }

    public List<object?[]> GetRowsObjectArrays(List<T> items, List<string> fieldList)
    {
      var output = new List<object?[]>();
      foreach (var item in items)
      {
        var row = new object?[fieldList.Count];
        for (int i = 0; i < fieldList.Count; i++)
        {
          var propName = fieldList[i];
          if (PropertyNameSpaceDelimiter != null)
          {
            propName = propName.Replace(" ", PropertyNameSpaceDelimiter);
          }

          row[i] = GetPropValueWithTranslate(item, propName);
        }
        output.Add(row);
      }

      return output;
    }
  }
}
