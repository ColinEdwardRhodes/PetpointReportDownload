using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lollypop
{
    /// <summary>
    /// Process the commandline.  Format is 
    /// 
    /// /r reportname
    /// /p name=value
    /// 
    /// where /p specifies parameters to the report.
    /// </summary>
    public class CommandLineProcessor
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="args"></param>
        public CommandLineProcessor(string[] args)
        {
            ReportValues = new Dictionary<string, string>();

            for (int p = 0; p < args.Length; p++)
            {
                if (args[p] == "/r" && p < args.Length - 1) {
                    ReportFileName = args[++p];
                }
                else if (args[p] == "/p" && p < args.Length - 1)
                {
                    var str = args[++p].Split('=');
                    if (str.Length != 2)
                    {
                        throw new FormatException("Params are of the form key=value - check your command line");
                    }

                    ReportValues.Add(str[0], str[1]);
                }
            }
        }

        /// <summary>
        /// Name of the report file to be used.
        /// </summary>
        public string ReportFileName { get; set; }

        /// <summary>
        /// Map from reportArgument.Name to the instantiated value in the report.
        /// This will need to become more sophisticated later to deal with dates.
        /// </summary>
        public Dictionary<string, string> ReportValues { get; set; }
    }
}
