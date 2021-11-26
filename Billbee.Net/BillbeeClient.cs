using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Billbee.Net.Extensions;
using Flurl;
using Microsoft.Extensions.Configuration;

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

        public BillbeeClient()//, ILoggerFactory loggerFactory)
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

        public async Task<T> Get<T>(string endPoint, Dictionary<string, string> param)
        {
            var result = await baseUrl
                    .AppendPathSegments(endPoint)
                    .SetQueryParams(param)
                    .GetSingleResponse<T>(apiKey, username, password);

            return result;
        }

        public async Task<List<T>> GetAll<T>(string endPoint, Dictionary<string, string> param)
        {
            var result = await baseUrl
                    .AppendPathSegments(endPoint)
                    .SetQueryParams(param)
                    .GetPagedResponse<T>(apiKey, username, password);

            return result;
        }

    }
}

