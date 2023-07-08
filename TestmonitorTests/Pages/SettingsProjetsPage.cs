using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestmonitorTests.Utilities.Configuration;
using TestmonitorTests.Wrappers;

namespace TestmonitorTests.Pages
{
    public class SettingsProjetsPage : BasePage
    {
        private static string END_POINT = "settings/projects";

        //Locators
        private readonly By CreateProjectButtonBy = By.CssSelector("button.is-primary");
        private readonly By ProjectsTabBy = By.Id("active-content");
        private readonly By ProjectCardBy = By.CssSelector($"a[href^='{Configurator.AppSettings.URL + END_POINT}']");

        public SettingsProjetsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public SettingsProjetsPage(IWebDriver driver) : base(driver, false) { }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(ProjectCardBy) != null;
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public Button CreateProjectButton()
        {
            return new Button(Driver, CreateProjectButtonBy);
        }

        public UIElement ProjectCards()
        {
            return new UIElement(Driver, ProjectsTabBy);
        }

        public IWebElement FindLastProject()
        {
            //WaitService.ExistsElement(ProjectCardBy);
            return ProjectCards().FindElements(ProjectCardBy).Last();
        }
    }
}