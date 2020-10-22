namespace AutoBogus.Conventions.Generators
{

  // Address.BuildingNumber
  internal sealed class BuildingNumberByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.BuildingNumber.Enabled &&
             config.BuildingNumber.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.BuildingNumber.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Address.BuildingNumber();
      }

      return context.Instance;
    }
  }

  // Address.CardinalDirection
  internal sealed class CardinalDirectionByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.CardinalDirection.Enabled &&
             config.CardinalDirection.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.CardinalDirection.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Address.CardinalDirection();
      }

      return context.Instance;
    }
  }

  // Address.City
  internal sealed class CityByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.City.Enabled &&
             config.City.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.City.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Address.City();
      }

      return context.Instance;
    }
  }

  // Address.CityPrefix
  internal sealed class CityPrefixByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.CityPrefix.Enabled &&
             config.CityPrefix.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.CityPrefix.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Address.CityPrefix();
      }

      return context.Instance;
    }
  }

  // Address.CitySuffix
  internal sealed class CitySuffixByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.CitySuffix.Enabled &&
             config.CitySuffix.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.CitySuffix.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Address.CitySuffix();
      }

      return context.Instance;
    }
  }

  // Address.Country
  internal sealed class CountryByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Country.Enabled &&
             config.Country.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Country.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Address.Country();
      }

      return context.Instance;
    }
  }

  // Address.CountryCode
  internal sealed class CountryCodeByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.CountryCode.Enabled &&
             config.CountryCode.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.CountryCode.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Address.CountryCode();
      }

      return context.Instance;
    }
  }

  // Address.County
  internal sealed class CountyByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.County.Enabled &&
             config.County.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.County.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Address.County();
      }

      return context.Instance;
    }
  }

  // Address.Direction
  internal sealed class DirectionByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Direction.Enabled &&
             config.Direction.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Direction.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Address.Direction();
      }

      return context.Instance;
    }
  }

  // Address.FullAddress
  internal sealed class FullAddressByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.FullAddress.Enabled &&
             config.FullAddress.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.FullAddress.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Address.FullAddress();
      }

      return context.Instance;
    }
  }

  // Address.Latitude
  internal sealed class LatitudeByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Latitude.Enabled &&
             config.Latitude.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.Double);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Latitude.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Address.Latitude();
      }

      return context.Instance;
    }
  }

  // Address.Longitude
  internal sealed class LongitudeByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Longitude.Enabled &&
             config.Longitude.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.Double);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Longitude.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Address.Longitude();
      }

      return context.Instance;
    }
  }

  // Address.OrdinalDirection
  internal sealed class OrdinalDirectionByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.OrdinalDirection.Enabled &&
             config.OrdinalDirection.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.OrdinalDirection.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Address.OrdinalDirection();
      }

      return context.Instance;
    }
  }

  // Address.SecondaryAddress
  internal sealed class SecondaryAddressByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.SecondaryAddress.Enabled &&
             config.SecondaryAddress.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.SecondaryAddress.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Address.SecondaryAddress();
      }

      return context.Instance;
    }
  }

  // Address.State
  internal sealed class StateByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.State.Enabled &&
             config.State.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.State.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Address.State();
      }

      return context.Instance;
    }
  }

  // Address.StateAbbr
  internal sealed class StateAbbrByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.StateAbbr.Enabled &&
             config.StateAbbr.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.StateAbbr.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Address.StateAbbr();
      }

      return context.Instance;
    }
  }

  // Address.StreetAddress
  internal sealed class StreetAddressByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.StreetAddress.Enabled &&
             config.StreetAddress.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.StreetAddress.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Address.StreetAddress();
      }

      return context.Instance;
    }
  }

  // Address.StreetName
  internal sealed class StreetNameByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.StreetName.Enabled &&
             config.StreetName.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.StreetName.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Address.StreetName();
      }

      return context.Instance;
    }
  }

  // Address.StreetSuffix
  internal sealed class StreetSuffixByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.StreetSuffix.Enabled &&
             config.StreetSuffix.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.StreetSuffix.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Address.StreetSuffix();
      }

      return context.Instance;
    }
  }

  // Address.ZipCode
  internal sealed class ZipCodeByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.ZipCode.Enabled &&
             config.ZipCode.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.ZipCode.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Address.ZipCode();
      }

      return context.Instance;
    }
  }

  // Commerce.Color
  internal sealed class ColorByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Color.Enabled &&
             config.Color.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Color.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Commerce.Color();
      }

      return context.Instance;
    }
  }

  // Commerce.Department
  internal sealed class DepartmentByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Department.Enabled &&
             config.Department.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Department.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Commerce.Department();
      }

      return context.Instance;
    }
  }

  // Commerce.Ean13
  internal sealed class Ean13ByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Ean13.Enabled &&
             config.Ean13.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Ean13.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Commerce.Ean13();
      }

      return context.Instance;
    }
  }

  // Commerce.Ean8
  internal sealed class Ean8ByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Ean8.Enabled &&
             config.Ean8.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Ean8.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Commerce.Ean8();
      }

      return context.Instance;
    }
  }

  // Commerce.Price
  internal sealed class PriceByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Price.Enabled &&
             config.Price.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Price.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Commerce.Price();
      }

      return context.Instance;
    }
  }

  // Commerce.Product
  internal sealed class ProductByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Product.Enabled &&
             config.Product.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Product.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Commerce.Product();
      }

      return context.Instance;
    }
  }

  // Commerce.ProductAdjective
  internal sealed class ProductAdjectiveByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.ProductAdjective.Enabled &&
             config.ProductAdjective.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.ProductAdjective.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Commerce.ProductAdjective();
      }

      return context.Instance;
    }
  }

  // Commerce.ProductDescription
  internal sealed class ProductDescriptionByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.ProductDescription.Enabled &&
             config.ProductDescription.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.ProductDescription.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Commerce.ProductDescription();
      }

      return context.Instance;
    }
  }

  // Commerce.ProductMaterial
  internal sealed class ProductMaterialByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.ProductMaterial.Enabled &&
             config.ProductMaterial.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.ProductMaterial.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Commerce.ProductMaterial();
      }

      return context.Instance;
    }
  }

  // Commerce.ProductName
  internal sealed class ProductNameByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.ProductName.Enabled &&
             config.ProductName.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.ProductName.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Commerce.ProductName();
      }

      return context.Instance;
    }
  }

  // Company.Bs
  internal sealed class BsByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Bs.Enabled &&
             config.Bs.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Bs.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Company.Bs();
      }

      return context.Instance;
    }
  }

  // Company.CatchPhrase
  internal sealed class CatchPhraseByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.CatchPhrase.Enabled &&
             config.CatchPhrase.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.CatchPhrase.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Company.CatchPhrase();
      }

      return context.Instance;
    }
  }

  // Company.CompanyName
  internal sealed class CompanyNameByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.CompanyName.Enabled &&
             config.CompanyName.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.CompanyName.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Company.CompanyName();
      }

      return context.Instance;
    }
  }

  // Company.CompanySuffix
  internal sealed class CompanySuffixByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.CompanySuffix.Enabled &&
             config.CompanySuffix.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.CompanySuffix.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Company.CompanySuffix();
      }

      return context.Instance;
    }
  }

  // Database.Collation
  internal sealed class CollationByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Collation.Enabled &&
             config.Collation.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Collation.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Database.Collation();
      }

      return context.Instance;
    }
  }

  // Database.Column
  internal sealed class ColumnByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Column.Enabled &&
             config.Column.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Column.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Database.Column();
      }

      return context.Instance;
    }
  }

  // Database.Engine
  internal sealed class EngineByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Engine.Enabled &&
             config.Engine.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Engine.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Database.Engine();
      }

      return context.Instance;
    }
  }

  // Database.Type
  internal sealed class TypeByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Type.Enabled &&
             config.Type.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Type.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Database.Type();
      }

      return context.Instance;
    }
  }

  // Finance.Account
  internal sealed class AccountByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Account.Enabled &&
             config.Account.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Account.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Finance.Account();
      }

      return context.Instance;
    }
  }

  // Finance.AccountName
  internal sealed class AccountNameByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.AccountName.Enabled &&
             config.AccountName.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.AccountName.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Finance.AccountName();
      }

      return context.Instance;
    }
  }

  // Finance.Amount
  internal sealed class AmountByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Amount.Enabled &&
             config.Amount.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.Decimal);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Amount.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Finance.Amount();
      }

      return context.Instance;
    }
  }

  // Finance.Bic
  internal sealed class BicByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Bic.Enabled &&
             config.Bic.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Bic.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Finance.Bic();
      }

      return context.Instance;
    }
  }

  // Finance.BitcoinAddress
  internal sealed class BitcoinAddressByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.BitcoinAddress.Enabled &&
             config.BitcoinAddress.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.BitcoinAddress.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Finance.BitcoinAddress();
      }

      return context.Instance;
    }
  }

  // Finance.CreditCardCvv
  internal sealed class CreditCardCvvByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.CreditCardCvv.Enabled &&
             config.CreditCardCvv.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.CreditCardCvv.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Finance.CreditCardCvv();
      }

      return context.Instance;
    }
  }

  // Finance.CreditCardNumber
  internal sealed class CreditCardNumberByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.CreditCardNumber.Enabled &&
             config.CreditCardNumber.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.CreditCardNumber.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Finance.CreditCardNumber();
      }

      return context.Instance;
    }
  }

  // Finance.Currency
  internal sealed class CurrencyByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Currency.Enabled &&
             config.Currency.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(Bogus.DataSets.Currency);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Currency.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Finance.Currency();
      }

      return context.Instance;
    }
  }

  // Finance.EthereumAddress
  internal sealed class EthereumAddressByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.EthereumAddress.Enabled &&
             config.EthereumAddress.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.EthereumAddress.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Finance.EthereumAddress();
      }

      return context.Instance;
    }
  }

  // Finance.Iban
  internal sealed class IbanByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Iban.Enabled &&
             config.Iban.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Iban.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Finance.Iban();
      }

      return context.Instance;
    }
  }

  // Finance.LitecoinAddress
  internal sealed class LitecoinAddressByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.LitecoinAddress.Enabled &&
             config.LitecoinAddress.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.LitecoinAddress.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Finance.LitecoinAddress();
      }

      return context.Instance;
    }
  }

  // Finance.RoutingNumber
  internal sealed class RoutingNumberByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.RoutingNumber.Enabled &&
             config.RoutingNumber.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.RoutingNumber.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Finance.RoutingNumber();
      }

      return context.Instance;
    }
  }

  // Finance.TransactionType
  internal sealed class TransactionTypeByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.TransactionType.Enabled &&
             config.TransactionType.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.TransactionType.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Finance.TransactionType();
      }

      return context.Instance;
    }
  }

  // Internet.Avatar
  internal sealed class AvatarByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Avatar.Enabled &&
             config.Avatar.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Avatar.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Internet.Avatar();
      }

      return context.Instance;
    }
  }

  // Internet.DomainName
  internal sealed class DomainNameByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.DomainName.Enabled &&
             config.DomainName.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.DomainName.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Internet.DomainName();
      }

      return context.Instance;
    }
  }

  // Internet.DomainSuffix
  internal sealed class DomainSuffixByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.DomainSuffix.Enabled &&
             config.DomainSuffix.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.DomainSuffix.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Internet.DomainSuffix();
      }

      return context.Instance;
    }
  }

  // Internet.DomainWord
  internal sealed class DomainWordByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.DomainWord.Enabled &&
             config.DomainWord.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.DomainWord.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Internet.DomainWord();
      }

      return context.Instance;
    }
  }

  // Internet.Email
  internal sealed class EmailByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Email.Enabled &&
             config.Email.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Email.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Internet.Email();
      }

      return context.Instance;
    }
  }

  // Internet.ExampleEmail
  internal sealed class ExampleEmailByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.ExampleEmail.Enabled &&
             config.ExampleEmail.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.ExampleEmail.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Internet.ExampleEmail();
      }

      return context.Instance;
    }
  }

  // Internet.Ip
  internal sealed class IpByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Ip.Enabled &&
             config.Ip.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Ip.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Internet.Ip();
      }

      return context.Instance;
    }
  }

  // Internet.IpAddress
  internal sealed class IpAddressByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.IpAddress.Enabled &&
             config.IpAddress.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.Net.IPAddress);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.IpAddress.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Internet.IpAddress();
      }

      return context.Instance;
    }
  }

  // Internet.IpEndPoint
  internal sealed class IpEndPointByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.IpEndPoint.Enabled &&
             config.IpEndPoint.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.Net.IPEndPoint);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.IpEndPoint.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Internet.IpEndPoint();
      }

      return context.Instance;
    }
  }

  // Internet.Ipv6
  internal sealed class Ipv6ByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Ipv6.Enabled &&
             config.Ipv6.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Ipv6.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Internet.Ipv6();
      }

      return context.Instance;
    }
  }

  // Internet.Ipv6Address
  internal sealed class Ipv6AddressByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Ipv6Address.Enabled &&
             config.Ipv6Address.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.Net.IPAddress);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Ipv6Address.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Internet.Ipv6Address();
      }

      return context.Instance;
    }
  }

  // Internet.Ipv6EndPoint
  internal sealed class Ipv6EndPointByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Ipv6EndPoint.Enabled &&
             config.Ipv6EndPoint.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.Net.IPEndPoint);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Ipv6EndPoint.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Internet.Ipv6EndPoint();
      }

      return context.Instance;
    }
  }

  // Internet.Mac
  internal sealed class MacByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Mac.Enabled &&
             config.Mac.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Mac.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Internet.Mac();
      }

      return context.Instance;
    }
  }

  // Internet.Password
  internal sealed class PasswordByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Password.Enabled &&
             config.Password.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Password.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Internet.Password();
      }

      return context.Instance;
    }
  }

  // Internet.Protocol
  internal sealed class ProtocolByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Protocol.Enabled &&
             config.Protocol.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Protocol.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Internet.Protocol();
      }

      return context.Instance;
    }
  }

  // Internet.Url
  internal sealed class UrlByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Url.Enabled &&
             config.Url.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Url.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Internet.Url();
      }

      return context.Instance;
    }
  }

  // Internet.UrlRootedPath
  internal sealed class UrlRootedPathByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.UrlRootedPath.Enabled &&
             config.UrlRootedPath.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.UrlRootedPath.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Internet.UrlRootedPath();
      }

      return context.Instance;
    }
  }

  // Internet.UrlWithPath
  internal sealed class UrlWithPathByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.UrlWithPath.Enabled &&
             config.UrlWithPath.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.UrlWithPath.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Internet.UrlWithPath();
      }

      return context.Instance;
    }
  }

  // Internet.UserAgent
  internal sealed class UserAgentByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.UserAgent.Enabled &&
             config.UserAgent.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.UserAgent.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Internet.UserAgent();
      }

      return context.Instance;
    }
  }

  // Internet.UserName
  internal sealed class UserNameByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.UserName.Enabled &&
             config.UserName.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.UserName.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Internet.UserName();
      }

      return context.Instance;
    }
  }

  // Internet.UserNameUnicode
  internal sealed class UserNameUnicodeByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.UserNameUnicode.Enabled &&
             config.UserNameUnicode.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.UserNameUnicode.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Internet.UserNameUnicode();
      }

      return context.Instance;
    }
  }

  // Music.Genre
  internal sealed class GenreByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Genre.Enabled &&
             config.Genre.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Genre.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Music.Genre();
      }

      return context.Instance;
    }
  }

  // Name.FindName
  internal sealed class FindNameByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.FindName.Enabled &&
             config.FindName.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.FindName.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Name.FindName();
      }

      return context.Instance;
    }
  }

  // Name.FirstName
  internal sealed class FirstNameByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.FirstName.Enabled &&
             config.FirstName.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.FirstName.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Name.FirstName();
      }

      return context.Instance;
    }
  }

  // Name.FullName
  internal sealed class FullNameByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.FullName.Enabled &&
             config.FullName.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.FullName.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Name.FullName();
      }

      return context.Instance;
    }
  }

  // Name.JobArea
  internal sealed class JobAreaByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.JobArea.Enabled &&
             config.JobArea.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.JobArea.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Name.JobArea();
      }

      return context.Instance;
    }
  }

  // Name.JobDescriptor
  internal sealed class JobDescriptorByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.JobDescriptor.Enabled &&
             config.JobDescriptor.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.JobDescriptor.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Name.JobDescriptor();
      }

      return context.Instance;
    }
  }

  // Name.JobTitle
  internal sealed class JobTitleByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.JobTitle.Enabled &&
             config.JobTitle.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.JobTitle.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Name.JobTitle();
      }

      return context.Instance;
    }
  }

  // Name.JobType
  internal sealed class JobTypeByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.JobType.Enabled &&
             config.JobType.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.JobType.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Name.JobType();
      }

      return context.Instance;
    }
  }

  // Name.LastName
  internal sealed class LastNameByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.LastName.Enabled &&
             config.LastName.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.LastName.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Name.LastName();
      }

      return context.Instance;
    }
  }

  // Name.Prefix
  internal sealed class PrefixByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Prefix.Enabled &&
             config.Prefix.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Prefix.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Name.Prefix();
      }

      return context.Instance;
    }
  }

  // Name.Suffix
  internal sealed class SuffixByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Suffix.Enabled &&
             config.Suffix.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Suffix.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Name.Suffix();
      }

      return context.Instance;
    }
  }

  // Phone.PhoneNumber
  internal sealed class PhoneNumberByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.PhoneNumber.Enabled &&
             config.PhoneNumber.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.PhoneNumber.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Phone.PhoneNumber();
      }

      return context.Instance;
    }
  }

  // Phone.PhoneNumberFormat
  internal sealed class PhoneNumberFormatByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.PhoneNumberFormat.Enabled &&
             config.PhoneNumberFormat.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.PhoneNumberFormat.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Phone.PhoneNumberFormat();
      }

      return context.Instance;
    }
  }

  // System.AndroidId
  internal sealed class AndroidIdByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.AndroidId.Enabled &&
             config.AndroidId.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.AndroidId.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.System.AndroidId();
      }

      return context.Instance;
    }
  }

  // System.ApplePushToken
  internal sealed class ApplePushTokenByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.ApplePushToken.Enabled &&
             config.ApplePushToken.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.ApplePushToken.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.System.ApplePushToken();
      }

      return context.Instance;
    }
  }

  // System.BlackBerryPin
  internal sealed class BlackBerryPinByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.BlackBerryPin.Enabled &&
             config.BlackBerryPin.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.BlackBerryPin.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.System.BlackBerryPin();
      }

      return context.Instance;
    }
  }

  // System.CommonFileExt
  internal sealed class CommonFileExtByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.CommonFileExt.Enabled &&
             config.CommonFileExt.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.CommonFileExt.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.System.CommonFileExt();
      }

      return context.Instance;
    }
  }

  // System.CommonFileName
  internal sealed class CommonFileNameByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.CommonFileName.Enabled &&
             config.CommonFileName.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.CommonFileName.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.System.CommonFileName();
      }

      return context.Instance;
    }
  }

  // System.CommonFileType
  internal sealed class CommonFileTypeByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.CommonFileType.Enabled &&
             config.CommonFileType.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.CommonFileType.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.System.CommonFileType();
      }

      return context.Instance;
    }
  }

  // System.DirectoryPath
  internal sealed class DirectoryPathByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.DirectoryPath.Enabled &&
             config.DirectoryPath.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.DirectoryPath.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.System.DirectoryPath();
      }

      return context.Instance;
    }
  }

  // System.Exception
  internal sealed class ExceptionByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Exception.Enabled &&
             config.Exception.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.Exception);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Exception.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.System.Exception();
      }

      return context.Instance;
    }
  }

  // System.FileExt
  internal sealed class FileExtByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.FileExt.Enabled &&
             config.FileExt.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.FileExt.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.System.FileExt();
      }

      return context.Instance;
    }
  }

  // System.FileName
  internal sealed class FileNameByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.FileName.Enabled &&
             config.FileName.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.FileName.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.System.FileName();
      }

      return context.Instance;
    }
  }

  // System.FilePath
  internal sealed class FilePathByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.FilePath.Enabled &&
             config.FilePath.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.FilePath.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.System.FilePath();
      }

      return context.Instance;
    }
  }

  // System.FileType
  internal sealed class FileTypeByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.FileType.Enabled &&
             config.FileType.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.FileType.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.System.FileType();
      }

      return context.Instance;
    }
  }

  // System.MimeType
  internal sealed class MimeTypeByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.MimeType.Enabled &&
             config.MimeType.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.MimeType.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.System.MimeType();
      }

      return context.Instance;
    }
  }

  // System.Semver
  internal sealed class SemverByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Semver.Enabled &&
             config.Semver.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Semver.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.System.Semver();
      }

      return context.Instance;
    }
  }

  // System.Version
  internal sealed class VersionByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Version.Enabled &&
             config.Version.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.Version);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Version.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.System.Version();
      }

      return context.Instance;
    }
  }

  // Vehicle.Fuel
  internal sealed class FuelByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Fuel.Enabled &&
             config.Fuel.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Fuel.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Vehicle.Fuel();
      }

      return context.Instance;
    }
  }

  // Vehicle.Manufacturer
  internal sealed class ManufacturerByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Manufacturer.Enabled &&
             config.Manufacturer.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Manufacturer.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Vehicle.Manufacturer();
      }

      return context.Instance;
    }
  }

  // Vehicle.Model
  internal sealed class ModelByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Model.Enabled &&
             config.Model.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Model.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Vehicle.Model();
      }

      return context.Instance;
    }
  }

  // Vehicle.Vin
  internal sealed class VinByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.CanGenerate(AutoConventionConfig config, AutoGenerateContext context)
    {
      return config.Vin.Enabled &&
             config.Vin.HasAlias(context.GenerateName) &&
             context.GenerateType == typeof(System.String);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      var alwaysGenerate = context.Config.AlwaysGenerate && context.Config.Vin.AlwaysGenerate;

      if (context.Instance == null || alwaysGenerate)
      {
        return context.OverrideContext.Faker.Vehicle.Vin();
      }

      return context.Instance;
    }
  }

  internal static class ByNameGeneratorRegistry
  {
    internal static System.Collections.Generic.IList<IAutoConventionGenerator> Generators = new System.Collections.Generic.List<IAutoConventionGenerator>
    {
      new BuildingNumberByNameGenerator(),
      new CardinalDirectionByNameGenerator(),
      new CityByNameGenerator(),
      new CityPrefixByNameGenerator(),
      new CitySuffixByNameGenerator(),
      new CountryByNameGenerator(),
      new CountryCodeByNameGenerator(),
      new CountyByNameGenerator(),
      new DirectionByNameGenerator(),
      new FullAddressByNameGenerator(),
      new LatitudeByNameGenerator(),
      new LongitudeByNameGenerator(),
      new OrdinalDirectionByNameGenerator(),
      new SecondaryAddressByNameGenerator(),
      new StateByNameGenerator(),
      new StateAbbrByNameGenerator(),
      new StreetAddressByNameGenerator(),
      new StreetNameByNameGenerator(),
      new StreetSuffixByNameGenerator(),
      new ZipCodeByNameGenerator(),
      new ColorByNameGenerator(),
      new DepartmentByNameGenerator(),
      new Ean13ByNameGenerator(),
      new Ean8ByNameGenerator(),
      new PriceByNameGenerator(),
      new ProductByNameGenerator(),
      new ProductAdjectiveByNameGenerator(),
      new ProductDescriptionByNameGenerator(),
      new ProductMaterialByNameGenerator(),
      new ProductNameByNameGenerator(),
      new BsByNameGenerator(),
      new CatchPhraseByNameGenerator(),
      new CompanyNameByNameGenerator(),
      new CompanySuffixByNameGenerator(),
      new CollationByNameGenerator(),
      new ColumnByNameGenerator(),
      new EngineByNameGenerator(),
      new TypeByNameGenerator(),
      new AccountByNameGenerator(),
      new AccountNameByNameGenerator(),
      new AmountByNameGenerator(),
      new BicByNameGenerator(),
      new BitcoinAddressByNameGenerator(),
      new CreditCardCvvByNameGenerator(),
      new CreditCardNumberByNameGenerator(),
      new CurrencyByNameGenerator(),
      new EthereumAddressByNameGenerator(),
      new IbanByNameGenerator(),
      new LitecoinAddressByNameGenerator(),
      new RoutingNumberByNameGenerator(),
      new TransactionTypeByNameGenerator(),
      new AvatarByNameGenerator(),
      new DomainNameByNameGenerator(),
      new DomainSuffixByNameGenerator(),
      new DomainWordByNameGenerator(),
      new EmailByNameGenerator(),
      new ExampleEmailByNameGenerator(),
      new IpByNameGenerator(),
      new IpAddressByNameGenerator(),
      new IpEndPointByNameGenerator(),
      new Ipv6ByNameGenerator(),
      new Ipv6AddressByNameGenerator(),
      new Ipv6EndPointByNameGenerator(),
      new MacByNameGenerator(),
      new PasswordByNameGenerator(),
      new ProtocolByNameGenerator(),
      new UrlByNameGenerator(),
      new UrlRootedPathByNameGenerator(),
      new UrlWithPathByNameGenerator(),
      new UserAgentByNameGenerator(),
      new UserNameByNameGenerator(),
      new UserNameUnicodeByNameGenerator(),
      new GenreByNameGenerator(),
      new FindNameByNameGenerator(),
      new FirstNameByNameGenerator(),
      new FullNameByNameGenerator(),
      new JobAreaByNameGenerator(),
      new JobDescriptorByNameGenerator(),
      new JobTitleByNameGenerator(),
      new JobTypeByNameGenerator(),
      new LastNameByNameGenerator(),
      new PrefixByNameGenerator(),
      new SuffixByNameGenerator(),
      new PhoneNumberByNameGenerator(),
      new PhoneNumberFormatByNameGenerator(),
      new AndroidIdByNameGenerator(),
      new ApplePushTokenByNameGenerator(),
      new BlackBerryPinByNameGenerator(),
      new CommonFileExtByNameGenerator(),
      new CommonFileNameByNameGenerator(),
      new CommonFileTypeByNameGenerator(),
      new DirectoryPathByNameGenerator(),
      new ExceptionByNameGenerator(),
      new FileExtByNameGenerator(),
      new FileNameByNameGenerator(),
      new FilePathByNameGenerator(),
      new FileTypeByNameGenerator(),
      new MimeTypeByNameGenerator(),
      new SemverByNameGenerator(),
      new VersionByNameGenerator(),
      new FuelByNameGenerator(),
      new ManufacturerByNameGenerator(),
      new ModelByNameGenerator(),
      new VinByNameGenerator(),
   
    };
  }
}

