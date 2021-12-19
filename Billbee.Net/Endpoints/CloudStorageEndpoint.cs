using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints
{

    public interface ICloudStorageEndpoint: IBaseEndpoint
    {
        Task<List<CloudStorage>> GetAllAsync();
    }


    public class CloudStorageEndpoint : BaseEndpoint, ICloudStorageEndpoint
    {

        public CloudStorageEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            this.EndPoint = "cloudstorages";
        }

        public async Task<List<CloudStorage>> GetAllAsync()
        {
            try
            {
                var result = await billbeeClient.GetAllAsync<CloudStorage>(this.EndPoint);
                return result;
            }
            catch (ApiException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}

