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
using TestmonitorTests.Pages;
using TestmonitorTests.Steps;
using TestmonitorTests.Utilities.Configuration;

namespace TestmonitorTests.Tetsts.UI
{
    public class ProjectCRUDTests : BaseUITest
    {
        public SettingsProjetsPage SettingsProjetsPage => new SettingsProjetsPage(Driver);

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
                .SetProjectName("Regression Test")
                .SetProjectDescription("Regression test description")
                .Build();

            ProjectSteps.CreateProject(project);

            Assert.AreEqual(project.Name, SettingsProjetsPage.FindLastProject().Text);
        }

        [Test]
        public void ArchivinProjectTest()
        {
            ProjectSteps.ArchieveProject();
        }
    }
}
