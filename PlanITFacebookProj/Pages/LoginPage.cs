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
        By usernameField = By.Id("txtLogin");
        By passwordField = By.Id("txtPassword");
        By loginButton = By.Id("btnLogin");
        By successMessageLocator = By.Id("header");


        public LoginPage()
        {
        }

        public void with(String username, String password)
        {
            visit("LoginURL");
            type(username, usernameField);
            type(password, passwordField);
        }

        public void submit()
        {
            click(loginButton);
        }

        public void successMessagePresent()
        {
            Assert.True(isDisplayed(successMessageLocator));
        }

        public void failureMessagePresent()
        {
            Assert.False(isDisplayed(successMessageLocator));
        }
    }
}