namespace AutoBogus.Conventions
{
  public sealed partial class AutoConventionConfig
  {

    /// <summary>
    /// Configures the BuildingNumber convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig BuildingNumber { get; } = new AutoConventionGeneratorConfig("BuildingNumber");

    /// <summary>
    /// Configures the CardinalDirection convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CardinalDirection { get; } = new AutoConventionGeneratorConfig("CardinalDirection");

    /// <summary>
    /// Configures the City convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig City { get; } = new AutoConventionGeneratorConfig("City");

    /// <summary>
    /// Configures the CityPrefix convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CityPrefix { get; } = new AutoConventionGeneratorConfig("CityPrefix");

    /// <summary>
    /// Configures the CitySuffix convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CitySuffix { get; } = new AutoConventionGeneratorConfig("CitySuffix");

    /// <summary>
    /// Configures the Country convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Country { get; } = new AutoConventionGeneratorConfig("Country");

    /// <summary>
    /// Configures the CountryCode convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CountryCode { get; } = new AutoConventionGeneratorConfig("CountryCode");

    /// <summary>
    /// Configures the County convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig County { get; } = new AutoConventionGeneratorConfig("County");

    /// <summary>
    /// Configures the Direction convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Direction { get; } = new AutoConventionGeneratorConfig("Direction");

