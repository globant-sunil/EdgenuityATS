using System;
using TechTalk.SpecFlow;
using WebPages;
using FluentAssertions;
using WebPages.Family;
using System.Threading;

namespace Test.Steps.UI_Steps.Family
{
    [Binding]
    public class FamilyLoginSteps
    {
        FamilyLoginPage loginPage;
        FamilyWelcomePage welcomePage;

        [Given(@"Go to (.*) appication Portal")]
        public void GivenGoToQA_FamilyApplicationPortal(String portal)
        {
            loginPage = new FamilyLoginPage();
            loginPage.GoToFamilyPortal(portal);
        }
        
        [When(@"Login using (.*) and (.*) credentials")]
        public void WhenLoginUsingChetanTeachAndChetanCredentials(string username, string password)
        {
            welcomePage = loginPage.Login(username, password);
        }
        
        [Then(@"user clicks on signout buttton")]
        public void WhenUserClicksOnSignoutButtton()
        {
            loginPage = welcomePage.ClickSignOut();
        }
        
        [Then(@"validate that the user was successfully logged into Family")]
        public void ThenValidateThatTheUserWasSuccessfullyLoggedIntoFamily()
        {
            bool theBoolean = true;
            theBoolean.Should().Be(welcomePage.IsLoad());
            Thread.Sleep(5000);
        }
        
        [Then(@"validate that user is successfully signed out")]
        public void ThenValidateThatUserIsSuccessfullySignedOut()
        {
            loginPage.IsElementDisplayed(loginPage.BtnLogin).Should().Be(true);
        }
    }
}
