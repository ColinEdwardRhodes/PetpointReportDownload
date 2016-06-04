using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string ShelterId
        {
            get
            {
                return "usny2";
            }
        }

        public string UserName
        {
            get
            {
                return "";
            }
        }

        public string Password
        {
            get
            {
                return "";
            }
        }

        public string ReportName
        {
            get
            {
                return "Animal: Intake with Results Extended";
            }
        }

        public int ReportWaitTimeSeconds
        {
            get
            {
                return 20;
            }
        }
    }
}
