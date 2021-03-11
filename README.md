[![NuGet](https://img.shields.io/nuget/v/AutoBogus?style=for-the-badge)](https://www.nuget.org/packages/AutoBogus/)
[![NuGet](https://img.shields.io/nuget/dt/AutoBogus?style=for-the-badge)](https://www.nuget.org/packages/AutoBogus/)

# AutoBogus
A C# library complementing the [Bogus](https://github.com/bchavez/Bogus) generator by adding auto creation and population capabilities.

The following packages are available for download from NuGet:

- [AutoBogus](https://www.nuget.org/packages/AutoBogus)
- [AutoBogus.Conventions](https://www.nuget.org/packages/AutoBogus.Conventions)
- [AutoBogus.FakeItEasy](https://www.nuget.org/packages/AutoBogus.FakeItEasy)
- [AutoBogus.Moq](https://www.nuget.org/packages/AutoBogus.Moq)
- [AutoBogus.NSubstitute](https://www.nuget.org/packages/AutoBogus.NSubstitute)

## Configuration
There are several levels of configuration available.

- `Global` > this is scoped as the default configuration across all generate requests.
- `Faker` > this is scoped as the configuration applied to all generate requests for an `AutoFaker` instance.
- `Generate` > this is scoped as the configuration for a specific generate request.

The above levels are hierarchical and in the order listed. Therefore, if a setting is **not** set for a `Generate` configuration, then the `Faker` value is used and then the `Global`.

#### Builder
A configuration is defined via a builder action that invokes the relevant setup method.

```c#
// Configure globally
AutoFaker.Configure(builder =>
{
  builder
    .WithLocale()         // Configures the locale to use
    .WithRepeatCount()    // Configures the number of items in a collection
    .WithRecursiveDepth() // Configures how deep nested types should recurse
    .WithBinder()         // Configures the binder to use
    .WithFakerHub()       // Configures a Bogus.Faker instance to be used - instead of a default instance
    .WithSkip()           // Configures members to be skipped for a type
    .WithOverride();      // Configures the generator overrides to use - can be called multiple times
});

// Configure a faker
var faker = AutoFaker.Create(builder => ...);

// Configure a generate request
faker.Generate<TType>(builder => ...);
faker.Generate<TType, TFaker>(builder => ...);

AutoFaker.Generate<TType>(builder => ...);
AutoFaker.Generate<TType, TFaker>(builder => ...);

// Configure an AutoFaker<T> 
var personFaker = new AutoFaker<Person>()
  .Configure(builder => ...)
  .RuleFor(fake => fake.Id, fake => fake.Random.Int())
  .Generate();
```

The `Generate<TType, TFaker>()` methods also include `WithArgs()` so constructor arguments can be defined for the `TFaker` instance.

## Usage

### AutoFaker
The non-generic `AutoFaker` class provides convenience methods to generate type instances.

It can be used statically or as a configured instance. The static methods provide a means of quickly generating types on-the-fly and the instance can be reused across multiple generate requests.

#### Static
```c#
AutoFaker.Generate<int>();
AutoFaker.Generate<Person>();
```

#### Instance
```c#
var faker = AutoFaker.Create();

faker.Generate<int>();
faker.Generate<Person>();
```

### AutoFaker&lt;T&gt;
The `AutoFaker<T>` class is a **Bogus** wrapper that adds auto generation for member values. In turn, it means all the goodness of **Bogus** is automatically available (e.g. rule sets).

```c#
var personFaker = new AutoFaker<Person>()
  .RuleFor(fake => fake.Id, fake => fake.Random.Int())
  .RuleSet("empty", rules =>
  {
    rules.RuleFor(fake => fake.Id, () => 0);
  });

// Use explicit conversion or call Generate()
var person1 = (Person)personFaker;
var person2 = personFaker.Generate();

person1.Dump();
person2.Dump();

// An existing instance can also be populated
var person3 = new Person();

personFaker.Populate(person3);
person3.Dump();
```

When the `AutoFaker<T>` class is inherited, you can either instantiate an instance or use the `AutoFaker` class to auto instantiate and invoke a `Generate()` method.

```c#
public class PersonFaker : AutoFaker<Person>
{
  public PersonFaker(int id)
  {
    RuleFor(fake => fake.Id, () => id)
  }
}

var id = AutoFaker.Generate<int>();

// Create an instance and call Generate()
var personFaker = new PersonFaker(id);
var person1 = personFaker.Generate();

person1.Dump();

// Create a Person instance using AutoFaker.Generate()
// If the AutoFaker<T> class needs constructor arguments, they can be passed using WithArgs()
var person2 = AutoFaker.Generate<Person, PersonFaker>(builder => builder.WithArgs(id));

person2.Dump();
```

Note that, should a rule set be used to generate a type, then only members **not** defined in the rule set are auto generated. In the examples above, the `Id` member will **not** be generated, but will instead use the `RuleFor` value.

## Binders
A default `IAutoBinder` implementation is included with **AutoBogus**, but it will not generate interfaces or abstract classes. For this, the following packages are available:

- [AutoBogus.FakeItEasy](https://www.nuget.org/packages/AutoBogus.FakeItEasy)
- [AutoBogus.Moq](https://www.nuget.org/packages/AutoBogus.Moq)
- [AutoBogus.NSubstitute](https://www.nuget.org/packages/AutoBogus.NSubstitute)

## Skipping
The generating of values can be skipped based on either a type or the member path of a type. 

```c#
AutoFaker.Configure(builder =>
{
  // Types
  builder
    .WithSkip<Address>()                      // Define a generic type
    .WithSkip(typeof(Country));               // Define a type

  // Type members
  builder
    .WithSkip<Person>(person => person.Name); // Define using an expression for public members
    .WithSkip<Person>("Age");                 // Define using a string for protected, internal, etc. members
    .WithSkip(typeof(Person), "Gender");      // Define using a string for protected, internal, etc. members
});
```

## Overrides
In some cases, custom rules are needed to generate a type and for this, **AutoBogus** provides generator overrides. By implementating a class that inherits `AutoGeneratorOverride` and registering it via a configuration, these custom rules can be invoked as part of a generate request.

```c#
public class PersonOverride : AutoGeneratorOverride
{
  public override bool CanOverride(AutoGenerateContext context)
  {
    return context.GenerateType == typeof(Person);
  }

  public override void Generate(AutoGenerateOverrideContext context)
  {
    // Apply an email value to the person
    var person = context.Instance as Person;
    person.Email = context.Faker.Internet.Email();
  }
}

// Register the override
AutoFaker.Configure(builder => builder.WithOverride(new PersonOverride()));
```

## Behaviors
The following underlying behaviors are in place in **AutoBogus**:

- Interface and abstract class types are not auto generated - they will result in `null` values. A custom binder would be needed, like one of the packages listed above.
- Rescursive types - a nested member with the same parent type - will be generated to **2** levels by default to avoid a `StackOverflowException` - `Person.Parent -> Person.Parent -> null`
- Read only properties - if a property is read only but can be resolved as an `ICollection<>` or `IDictionary<,>`, then it will be populated via the `Add()` method.

## Conventions
The [AutoBogus.Conventions](https://www.nuget.org/packages/AutoBogus.Conventions) package provides conventions for generating values, currently based on generation type and name. As an example, a property named `Email` and of type `string` will be assigned a value using the `Faker.Internet.Email()` generator.

To include the conventions in your project, apply the following configuration at the required level:

```c#
AutoFaker.Configure(builder =>
{
  builder.WithConventions();
});
```

Each convention generator maps to a **Bogus** generator method and can be configured individually.

```c#
AutoFaker.Configure(builder =>
{
  builder.WithConventions(config =>
  {
    config.FirstName.Enabled = false;      // Disables the FirstName generator
    config.LastName.AlwaysGenerate = true; // Overrides any LastName values previously generated
    config.Email.Aliases("AnotherEmail");  // Generates an email value for members named AnotherEmail
  });
});
```
