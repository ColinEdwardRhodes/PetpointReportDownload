using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lollypop
{
    /// <summary>
    /// An argument (input field) for a report.
    /// </summary>
    public class ReportArgument
    {
        public string Name { get; set; }

        public string XPath { get; set; }

        public string Value { get; set; }

        public Boolean UseDefault { get; set; }
    }
}
