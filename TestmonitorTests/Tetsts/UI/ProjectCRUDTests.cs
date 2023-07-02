using Allure.Commons;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestmonitorTests.Core;
using TestmonitorTests.Models;
using TestmonitorTests.Steps;
using TestmonitorTests.Utilities.Configuration;

namespace TestmonitorTests.Tetsts.UI
{
    public class ProjectCRUDTests : BaseUITest
    {
        [SetUp]
        public void CreateUser()
        {
            User user = new UserBuilder()
                .SetUsername(Configurator.UserByUsername("k.paraschenko@gmail.com").Username)
                .SetPassword(Configurator.UserByUsername("k.paraschenko@gmail.com").Password)
                .Build();

            LoginSteps.NavigateToLoginPage();
            LoginSteps.SuccessfulLogin(user);
        }

        [Test]
        public void CreationProjectTest()
        {
            Project project = new ProjectBuilder()
                .SetProjectName("Smoke Test")
                .SetProjectDescription("Smoke test description")
                .Build();

            CreateProjectSteps.CreateProject(project);
        }
    }
}
