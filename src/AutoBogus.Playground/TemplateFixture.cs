using AutoBogus.Templating;
using FluentAssertions;
using Xunit;

namespace AutoBogus.Playground
{
  public class TemplateFixture
  {
    private class Person
    {
      public int Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Status { get; set; }
    }

    [Fact]
    public void TestAutoFaker()
    {
      var binder = new TemplateBinder();
      var persons = new AutoFaker<Person>(binder)
        .GenerateWithTemplate(@"
          Id | FirstName | LastName
	        0  | John      | Smith
	        1  | Jane      | Jones
	        2  | Bob       | Clark
        ");

      persons.Should().BeEquivalentTo(
        new[]
        {
          new { Id = 0, FirstName = "John", LastName = "Smith", Status = default(string) },
          new { Id = 1, FirstName = "Jane", LastName = "Jones", Status = default(string) },
          new { Id = 2, FirstName = "Bob", LastName = "Clark", Status = default(string) }
        },
        options => options
          .Using<string>(context => context.Subject.Should().NotBeNull())
          .When(info => info.SelectedMemberPath == "Status")
      );
    }
  }
}
