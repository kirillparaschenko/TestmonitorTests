using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestmonitorTests.Wrappers;

namespace TestmonitorTests.Pages
{
    public class LoginPage : BasePage
    {
        private static string END_POINT = "";

        // Locators
        private static readonly By EmailInputBy = By.Id("email");
        private static readonly By PswInputBy = By.Id("password");
        private static readonly By RememberMeCheckboxBy = By.Name("remember");
        private static readonly By LoginInButtonBy = By.ClassName("button is-primary is-fullwidth");

        public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public LoginPage(IWebDriver driver) : base(driver, false)
        {
        }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(LoginInButtonBy) != null;
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        //Methods
        public Input EmailInput()
        {
            return new Input(Driver, EmailInputBy);
        }

        public Input PswInput()
        {
            return new Input(Driver, PswInputBy);
        }

        public UIElement RememberMeCheckbox()
        {
            return new UIElement(Driver, RememberMeCheckboxBy);
        }

        public Button LoginInButton()
        {
            return new Button(Driver, LoginInButtonBy);
        }
    }
}
