public class Utils
{
    public static int GetDigit(int value, int place)
    {
        if (place <= 0)
        {
            return value;
        }

        var prefixDigit = (int) Math.Pow(10, place);
        var suffixDigit = (int) Math.Pow(10, place - 1);
        return (value % prefixDigit) - (value % suffixDigit);
    }
}
