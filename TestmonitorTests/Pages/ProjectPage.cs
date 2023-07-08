using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestmonitorTests.Wrappers;

namespace TestmonitorTests.Pages
{
    public class ProjectPage : BasePage
    {
        private string END_POINT = "settings/projects/{id}";

        //Locators
        private readonly By DropdownButtonBy = By.CssSelector("dropdown-component");

        public ProjectPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public ProjectPage(IWebDriver driver) : base(driver, false) { }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(DropdownButtonBy) != null;
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public UIElement DropdownButton()
        {
            return new UIElement(Driver, DropdownButtonBy);
        }
    }
}
