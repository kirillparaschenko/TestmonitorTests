using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestmonitorTests.Wrappers;

namespace TestmonitorTests.Pages
{
    public class SettingsProjetsPage : BasePage
    {
        private string END_POINT = "settings/projects";

        //Locators
        private readonly By CreateProjectButtonBy = By.CssSelector("button.is-primary");
        private readonly By ProjectCardBy = By.ClassName("card-content");

        public SettingsProjetsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public SettingsProjetsPage(IWebDriver driver) : base(driver, false) { }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(CreateProjectButtonBy) != null;
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public Button CreateProjectButton()
        {
            return new Button(Driver, CreateProjectButtonBy);
        }

        public UIElement ProjectCard()
        {
            return new UIElement(Driver, ProjectCardBy);
        }
    }
}
