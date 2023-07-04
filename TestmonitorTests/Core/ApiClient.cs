using NLog;
using RestSharp.Authenticators;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestmonitorTests.Utilities.Configuration;
using Newtonsoft.Json.Linq;
using RestSharp.Authenticators.OAuth2;

namespace TestmonitorTests.Core
{
    public class ApiClient
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly RestClient _restClient;

        public ApiClient()
        {
            var options = new RestClientOptions(Configurator.AppSettings.URL)
            {          
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(Configurator.Bearer, "Bearer"),
                ThrowOnAnyError = false,
                MaxTimeout = 10000
            };

            _restClient = new RestClient(options);
        }

        public RestResponse Execute(RestRequest request)
        {
            _logger.Info("Request: " + request.Resource);
            var response = _restClient.Execute(request);

            _logger.Info("Response Status: " + response.ResponseStatus);
            _logger.Info("Response Body: " + response.Content);

            return response;
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            _logger.Info("Request: " + request.Resource);
            var response = _restClient.Execute<T>(request);

            _logger.Info("Response Status: " + response.ResponseStatus);
            _logger.Info("Response Body: " + response.Content);

            return response.Data;
        }

        public async Task<RestResponse> ExecuteAsync(RestRequest request)
        {
            _logger.Info("Request: " + request.Resource);
            var response = await _restClient.ExecuteAsync(request);

            _logger.Info("Response Status: " + response.ResponseStatus);
            _logger.Info("Response Body: " + response.Content);

            return response;
        }

        public async Task<T> ExecuteAsync<T>(RestRequest request)
        {
            _logger.Info("Request: " + request.Resource);
            var response = await _restClient.ExecuteAsync<T>(request);

            _logger.Info("Response Status: " + response.ResponseStatus);
            _logger.Info("Response Body: " + response.Content);

            return response.Data;
        }
    }
}
