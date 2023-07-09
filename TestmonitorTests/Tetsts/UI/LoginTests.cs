using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestmonitorTests.Models;
using TestmonitorTests.Pages;
using TestmonitorTests.Utilities.Configuration;

namespace TestmonitorTests.Tetsts.UI
{
    public class LoginTests : BaseUITest
    {
        public LoginPage LoginPage => new LoginPage(Driver);

        [Test, Category("Negative")]
        public void LoginWithInvalidPasswordTest()
        {
            User user = new UserBuilder()
                .SetUsername(Configurator.UserByUsername("k.paraschenko+1@gmail.com").Username)
                .SetPassword("Qweerty123")
                .Build();

            LoginSteps.NavigateToLoginPage();
            LoginSteps.IncorrectLogin(user);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(LoginPage.IncorrectLoginMessage().Text, "These credentials do not match our records.");
                Assert.IsTrue(LoginPage.LoginInButton().Displayed);
            });
        }
    }
}
