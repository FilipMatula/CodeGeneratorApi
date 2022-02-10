using System.Drawing;

namespace CodeGenerator.Extensions
{
    static class ColorTranslatorExtensions
    {
        public static string ToHexString(this Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}";

        public static string ToHtmlText(this string htmlColor)
        {
            if (!htmlColor.StartsWith("#"))
                htmlColor = $"#{htmlColor}";
            return htmlColor;
        }
    }
}
