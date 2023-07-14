using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestmonitorTests.Core;
using TestmonitorTests.Models;

namespace TestmonitorTests.Services
{
    public class ProjectService : BaseService
    {
        public static readonly string GET_PROJECT = "api/v1/projects/{project_id}";
        public static readonly string POST_PROJECT = "api/v1/projects";

        public ProjectService(ApiClient apiClient) : base(apiClient)
        {

        }

        public RestResponse GetProject(string projectId)
        {
            var request = new RestRequest(GET_PROJECT)
                .AddUrlSegment("project_id", projectId);

            return _apiClient.Execute(request);
        }

        public Project GetAsProject(string projectId)
        {
            var request = new RestRequest(GET_PROJECT)
                .AddUrlSegment("project_id", projectId);

            return _apiClient.Execute<Project>(request);
        }

        public async Task<RestResponse> GetProjectAsync(string projectId)
        {
            var request = new RestRequest(GET_PROJECT)
                .AddUrlSegment("project_id", projectId);

            return await _apiClient.ExecuteAsync(request);
        }

        public async Task<Project> GetAsProjectAsync(string projectId)
        {
            var request = new RestRequest(GET_PROJECT)
                .AddUrlSegment("project_id", projectId);

            return await _apiClient.ExecuteAsync<Project>(request);
        }

        public async Task<Project> PostProjectAsProjectAsync(ProjectData project)
        {
            var request = new RestRequest(POST_PROJECT, Method.Post)
                .AddHeader("Content-Type", "application/json")
                .AddBody(project);

            return await _apiClient.ExecuteAsync<Project>(request);
        }

        public async Task<RestResponse> PostProjectAsync(ProjectData project)
        {
            var request = new RestRequest(POST_PROJECT, Method.Post)
                .AddHeader("Content-Type", "application/json")
                .AddBody(project);

            return await _apiClient.ExecuteAsync(request);
        }

    }
}
