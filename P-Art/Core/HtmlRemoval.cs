using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace PArt.Core
{
    public class HtmlRemoval
    {
        /// <summary>
        /// Remove HTML from string with Regex.
        /// </summary>
        /// 
        public string HtmlStrip(string input)
        {
            string acceptable = "p|br";
            string stringPattern = @"</?(?(?=" + acceptable + @")notag|[a-zA-Z0-9]+)(?:\s[a-zA-Z0-9\-]+=?(?:(["",']?).*?\1?)?)*\s*/?>";
            return Regex.Replace(input, stringPattern, String.Empty);
        }

        public string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }
        public static string ScriptTagsRegex(object source)
        {
            return Regex.Replace(source+"", "<.*?>", string.Empty);
        }
        /// <summary>
        /// Compiled regular expression for performance.
        /// </summary>
        static Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);

        /// <summary>
        /// Remove HTML from string with compiled Regex.
        /// </summary>
        public string StripTagsRegexCompiled(string source)
        {
            return _htmlRegex.Replace(source, string.Empty);
        }

        /// <summary>
        /// Remove HTML tags from string using char array.
        /// </summary>
        public string StripTagsCharArray(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        public string NormalText(string strin,bool IsCinema)
        {

            string html = strin;
            string result = StripTagsRegex(html).Trim();
            //string result = HtmlStrip(html).Trim();
            
            result = result.ToString().Replace('ی', 'ي');
            result = result.ToString().Replace('ك', 'ک');
            
            result = result.Replace('۰', '0');
            result = result.Replace('۱', '1');
            result = result.Replace('۲', '2');
            result = result.Replace('۳', '3');
            result = result.Replace('۴', '4');
            result = result.Replace('۵', '5');
            result = result.Replace('۶', '6');
            result = result.Replace('۷', '7');
            result = result.Replace('۸', '8');
            result = result.Replace('۹', '9');


            if (IsCinema == false)
            {
                result = result.Replace("\r", " ").Replace("\n", " ");
                result = Regex.Replace(result, @"\s+", " ");
                result = result.ToString().Replace("'", "");
                string regex = "&(.*?);";
                RegexOptions options = (RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline | RegexOptions.IgnoreCase);
                Regex reg = new Regex(regex, options);

                result = reg.Replace(result, " ");
            }
            


            return result;
        }
    
   
        public int CountStringOccurrences(string text, string pattern)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }
    }
}