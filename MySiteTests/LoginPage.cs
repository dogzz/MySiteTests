using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MySiteTests
{
    class LoginPage: BasePage
    {
        private String pageUrl = "/admin";
        private String host;
        private Elem loginField;
        private Elem passwordField;
        private Elem submitButton;
        public LoginPage(IWebDriver driver, String host):base(driver)
        {
            this.host = host;
            loginField = () => find(By.Id("id_username"));
            passwordField = () => find(By.Id("id_password"));
            submitButton = () => find(By.XPath("//input[@value = 'Log in']"));
        }

        internal void open()
        {
            driver.Navigate().GoToUrl(host + pageUrl);
        }

        public void enterLogin(String login)
        {
            loginField().Clear();
            loginField().SendKeys(login);
        }

        public void enterPassword(String password)
        {
            passwordField().Clear();
            passwordField().SendKeys(password);
        }

        public void submitCredentials()
        {
            submitButton().Click();
        }
    }
}
