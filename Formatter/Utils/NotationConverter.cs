using DocumentFormat.OpenXml;

namespace Formatter.Utils;

public static class NotationConverter
{
    public static UInt32Value ToUInt32Value(double centimeter) => new UInt32Value((uint)(centimeter * 567));
    public static Int32Value ToInt32Value(double centimeter) => new Int32Value((int)(centimeter * 567));
    public static StringValue ToHpsMeasureFontSize(int fontSize) => new StringValue((fontSize * 2).ToString());
}

