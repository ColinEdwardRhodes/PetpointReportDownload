using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lollypop
{
    /// <summary>
    /// Formula processor class - handles %% formulas for manipulation.
    /// </summary>
    public class FormulaProcessor
    {
        /// <summary>
        /// Process an argument formula string denoted between %% in a 
        /// string.  Current choices are;
        /// %LAST_x% where x is an integer.
        /// </summary>
        /// <param name="actualValue"></param>
        /// <returns></returns>
        internal static string Process(string actualValue)
        {
            Regex re = new Regex(@"%LAST_(\d+)%",RegexOptions.IgnoreCase);
            if (re.IsMatch(actualValue))
            {
                var days = Int32.Parse(re.Match(actualValue).Groups[1].Value);
                return DateTime.Now.AddDays(-1 * days).ToString("MM/dd/yyyy");
            }
            else
            {
                return actualValue;
            }
        }
    }
}