    /// <summary>
    /// Configures the FullAddress convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig FullAddress { get; } = new AutoConventionGeneratorConfig("FullAddress");

    /// <summary>
    /// Configures the Latitude convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Latitude { get; } = new AutoConventionGeneratorConfig("Latitude");

    /// <summary>
    /// Configures the Longitude convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Longitude { get; } = new AutoConventionGeneratorConfig("Longitude");

    /// <summary>
    /// Configures the OrdinalDirection convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig OrdinalDirection { get; } = new AutoConventionGeneratorConfig("OrdinalDirection");

    /// <summary>
    /// Configures the SecondaryAddress convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig SecondaryAddress { get; } = new AutoConventionGeneratorConfig("SecondaryAddress");

    /// <summary>
    /// Configures the State convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig State { get; } = new AutoConventionGeneratorConfig("State");

    /// <summary>
    /// Configures the StateAbbr convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig StateAbbr { get; } = new AutoConventionGeneratorConfig("StateAbbr");

    /// <summary>
    /// Configures the StreetAddress convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig StreetAddress { get; } = new AutoConventionGeneratorConfig("StreetAddress");

    /// <summary>
    /// Configures the StreetName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig StreetName { get; } = new AutoConventionGeneratorConfig("StreetName");

