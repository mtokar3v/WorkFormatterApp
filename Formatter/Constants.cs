namespace Formatter
{
    //  <summary>
    //  There is describe of the work's decorate standard
    //  And something helpful data
    //  </summary>
    public static class Constants
    {
        public static class Font
        {
            #region Font sizes

            public const int MainTextFontSize   = 14;
            public const int HeaderTextFontSize = 16;

            #endregion

            #region Font names

            public const string DefaultFont = "Times New Roman";

            #endregion

            #region Font colors

            public const string DefaultFontColor = "Black";
            public const string DangerFontColor = "Red";

            #endregion
        }

        public static class Style
        {
            public const string CommonTextStyleName = "Main Text";
            public static readonly string CommonTextStyleId = Guid.NewGuid().ToString();
            
            public const string DangerTextStyleName = "Dander Text";
            public static readonly string DanderTextStyleId = Guid.NewGuid().ToString();

            public const string HeaderTextStyleName = "Header Text";
            public static readonly string HeaderTextStyleId = Guid.NewGuid().ToString();
        }

        public static class Text
        {
            public static readonly char[] SeparateSymbols = { ' ', ',', '.', ';', ':', '!', '?', '(', ')', '[', ']', '\'', '\"', '-', '—', '_' };
            public static readonly char[] EndingSymbols = { '.', ';', '!', '?' };
        }

        public static class Margin
        {
            public const double Left   = 3.0;
            public const double Right  = 1.5;
            public const double Top    = 2.0;
            public const double Bottom = 2.0;
        }

        public static class NeedRemoveToConfig
        {
            public const string PathToTestFile = @"C:\Users\Максим\Desktop\word";
        }
    }
}
