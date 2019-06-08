namespace AutoBogus.Conventions.Generators
{

  // Address.BuildingNumber
  internal sealed class BuildingNumberGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "BuildingNumber".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Address.BuildingNumber();
    }
  }

  // Address.CardinalDirection
  internal sealed class CardinalDirectionGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CardinalDirection".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Address.CardinalDirection();
    }
  }

  // Address.City
  internal sealed class CityGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "City".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Address.City();
    }
  }

  // Address.CityPrefix
  internal sealed class CityPrefixGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CityPrefix".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Address.CityPrefix();
    }
  }

  // Address.CitySuffix
  internal sealed class CitySuffixGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CitySuffix".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Address.CitySuffix();
    }
  }

  // Address.Country
  internal sealed class CountryGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Country".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Address.Country();
    }
  }

  // Address.CountryCode
  internal sealed class CountryCodeGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CountryCode".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Address.CountryCode();
    }
  }

  // Address.County
  internal sealed class CountyGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "County".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Address.County();
    }
  }

  // Address.Direction
  internal sealed class DirectionGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Direction".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Address.Direction();
    }
  }

  // Address.FullAddress
  internal sealed class FullAddressGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "FullAddress".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Address.FullAddress();
    }
  }

  // Address.Latitude
  internal sealed class LatitudeGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.Double) &&
             "Latitude".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Address.Latitude();
    }
  }

  // Address.Longitude
  internal sealed class LongitudeGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.Double) &&
             "Longitude".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Address.Longitude();
    }
  }

  // Address.OrdinalDirection
  internal sealed class OrdinalDirectionGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "OrdinalDirection".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Address.OrdinalDirection();
    }
  }

  // Address.SecondaryAddress
  internal sealed class SecondaryAddressGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "SecondaryAddress".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Address.SecondaryAddress();
    }
  }

  // Address.State
  internal sealed class StateGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "State".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Address.State();
    }
  }

  // Address.StateAbbr
  internal sealed class StateAbbrGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "StateAbbr".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Address.StateAbbr();
    }
  }

  // Address.StreetAddress
  internal sealed class StreetAddressGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "StreetAddress".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Address.StreetAddress();
    }
  }

  // Address.StreetName
  internal sealed class StreetNameGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "StreetName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Address.StreetName();
    }
  }

  // Address.StreetSuffix
  internal sealed class StreetSuffixGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "StreetSuffix".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Address.StreetSuffix();
    }
  }

  // Address.ZipCode
  internal sealed class ZipCodeGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "ZipCode".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Address.ZipCode();
    }
  }

  // Commerce.Color
  internal sealed class ColorGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Color".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Commerce.Color();
    }
  }

  // Commerce.Department
  internal sealed class DepartmentGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Department".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Commerce.Department();
    }
  }

  // Commerce.Ean13
  internal sealed class Ean13Generator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Ean13".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Commerce.Ean13();
    }
  }

  // Commerce.Ean8
  internal sealed class Ean8Generator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Ean8".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Commerce.Ean8();
    }
  }

  // Commerce.Price
  internal sealed class PriceGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Price".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Commerce.Price();
    }
  }

  // Commerce.Product
  internal sealed class ProductGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Product".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Commerce.Product();
    }
  }

  // Commerce.ProductAdjective
  internal sealed class ProductAdjectiveGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "ProductAdjective".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Commerce.ProductAdjective();
    }
  }

  // Commerce.ProductMaterial
  internal sealed class ProductMaterialGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "ProductMaterial".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Commerce.ProductMaterial();
    }
  }

  // Commerce.ProductName
  internal sealed class ProductNameGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "ProductName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Commerce.ProductName();
    }
  }

  // Company.Bs
  internal sealed class BsGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Bs".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Company.Bs();
    }
  }

  // Company.CatchPhrase
  internal sealed class CatchPhraseGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CatchPhrase".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Company.CatchPhrase();
    }
  }

  // Company.CompanyName
  internal sealed class CompanyNameGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CompanyName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Company.CompanyName();
    }
  }

  // Company.CompanySuffix
  internal sealed class CompanySuffixGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CompanySuffix".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Company.CompanySuffix();
    }
  }

  // Database.Collation
  internal sealed class CollationGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Collation".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Database.Collation();
    }
  }

  // Database.Column
  internal sealed class ColumnGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Column".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Database.Column();
    }
  }

  // Database.Engine
  internal sealed class EngineGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Engine".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Database.Engine();
    }
  }

  // Database.Type
  internal sealed class TypeGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Type".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Database.Type();
    }
  }

  // Finance.Account
  internal sealed class AccountGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Account".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Finance.Account();
    }
  }

  // Finance.AccountName
  internal sealed class AccountNameGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "AccountName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Finance.AccountName();
    }
  }

  // Finance.Amount
  internal sealed class AmountGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.Decimal) &&
             "Amount".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Finance.Amount();
    }
  }

  // Finance.Bic
  internal sealed class BicGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Bic".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Finance.Bic();
    }
  }

  // Finance.BitcoinAddress
  internal sealed class BitcoinAddressGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "BitcoinAddress".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Finance.BitcoinAddress();
    }
  }

  // Finance.CreditCardCvv
  internal sealed class CreditCardCvvGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CreditCardCvv".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Finance.CreditCardCvv();
    }
  }

  // Finance.CreditCardNumber
  internal sealed class CreditCardNumberGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CreditCardNumber".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Finance.CreditCardNumber();
    }
  }

  // Finance.Currency
  internal sealed class CurrencyGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(Bogus.DataSets.Currency) &&
             "Currency".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Finance.Currency();
    }
  }

  // Finance.EthereumAddress
  internal sealed class EthereumAddressGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "EthereumAddress".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Finance.EthereumAddress();
    }
  }

  // Finance.Iban
  internal sealed class IbanGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Iban".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Finance.Iban();
    }
  }

  // Finance.RoutingNumber
  internal sealed class RoutingNumberGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "RoutingNumber".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Finance.RoutingNumber();
    }
  }

  // Finance.TransactionType
  internal sealed class TransactionTypeGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "TransactionType".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Finance.TransactionType();
    }
  }

  // Internet.Avatar
  internal sealed class AvatarGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Avatar".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Internet.Avatar();
    }
  }

  // Internet.DomainName
  internal sealed class DomainNameGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "DomainName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Internet.DomainName();
    }
  }

  // Internet.DomainSuffix
  internal sealed class DomainSuffixGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "DomainSuffix".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Internet.DomainSuffix();
    }
  }

  // Internet.DomainWord
  internal sealed class DomainWordGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "DomainWord".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Internet.DomainWord();
    }
  }

  // Internet.Email
  internal sealed class EmailGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Email".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Internet.Email();
    }
  }

  // Internet.ExampleEmail
  internal sealed class ExampleEmailGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "ExampleEmail".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Internet.ExampleEmail();
    }
  }

  // Internet.Ip
  internal sealed class IpGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Ip".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Internet.Ip();
    }
  }

  // Internet.Ipv6
  internal sealed class Ipv6Generator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Ipv6".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Internet.Ipv6();
    }
  }

  // Internet.Mac
  internal sealed class MacGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Mac".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Internet.Mac();
    }
  }

  // Internet.Password
  internal sealed class PasswordGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Password".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Internet.Password();
    }
  }

  // Internet.Protocol
  internal sealed class ProtocolGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Protocol".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Internet.Protocol();
    }
  }

  // Internet.Url
  internal sealed class UrlGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Url".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Internet.Url();
    }
  }

  // Internet.UrlWithPath
  internal sealed class UrlWithPathGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "UrlWithPath".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Internet.UrlWithPath();
    }
  }

  // Internet.UserAgent
  internal sealed class UserAgentGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "UserAgent".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Internet.UserAgent();
    }
  }

  // Internet.UserName
  internal sealed class UserNameGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "UserName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Internet.UserName();
    }
  }

  // Name.FindName
  internal sealed class FindNameGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "FindName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Name.FindName();
    }
  }

  // Name.FirstName
  internal sealed class FirstNameGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "FirstName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Name.FirstName();
    }
  }

  // Name.FullName
  internal sealed class FullNameGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "FullName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Name.FullName();
    }
  }

  // Name.JobArea
  internal sealed class JobAreaGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "JobArea".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Name.JobArea();
    }
  }

  // Name.JobDescriptor
  internal sealed class JobDescriptorGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "JobDescriptor".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Name.JobDescriptor();
    }
  }

  // Name.JobTitle
  internal sealed class JobTitleGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "JobTitle".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Name.JobTitle();
    }
  }

  // Name.JobType
  internal sealed class JobTypeGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "JobType".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Name.JobType();
    }
  }

  // Name.LastName
  internal sealed class LastNameGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "LastName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Name.LastName();
    }
  }

  // Name.Prefix
  internal sealed class PrefixGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Prefix".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Name.Prefix();
    }
  }

  // Name.Suffix
  internal sealed class SuffixGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Suffix".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Name.Suffix();
    }
  }

  // Phone.PhoneNumber
  internal sealed class PhoneNumberGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "PhoneNumber".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Phone.PhoneNumber();
    }
  }

  // Phone.PhoneNumberFormat
  internal sealed class PhoneNumberFormatGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "PhoneNumberFormat".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.Phone.PhoneNumberFormat();
    }
  }

  // System.AndroidId
  internal sealed class AndroidIdGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "AndroidId".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.System.AndroidId();
    }
  }

  // System.ApplePushToken
  internal sealed class ApplePushTokenGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "ApplePushToken".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.System.ApplePushToken();
    }
  }

  // System.BlackBerryPin
  internal sealed class BlackBerryPinGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "BlackBerryPin".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.System.BlackBerryPin();
    }
  }

  // System.CommonFileExt
  internal sealed class CommonFileExtGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CommonFileExt".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.System.CommonFileExt();
    }
  }

  // System.CommonFileName
  internal sealed class CommonFileNameGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CommonFileName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.System.CommonFileName();
    }
  }

  // System.CommonFileType
  internal sealed class CommonFileTypeGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "CommonFileType".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.System.CommonFileType();
    }
  }

  // System.DirectoryPath
  internal sealed class DirectoryPathGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "DirectoryPath".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.System.DirectoryPath();
    }
  }

  // System.Exception
  internal sealed class ExceptionGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.Exception) &&
             "Exception".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.System.Exception();
    }
  }

  // System.FileExt
  internal sealed class FileExtGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "FileExt".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.System.FileExt();
    }
  }

  // System.FileName
  internal sealed class FileNameGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "FileName".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.System.FileName();
    }
  }

  // System.FilePath
  internal sealed class FilePathGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "FilePath".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.System.FilePath();
    }
  }

  // System.FileType
  internal sealed class FileTypeGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "FileType".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.System.FileType();
    }
  }

  // System.MimeType
  internal sealed class MimeTypeGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "MimeType".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.System.MimeType();
    }
  }

  // System.Semver
  internal sealed class SemverGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.String) &&
             "Semver".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.System.Semver();
    }
  }

  // System.Version
  internal sealed class VersionGenerator
    : IAutoConventionGenerator
  {
    bool IAutoConventionGenerator.CanGenerate(AutoGenerateContext context)
    {
      return context.GenerateType == typeof(System.Version) &&
             "Version".Equals(context.GenerateName, System.StringComparison.OrdinalIgnoreCase);
    }

    object IAutoConventionGenerator.Generate(AutoConventionContext context)
    {
      return context.Faker.System.Version();
    }
  }

  internal static class GeneratorRegistry
  {
    internal static System.Collections.Generic.IList<IAutoConventionGenerator> Generators = new System.Collections.Generic.List<IAutoConventionGenerator>
    {
      new BuildingNumberGenerator(),
      new CardinalDirectionGenerator(),
      new CityGenerator(),
      new CityPrefixGenerator(),
      new CitySuffixGenerator(),
      new CountryGenerator(),
      new CountryCodeGenerator(),
      new CountyGenerator(),
      new DirectionGenerator(),
      new FullAddressGenerator(),
      new LatitudeGenerator(),
      new LongitudeGenerator(),
      new OrdinalDirectionGenerator(),
      new SecondaryAddressGenerator(),
      new StateGenerator(),
      new StateAbbrGenerator(),
      new StreetAddressGenerator(),
      new StreetNameGenerator(),
      new StreetSuffixGenerator(),
      new ZipCodeGenerator(),
      new ColorGenerator(),
      new DepartmentGenerator(),
      new Ean13Generator(),
      new Ean8Generator(),
      new PriceGenerator(),
      new ProductGenerator(),
      new ProductAdjectiveGenerator(),
      new ProductMaterialGenerator(),
      new ProductNameGenerator(),
      new BsGenerator(),
      new CatchPhraseGenerator(),
      new CompanyNameGenerator(),
      new CompanySuffixGenerator(),
      new CollationGenerator(),
      new ColumnGenerator(),
      new EngineGenerator(),
      new TypeGenerator(),
      new AccountGenerator(),
      new AccountNameGenerator(),
      new AmountGenerator(),
      new BicGenerator(),
      new BitcoinAddressGenerator(),
      new CreditCardCvvGenerator(),
      new CreditCardNumberGenerator(),
      new CurrencyGenerator(),
      new EthereumAddressGenerator(),
      new IbanGenerator(),
      new RoutingNumberGenerator(),
      new TransactionTypeGenerator(),
      new AvatarGenerator(),
      new DomainNameGenerator(),
      new DomainSuffixGenerator(),
      new DomainWordGenerator(),
      new EmailGenerator(),
      new ExampleEmailGenerator(),
      new IpGenerator(),
      new Ipv6Generator(),
      new MacGenerator(),
      new PasswordGenerator(),
      new ProtocolGenerator(),
      new UrlGenerator(),
      new UrlWithPathGenerator(),
      new UserAgentGenerator(),
      new UserNameGenerator(),
      new FindNameGenerator(),
      new FirstNameGenerator(),
      new FullNameGenerator(),
      new JobAreaGenerator(),
      new JobDescriptorGenerator(),
      new JobTitleGenerator(),
      new JobTypeGenerator(),
      new LastNameGenerator(),
      new PrefixGenerator(),
      new SuffixGenerator(),
      new PhoneNumberGenerator(),
      new PhoneNumberFormatGenerator(),
      new AndroidIdGenerator(),
      new ApplePushTokenGenerator(),
      new BlackBerryPinGenerator(),
      new CommonFileExtGenerator(),
      new CommonFileNameGenerator(),
      new CommonFileTypeGenerator(),
      new DirectoryPathGenerator(),
      new ExceptionGenerator(),
      new FileExtGenerator(),
      new FileNameGenerator(),
      new FilePathGenerator(),
      new FileTypeGenerator(),
      new MimeTypeGenerator(),
      new SemverGenerator(),
      new VersionGenerator(),
   
    };
  }
}
