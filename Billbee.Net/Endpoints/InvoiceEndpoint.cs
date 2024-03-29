﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Billbee.Net.Enums;
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
            EndPoint = "orders";
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
                queryParams.Add("minOrderDate", minInvoiceDate.Value.ToString("yyyy-MM-dd HH:mm"));

            if (maxInvoiceDate != null)
                queryParams.Add("maxOrderDate", maxInvoiceDate.Value.ToString("yyyy-MM-dd HH:mm"));

            if (minPayDate != null) queryParams.Add("modifiedAtMin", minPayDate.Value.ToString("yyyy-MM-dd HH:mm"));

            if (maxPayDate != null) queryParams.Add("modifiedAtMax", maxPayDate.Value.ToString("yyyy-MM-dd HH:mm"));

            if (shopId != null)
            {
                var i = 0;
                foreach (var id in shopId) queryParams.Add($"shopId[{i++}]", id.ToString());
            }

            if (tag != null)
            {
                var i = 0;
                foreach (var id in tag) queryParams.Add($"tag[{i++}]", id);
            }

            if (orderStateId != null)
            {
                var i = 0;
                foreach (var id in orderStateId) queryParams.Add($"orderStateId[{i++}]", ((int) id).ToString());
            }

            var result = await billbeeClient.GetAllAsync<Invoice>(EndPoint + "/invoices", queryParams);
            return result;
        }


        public async Task<Invoice> AddInvoiceAsync(long orderId, bool includePdf = false, long? templateId = null,
            long? sendToCloudId = null)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("includeInvoicePdf", includePdf.ToString());

            if (sendToCloudId.HasValue)
                queryParams.Add("sendToCloudId", sendToCloudId.ToString());

            if (templateId.HasValue)
                queryParams.Add("templateId", templateId.ToString());

            var result = await billbeeClient.AddAsync(EndPoint + "/CreateInvoice/" + orderId, new Invoice(),
                queryParams);
            return result;
        }
    }
}