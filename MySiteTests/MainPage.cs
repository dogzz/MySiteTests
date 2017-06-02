using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySiteTests
{
    class MainPage: BasePage
    {
        private String pageUrl = "/admin";
        private Elem logOut;
        private Elem changeQuestions;

        public MainPage(IWebDriver driver) : base(driver)
        {
            logOut = () => find(By.LinkText("Log out"), false, 5);
            changeQuestions = () => find(By.LinkText("Questions"));
        }

        public bool isLogOutDisplayed()
        {
            return logOut() != null && logOut().Displayed;
        }

        public void navigateToQuestions()
        {
            changeQuestions().Click();
        }
    }
}
