using System.Text.RegularExpressions;

namespace andrena.Usus.net.Core.Helper
{
    public static class StringExtensions
    {
        public static string ReplaceIfStartsWith(this string fullText, string prefix, string searchPattern, string replacePattern)
        {
            if (fullText.StartsWith(prefix))
                return fullText.StartingAfterFirst(prefix).Replace(searchPattern, replacePattern);
            else
                return fullText;
        }

        public static string StartingAfterFirst(this string fullText, string textToSkip)
        {
            int toSkip = fullText.IndexOf(textToSkip) + textToSkip.Length;
            return fullText.Substring(toSkip);
        }

        public static string ReplaceRegex(this string fullText, string searchPattern, string replacePattern)
        {
            return Regex.Replace(fullText, "`.*?\\[", "[");
        }
    }
}