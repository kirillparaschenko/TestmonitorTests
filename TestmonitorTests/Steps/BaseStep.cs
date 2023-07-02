using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestmonitorTests.Pages;

namespace TestmonitorTests.Steps
{
    public class BaseStep
    {
        protected IWebDriver Driver;

        public LoginPage LoginPage => new LoginPage(Driver);
        public ProjectsPage ProjectsPage => new ProjectsPage(Driver);

        public BaseStep(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
