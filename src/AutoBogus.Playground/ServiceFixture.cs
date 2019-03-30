using AutoBogus.Playground.Model;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace AutoBogus.Playground
{
  public class ServiceFixture
    : FixtureBase
  {
    private Item _item;
    private IEnumerable<Item> _items;

    private IRepository _repository;
    private Service _service;
    private ITestOutputHelper _output;

    public ServiceFixture(ITestOutputHelper output)
    {
      var id = Faker.Generate<Guid>();
      var generator = new AutoFaker<Item>()
        .RuleFor(item => item.Id, () => id)
        .RuleFor(item => item.Name, faker => faker.Person.FullName);

      _item = generator;
      _items = generator.Generate(5);

      _repository = Faker.Generate<IRepository>();

      _repository.Get(id).Returns(_item);
      _repository.GetAll().Returns(_items);

      _service = new Service(_repository);
      _output = output;
    }

    [Fact]
    public void Service_Get_Should_Call_Repository_Get()
    {
      _service.Get(_item.Id);

      _repository.Received().Get(_item.Id);
    }

    [Fact]
    public void Service_Get_Should_Return_Item()
    {
      _service.Get(_item.Id).Should().Be(_item);
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

    [Fact]
    public void Service_GetPending_Should_Call_Repository_GetFiltered()
    {
      _service.GetPending();

      _repository.Received().GetFiltered(Service.PendingFilter);
    }

    [Fact]
    public void Service_GetPending_Should_Return_Items()
    {
      var id = Faker.Generate<Guid>();
      var item = AutoFaker.Generate<Item>();
      var items = new List<Item>
      {
        Faker.Generate<Item, ItemFaker>(builder => builder.WithArgs(id)),
        AutoFaker.Generate<Item, ItemFaker>(builder => builder.WithArgs(id))
      };

      item.Status = ItemStatus.Pending;
      items.Add(item);

      _repository.GetFiltered(Service.PendingFilter).Returns(items);

      _service.GetPending().Should().BeSameAs(items);
    }
  }
}
