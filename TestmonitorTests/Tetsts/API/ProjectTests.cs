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
            var actualProject = _projectService.GetProjectAsync("4");

            //Assertion
            Assert.AreEqual(actualProject.Result.Name, "123");
        }

        [Test]
        public void GetNotValidProjectTest()
        {
            //Action
            var actualProject = _projectService.GetProjectAsync("-1");

        }

        [Test]
        public void AddProjectTest()
        {
            //TestData
            var testProject = new ProjectData()
            {
                Name = "ApiAutoTest",
                Description = "ApiAutoTest Description",
            };

            //Action
            var actualProject = _projectService.PostProjectAsync(testProject);
        }

        [Test]
        public void AddProjectWithoutName()
        {
            //TestData
            var testProject = new ProjectData()
            {
                Description = "ApiAutoTest Description",
            };

            //Action
            var actualProject = _projectService.PostProjectAsync(testProject);

            //Assert
        }
    }
}
