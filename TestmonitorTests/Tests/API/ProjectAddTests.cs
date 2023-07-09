using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestmonitorTests.Models;

namespace TestmonitorTests.Tetsts.API
{
    public class ProjectAddTests : BaseApiTest
    {
        [Test, Order(1)]
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
            var actualProject = _projectService.PostProjectAsProjectAsync(testProject);

            //Assertion
            Assert.Multiple(() =>
            {
                Assert.AreEqual(actualProject.Result.ProjectData.Name, testProject.Name);
                Assert.AreEqual(actualProject.Result.ProjectData.Description, testProject.Description);
                Assert.AreEqual(actualProject.Result.ProjectData.SymbolId, testProject.SymbolId);
            });
        }

        [Test, Order(2)]
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
                Assert.AreEqual(actualProject.Result.StatusCode.ToString(), "UnprocessableEntity");
                Assert.AreEqual(actualProject.Result.Content.ToString(), "{\"message\":\"The name field is required.\",\"errors\":{\"name\":[\"The name field is required.\"]}}");
            });
        }
    }
}
