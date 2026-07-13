using System.Text.RegularExpressions;


HashSet<string> allowedTags = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "font", "b", "i", "u", "sub", "br", "p"
        };
string htmlText = "\r\n<div><p>This is supported text with <span>inline span</span>.</p></div>\r\n<b>Bold text</b> and <i>italic text</i> are supported.\r\n<marquee>This tag is deprecated and unsupported in modern HTML.</marquee>\r\n<blink>Blink tag is unsupported and ignored by browsers.</blink>\r\n<script>alert('Script tag is supported but may be restricted');</script>\r\n";
Console.WriteLine("Input Text: " + htmlText + "\n");
string text1 = FilterSupportedHtml(htmlText);
Console.WriteLine("Sanitize tags: " + text1 + "\n");

string FilterSupportedHtml(string input)
{
    if (string.IsNullOrEmpty(input))
        return input;

    // Step 1: Decode HTML entities (&lt; &gt; etc.)
    string decodedHtml = System.Net.WebUtility.HtmlDecode(input);

    // Step 2: Remove script tags completely (security)
    decodedHtml = Regex.Replace(
        decodedHtml,
        @"<script\b[^>]*>.*?</script>",
        string.Empty,
        RegexOptions.IgnoreCase | RegexOptions.Singleline
    );

    string output = Regex.Replace(
        decodedHtml,
        @"</?([a-zA-Z0-9]+)(\s[^>]*)?>",
        match =>
        {
            string tagName = match.Groups[1].Value;

            // If supported tag → keep as is
            if (allowedTags.Contains(tagName))
            {
                return match.Value;
            }

            // Else → remove tag
            return string.Empty;
        },
        RegexOptions.IgnoreCase
    );

    return output;
}