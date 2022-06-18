namespace Formatter
{
    public static class Constants
    {
        public static class Font
        {
            #region Font sizes

            public const int MainTextFontSize = 14;
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
            public const string CommonTextStyleId = "MainText";
            
            public const string DangerTextStyleName = "Dander Text";
            public const string DanderTextStyleId = "DanderText";

            public const string HeaderTextStyleName = "Header Text";
            public const string HeaderTextStyleId = "HeaderText";
        }

        public static class Text
        {
            public static readonly char[] SeparateSymbols = { ' ', ',', '.', ';', ':', '!', '?', '(', ')', '[', ']', '\'', '\"', '-', '—', '_' };
            public static readonly char[] EndingSymbols = { '.', ';', '!', '?' };
        }


        public static class NeedRemoveToConfig
        {
            public const string PathToTestFile = @"C:\Users\Максим\Desktop\word";
        }
    }
}
