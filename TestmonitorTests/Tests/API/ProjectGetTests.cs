using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestmonitorTests.Models;

namespace TestmonitorTests.Tetsts.API
{
    public class ProjectGetTests : BaseApiTest
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
        public void GetNonExistentProjectTest()
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
        public void GetNotValidProjectTest()
        {
            //Action
            var actualProject = _projectService.GetProjectAsync("a1");

            //Assertion
            Assert.Multiple(() =>
            {
                Assert.AreEqual(actualProject.Result.StatusCode.ToString(), "NotFound");
                Assert.AreEqual(actualProject.Result.Content.ToString(), "{\n    \"message\": \"No query results for model [App\\\\Models\\\\Project] \"\n}");
            });
        }
    }
}
