using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestmonitorTests.Wrappers;

namespace TestmonitorTests.Pages
{
    public class ProjectsPage : BasePage
    {
        private string END_POINT = "my-projects";

        //Locators
        private readonly By ManageProjectsButtonBy = By.CssSelector("a.button.is-white");

        public ProjectsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public ProjectsPage(IWebDriver driver) : base(driver, false) { }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(ManageProjectsButtonBy) != null;
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        //Methods

        public Button ManageProjectsButton()
        {
            return new Button(Driver, ManageProjectsButtonBy);
        }

        public void OpenSettingsProjetsPage()
        {
            ManageProjectsButton().Click();
        }
    }
}
