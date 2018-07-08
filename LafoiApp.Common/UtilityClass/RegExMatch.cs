using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LafoiApp.Common.UtilityClass
{
    public static class RegExMatch
    {
        public static string RegexReplace(string Str, string RegStr, string replTo, bool ignoreCase = false)
        {
            return new Regex(RegStr, ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None).Replace(Str, replTo);
        }

        public static string RegexMatched(string Str, string RegStr)
        {
            return new Regex(RegStr).Match(Str).Value;
        }

        public static string RegexMatchedIngoreCase(string Str, string RegStr)
        {
            return new Regex(RegStr, RegexOptions.IgnoreCase).Match(Str).Value;
        }

        public static bool RegexMatched2(string Str, string RegStr)
        {
            return !string.IsNullOrEmpty(new Regex(RegStr).Match(Str).Value);
        }

        public static bool RegexMatchedIngoreCase2(string Str, string RegStr)
        {
            return !string.IsNullOrEmpty(new Regex(RegStr, RegexOptions.IgnoreCase).Match(Str).Value);
        }
    }
}
