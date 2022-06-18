using DocumentFormat.OpenXml;

namespace Formatter.Utils;

public static class NotationConverter
{
    public static UInt32Value ToUInt32Value(double Centimeter) => new UInt32Value((uint)(Centimeter * 567));
    public static Int32Value ToInt32Value(double Centimeter) => new Int32Value((int)(Centimeter * 567));
    public static StringValue ToHpsMeasureFontSize(int fontSize) => new StringValue((fontSize * 2).ToString());
}

