namespace Formatter.Extensions
{
    public static class StringExtension
    {
        public static string FirstCharToUpper(this string input) 
            => input[0].ToString().ToUpper() + input.Substring(1);

        public static bool Contains(this string input, IEnumerable<string> words, IEqualityComparer<string>? comparer = null)
            => input.Split(Constants.Text.SeparateSymbols).Any(w => words.Contains(w, comparer));
    }
}
