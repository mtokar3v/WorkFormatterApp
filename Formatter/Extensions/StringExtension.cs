namespace Formatter.Extensions;

public static class StringExtension
{
    public static string FirstCharToUpper(this string input)
    {
        return input switch
        {
            null => throw new NullReferenceException(nameof(input)),
            var i when string.IsNullOrWhiteSpace(i) => string.Empty,
            _ => input.ElementAt(0).ToString().ToUpper() + input?.Substring(1) ?? ""
        };
    }

    public static bool Contains(this string input, IEnumerable<string> words, IEqualityComparer<string>? comparer = null)
    {
        if (input == null) throw new NullReferenceException(nameof(input));
        if (words == null) throw new NullReferenceException(nameof(words));

        return input.Split(Constants.Text.SeparateSymbols).Any(w => words.Contains(w, comparer));
    }
}

