using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestmonitorTests.Models;

namespace TestmonitorTests.Tetsts.API
{
    public class ProjectTests : BaseApiTest
    {
        [Test]
        public void GetValidProjectTest()
        {
            //Action
            var actualProject = _projectService.GetAsProjectAsync("4");

            //Assertion
            Assert.AreEqual(actualProject.Result.ProjectData.Name, "123");
        }

        [Test]
        public void GetNotValidProjectTest()
        {
            //Action
            var actualProject = _projectService.GetProjectAsync("0");

            //Assertion
            Assert.Multiple(() =>
            {
                Assert.AreEqual(actualProject.Result.StatusCode.ToString(), "NotFound");
                Assert.AreEqual(actualProject.Result.Content.ToString(), "{\n    \"message\": \"No query results for model [App\\\\Models\\\\Project] \"\n}");
            });
        }

        [Test]
        public void AddProjectTest()
        {
            //TestData
            var testProject = new ProjectData()
            {
                Name = "ApiAutoTest",
                Description = "ApiAutoTest Description",
                SymbolId = 1
            };

            //Action
            var actualProject = _projectService.PostProjectAsync(testProject);

            //Assertion
            Assert.Multiple(() =>
            {
                Assert.AreEqual(actualProject.Result.ProjectData.Name, testProject.Name);
                Assert.AreEqual(actualProject.Result.ProjectData.Description, testProject.Description);
                Assert.AreEqual(actualProject.Result.ProjectData.SymbolId, testProject.SymbolId);
            });
        }

        [Test]
        public void AddProjectWithoutName()
        {
            //TestData
            var testProject = new ProjectData()
            {
                Description = "ApiAutoTest Description",
                SymbolId = 1
            };

            //Action
            var actualProject = _projectService.PostProjectAsync(testProject);

            //Assert
            Assert.Multiple(() =>
            {
                //Assert.AreEqual(actualProject.Result, "NotFound");
                //Assert.AreEqual(actualProject.Content.ToString(), "{\n    \"message\": \"No query results for model [App\\\\Models\\\\Project] \"\n}");
            });
        }
    }
}
