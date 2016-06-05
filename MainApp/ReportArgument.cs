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
        /// <summary>
        /// Name of the argument
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// An xpath to that argument on the report screen.
        /// </summary>
        public string XPath { get; set; }

        /// <summary>
        /// The value we would like to set on the xpath
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// If set, don't apply the value and use the form default
        /// </summary>
        public Boolean UseDefault { get; set; }
    }
}
