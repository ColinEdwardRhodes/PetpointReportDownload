using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lollypop
{
    /// <summary>
    /// A report at petpoint.
    /// </summary>
    public class Report 
    {
        /// <summary>
        /// Name of the report
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Arguments used to fill values on the report.
        /// </summary>
        public List<ReportArgument> Arguments { get; set; }
    }
}
