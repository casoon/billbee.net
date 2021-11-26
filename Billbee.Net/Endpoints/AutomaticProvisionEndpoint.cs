using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
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
            this.EndPoint = "automaticprovision";
        }

        public async Task<Account> CreateAccountAsync(Account account)
        {
            try
            {
                var result = await billbeeClient.AddAsync<Account>(this.EndPoint + "/createaccount/", account);
                return result;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TermsResult> TermsInfoAsync()
        {
            try
            {
                var result = await billbeeClient.GetAsync<TermsResult>(this.EndPoint + "/termsinfo");
                return result;
            }
            catch (NotFoundException)
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

