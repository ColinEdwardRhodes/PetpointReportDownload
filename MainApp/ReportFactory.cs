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
        /// <summary>
        /// Build a report from the report file.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Report GetReport(string reportFileName)
        {
            ReportConfigurationFileReader reader = new ReportConfigurationFileReader(reportFileName);

            return new Report()
            {
                Name = reader.Name,
                Arguments = reader.ReportArguments
            };
        }
    }
}
