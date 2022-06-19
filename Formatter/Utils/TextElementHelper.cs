using System.Text.RegularExpressions;
namespace Formatter.Utils;

public static class TextElementHelper
{
    #region Header

    private static readonly List<string> _headerKeyWords = new List<string>
    {
        "Глава"
    };
    private static readonly string _headerPattern = @$"^({string.Join('|', _headerKeyWords)})\s+[\dIVXCDL]+";
    private static readonly int _maxHeaderLength = 120;
    public static bool IsHeader(string? paragraph)
    {
        if (string.IsNullOrEmpty(paragraph) || paragraph.Length > _maxHeaderLength)
            return false;

        if(paragraph.Split(Constants.Text.SeparateSymbols).Length == 1 &&
            _headerKeyWords.Contains(paragraph.Trim(Constants.Text.SeparateSymbols)))
        {
            return true;
        }

        return Regex.IsMatch(paragraph!, _headerPattern, RegexOptions.IgnoreCase);
    }

    #endregion

    #region Table Header

    private static readonly List<string> _tableHeaderKeyWords = new List<string>
    {
        "Таблица",
        "Табл",
        "Table"
    };
    public static bool IsTableHeader(string? text)
    {
        if (string.IsNullOrEmpty(text))
            return false;

        var pattern = string.Join('|', _tableHeaderKeyWords);

        return text
            .Split()
            .ToList()
            .Any(s => Regex.Matches(s, pattern, RegexOptions.IgnoreCase).Count() != 0);
    }

    public static string? GetTableName(string tableHeader)
    {
        //To do: update regex to get tableName for effective
        var pattern = @$"[^{string.Join('|', _tableHeaderKeyWords)}\s+\d+\s+][\w\W]+[^{string.Concat(Constants.Text.EndingSymbols)}]";
        var matches = Regex.Matches(tableHeader, pattern);

        return matches.Count() > 0 ? matches.ElementAt(matches.Count() - 1).Value : null;
    }
    #endregion
}

