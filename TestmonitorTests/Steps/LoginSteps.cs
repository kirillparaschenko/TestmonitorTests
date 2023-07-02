using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestmonitorTests.Models;
using TestmonitorTests.Pages;

namespace TestmonitorTests.Steps
{
    public class LoginSteps : BaseStep
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public LoginSteps(IWebDriver driver) : base(driver)
        {
        }

        public LoginPage NavigateToLoginPage()
        {
            return new LoginPage(Driver, true);
        }

        public ProjectsPage SuccessfulLogin(string username, string psw)
        {
            Login(username, psw);
            return ProjectsPage;
        }

        public ProjectsPage SuccessfulLogin(User user)
        {
            return SuccessfulLogin(user.Username, user.Password);
            _logger.Info("Success login");
        }

        public LoginPage IncorrectLogin(User user)
        {
            Login(user.Username, user.Password);
            return LoginPage;
            _logger.Info("Incorrect login");
        }

        private void Login(string username, string psw)
        {
            LoginPage.EmailInput().SendKeys(username);
            LoginPage.PswInput().SendKeys(psw);
            LoginPage.LoginInButton().Click();
        }
    }
}
