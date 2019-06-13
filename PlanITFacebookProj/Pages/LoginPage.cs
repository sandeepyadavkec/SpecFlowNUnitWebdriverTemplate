using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace PlanITFacebookProj.Pages
{
    class LoginPage : BasePage
    {
        By usernameField = By.Id("email");
        By passwordField = By.Id("pass");
        By loginButton = By.XPath("//input[@value='Log In']");


        public LoginPage()
        {
        }

        public void with(String username, String password)
        {
            visit("baseURL");
            type(username, usernameField);
            type(password, passwordField);
        }

        public void submit()
        {
            click(loginButton);
        }

        internal void HomePageIsLoaded()
        {
            Assert.IsTrue(GetDriver().Title.Equals("Facebook"));
        }

        internal void StillOnLoginPage()
        {
            Assert.IsTrue(GetDriver().Title.Contains("Log in"));
        }
    }
}
