﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;

namespace Billbee.Net.Endpoints
{

    public abstract class BaseEndpoint<T>
    {

        protected IBillbeeClient billbeeClient;

        public BaseEndpoint(IBillbeeClient billbeeClient)
        {
            this.billbeeClient = billbeeClient;
        }

        protected string EndPoint { get; set; }

        public async Task<T> GetSingleAsync(string id)
        {

            var queryParams = new Dictionary<string, string>();
            try
            {
                var result = await billbeeClient.Request<T>(this.EndPoint + "/" + id, queryParams);
                return result;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public Task<T> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> PatchAsync(string query)
        {
            throw new NotImplementedException();
        }

        public Task<T> PostAsync(string query)
        {
            throw new NotImplementedException();
        }

        public Task<T> PutAsync(string query)
        {
            throw new NotImplementedException();
        }



    }
}