    /// <summary>
    /// Configures the StreetSuffix convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig StreetSuffix { get; } = new AutoConventionGeneratorConfig("StreetSuffix");

    /// <summary>
    /// Configures the ZipCode convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig ZipCode { get; } = new AutoConventionGeneratorConfig("ZipCode");

    /// <summary>
    /// Configures the Color convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Color { get; } = new AutoConventionGeneratorConfig("Color");

    /// <summary>
    /// Configures the Department convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Department { get; } = new AutoConventionGeneratorConfig("Department");

    /// <summary>
    /// Configures the Ean13 convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Ean13 { get; } = new AutoConventionGeneratorConfig("Ean13");

    /// <summary>
    /// Configures the Ean8 convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Ean8 { get; } = new AutoConventionGeneratorConfig("Ean8");

    /// <summary>
    /// Configures the Price convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Price { get; } = new AutoConventionGeneratorConfig("Price");

    /// <summary>
    /// Configures the Product convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Product { get; } = new AutoConventionGeneratorConfig("Product");

    /// <summary>
    /// Configures the ProductAdjective convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig ProductAdjective { get; } = new AutoConventionGeneratorConfig("ProductAdjective");

    /// <summary>
    /// Configures the ProductDescription convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig ProductDescription { get; } = new AutoConventionGeneratorConfig("ProductDescription");

