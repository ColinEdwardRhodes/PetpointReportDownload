using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Lollypop
{
    public class Configuration
    {
        /// <summary>
        /// instance member - decidedly not threadsafe but not needed.
        /// </summary>
        private static Configuration configuration;

        /// <summary>
        /// Instance method
        /// </summary>
        public static Configuration Instance
        {
            get
            {
                if (configuration == null)
                {
                    configuration = new Configuration();
                }

                return configuration;
            }
        }

        /// <summary>
        /// Name of the shelter for petpoint
        /// </summary>
        public string ShelterId
        {
            get
            {
                return ConfigurationManager.AppSettings["ShelterId"];
            }
        }

        /// <summary>
        /// User name for pet point
        /// </summary>
        public string UserName
        {
            get
            {
                return ConfigurationManager.AppSettings["UserName"];
            }
        }

        /// <summary>
        /// Password for petpoint
        /// </summary>
        public string Password
        {
            get
            {
                return ConfigurationManager.AppSettings["Password"];
            }
        }

        /// <summary>
        /// How long to wait for a report to download
        /// before we close the browser window.
        /// </summary>
        public int ReportWaitTimeSeconds
        {
            get
            {
                return 20;
            }
        }
    }
}
