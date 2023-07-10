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

        [Test, Category("Positive"), Order(1)]
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
            Assert.AreEqual(project.Name, SettingsProjetsPage.LastProjectCard().Text);
        }

        [Test, Category("Positive"), Order(2)]
        public void ArchivingProjectTest()
        {
            //Action
            ProjectSteps.ArchieveProject();

            //Assertion
            Assert.AreNotEqual(project.Name, SettingsProjetsPage.LastProjectCard().Text);
        }

        [Test, Category("Positive")]
        public void VerifyPopUpMessageProjectCreatedTest()
        {
            //TestData
            Project project = new ProjectBuilder()
                .SetProjectName("Regression Test")
                .SetProjectDescription("Regression test description")
                .Build();

            //Action
            ProjectSteps.CreateProject(project);

            //Assertion
            Assert.Multiple(() =>
            {
                Assert.IsTrue(SettingsProjetsPage.ProjectIsCreatedPopUp().Displayed);
                Assert.AreEqual(SettingsProjetsPage.ProjectIsCreatedPopUp().Text, $"Project {project.Name} created");
            });
        }

        [Test, Category("Positive")]
        public void VerifyCreateProjectModalTest()
        {
            //Action
            ProjectSteps.OpenCreateProjectModal();

            //Assertion
            Assert.Multiple(() =>
            {
                Assert.IsTrue(SettingsProjetsPage.CreateProjectModal().Displayed);
                Assert.IsTrue(SettingsProjetsPage.CreateProjectModal().Text.Contains($"Create project"));
            });
        }

        [Test, Category("Negative"), Description("Artificial bug")]
        public void CloseProjectModalTest()
        {
            //Action
            ProjectSteps.CloseCreateProjectModal();

            //Assertion
            Assert.IsFalse(SettingsProjetsPage.CreateProjectModal().Displayed);
        }
    }
}
