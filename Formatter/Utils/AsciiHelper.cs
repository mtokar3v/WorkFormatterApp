namespace Formatter.Utils;

public static class AsciiHelper
{
    private static readonly Dictionary<char, string> _adobeGlyphListForW1251 = new Dictionary<char, string>
    {
        { 'А', "afii10017" },   //192
        { 'Б', "afii10018" },   //193
        { 'В', "afii10019" },   //194
        { 'Г', "afii10020" },   //195
        { 'Д', "afii10021" },   //196
        { 'Е', "afii10022" },   //197
        { 'Ё', "afii10023" },   //168
        { 'Ж', "afii10024" },   //198
        { 'З', "afii10025" },   //199
        { 'И', "afii10026" },   //200
        { 'Й', "afii10027" },   //201
        { 'К', "afii10028" },   //202
        { 'Л', "afii10029" },   //203
        { 'М', "afii10030" },   //204
        { 'Н', "afii10031" },   //205
        { 'О', "afii10032" },   //206
        { 'П', "afii10033" },   //207
        { 'Р', "afii10034" },   //208
        { 'С', "afii10035" },   //209
        { 'Т', "afii10036" },   //210
        { 'У', "afii10037" },   //211
        { 'Ф', "afii10038" },   //212
        { 'Х', "afii10039" },   //213
        { 'Ц', "afii10040" },   //214
        { 'Ч', "afii10041" },   //215
        { 'Ш', "afii10042" },   //216
        { 'Щ', "afii10043" },   //217
        { 'Ъ', "afii10044" },   //218
        { 'Ы', "afii10045" },   //219
        { 'Ь', "afii10046" },   //220
        { 'Э', "afii10047" },   //221
        { 'Ю', "afii10048" },   //222
        { 'Я', "afii10049" },   //223

        { 'а', "afii10065" },   //224
        { 'б', "afii10066" },   //225
        { 'в', "afii10067" },   //226
        { 'г', "afii10068" },   //227
        { 'д', "afii10069" },   //228
        { 'е', "afii10070" },   //229
        { 'ё', "afii10071" },   //184
        { 'ж', "afii10072" },   //230
        { 'з', "afii10073" },   //231
        { 'и', "afii10074" },   //232
        { 'й', "afii10075" },   //233
        { 'к', "afii10076" },   //234
        { 'л', "afii10077" },   //235
        { 'м', "afii10078" },   //236
        { 'н', "afii10079" },   //237
        { 'о', "afii10080" },   //238
        { 'п', "afii10081" },   //239
        { 'р', "afii10082" },   //240
        { 'с', "afii10083" },   //241
        { 'т', "afii10084" },   //242
        { 'у', "afii10085" },   //243
        { 'ф', "afii10086" },   //244
        { 'х', "afii10087" },   //245
        { 'ц', "afii10088" },   //246
        { 'ч', "afii10089" },   //247
        { 'ш', "afii10090" },   //248
        { 'щ', "afii10091" },   //249
        { 'ъ', "afii10092" },   //250
        { 'ы', "afii10093" },   //251
        { 'ь', "afii10094" },   //252
        { 'э', "afii10095" },   //253
        { 'ю', "afii10096" },   //254
        { 'я', "afii10097" },   //255
    };

    private static readonly List<Dictionary<char, string>> _adobeGlyphLists = new List<Dictionary<char, string>>
    {
        _adobeGlyphListForW1251
    };

    //The more lists the more comparisons
    public static bool IsExpandedAscii(char c) => _adobeGlyphLists.Any(l=>l.ContainsKey(c));

    public static string? GetAsciiName(char symbol)
    {
        string? value = null;
        foreach(var list in _adobeGlyphLists)
        {
            list.TryGetValue(symbol, out value);
            if (!string.IsNullOrEmpty(value))
                return value;
        }
        return null;
    }
}

