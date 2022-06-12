using DocumentFormat.OpenXml.Wordprocessing;

namespace Formatter.Extensions
{
    public static class RunExtension
    {
        public static Text GetOrCreateText(this Run run)
        {
            if (run.Elements<Text>().Count() == 0)
            {
                run.PrependChild(new Text());
            }

            return run.GetFirstChild<Text>()!;
        }
    }
}
