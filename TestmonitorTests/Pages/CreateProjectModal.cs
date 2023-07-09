using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestmonitorTests.Models;
using TestmonitorTests.Wrappers;

namespace TestmonitorTests.Pages
{
    public class CreateProjectModal : BasePage
    {
        private string END_POINT = "settings/projects";

        //Locators
        private readonly By NameInputBy = By.Name("name");
        private readonly By DescriptionInputBy = By.Name("description");
        private readonly By FeaturetButtonBy = By.CssSelector(".modal-card .button.is-primary");
        private readonly By CancelButtonBy = By.CssSelector(".columns .dropdown-trigger"); //Artificial bug: true locator By.CssSelector(".modal-card. button.is-white")
        private readonly By CloseButtonBy = By.CssSelector(".modal-card. modal-close.is-large");

        public CreateProjectModal(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public CreateProjectModal(IWebDriver driver) : base(driver, false) { }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(CancelButtonBy) != null;
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public Input NameInput()
        {
            return new Input(Driver, NameInputBy);
        }

        public Input DescriptionInput()
        {
            return new Input(Driver, DescriptionInputBy);
        }

        public Button FeaturetButton()
        {
            return new Button(Driver, FeaturetButtonBy);
        }

        public Button CancelButton()
        {
            return new Button(Driver, CancelButtonBy);
        }

        public Button CloseButton()
        {
            return new Button(Driver, CloseButtonBy);
        }

        public void FillCreateProjectForm(Project project)
        {
            NameInput().SendKeys(project.Name);
            DescriptionInput().SendKeys(project.Description);
        }
    }
}
