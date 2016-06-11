using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lollypop
{
    class Program
    {
        /// <summary>
        /// Pass the name of the report, and any parameter values for that report 
        /// on the command line as the primary arguments to the script.  It will download
        /// the report into the download folder where it can be processed by the next
        /// step on the chain.  Error is reported by returning 0, success 1 - unix style.
        /// </summary>
        /// <param name="args"></param>
        static int Main(string[] args)
        {
            var result = 1;
            CommandLineProcessor cmdProcessor = new CommandLineProcessor(args);

            try
            {
                using (IWebDriver driver = WebDriverInit())
                {
                    DownloadReport(
                        driver,
                        cmdProcessor,
                        ReportFactory.GetReport(cmdProcessor.ReportFileName));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown " + ex.ToString());
                result = 0;
            }

            return result;

        }

        /// <summary>
        /// Download a petpoint report instantiating params appropriately.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="report"></param>
        private static void DownloadReport(IWebDriver driver, CommandLineProcessor cmdProcessor, Report report)
        {
            GoToPetPoint(driver);
            Login(driver);
            NavigateToReports(driver);
            OpenReport(driver, report);
            InstantiateReport(driver, cmdProcessor, report);
            RunReport(driver, report);
        }

        /// <summary>
        /// Run the report (submit the form)
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="report"></param>
        private static void RunReport(IWebDriver driver, Report report)
        {
            var btn = driver.FindElement(By.CssSelector("#Btn_Submit"));
            btn.Click();

            // Wait for download to complete according to configuration
            Thread.Sleep(
                new TimeSpan(0, 0, Configuration.Instance.ReportWaitTimeSeconds));
        }

        /// <summary>
        /// Instantiate report fields
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="report"></param>
        private static void InstantiateReport(IWebDriver driver, CommandLineProcessor cmdProcessor, Report report)
        {            
            report.Arguments.ForEach(r =>
            {
                if (!r.UseDefault)
                {
                    var value = r.Value;
                    if (cmdProcessor.ReportValues.ContainsKey(r.Name))
                    {
                        value = cmdProcessor.ReportValues[r.Name];
                    }

                    var argElt = driver.FindElement(By.XPath(r.XPath));

                    if (argElt.TagName.ToLower() == "select")
                    {
                        // Drop it down
                        argElt.Click();
                        var elt = argElt.FindElement(
                            By.XPath( "//option[contains(text(), " + value + ")]"));

                        if (elt != null)
                        {
                            elt.Click();
                        }
                    }
                    else
                    {
                        argElt.Clear();
                        argElt.SendKeys(value);
                    }
                }
            });
        }

        /// <summary>
        /// Open the report of interest.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="report"></param>
        private static void OpenReport(IWebDriver driver, Report report)
        {
            var reportLink = driver.FindElement(By.LinkText(report.Name));
            reportLink.Click();
        }

        /// <summary>
        /// Initialize the driver.
        /// </summary>
        /// <returns></returns>
        static IWebDriver WebDriverInit()
        {
            IWebDriver driver = null;
            if (!Configuration.Instance.UseChrome)
            {
                InternetExplorerOptions options = new InternetExplorerOptions();
                options.EnableNativeEvents = true;
                options.UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Accept;
                options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                options.EnablePersistentHover = true;

                driver = new InternetExplorerDriver(options);
            }
            else
            {
                driver = new ChromeDriver();
            }
            
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 60));
            return driver;
        }

        /// <summary>
        /// Go to the main pet point site.
        /// </summary>
        /// <param name="driver"></param>
        private static void GoToPetPoint(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(Configuration.Instance.LoginPage);
        }

        /// <summary>
        /// Navigate to the reports web site.  Note, you cannot go there directly .. the web
        /// app is very poorly written indeed.
        /// </summary>
        /// <param name="driver"></param>
        private static void NavigateToReports(IWebDriver driver)
        {
            var navigateMenu = driver.FindElement(By.LinkText("Reports"));
            navigateMenu.Click();

            var navigateLink = driver.FindElement(By.LinkText("Report Website"));
            navigateLink.Click();

            // A little time to grease the skids
            Thread.Sleep(3000);

            // It opens a new tab
            SwitchToWindow(driver, d => d.Title == "Report List");

        }

        /// <summary>
        /// Login to petpoint.
        /// </summary>
        /// <param name="driver"></param>
        private static void Login(IWebDriver driver)
        {
            var signIn = driver.FindElement(By.CssSelector("#cphSearchArea_btn_SignIn"));
            var shelterId = driver.FindElement(By.CssSelector("#cphSearchArea_txtShelterPetFinderId"));
            var userName = driver.FindElement(By.CssSelector("#cphSearchArea_txtUserName"));
            var password = driver.FindElement(By.CssSelector("#cphSearchArea_txtPassword"));

            shelterId.SendKeys(Configuration.Instance.ShelterId);
            userName.SendKeys(Configuration.Instance.UserName);
            password.SendKeys(Configuration.Instance.Password);
            signIn.Click();
        }

        /// <summary>
        /// Switch to window
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="predicateExp"></param>
        private static void SwitchToWindow(IWebDriver driver, Expression<Func<IWebDriver, bool>> predicateExp)
        {
            var predicate = predicateExp.Compile();
            foreach (var handle in driver.WindowHandles)
            {
                driver.SwitchTo().Window(handle);
                if (predicate(driver))
                {
                    return;
                }
            }

            throw new ArgumentException(string.Format("Unable to find window with condition: '{0}'", predicateExp.Body));
        }



    }
}
