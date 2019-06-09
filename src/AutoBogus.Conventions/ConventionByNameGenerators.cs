namespace AutoBogus.Conventions.Generators
{

  // Address.BuildingNumber
  internal sealed class BuildingNumberByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.BuildingNumber.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "BuildingNumber".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.CardinalDirection.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CardinalDirection".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.City.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "City".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.CityPrefix.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CityPrefix".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.CitySuffix.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CitySuffix".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Country.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Country".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.CountryCode.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CountryCode".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.County.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "County".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Direction.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Direction".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.FullAddress.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "FullAddress".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Latitude.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.Double) &&
             "Latitude".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Longitude.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.Double) &&
             "Longitude".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.OrdinalDirection.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "OrdinalDirection".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.SecondaryAddress.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "SecondaryAddress".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.State.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "State".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.StateAbbr.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "StateAbbr".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.StreetAddress.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "StreetAddress".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.StreetName.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "StreetName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.StreetSuffix.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "StreetSuffix".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.ZipCode.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "ZipCode".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Color.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Color".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Department.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Department".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Ean13.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Ean13".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Ean8.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Ean8".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Price.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Price".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Product.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Product".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.ProductAdjective.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "ProductAdjective".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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

  // Commerce.ProductMaterial
  internal sealed class ProductMaterialByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.ProductMaterial.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "ProductMaterial".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.ProductName.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "ProductName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Bs.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Bs".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.CatchPhrase.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CatchPhrase".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.CompanyName.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CompanyName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.CompanySuffix.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CompanySuffix".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Collation.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Collation".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Column.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Column".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Engine.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Engine".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Type.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Type".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Account.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Account".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.AccountName.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "AccountName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Amount.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.Decimal) &&
             "Amount".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Bic.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Bic".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.BitcoinAddress.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "BitcoinAddress".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.CreditCardCvv.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CreditCardCvv".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.CreditCardNumber.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CreditCardNumber".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Currency.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(Bogus.DataSets.Currency) &&
             "Currency".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.EthereumAddress.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "EthereumAddress".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Iban.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Iban".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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

  // Finance.RoutingNumber
  internal sealed class RoutingNumberByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.RoutingNumber.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "RoutingNumber".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.TransactionType.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "TransactionType".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Avatar.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Avatar".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.DomainName.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "DomainName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.DomainSuffix.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "DomainSuffix".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.DomainWord.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "DomainWord".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Email.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Email".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.ExampleEmail.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "ExampleEmail".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Ip.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Ip".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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

  // Internet.Ipv6
  internal sealed class Ipv6ByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Ipv6.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Ipv6".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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

  // Internet.Mac
  internal sealed class MacByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Mac.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Mac".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Password.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Password".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Protocol.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Protocol".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Url.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Url".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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

  // Internet.UrlWithPath
  internal sealed class UrlWithPathByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.UrlWithPath.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "UrlWithPath".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.UserAgent.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "UserAgent".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.UserName.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "UserName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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

  // Name.FindName
  internal sealed class FindNameByNameGenerator
    : IAutoConventionGenerator
  {  
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.FindName.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "FindName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.FirstName.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "FirstName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.FullName.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "FullName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.JobArea.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "JobArea".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.JobDescriptor.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "JobDescriptor".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.JobTitle.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "JobTitle".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.JobType.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "JobType".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.LastName.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "LastName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Prefix.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Prefix".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Suffix.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Suffix".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.PhoneNumber.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "PhoneNumber".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.PhoneNumberFormat.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "PhoneNumberFormat".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.AndroidId.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "AndroidId".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.ApplePushToken.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "ApplePushToken".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.BlackBerryPin.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "BlackBerryPin".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.CommonFileExt.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CommonFileExt".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.CommonFileName.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CommonFileName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.CommonFileType.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CommonFileType".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.DirectoryPath.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "DirectoryPath".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Exception.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.Exception) &&
             "Exception".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.FileExt.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "FileExt".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.FileName.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "FileName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.FilePath.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "FilePath".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.FileType.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "FileType".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.MimeType.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "MimeType".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Semver.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Semver".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
    bool IAutoConventionGenerator.Enabled(AutoConventionConfig config)
    {
      return config.Version.Enabled;
    }

    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.Version) &&
             "Version".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
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
      new RoutingNumberByNameGenerator(),
      new TransactionTypeByNameGenerator(),
      new AvatarByNameGenerator(),
      new DomainNameByNameGenerator(),
      new DomainSuffixByNameGenerator(),
      new DomainWordByNameGenerator(),
      new EmailByNameGenerator(),
      new ExampleEmailByNameGenerator(),
      new IpByNameGenerator(),
      new Ipv6ByNameGenerator(),
      new MacByNameGenerator(),
      new PasswordByNameGenerator(),
      new ProtocolByNameGenerator(),
      new UrlByNameGenerator(),
      new UrlWithPathByNameGenerator(),
      new UserAgentByNameGenerator(),
      new UserNameByNameGenerator(),
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
    public AutoConventionGeneratorConfig BuildingNumber { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the CardinalDirection convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CardinalDirection { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the City convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig City { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the CityPrefix convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CityPrefix { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the CitySuffix convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CitySuffix { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Country convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Country { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the CountryCode convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CountryCode { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the County convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig County { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Direction convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Direction { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the FullAddress convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig FullAddress { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Latitude convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Latitude { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Longitude convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Longitude { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the OrdinalDirection convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig OrdinalDirection { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the SecondaryAddress convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig SecondaryAddress { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the State convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig State { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the StateAbbr convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig StateAbbr { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the StreetAddress convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig StreetAddress { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the StreetName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig StreetName { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the StreetSuffix convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig StreetSuffix { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the ZipCode convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig ZipCode { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Color convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Color { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Department convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Department { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Ean13 convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Ean13 { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Ean8 convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Ean8 { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Price convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Price { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Product convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Product { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the ProductAdjective convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig ProductAdjective { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the ProductMaterial convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig ProductMaterial { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the ProductName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig ProductName { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Bs convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Bs { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the CatchPhrase convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CatchPhrase { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the CompanyName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CompanyName { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the CompanySuffix convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CompanySuffix { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Collation convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Collation { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Column convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Column { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Engine convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Engine { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Type convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Type { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Account convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Account { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the AccountName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig AccountName { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Amount convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Amount { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Bic convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Bic { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the BitcoinAddress convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig BitcoinAddress { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the CreditCardCvv convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CreditCardCvv { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the CreditCardNumber convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CreditCardNumber { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Currency convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Currency { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the EthereumAddress convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig EthereumAddress { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Iban convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Iban { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the RoutingNumber convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig RoutingNumber { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the TransactionType convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig TransactionType { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Avatar convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Avatar { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the DomainName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig DomainName { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the DomainSuffix convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig DomainSuffix { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the DomainWord convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig DomainWord { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Email convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Email { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the ExampleEmail convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig ExampleEmail { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Ip convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Ip { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Ipv6 convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Ipv6 { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Mac convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Mac { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Password convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Password { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Protocol convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Protocol { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Url convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Url { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the UrlWithPath convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig UrlWithPath { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the UserAgent convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig UserAgent { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the UserName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig UserName { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the FindName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig FindName { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the FirstName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig FirstName { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the FullName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig FullName { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the JobArea convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig JobArea { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the JobDescriptor convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig JobDescriptor { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the JobTitle convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig JobTitle { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the JobType convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig JobType { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the LastName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig LastName { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Prefix convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Prefix { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Suffix convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Suffix { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the PhoneNumber convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig PhoneNumber { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the PhoneNumberFormat convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig PhoneNumberFormat { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the AndroidId convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig AndroidId { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the ApplePushToken convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig ApplePushToken { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the BlackBerryPin convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig BlackBerryPin { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the CommonFileExt convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CommonFileExt { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the CommonFileName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CommonFileName { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the CommonFileType convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig CommonFileType { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the DirectoryPath convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig DirectoryPath { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Exception convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Exception { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the FileExt convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig FileExt { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the FileName convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig FileName { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the FilePath convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig FilePath { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the FileType convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig FileType { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the MimeType convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig MimeType { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Semver convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Semver { get; } = new AutoConventionGeneratorConfig();

    /// <summary>
    /// Configures the Version convention generator.
    /// </summary>
    public AutoConventionGeneratorConfig Version { get; } = new AutoConventionGeneratorConfig();

  }
}
