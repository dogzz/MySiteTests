using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySiteTests
{
    class BasePage
    {
        private static int DEFAULT_DRIVER_WAIT_TIMEOUT = 20;
        private static int DEFAULT_DRIVER_POLLING_INTERVAL = 500;
        protected delegate IWebElement Elem();

    protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void closeBrowser()
        {
            driver.Quit();
        }

        /**
         * Find UI Element using instance of Driver with default timeout
         * NoSuchElementException will be raised if no element found during timeout
         * @param locator of the element to be found
         * @return WebElement if found
         */
        protected IWebElement find(By locator)
        {
            return find(locator, true, DEFAULT_DRIVER_WAIT_TIMEOUT, DEFAULT_DRIVER_POLLING_INTERVAL);
        }

        /**
         * Find UI Element using instance of Driver
         * @param locator of the element to be found
         * @param isRequired if true exception will be raised if element not found
         * @return WebElement if found or null otherwise
         */
        protected IWebElement find(By locator, bool isRequired)
        {
            return find(locator, isRequired, DEFAULT_DRIVER_WAIT_TIMEOUT, DEFAULT_DRIVER_POLLING_INTERVAL);
        }

        /**
         * Find UI Element using instance of Driver
         * NoSuchElementException will be raised if no element found during timeout
         * @param locator of the element to be found
         * @param timeout to wait element in seconds
         * @return WebElement if found
         */
        protected IWebElement find(By locator, int timeout)
        {
            return find(locator, true, timeout, DEFAULT_DRIVER_POLLING_INTERVAL);
        }

        /**
         * Find UI Element using instance of Driver
         * @param locator of the element to be found
         * @param isRequired if true exception will be raised if element not found
         * @param timeout to wait element in seconds
         * @return WebElement if found or null otherwise
         */
        protected IWebElement find(By locator, bool isRequired, int timeout)
        {
            return find(locator, isRequired, timeout, DEFAULT_DRIVER_POLLING_INTERVAL);
        }

        /**
         * Find UI Element using instance of Driver
         * @param locator of the element to be found
         * @param isRequired if true exception will be raised if element not found
         * @param timeout to wait element in seconds
         * @param pollingInterval interval of checking element existence in milliseconds
         * @return WebElement if found or null otherwise
         */
        protected IWebElement find(By locator, bool isRequired, int timeout, int pollingInterval)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.PollingInterval = TimeSpan.FromMilliseconds(pollingInterval);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            IWebElement result;
            String strLocator = locator.ToString();

            Func<IWebDriver, IWebElement> waiter = new Func<IWebDriver, IWebElement>((IWebDriver driver) =>
            {
                Console.WriteLine("Try to find element " + strLocator);
                return driver.FindElement(locator);
            });
            try
            {
                result = wait.Until(waiter);
            } catch (WebDriverTimeoutException e)
            {
                if(isRequired)
                {
                    throw new NoSuchElementException(String.Format("Cant find Element using Driver with locator %s", strLocator));
                } else
                {
                    Console.WriteLine("Element not found " + strLocator);
                    return null;
                }
            }

            Console.WriteLine("Element found " + strLocator);
            return result;
}
    }
}
