using EdgeWebDriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.Utils
{
    public static class SeleniumUtils
    {
        public static void CloseAlert(bool traceError) {
            IAlert alert;
            try
            {
                alert = Driver.Get().SwitchTo().Alert();
                alert.Dismiss();
            }
            catch (Exception e)
            {
                if (traceError) { throw new NoAlertPresentException(); }
                else { Console.WriteLine("Popup session opened closed ok!"); }
            }
            finally {
                Driver.Get().SwitchTo().DefaultContent();
            }
        }
    }
}
