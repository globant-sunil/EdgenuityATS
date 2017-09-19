using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EdgeWebDriver;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using CommonUtilities;

namespace WebPages.Family
{
    public class FamilyLoginPage: BasePage{

        public FamilyLoginPage()
        {
        }

        #region WebElements
        [FindsBy(How = How.Id, Using = "LoginUsername")]
        public IWebElement TxtUserName { get; private set; }

        [FindsBy(How = How.Id, Using = "LoginPassword")]
        public IWebElement TxtPassword { get; private set; }

        [FindsBy(How = How.Id, Using = "LoginSubmit")]
        public IWebElement BtnLogin { get; private set; }
        #endregion

        public void GoToFamilyPortal(string portal)
        {
            GoToSite(DataAccess.getEnvironmentURL(portal));
        }

        /// <summary>
        /// Click on Login Button
        /// </summary>
        /// <returns></returns>
        public FamilyLoginPage ClickLogin()
        {
            BtnLogin.Click();
            return this;
        }

        /// <summary>
        /// Method used to complete username input in Family Login Page
        /// </summary>
        /// <param name="Username"></param>
        public void EnterUserName(string Username)
        {
            TxtUserName.SendKeys(Username);
        }
        /// <summary>
        /// Method used to complete password input in Family Login Page
        /// </summary>
        /// <param name="password"></param>
        public void EnterPassword(string password)
        {
            TxtPassword.SendKeys(password);
        }

        /// <summary>
        /// Method used to proceed to login a user in Family application. 
        /// This process return a WelcomePage
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public FamilyWelcomePage Login(string username, string password)
        {
            EnterUserName(username);
            EnterPassword(password);
            ClickLogin();
            CloseIfIsShowedPopUpOpenedSession();
            return new FamilyWelcomePage();
        }

        public bool IsLoad(IWebElement element)
        {
            return element.Displayed;
        }

        public static bool CloseIfIsShowedPopUpOpenedSession()
        {
            try
            {
                IWebElement buttonContinueIsLoggedUser = driver.FindElement(By.Name("continue"));
                buttonContinueIsLoggedUser.Click();
                Console.WriteLine("Closed popup 'Is Logged the user' successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine("The popup 'Is Logged the user' was NOT showed!");
            }
            return true;
        }
    }
}