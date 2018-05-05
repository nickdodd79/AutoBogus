# AutoBogus
A C# library complementing the [Bogus](https://github.com/bchavez/Bogus) generator by adding auto creation and population capabilities.

# Usage

## AutoFaker
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

An `IAutoBinder` instance is required to tell **AutoBogus** how to bind generated values to types and members. A default is included, but if a custom binder is required, then it can be set both statically and for an instance.

#### Static
```c#
AutoFaker.SetBinder<ICustomBinder>();
```

#### Instance
```c#
var faker = AutoFaker.Create<ICustomBinder>();
```

Note that the static definition will be used as the default if nothing is defined for an instance or for an `AutoFaker[T]` implementation (see below).

## AutoFaker[T]
The `AutoFaker[T]` class is a Bogus wrapper that adds auto generation for member values. In turn, it means all the goodness of Bogus is automatically available (like rule sets).

```c#
var personFake = new AutoFaker<Person>()
  .RuleFor(fake => fake.Id, fake => fake.Random.Int())
  .RuleSet("empty", rules =>
  {
    rules.RuleFor(fake => fake.Id, () => 0);
  });

// Call Generate() or use explicit conversion 
var person1 = personFake.Generate();
var person2 = (Person)personFake;

person1.Dump();
person2.Dump();

// An existing instance can also be populated
var person3 = new Person();

personFake.Populate(person3);
person3.Dump();
```

Note that, should a rule set be used to generate a type, then only members not defined in the rule set are auto generated. In the example above, the `Id` member will not be generated - it would use the value from `fake => fake.Random.Int()`.

# Binders
A default `IAutoBinder` implementation is included with **AutoBogus**, but it will not generate interfaces or abstract classes. For this, the following packages are available:

* [AutoBogus.FakeItEasy](https://www.nuget.org/packages/AutoBogus.FakeItEasy)
* [AutoBogus.Moq](https://www.nuget.org/packages/AutoBogus.Moq)
* [AutoBogus.NSubstitute](https://www.nuget.org/packages/AutoBogus.NSubstitute)

# Behaviors
The following underlying behaviors are in place in **AutoBogus**:

* Interface and abstract class types are not auto generated - they will result in `null` values. A custom binder would be needed, like one of the packages listed above.
* Rescursive types - a nested member with the same parent type - will be generated to **2** levels to avoid a `StackOverflowException` - `Person.Parent -> Person.Parent -> null`
