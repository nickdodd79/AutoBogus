using Bogus;
using System.Collections.Generic;
using System.Reflection;

namespace AutoBogus
{
  public interface IAutoBinder
    : IBinder
  {
    TType CreateInstance<TType>(AutoGenerateContext context);
    void PopulateInstance<TType>(object instance, AutoGenerateContext context, IEnumerable<MemberInfo> members = null);
  }
}
