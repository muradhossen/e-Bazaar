using System.Text.RegularExpressions;

namespace e_Bazaar.Client.Common.Extensions
{
    public static class StringExtensions
    {
        public static string RegexReplace(this string input, string pattern, string replacement)
        {
            return Regex.Replace(input, pattern, replacement);
        }
    }
}
