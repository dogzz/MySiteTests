using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MySiteTests
{
    class LoginTest:BaseTest
    {
        [Test]
        public void performLoginWithValidCredentials()
        {
            BaseSteps.startApp();
            BaseSteps.login("admin", "123456");
            Assert.IsTrue(BaseSteps.isUserLoggedIn(), "User was not able to log in with valid credentials");
        }

        [Test]
        public void performLoginWithInvalidCredentials()
        {
            BaseSteps.startApp();
            BaseSteps.login("admin", "12345");
            Assert.IsFalse(BaseSteps.isUserLoggedIn(), "User was able to log in with invalid credentials");
        }
    }
}
