using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            ReportArguments = new List<ReportArgument>();
            this.ReadFile(reportFileName);
        }

        /// <summary>
        /// Read the report configuration file
        /// </summary>
        /// <param name="reportFileName"></param>
        private void ReadFile(string reportFileName)
        {
            using (StreamReader reader = new StreamReader(reportFileName))
            {
                int lineNo = 1;
                int argumentLine = -1;
                ReportArgument currentArgument = new ReportArgument();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.TrimStart().StartsWith("#"))
                        continue;

                    lineNo++;

                    if (!line.StartsWith("\t"))
                    {
                        Name = line;
                    }
                    else if (line.StartsWith("\t\t"))
                    {
                        switch (argumentLine)
                        {
                            case 1:
                                // xpath
                                currentArgument.XPath = line.Trim();
                                break;
                            case 2:
                                // value
                                currentArgument.Value = line.Trim();
                                break;
                            case 3:
                                // use default
                                currentArgument.UseDefault = Boolean.Parse(line.Trim());
                                ReportArguments.Add(currentArgument);
                                currentArgument = new ReportArgument();
                                break;
                            case 4:
                                // error!
                                throw new Exception("Invalid config file at line " + line);
                        }
                        argumentLine++;

                    } else if (line.StartsWith("\t"))
                    {
                        // We are processing a new argument.
                        var argumentName = line.TrimStart();
                        argumentLine = 1;
                        currentArgument.Name = line.Trim();
                    }
                }
            }
        }

        /// <summary>
        /// Return the name of the report (first line of the file)
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Return the arguments for the report. Four tabbed lines
        /// under the report name in this order .. name, path, value, usedefault.
        /// </summary>
        public List<ReportArgument> ReportArguments
        {
           get; set;
        }
    }
}
