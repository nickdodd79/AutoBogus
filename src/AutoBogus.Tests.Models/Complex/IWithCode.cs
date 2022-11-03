using System;

namespace AutoBogus.Tests.Models.Complex
{
  public interface IWithCode
  {
    Guid? Code { get; set; }
  }
}
