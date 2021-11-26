using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Billbee.Net.Extensions;
using Flurl;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Billbee.Net
{

    public class BillbeeClient : IBillbeeClient
    {
        protected IConfiguration config;
        //protected ILogger<T> logger;
        protected internal readonly string baseUrl;
        protected internal readonly string username;
        protected internal readonly string password;
        protected internal readonly string apiKey;

        public BillbeeClient(ILogger<BillbeeClient> logger)
        {
            this.config = ServiceRegistration.Configuration;


            //this.logger = loggerFactory.CreateLogger<T>();
            baseUrl = this.config["BillbeeUrl"];
            username = this.config["Username"];
            password = this.config["Password"];
            apiKey = this.config["ApiKey"];

            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new Exception("Base Url not configured. Please add BillbeeUrl to configuration");
            }

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new Exception("ApiKey not configured. Please add ApiKey to configuration");
            }

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Username and or Password are not configured. Please add Username and Password to configuration file");
            }
        }

        public async Task<T> GetAsync<T>(string endPoint, Dictionary<string, string> param = null)
        {
            if (param == null)
                param = new Dictionary<string, string>();

            var result = await baseUrl
                    .AppendPathSegments(endPoint)
                    .SetQueryParams(param)
                    .Get<T>(apiKey, username, password);

            return result;
        }

        public async Task<List<T>> GetAllAsync<T>(string endPoint, Dictionary<string, string> param = null)
        {
            if (param == null)
                param = new Dictionary<string, string>();

            var result = await baseUrl
                    .AppendPathSegments(endPoint)
                    .SetQueryParams(param)
                    .GetAll<T>(apiKey, username, password);

            return result;
        }

        public async Task<T> AddAsync<T>(string endPoint, T t, Dictionary<string, string> param)
        {
            var result = await baseUrl
                    .AppendPathSegments(endPoint)
                    .SetQueryParams(param)
                    .Post<T>(apiKey, username, password, t);
            return result;
        }

        public async Task<T> UpdateAsync<T>(string endPoint, T t, Dictionary<string, string> param = null)
        {
            if (param == null)
                param = new Dictionary<string, string>();

            var result = await baseUrl
                    .AppendPathSegments(endPoint)
                    .SetQueryParams(param)
                    .Put<T>(apiKey, username, password, t);
            return result;
        }

        public async Task<T> PatchAsync<T>(string endPoint, Dictionary<string, object> param)
        {
            var result = await baseUrl
                    .AppendPathSegments(endPoint)
                    .Patch<T>(apiKey, username, password, param);
            return result;
        }

        public async Task<T> DeleteAsync<T>(string endPoint)
        {
            var result = await baseUrl
                    .AppendPathSegments(endPoint)
                    .Delete<T>(apiKey, username, password);
            return result;
        }

        public async Task<T> DeleteAsync<T>(string endPoint, T t)
        {
            var result = await baseUrl
                    .AppendPathSegments(endPoint)
                    .Post<T>(apiKey, username, password, t);
            return result;
        }

    }
}

