using Microsoft.CSharp;
using System;
using System.CodeDom;

public static class TypeNameExtension
{
  /*
    - Convert String to string and Int32 to int etc
    - Deal with Nullable<Int32> as int? etc
    - Suppress System.DateTime to be DateTime
    - All other types are written in full
  */
  public static string GetSimplifiedName(this Type t)
  {
    using (var provider = new CSharpCodeProvider())
    {
      if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
      {
          return provider.GetTypeOutput(new CodeTypeReference(t.GetGenericArguments()[0])).Replace("System.", "") + "?";
      }

      return provider.GetTypeOutput(new CodeTypeReference(t)).Replace("System.", "");
    }    
  }
}