    /// <summary>
    /// Configures the ProductMaterial convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig ProductMaterial { get; } = new AutoConventionGeneratorConfig("ProductMaterial");

    /// <summary>
    /// Configures the ProductName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig ProductName { get; } = new AutoConventionGeneratorConfig("ProductName");

    /// <summary>
    /// Configures the Bs convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Bs { get; } = new AutoConventionGeneratorConfig("Bs");

    /// <summary>
    /// Configures the CatchPhrase convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CatchPhrase { get; } = new AutoConventionGeneratorConfig("CatchPhrase");

    /// <summary>
    /// Configures the CompanyName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CompanyName { get; } = new AutoConventionGeneratorConfig("CompanyName");

    /// <summary>
    /// Configures the CompanySuffix convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CompanySuffix { get; } = new AutoConventionGeneratorConfig("CompanySuffix");

    /// <summary>
    /// Configures the Collation convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Collation { get; } = new AutoConventionGeneratorConfig("Collation");

    /// <summary>
    /// Configures the Column convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Column { get; } = new AutoConventionGeneratorConfig("Column");

    /// <summary>
    /// Configures the Engine convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Engine { get; } = new AutoConventionGeneratorConfig("Engine");

    /// <summary>
    /// Configures the Type convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Type { get; } = new AutoConventionGeneratorConfig("Type");

