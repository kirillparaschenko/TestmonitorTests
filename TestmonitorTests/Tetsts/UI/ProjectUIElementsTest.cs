﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestmonitorTests.Models;

namespace TestmonitorTests.Tetsts.UI
{
    public class ProjectUIElementsTest : ProjectTests
    {
        [Test]
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

        [Test]
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
    }
}
