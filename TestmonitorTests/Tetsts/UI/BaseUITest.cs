using Allure.Commons;
using NLog;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestmonitorTests.Core;
using TestmonitorTests.Pages;
using TestmonitorTests.Steps;

namespace TestmonitorTests.Tetsts.UI
{
    public class BaseUITest
    {
        protected IWebDriver Driver;
        private AllureLifecycle _allure;
        protected LoginSteps LoginSteps;
        protected ProjectsPage ProjectsPage;
        protected SettingsProjetsPage SettingsProjetsPage;

        [SetUp]
        public void Setup()
        {
            Driver = new Browser().Driver;

            // Init Steps
            LoginSteps = new LoginSteps(Driver);
            ProjectsPage = new ProjectsPage(Driver);
            SettingsProjetsPage = new SettingsProjetsPage(Driver);

            // Init Allure
            _allure = AllureLifecycle.Instance;
        }

        [TearDown]
        public void TearDown()
        {
            // If test is failed
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                // Creating screenshot
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;

                // Added attachment
                _allure.AddAttachment("Screenshot", "image/png", screenshotBytes);
            }

            Driver.Quit();
            Driver.Dispose();
        }
    }
}
