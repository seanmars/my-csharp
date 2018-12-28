public static class StringExtension
{
    static readonly char[] padding = { '=' };

    public static string ToUrlSafeBase64(this string raw)
    {
        var bytes = System.Text.Encoding.Unicode.GetBytes(raw);
        return System.Convert.ToBase64String(bytes)
            .TrimEnd(padding).Replace('+', '-').Replace('/', '_');
    }

    public static string FromUrlSafeBase64(this string base64)
    {
        var incoming = base64.Replace('_', '/').Replace('-', '+');
        switch (base64.Length % 4)
        {
            case 2:
                incoming += "==";
                break;
            case 3:
                incoming += "=";
                break;
        }
        var bytes = System.Convert.FromBase64String(incoming);

        return System.Text.Encoding.Unicode.GetString(bytes);
    }
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
