using DocumentFormat.OpenXml.Wordprocessing;

namespace Formatter.Extensions
{
    public static class BodyExtension
    {
        public static SectionProperties GetOrCreateSectionProperties(this Body body)
        {
            var sectionProperties = (SectionProperties)null;
            if (body.Elements<SectionProperties>().Count() == 0)
            {
                sectionProperties = new SectionProperties();
                body.Append(sectionProperties);
            }
            else
            {
                sectionProperties = body.Elements<SectionProperties>().First();
            }

            return sectionProperties;
        }
    }
}
