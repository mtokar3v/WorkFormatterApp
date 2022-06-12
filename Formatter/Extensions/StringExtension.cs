namespace Formatter.Extensions
{
    public static class StringExtension
    {
        public static string FirstCharToUpper(this string input)
        {
            return input[0].ToString().ToUpper() + input.Substring(1);
        }
    }
}
