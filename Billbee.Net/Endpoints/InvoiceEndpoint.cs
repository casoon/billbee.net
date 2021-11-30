using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Enums;
using Billbee.Net.Exceptions;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints
{

    public interface IInvoiceEndpoint : IBaseEndpoint
    {
        Task<List<Invoice>> GetAllAsync(
            int page = 0,
            int pageSize = 50,
            DateTime? minInvoiceDate = null,
            DateTime? maxInvoiceDate = null,
            List<long> shopId = null,
            List<OrderStateEnum> orderStateId = null,
            List<string> tag = null,
            DateTime? minPayDate = null,
            DateTime? maxPayDate = null,
            bool includePositions = false,
            bool excludeTags = false
        );
    }


    public class InvoiceEndpoint : BaseEndpoint, IInvoiceEndpoint
    {
        public InvoiceEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            this.EndPoint = "orders/invoices";
        }

        public async Task<List<Invoice>> GetAllAsync(
    int page = 0,
    int pageSize = 50,
    DateTime? minInvoiceDate = null,
    DateTime? maxInvoiceDate = null,
    List<long> shopId = null,
    List<OrderStateEnum> orderStateId = null,
    List<string> tag = null,
    DateTime? minPayDate = null,
    DateTime? maxPayDate = null,
    bool includePositions = false,
    bool excludeTags = false
)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("page", page.ToString());
            queryParams.Add("pageSize", pageSize.ToString());
            queryParams.Add("excludeTags", excludeTags.ToString());

            if (minInvoiceDate != null)
            {
                queryParams.Add("minOrderDate", minInvoiceDate.Value.ToString("yyyy-MM-dd HH:mm"));
            }

            if (maxInvoiceDate != null)
            {
                queryParams.Add("maxOrderDate", maxInvoiceDate.Value.ToString("yyyy-MM-dd HH:mm"));
            }

            if (minPayDate != null)
            {
                queryParams.Add("modifiedAtMin", minPayDate.Value.ToString("yyyy-MM-dd HH:mm"));
            }

            if (maxPayDate != null)
            {
                queryParams.Add("modifiedAtMax", maxPayDate.Value.ToString("yyyy-MM-dd HH:mm"));
            }

            if (shopId != null)
            {
                int i = 0;
                foreach (var id in shopId)
                {
                    queryParams.Add($"shopId[{i++}]", id.ToString());
                }
            }

            if (tag != null)
            {
                int i = 0;
                foreach (var id in tag)
                {
                    queryParams.Add($"tag[{i++}]", id.ToString());
                }
            }

            if (orderStateId != null)
            {
                int i = 0;
                foreach (var id in orderStateId)
                {
                    queryParams.Add($"orderStateId[{i++}]", ((int)id).ToString());
                }
            }

            try
            {
                var result = await billbeeClient.GetAllAsync<Invoice>(this.EndPoint, queryParams);
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

