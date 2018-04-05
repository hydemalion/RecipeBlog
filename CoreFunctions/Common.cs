using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CoreFunctions
{
    public class Common
    {
        public static string CleanStringForURL(string input)
        {
            //replace anything that isn't a character or a number with a dash
            string cleaned = Regex.Replace(input, "[^\\w]", "-");
            //make sure no dashes are doubled
            cleaned = cleaned.Replace("--", "-").Replace("--", "-");
            return cleaned;
        }

    }
}