    /// <summary>
    /// Configures the Account convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Account { get; } = new AutoConventionGeneratorConfig("Account");

    /// <summary>
    /// Configures the AccountName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig AccountName { get; } = new AutoConventionGeneratorConfig("AccountName");

    /// <summary>
    /// Configures the Amount convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Amount { get; } = new AutoConventionGeneratorConfig("Amount");

    /// <summary>
    /// Configures the Bic convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Bic { get; } = new AutoConventionGeneratorConfig("Bic");

    /// <summary>
    /// Configures the BitcoinAddress convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig BitcoinAddress { get; } = new AutoConventionGeneratorConfig("BitcoinAddress");

    /// <summary>
    /// Configures the CreditCardCvv convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CreditCardCvv { get; } = new AutoConventionGeneratorConfig("CreditCardCvv");

    /// <summary>
    /// Configures the CreditCardNumber convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CreditCardNumber { get; } = new AutoConventionGeneratorConfig("CreditCardNumber");

    /// <summary>
    /// Configures the Currency convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Currency { get; } = new AutoConventionGeneratorConfig("Currency");

    /// <summary>
    /// Configures the EthereumAddress convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig EthereumAddress { get; } = new AutoConventionGeneratorConfig("EthereumAddress");

    /// <summary>
    /// Configures the Iban convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Iban { get; } = new AutoConventionGeneratorConfig("Iban");

