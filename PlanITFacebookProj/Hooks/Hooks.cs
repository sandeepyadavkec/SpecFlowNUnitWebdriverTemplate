using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PlanITFacebookProj.Utils;
using System.IO;
using NUnit.Framework;

namespace PlanITFacebookProj.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        IWebDriver driver;
        Helper utils = new Helper();

        [BeforeScenario("chrome")]
        public void BeforeScenario()
        {
            
            String maxWaitInSec = utils.GetConfigByKey("maxWaitInSec");
            int maxWaitInt = Int32.Parse(maxWaitInSec);
            var @driverDir = utils.GetCurrentDir()+"\\drivers";
            if (!Directory.Exists(@driverDir))
                Assert.Fail("Driver exe directory does not exists: " + driverDir);
            driver = new ChromeDriver(@driverDir);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(maxWaitInt);
            driver.Manage().Window.Maximize();
            ScenarioContext.Current["driver"] = driver;

        }

        [AfterScenario()]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                TakeScreenshot(driver);
            }
            driver.Quit();
        }

        private void TakeScreenshot(IWebDriver driver)
        {
            try
            {
                string fileNameBase = string.Format("error_{0}_{1}_{2}",
                    FeatureContext.Current.FeatureInfo.Title,
                    ScenarioContext.Current.ScenarioInfo.Title,
                    DateTime.Now.ToString("yyyyMMdd_HHmmss"));

                var artifactDirectory = utils.GetCurrentDir()+"\\testresults";
                if (!Directory.Exists(artifactDirectory))
                    Directory.CreateDirectory(artifactDirectory);

                string pageSource = driver.PageSource;
                string sourceFilePath = Path.Combine(artifactDirectory, fileNameBase + "_source.html");
                File.WriteAllText(sourceFilePath, pageSource, Encoding.UTF8);
                Console.WriteLine("Page source: {0}", new Uri(sourceFilePath));

                ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;

                if (takesScreenshot != null)
                {
                    var screenshot = takesScreenshot.GetScreenshot();
                    string screenshotFilePath = Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");
                    screenshot.SaveAsFile(screenshotFilePath, OpenQA.Selenium.ScreenshotImageFormat.Png);
                    Console.WriteLine("Screenshot: {0}", new Uri(screenshotFilePath));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while taking screenshot: {0}", ex);
            }
        }
    }
}
