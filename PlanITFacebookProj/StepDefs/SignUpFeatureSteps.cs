using System;
using TechTalk.SpecFlow;
using PlanITFacebookProj.Pages;
using PlanITFacebookProj.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace PlanITFacebookProj.StepDefs
{
    [Binding]
    public class SignUpFeatureSteps
    {
        SignUpPage signUpPage = new SignUpPage();
        Helper utils = new Helper();
        Random rand = new Random();


        [Given(@"I open Sign Up page")]
        public void GivenIOpenSignUpPage()
        {
            String baseURL = utils.GetConfigByKey("baseURL");
            signUpPage.GetDriver().Navigate().GoToUrl(baseURL);
        }



        [Given(@"I enter the randomly generated (.*) firstname")]
        public void GivenIEnterTheRandomlyGeneratedFirstname(String testType)
        {
            String firstName;
            Random rand = new Random();
            if(testType.Equals("valid"))
            {
                firstName = "A" + SignUpPage.GenerateRandomString(8, rand).ToLower();
            }
            else
            {
                firstName = null;
                //TODO: negative scenarios
            }
            signUpPage.FirstName().SendKeys(firstName);
        }
        
        [Given(@"I enter the randomly generated (.*) surname")]
        public void GivenIEnterTheRandomlyGeneratedSurname(String testType)
        {
            String lastName;
            if (testType.Equals("valid"))
            {
                lastName = "A" + SignUpPage.GenerateRandomString(8, rand).ToLower();
            }
            else
            {
                lastName = null;
                //TODO: negative scenarios
            }
            signUpPage.LastName().SendKeys(lastName);
        }
        
        [Given(@"I enter the randomly generated (.*) email")]
        public void GivenIEnterTheRandomlyGeneratedEmail(String testType)
        {
            String email;
            if (testType.Equals("valid"))
            {
                email = SignUpPage.GenerateRandomString(8, rand) + "@gmail.com";
            }
            else
            {
                email = null;
                //TODO: negative scenarios
            }
            signUpPage.EmailPhone().SendKeys(email);
            signUpPage.ConfirmEmailPhone().SendKeys(email);
        }
        
        [Given(@"I enter the randomly generated (.*) password")]
        public void GivenIEnterTheRandomlyGeneratedPassword(String testType)
        {
            String password;
            if (testType.Equals("valid"))
            {
                password = SignUpPage.GenerateRandomString(8, rand) + "123";
            }
            else
            {
                password = null;
                //TODO: negative scenarios
            }
            signUpPage.Password().SendKeys(password);
        }
        
        [Given(@"I enter the randomly generated (.*) birthday")]
        public void GivenIEnterTheRandomlyGeneratedBirthday(String testType)
        {
            int day = rand.Next(1, 29);
            int month = rand.Next(1, 13);
            int year = rand.Next(10, 100);

            IWebElement dayOfBirthElement = signUpPage.DayOfBirth();
            signUpPage.SelectDropdownByValue(day.ToString(), dayOfBirthElement);

            IWebElement monthOfBirthElement = signUpPage.MonthOfBirth();
            signUpPage.SelectDropdownByValue(month.ToString(), monthOfBirthElement);

            IWebElement yearOfBirthElement = signUpPage.YearOfBirth();
            signUpPage.SelectDropdownByValue("19"+year.ToString(), yearOfBirthElement);
        }
        
        [Given(@"I enter the randomly generated (.*) gender")]
        public void GivenIEnterTheRandomlyGeneratedGender(String testType)
        {
            String genderStr = rand.Next(1, 3).ToString();
            signUpPage.Gender(genderStr).Click();
        }
        
        [When(@"I click on Sign Up button")]
        public void WhenIClickOnSignUpButton()
        {
            signUpPage.SignUpButton().Click();
            signUpPage.HandleAlert();
            signUpPage.WaitForSignUp();
        }

        [Then(@"New user should be signed up successfully")]
        public void ThenNewUserShouldBeSignedUpSuccessfully()
        {
            String actualTitle = signUpPage.GetDriver().Title.Trim();
            Assert.IsTrue(actualTitle.Equals("Facebook"), "Sign up failed!\nTitle is: "+actualTitle);
        }
    }
}
