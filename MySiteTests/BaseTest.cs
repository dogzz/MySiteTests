using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MySiteTests
{
    [TestFixture]
    public class BaseTest
    {
        [SetUp]
        protected void SetUp()
        {
            BaseSteps.init();
            BaseSteps.startApp();
        }

        [TearDown]
        protected void TearDown()
        {
            BaseSteps.closeApp();
        }
    }
}
