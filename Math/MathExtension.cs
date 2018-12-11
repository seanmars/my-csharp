public static class MathExtension
{
    /// <summary>
    /// return the value between min(include) and max(include)
    /// </summary>
    /// <param name="min">min value(include)</param>
    /// <param name="max">max value(include)</param>
    /// <param name="value">check value</param>
    public static int Between(int min, int max, int value)
    {
        if (value < min)
        {
            return min;
        }
        else if (value > max)
        {
            return max;
        }
        else
        {
            return value;
        }
    }
}
