using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lollypop
{
    public class ReportConfigurationFileReader
    {
        /// <summary>
        /// The name of the report file we are to read.
        /// </summary>
        private string reportFileName;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reportFileName"></param>
        public ReportConfigurationFileReader(string reportFileName)
        {
            this.reportFileName = reportFileName;
            this.ReadFile(reportFileName);
        }

        /// <summary>
        /// Read the report configuration file
        /// </summary>
        /// <param name="reportFileName"></param>
        private void ReadFile(string reportFileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return the name of the report (first line of the file)
        /// </summary>
        public string Name
        {
            get
            {
                return "Animal: Intake with Results Extended";
            }
        }

        /// <summary>
        /// Return the arguments for the report. Four tabbed lines
        /// under the report name in this order .. name, path, value, usedefault.
        /// </summary>
        public List<ReportArgument> ReportArguments
        {
            get
            {
                return new List<ReportArgument>()
                {
                    new ReportArgument() { 
                        Name = "Intake Start Date:",
                        XPath = "//*[@id=\"calendar1_Date1\"]",
                        Value = "",
                        UseDefault = false
                    },
                    new ReportArgument() { 
                        Name = "Intake End Date:",
                        XPath = "//*[@id=\"calendar2_Date1\"]",
                        Value = "",
                        UseDefault = false
                    }
                };
            }
        }
    }
}
