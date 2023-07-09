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
    public class ProjectTests : BaseUITest
    {
        public SettingsProjetsPage SettingsProjetsPage => new SettingsProjetsPage(Driver);
        Project project;

        [SetUp]
        public void CreateUser()
        {
            User user = new UserBuilder()
                .SetUsername(Configurator.UserByUsername("k.paraschenko+1@gmail.com").Username)
                .SetPassword(Configurator.UserByUsername("k.paraschenko+1@gmail.com").Password)
                .Build();

            LoginSteps.NavigateToLoginPage();
            LoginSteps.SuccessfulLogin(user);
        }

        [Test, Order(1)]
        public void CreationProjectTest()
        {
            //TestData
            project = new ProjectBuilder()
                .SetProjectName("Regression Test")
                .SetProjectDescription("Regression test description")
                .Build();

            //Action
            ProjectSteps.CreateProject(project);
            
            //Assertion
            Assert.AreEqual(project.Name, SettingsProjetsPage.FindLastProject().Text);
        }

        [Test, Order(2)]
        public void ArchivingProjectTest()
        {
            //Action
            ProjectSteps.ArchieveProject();

            //Assertion
            Assert.AreNotEqual(project.Name, SettingsProjetsPage.FindLastProject().Text);
            
        }
    }
}
