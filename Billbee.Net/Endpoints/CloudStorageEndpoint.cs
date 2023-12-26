using System.Collections.Generic;
using System.Threading.Tasks;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints
{
    public interface ICloudStorageEndpoint : IBaseEndpoint
    {
        Task<List<CloudStorage>> GetAllAsync();
    }


    public class CloudStorageEndpoint : BaseEndpoint, ICloudStorageEndpoint
    {
        public CloudStorageEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            EndPoint = "cloudstorages";
        }

        public async Task<List<CloudStorage>> GetAllAsync()
        {
            var result = await billbeeClient.GetAllAsync<CloudStorage>(EndPoint);
            return result;
        }
    }
}