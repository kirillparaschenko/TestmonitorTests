﻿using Allure.Commons;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            ProjectSteps.ArchieveLastProject();

            //Assertion
            Assert.AreNotEqual(project.Name, SettingsProjetsPage.LastProjectCard().Text);
        }

        [Test, Category("Positive"), Order(3)]
        public void VerifyPopUpMessageProjectCreatedTest()
        {
            //TestData
            project = new ProjectBuilder()
                .SetProjectName("Regression Test PopUp")
                .SetProjectDescription("Regression test description PopUp")
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

        [TestCase("A", "A")]
        [TestCase("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean m",
            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean m")]
        [TestCase("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean ma",
            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean m")]
        public void CreationProjectTest(string projectName, string expectedProjectName)
        {
            //TestData
            project = new ProjectBuilder()
                .SetProjectName(projectName)
                .SetProjectDescription("Boundary values tests")
                .Build();

            //Action
            ProjectSteps.CreateProject(project);

            //Assertion
            Assert.AreEqual(expectedProjectName, SettingsProjetsPage.LastProjectCard().Text);
        }

    }
}
