public static class StringExtension
{
    public static string ToSnakeCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        var startUnderscores = System.Text.RegularExpressions.Regex.Match(input, @"^_+");

        return startUnderscores + System.Text.RegularExpressions.Regex
            .Replace(input, @"([a-z0-9])([A-Z])", "$1_$2")
            .ToLower();
    }

    public static string ToTitleCase(this string input)
    {
        return System.Globalization.CultureInfo.InvariantCulture.TextInfo
            .ToTitleCase(input.ToLowerInvariant().Trim())
            .Replace("_", "")
            .Replace("-", "")
            .Replace(".", "");
    }
}
