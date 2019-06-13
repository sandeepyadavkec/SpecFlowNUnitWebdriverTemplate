using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using PlanITFacebookProj.Utils;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using PlanITFacebookProj.StepDefs;

namespace PlanITFacebookProj.Pages
{
    class BasePage
    {
        readonly IWebDriver driver;
        Helper readConfig = new Helper();
        By loadingSpinner = By.Id("imgProgress");
        By bodyIFrameLocator = By.Id("body_iframe");


        public BasePage()
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public void WaitForPageLoad()
        {
            IWebElement loadingElem = driver.FindElement(loadingSpinner);
            String displayAttribute = loadingElem.GetAttribute("display");
            String maxWaitInSec = readConfig.GetConfigByKey("maxWaitInSec");
            int maxWaitInt = Int32.Parse(maxWaitInSec);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWaitInt));
            wait.Until(ExpectedConditions.ElementIsVisible(loadingSpinner));
        }


        internal void SwitchToIFrame()
        {
            IWebElement iFrameElement = driver.FindElement(bodyIFrameLocator);
            driver.SwitchTo().Frame(iFrameElement);
        }

        internal void SwitchToDefaultContent()
        {
            driver.SwitchTo().DefaultContent();
        }

        public void WaitForElementToBeClickable(IWebElement element)
        {
            String maxWaitInSec = readConfig.GetConfigByKey("maxWaitInSec");
            int maxWaitInt = Int32.Parse(maxWaitInSec);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWaitInt));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public void type(String inputText, By locator)
        {
            find(locator).Clear();
            find(locator).SendKeys(inputText);
        }
        public IWebElement find(By locator)
        {
            return driver.FindElement(locator);
        }

        public void visit(String url)
        {
            driver.Navigate().GoToUrl(readConfig.GetConfigByKey(url));

        }

        public void click(By locator)
        {
            find(locator).Click();
        }

        public void clickJavascript(IWebElement element)
        {
            String javaScript = "var evObj = document.createEvent('MouseEvents');" +
                            "evObj.initMouseEvent(\"click\",true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);" +
                            "arguments[0].dispatchEvent(evObj);";


            IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
            executor.ExecuteScript(javaScript, element);
        }

        public String getText(By locator)
        {
            return find(locator).Text;
        }

        public Boolean isDisplayed(By locator)
        {
            try
            {
                return find(locator).Displayed && find(locator).Enabled;
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
        }

        public Boolean isDisplayed(IWebElement element)
        {
            try
            {
                return element.Displayed && element.Enabled;
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
        }


        public void SelectDropdownByText(string textToSelect, By locator)
        {
            IWebElement elementDropdownList = driver.FindElement(locator);
            var selectElement = new SelectElement(elementDropdownList);
            selectElement.SelectByText(textToSelect);
        }

        public void submit(By locator)
        {
            find(locator).Submit();
        }

        public static string GenerateRandomString(int length, Random random)
        {
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }
    }
}
