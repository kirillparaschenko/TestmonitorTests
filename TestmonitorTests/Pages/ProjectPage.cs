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
        private readonly By DropdownButtonBy = By.CssSelector(".level-right .dropdown-trigger");
        private readonly By ArchiveOptionBy = By.XPath(
            "//a[@class='dropdown-item']//*[contains(text(), 'Archive...')]");
        private readonly By ArchiveButtonBy = By.CssSelector(".modal-card .button.is-danger");

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

        public Button DropdownButton()
        {
            return new Button(Driver, DropdownButtonBy);
        }

        public UIElement ArchiveOption()
        {
            return new UIElement(Driver, ArchiveOptionBy);
        }

        public Button ArchiveButton()
        {
            return new Button(Driver, ArchiveButtonBy);
        }

        public void ArchiveProject()
        {
            DropdownButton().Click();
            ArchiveOption().Click();
            ArchiveButton().Click();
        }
    }
}
