using Bogus;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace AutoBogus.Playground
{
  public class ServiceFixture
    : FixtureBase
  {
    private IEnumerable<Item> _items;

    private IRepository _repository;
    private Service _service;

    public ServiceFixture()
    {
      var id = Faker.Generate<Guid>();
      var generator = new AutoFaker<Item>()
        .RuleFor(item => item.Id, () => id)
        .RuleFor(item => item.Name, faker => faker.Person.FullName);

      _items = generator.Generate(5);

      _repository = Faker.Generate<IRepository>();
      _repository.GetAll().Returns(_items);

      _service = new Service(_repository);
    }

    [Fact]
    public void Service_GetAll_Should_Call_Repository_GetAll()
    {
      _service.GetAll();

      _repository.Received().GetAll();
    }

    [Fact]
    public void Service_GetAll_Should_Return_Items()
    {
      _service.GetAll().Should().BeSameAs(_items);
    }
  }
}
