using System.Text.RegularExpressions;

namespace Test.Backend.Domain.Extentions
{
    public static class Strings
    {
        public static string OnlyLettersAndSpace(this string value)
        {
            return Regex.Replace(value, @"[^A-Za-z\s]+", "");
        }
    }
}
