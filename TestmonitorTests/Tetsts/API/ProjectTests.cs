using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestmonitorTests.Tetsts.API
{
    public class ProjectTests : BaseApiTest
    {
        [Test]
        public void GetProjectTest()
        {
            var actualProject = _projectService.GetProjectAsync("4");

        }
    }
}
