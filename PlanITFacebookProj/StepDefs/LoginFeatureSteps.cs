using System;
using TechTalk.SpecFlow;
using PlanITFacebookProj.Utils;
using PlanITFacebookProj.Pages;

namespace PlanITFacebookProj.StepDefs
{
    [Binding]
    public class LoginFeatureSteps
    {
        LoginPage loginPage = new LoginPage();
        Helper readConfig = new Helper();

        [Given(@"I have entered username '(.*)' and password '(.*)'")]
        public void GivenIHaveEnteredUsernameAndPassword(string loginUser, string loginPassword)
        {
            loginPage.with(loginUser, loginPassword);
        }

        [When(@"I login")]
        public void WhenILogin()
        {
            loginPage.submit();
        }


        [Then(@"I should be informed that login '(.*)'")]
        public void ThenIShouldBeInformedThatLogin(String loginStatus)
        {
            switch (loginStatus)
            {
                case "passed":
                    loginPage.HomePageIsLoaded();
                    break;
                case "failed":
                    loginPage.StillOnLoginPage();
                    break;
            }
        }
    }
}
