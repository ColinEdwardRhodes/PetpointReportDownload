using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lollypop
{
    /// <summary>
    /// Construct a report from the command line args
    /// </summary>
    public class ReportFactory 
    {
        public static Report GetReport(string reportName, string[] args)
        {
            return new Report()
            {
                Name = "Animal: Intake with Results Extended",
                Arguments = new List<ReportArgument>()
                {
                    new ReportArgument() { 
                        Name = "Intake Start Date:",
                        XPath = "//*[@id=\"calendar1_Date1\"]",
                        Value = DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy"),
                        UseDefault = false
                    },
                    new ReportArgument() { 
                        Name = "Intake End Date:",
                        XPath = "//*[@id=\"calendar2_Date1\"]",
                        Value = DateTime.Now.AddDays(+1).ToString("MM/dd/yyyy"),
                        UseDefault = false
                    }
                }
            };
        }
    }
}
