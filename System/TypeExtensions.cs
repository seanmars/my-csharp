using System.Linq;

public static class TypeExtension
{
  public static bool In<T>(this T val, params T[] values) where T : struct
  {
    return values.Contains(val);
  }
}
