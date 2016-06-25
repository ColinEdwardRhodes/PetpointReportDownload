using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lollypop;

namespace UnitTests
{
    [TestClass]
    public class CommandLineProcessorTest
    {
        [TestMethod]
        public void Basic()
        {
            var args = new string[] { "/r", "animal intake report", "/p", "k=v" };
            CommandLineProcessor proc = new CommandLineProcessor(args);
            Assert.IsTrue(proc.ReportFileName == "animal intake report");
            Assert.IsTrue(proc.ReportValues["k"] == "v");
        }
    }
}