    /// <summary>
    /// Configures the LitecoinAddress convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig LitecoinAddress { get; } = new AutoConventionGeneratorConfig("LitecoinAddress");

    /// <summary>
    /// Configures the RoutingNumber convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig RoutingNumber { get; } = new AutoConventionGeneratorConfig("RoutingNumber");

    /// <summary>
    /// Configures the TransactionType convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig TransactionType { get; } = new AutoConventionGeneratorConfig("TransactionType");

    /// <summary>
    /// Configures the Avatar convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Avatar { get; } = new AutoConventionGeneratorConfig("Avatar");

    /// <summary>
    /// Configures the DomainName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig DomainName { get; } = new AutoConventionGeneratorConfig("DomainName");

    /// <summary>
    /// Configures the DomainSuffix convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig DomainSuffix { get; } = new AutoConventionGeneratorConfig("DomainSuffix");

    /// <summary>
    /// Configures the DomainWord convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig DomainWord { get; } = new AutoConventionGeneratorConfig("DomainWord");

    /// <summary>
    /// Configures the Email convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Email { get; } = new AutoConventionGeneratorConfig("Email");

    /// <summary>
    /// Configures the ExampleEmail convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig ExampleEmail { get; } = new AutoConventionGeneratorConfig("ExampleEmail");

    /// <summary>
    /// Configures the Ip convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Ip { get; } = new AutoConventionGeneratorConfig("Ip");

    /// <summary>
    /// Configures the IpAddress convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig IpAddress { get; } = new AutoConventionGeneratorConfig("IpAddress");

    /// <summary>
    /// Configures the IpEndPoint convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig IpEndPoint { get; } = new AutoConventionGeneratorConfig("IpEndPoint");

    /// <summary>
    /// Configures the Ipv6 convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Ipv6 { get; } = new AutoConventionGeneratorConfig("Ipv6");

    /// <summary>
    /// Configures the Ipv6Address convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Ipv6Address { get; } = new AutoConventionGeneratorConfig("Ipv6Address");

    /// <summary>
    /// Configures the Ipv6EndPoint convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Ipv6EndPoint { get; } = new AutoConventionGeneratorConfig("Ipv6EndPoint");

    /// <summary>
    /// Configures the Mac convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Mac { get; } = new AutoConventionGeneratorConfig("Mac");

    /// <summary>
    /// Configures the Password convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Password { get; } = new AutoConventionGeneratorConfig("Password");

    /// <summary>
    /// Configures the Protocol convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Protocol { get; } = new AutoConventionGeneratorConfig("Protocol");

    /// <summary>
    /// Configures the Url convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Url { get; } = new AutoConventionGeneratorConfig("Url");

