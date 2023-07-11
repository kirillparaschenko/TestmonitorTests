using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestmonitorTests.Core;
using TestmonitorTests.Services;

namespace TestmonitorTests.Tetsts.API
{
    [Parallelizable(ParallelScope.Fixtures)]
    public class BaseApiTest
    {
        protected ApiClient _apiClient;
        protected ProjectService _projectService;

        [OneTimeSetUp]
        public void InitApiClient()
        {
            _apiClient = new ApiClient();
            _projectService = new ProjectService(_apiClient);
        }
    }
}
