namespace AutoBogus
{
  internal sealed class AutoFakerContext
  {
    internal AutoFakerContext(string locale, IAutoBinder binder)
    {
      Locale = locale ?? "en";
      Binder = binder ?? new AutoBinder();
    }
    
    internal string Locale { get; }
    internal IAutoBinder Binder { get; }
  }
}
