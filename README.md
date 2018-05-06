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

Note that the static definition will be used as the default if nothing is defined for an instance or for an `AutoFaker<T>` implementation (see below).

## AutoFaker&lt;T&gt;
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
// If the AutoFaker<T> class needs constructor arguments, they can be passed as an object array
var person2 = AutoFaker.Generate<Person, PersonFaker>(new[] { id });

person2.Dump();
```

Note that, should a rule set be used to generate a type, then only members **not** defined in the rule set are auto generated. In the examples above, the `Id` member will **not** be generated, but will instead use the `RuleFor` value.

# Binders
A default `IAutoBinder` implementation is included with **AutoBogus**, but it will not generate interfaces or abstract classes. For this, the following packages are available:

* [AutoBogus.FakeItEasy](https://www.nuget.org/packages/AutoBogus.FakeItEasy)
* [AutoBogus.Moq](https://www.nuget.org/packages/AutoBogus.Moq)
* [AutoBogus.NSubstitute](https://www.nuget.org/packages/AutoBogus.NSubstitute)

# Behaviors
The following underlying behaviors are in place in **AutoBogus**:

* Interface and abstract class types are not auto generated - they will result in `null` values. A custom binder would be needed, like one of the packages listed above.
* Rescursive types - a nested member with the same parent type - will be generated to **2** levels to avoid a `StackOverflowException` - `Person.Parent -> Person.Parent -> null`
