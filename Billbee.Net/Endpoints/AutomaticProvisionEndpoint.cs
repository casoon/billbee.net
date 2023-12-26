using System.Threading.Tasks;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints
{
    public interface IAutomaticProvisionEndpoint : IBaseEndpoint
    {
        Task<Account> CreateAccountAsync(Account account);
        Task<TermsResult> TermsInfoAsync();
    }


    public class AutomaticProvisionEndpoint : BaseEndpoint, IAutomaticProvisionEndpoint
    {
        public AutomaticProvisionEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            EndPoint = "automaticprovision";
        }

        public async Task<Account> CreateAccountAsync(Account account)
        {
            var result = await billbeeClient.AddAsync(EndPoint + "/createaccount/", account);
            return result;
        }

        public async Task<TermsResult> TermsInfoAsync()
        {
            var result = await billbeeClient.GetAsync<TermsResult>(EndPoint + "/termsinfo");
            return result;
        }
    }
}