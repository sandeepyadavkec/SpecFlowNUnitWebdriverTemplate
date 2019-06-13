using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PlanITFacebookProj.Utils;
using OpenQA.Selenium.Support.UI;

namespace PlanITFacebookProj.Pages
{
    class SignUpPage : BasePage
    {
        By firstNameLocator = By.Name("firstname");
        By lastNameLocator = By.Name("lastname");
        By emailPhoneLocator = By.Name("reg_email__");
        By confirmEmailPhoneLocator = By.Name("reg_email_confirmation__");
        By passwordLocator = By.Name("reg_passwd__");
        By dayOfBirthLocator = By.Id("day");
        By monthOfBirthLocator = By.Id("month");
        By yearOfBirthLocator = By.Id("year");
        By genderLocator = By.Name("sex");
        By signUpButtonLocator = By.Name("websubmit");
        By homeLocator = By.XPath("//a[contains(text(), 'Home')]");
        Helper utils = new Helper();

        public SignUpPage()
        {
        }

        public IWebElement FirstName()
        {
            return find(firstNameLocator);
        }

        public IWebElement LastName()
        {
            return find(lastNameLocator);
        }

        public IWebElement EmailPhone()
        {
            return find(emailPhoneLocator);
        }

        public IWebElement ConfirmEmailPhone()
        {
            return find(confirmEmailPhoneLocator);
        }

        public IWebElement Password()
        {
            return find(passwordLocator);
        }

        public IWebElement DayOfBirth()
        {
            return find(dayOfBirthLocator);
        }

        public IWebElement MonthOfBirth()
        {
            return find(monthOfBirthLocator);
        }

        public IWebElement YearOfBirth()
        {
            return find(yearOfBirthLocator);
        }

        public IWebElement Gender(string value)
        {
            IReadOnlyCollection<IWebElement> genderElementList = GetDriver().FindElements(genderLocator);

            foreach(IWebElement genderElement in genderElementList)
            {
                String valueAttribute = genderElement.GetAttribute("value");
                if (value.Equals(valueAttribute))
                    return genderElement;

            }
            return null;
        }

        public IWebElement SignUpButton()
        {
            return find(signUpButtonLocator);
        }

        internal void WaitForSignUp()
        {
            IWebDriver driver = GetDriver();
            String currentTitle = driver.Title;
            String maxWaitInSec = utils.GetConfigByKey("maxWaitInSec");
            int maxWaitInt = Int32.Parse(maxWaitInSec);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWaitInt));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(homeLocator));
        }
    }
}