    /// <summary>
    /// Configures the UrlRootedPath convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig UrlRootedPath { get; } = new AutoConventionGeneratorConfig("UrlRootedPath");

    /// <summary>
    /// Configures the UrlWithPath convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig UrlWithPath { get; } = new AutoConventionGeneratorConfig("UrlWithPath");

    /// <summary>
    /// Configures the UserAgent convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig UserAgent { get; } = new AutoConventionGeneratorConfig("UserAgent");

    /// <summary>
    /// Configures the UserName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig UserName { get; } = new AutoConventionGeneratorConfig("UserName");

    /// <summary>
    /// Configures the UserNameUnicode convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig UserNameUnicode { get; } = new AutoConventionGeneratorConfig("UserNameUnicode");

    /// <summary>
    /// Configures the Genre convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Genre { get; } = new AutoConventionGeneratorConfig("Genre");

    /// <summary>
    /// Configures the FindName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig FindName { get; } = new AutoConventionGeneratorConfig("FindName");

    /// <summary>
    /// Configures the FirstName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig FirstName { get; } = new AutoConventionGeneratorConfig("FirstName");

    /// <summary>
    /// Configures the FullName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig FullName { get; } = new AutoConventionGeneratorConfig("FullName");

    /// <summary>
    /// Configures the JobArea convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig JobArea { get; } = new AutoConventionGeneratorConfig("JobArea");

    /// <summary>
    /// Configures the JobDescriptor convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig JobDescriptor { get; } = new AutoConventionGeneratorConfig("JobDescriptor");

    /// <summary>
    /// Configures the JobTitle convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig JobTitle { get; } = new AutoConventionGeneratorConfig("JobTitle");

    /// <summary>
    /// Configures the JobType convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig JobType { get; } = new AutoConventionGeneratorConfig("JobType");

    /// <summary>
    /// Configures the LastName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig LastName { get; } = new AutoConventionGeneratorConfig("LastName");

    /// <summary>
    /// Configures the Prefix convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Prefix { get; } = new AutoConventionGeneratorConfig("Prefix");

    /// <summary>
    /// Configures the Suffix convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Suffix { get; } = new AutoConventionGeneratorConfig("Suffix");

    /// <summary>
    /// Configures the PhoneNumber convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig PhoneNumber { get; } = new AutoConventionGeneratorConfig("PhoneNumber");

    /// <summary>
    /// Configures the PhoneNumberFormat convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig PhoneNumberFormat { get; } = new AutoConventionGeneratorConfig("PhoneNumberFormat");

    /// <summary>
    /// Configures the AndroidId convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig AndroidId { get; } = new AutoConventionGeneratorConfig("AndroidId");

    /// <summary>
    /// Configures the ApplePushToken convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig ApplePushToken { get; } = new AutoConventionGeneratorConfig("ApplePushToken");

    /// <summary>
    /// Configures the BlackBerryPin convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig BlackBerryPin { get; } = new AutoConventionGeneratorConfig("BlackBerryPin");

    /// <summary>
    /// Configures the CommonFileExt convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CommonFileExt { get; } = new AutoConventionGeneratorConfig("CommonFileExt");

    /// <summary>
    /// Configures the CommonFileName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CommonFileName { get; } = new AutoConventionGeneratorConfig("CommonFileName");

    /// <summary>
    /// Configures the CommonFileType convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CommonFileType { get; } = new AutoConventionGeneratorConfig("CommonFileType");

    /// <summary>
    /// Configures the DirectoryPath convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig DirectoryPath { get; } = new AutoConventionGeneratorConfig("DirectoryPath");

    /// <summary>
    /// Configures the Exception convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Exception { get; } = new AutoConventionGeneratorConfig("Exception");

    /// <summary>
    /// Configures the FileExt convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig FileExt { get; } = new AutoConventionGeneratorConfig("FileExt");

    /// <summary>
    /// Configures the FileName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig FileName { get; } = new AutoConventionGeneratorConfig("FileName");

    /// <summary>
    /// Configures the FilePath convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig FilePath { get; } = new AutoConventionGeneratorConfig("FilePath");

    /// <summary>
    /// Configures the FileType convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig FileType { get; } = new AutoConventionGeneratorConfig("FileType");

    /// <summary>
    /// Configures the MimeType convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig MimeType { get; } = new AutoConventionGeneratorConfig("MimeType");

    /// <summary>
    /// Configures the Semver convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Semver { get; } = new AutoConventionGeneratorConfig("Semver");

    /// <summary>
    /// Configures the Version convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Version { get; } = new AutoConventionGeneratorConfig("Version");

    /// <summary>
    /// Configures the Fuel convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Fuel { get; } = new AutoConventionGeneratorConfig("Fuel");

    /// <summary>
    /// Configures the Manufacturer convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Manufacturer { get; } = new AutoConventionGeneratorConfig("Manufacturer");

    /// <summary>
    /// Configures the Model convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Model { get; } = new AutoConventionGeneratorConfig("Model");

    /// <summary>
    /// Configures the Vin convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Vin { get; } = new AutoConventionGeneratorConfig("Vin");

  }
}
