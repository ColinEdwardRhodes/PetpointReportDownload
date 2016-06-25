using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lollypop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UnitTests

{
    [TestClass]
    public class ReportConfigurationFileReaderTest
    {
        [TestMethod]
        public void ConfigFileLoadBasic()
        {
            ReportConfigurationFileReader reader = 
                new ReportConfigurationFileReader("../../../MainApp/SampleConfig.txt");
            Assert.AreEqual(reader.Name, "Animal: Intake with Results Extended");
            Assert.AreEqual(reader.ReportArguments.Count, 2);
            Assert.AreEqual(reader.ReportArguments[0].Name, "Intake Start Date:");
            Assert.AreEqual(reader.ReportArguments[0].XPath, "//*[@id=\"calendar1_Date1\"]");
            Assert.AreEqual(reader.ReportArguments[0].Value, "(DateTime.Now).ToString(\"MM/dd/yy\");");
            Assert.AreEqual(reader.ReportArguments[0].UseDefault, false);

            Assert.AreEqual(reader.ReportArguments[1].Name, "Intake End Date:");
            Assert.AreEqual(reader.ReportArguments[1].XPath, "//*[@id=\"calendar2_Date1\"]");
            Assert.AreEqual(reader.ReportArguments[1].Value, "(DateTime.Now - 30).ToString(\"MM/dd/yy\");");
            Assert.AreEqual(reader.ReportArguments[1].UseDefault, false);
        }
    }
}