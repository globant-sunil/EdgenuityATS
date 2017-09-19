using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Firefox;
using EdgeWebDriver;
using OpenQA.Selenium.Support.PageObjects;

namespace WebPages
{
    public abstract class BasePage    {
        protected static IWebDriver driver;

        protected BasePage(){
            driver = Driver.Get();
            PageFactory.InitElements(driver, this);
        }

        public void GoToSite(string WebUrl){
            Driver.Get().Navigate().GoToUrl(WebUrl);
        }

        public bool IsElementDisplayed(IWebElement element)
        {
            //Add WebdriverWait for element
            return (element.Displayed);
        }
    }
}
