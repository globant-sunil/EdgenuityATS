using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace WebPages.Family
{
    public class FamilyWelcomePage : BasePage  {

        public FamilyWelcomePage() { }

        #region WebElements
        [FindsBy(How = How.Id, Using = "ctl00_btnLogout")]
        public IWebElement LinkSignOut { get; private set; }

        [FindsBy(How = How.Id, Using = "ctl00_imgSelectStudent")]
        public IWebElement BtnSelectStudent { get; private set; }

        #endregion

        public FamilyLoginPage ClickSignOut()
        {
            LinkSignOut.Click();
            return new FamilyLoginPage();
        }

        public bool IsLoad()
        {
            return BtnSelectStudent.Displayed;
        }
    }
}
