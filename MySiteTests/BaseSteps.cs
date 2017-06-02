using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySiteTests
{
    class BaseSteps
    {
        protected static LoginPage loginPage;
        protected static MainPage mainPage;
        public static string HOST_NAME = "http://127.0.0.1:3030";

        public static void init()
        {
            IWebDriver driver = new ChromeDriver();
            loginPage = new LoginPage(driver, HOST_NAME);
            mainPage = new MainPage(driver);
        }

        public static void startApp()
        {
            loginPage.open();
        }

        public static void closeApp()
        {
            loginPage.closeBrowser();
        }

        public static void login(String login, String password)
        {
            loginPage.enterLogin(login);
            loginPage.enterPassword(password);
            loginPage.submitCredentials();
        }

        public static bool isUserLoggedIn()
        {
            return mainPage.isLogOutDisplayed();
        }

    }
}
