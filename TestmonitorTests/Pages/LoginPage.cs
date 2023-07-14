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
        private string END_POINT = "";

        // Locators
        private readonly By EmailInputBy = By.Name("email");
        private readonly By PswInputBy = By.Name("password");
        private readonly By RememberMeCheckboxBy = By.Name("remember");
        private readonly By LoginInButtonBy = By.ClassName("button");
        private readonly By IncorrectLoginMessageBy = By.CssSelector("div[class~='message-body']");

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

        public UIElement IncorrectLoginMessage()
        {
            return new UIElement (Driver, IncorrectLoginMessageBy);
        }
    }
}
