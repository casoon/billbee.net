using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
using Billbee.Net.Models;
using Billbee.Net.Enums;
using Newtonsoft.Json.Linq;

namespace Billbee.Net.Endpoints
{
    public interface IOrderEndpoint : IExtendedEndpoint<Order>
    {
        Task<String> GetLayoutsAsync();
        Task<String> GetPatchableFieldsAsync();
        Task<String> PatchOrderAsync(long id, Dictionary<string, object> fields);
        Task<Order> GetOrderByExternalReferenceAsync(string id);
        Task<List<Order>> GetAllAsync(
            int page = 0,
            int pageSize = 50,
            DateTime? minOrderDate = null,
            DateTime? maxOrderDate = null,
            List<long> shopId = null,
            List<OrderStateEnum> orderStateId = null,
            List<string> tag = null,
            long? minimumBillBeeOrderId = null,
            DateTime? modifiedAtMin = null,
            DateTime? modifiedAtMax = null,
            bool excludeTags = false
        );
        Task<List<Order>> GetInvoicesAsync(
            int page = 0,
            int pageSize = 50,
            DateTime? minInvoiceDate = null,
            DateTime? maxInvoiceDate = null,
            List<long> shopId = null,
            List<int> orderStateId = null,
            List<string> tag = null,
            DateTime? minPayDate = null,
            DateTime? maxPayDate = null,
            bool includePositions = false,
            bool excludeTags = false
        );
        Task<Order> AddAsync(Order order, long shopId);
        Task<dynamic> AddTagsAsync(long orderId, List<string> tags);
        Task<dynamic> UpdateTagsAsync(long orderId, List<string> tags);
        Task<OrderShipment> AddShipmentAsync(OrderShipment shipment);
        Task<DeliveryNote> AddDeliveryNoteAsync(long orderId, bool includePdf = false, long? sendToCloudId = null);
        Task<Invoice> AddInvoiceAsync(long orderId, bool includePdf = false, long? templateId = null, long? sendToCloudId = null);
        Task<dynamic> UpdateOrderStateAsync(long orderId, OrderStateEnum state);
        Task<dynamic> SendMailAsync(long orderId, SendMessage message);
        Task<dynamic> CreateEventAsync(long orderId, string eventName, uint delayInMinutes = 0);
    }

    public class OrderEndpoint : ExtendedEndpoint<Order>, IOrderEndpoint
    {
        public OrderEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            this.EndPoint = "orders";
        }

        public async Task<String> GetLayoutsAsync()
        {
            try
            {
                var result = await billbeeClient.GetAsync<String>(this.EndPoint + "/" + "layouts");
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

        public async Task<String> GetPatchableFieldsAsync()
        {
            try
            {
                var result = await billbeeClient.GetAsync<String>(this.EndPoint + "/patchablefields");
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


        public async Task<String> PatchOrderAsync(long id, Dictionary<string, object> fields)
        {
            try
            {
                var result = await billbeeClient.PatchAsync<String>(this.EndPoint + "/" + id.ToString(), fields);
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

        public async Task<Order> GetOrderByExternalReferenceAsync(string id)
        {
            try
            {
                var result = await billbeeClient.GetAsync<Order>(this.EndPoint + "/findbyextref/" + id);
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

        public async Task<List<Order>> GetAllAsync(
            int page = 0,
            int pageSize = 50,
            DateTime? minOrderDate = null,
            DateTime? maxOrderDate = null,
            List<long> shopId = null,
            List<OrderStateEnum> orderStateId = null,
            List<string> tag = null,
            long? minimumBillBeeOrderId = null,
            DateTime? modifiedAtMin = null,
            DateTime? modifiedAtMax = null,
            bool excludeTags = false
            )
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("page", page.ToString());
            queryParams.Add("pageSize", pageSize.ToString());
            queryParams.Add("excludeTags", excludeTags.ToString());

            if (minOrderDate != null)
            {
                queryParams.Add("minOrderDate", minOrderDate.Value.ToString("yyyy-MM-dd HH:mm"));
            }

            if (maxOrderDate != null)
            {
                queryParams.Add("maxOrderDate", maxOrderDate.Value.ToString("yyyy-MM-dd HH:mm"));
            }

            if (modifiedAtMin != null)
            {
                queryParams.Add("modifiedAtMin", modifiedAtMax.Value.ToString("yyyy-MM-dd HH:mm"));
            }

            if (modifiedAtMax != null)
            {
                queryParams.Add("modifiedAtMax", modifiedAtMax.Value.ToString("yyyy-MM-dd HH:mm"));
            }

            if (minimumBillBeeOrderId != null)
            {
                queryParams.Add("minimumBillBeeOrderId", minimumBillBeeOrderId.ToString());
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
                var result = await billbeeClient.GetAllAsync<Order>(this.EndPoint, queryParams);
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

        public async Task<List<Order>> GetInvoicesAsync(
             int page = 0,
             int pageSize = 50,
             DateTime? minInvoiceDate = null,
             DateTime? maxInvoiceDate = null,
             List<long> shopId = null,
             List<int> orderStateId = null,
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
            queryParams.Add("includePositions", includePositions.ToString());
            queryParams.Add("excludeTags", excludeTags.ToString());

            if (minInvoiceDate != null)
            {
                queryParams.Add("minInvoiceDate", minInvoiceDate.Value.ToString("yyyy-MM-dd HH:mm"));
            }

            if (maxInvoiceDate != null)
            {
                queryParams.Add("maxInvoiceDate", maxInvoiceDate.Value.ToString("yyyy-MM-dd HH:mm"));
            }

            if (minPayDate != null)
            {
                queryParams.Add("minPayDate", minPayDate.Value.ToString("yyyy-MM-dd HH:mm"));
            }

            if (maxPayDate != null)
            {
                queryParams.Add("maxPayDate", maxPayDate.Value.ToString("yyyy-MM-dd HH:mm"));
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
                    queryParams.Add($"orderStateId[{i++}]", id.ToString());
                }
            }


            try
            {
                var result = await billbeeClient.GetAllAsync<Order>(this.EndPoint + "/invoices", queryParams);
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


        public async Task<Order> AddAsync(Order order, long shopId)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("shopId", shopId.ToString());

            try
            {
                var result = await billbeeClient.AddAsync<Order>(this.EndPoint, order, queryParams);
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


        public async Task<dynamic> AddTagsAsync(long orderId, List<string> tags)
        {
            try
            {
                var result = await billbeeClient.AddAsync<dynamic>(this.EndPoint + "/" + orderId + "/tags", new { Tags = tags });
                return result;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<dynamic> UpdateTagsAsync(long orderId, List<string> tags)
        {
            try
            {
                var result = await billbeeClient.UpdateAsync<dynamic>(this.EndPoint + "/" + orderId + "/tags", new { Tags = tags });
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

        public async Task<OrderShipment> AddShipmentAsync(OrderShipment shipment)
        {
            try
            {
                var result = await billbeeClient.AddAsync<OrderShipment>(this.EndPoint + "/" + shipment.OrderId + "/shipment", shipment);
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

        public async Task<DeliveryNote> AddDeliveryNoteAsync(long orderId, bool includePdf = false, long? sendToCloudId = null)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("includePdf", includePdf.ToString());

            try
            {
                var result = await billbeeClient.AddAsync<DeliveryNote>(this.EndPoint + "/CreateDeliveryNote/" + orderId + "/shipment", new DeliveryNote(), queryParams);
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

        public async Task<Invoice> AddInvoiceAsync(long orderId, bool includePdf = false, long? templateId = null, long? sendToCloudId = null)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("includeInvoicePdf", includePdf.ToString());

            if (sendToCloudId.HasValue)
                queryParams.Add("sendToCloudId", sendToCloudId.ToString());

            if (templateId.HasValue)
                queryParams.Add("templateId", templateId.ToString());

            try
            {
                var result = await billbeeClient.AddAsync<Invoice>(this.EndPoint + "/CreateInvoice/" + orderId, new Invoice(), queryParams);
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


        public async Task<dynamic> UpdateOrderStateAsync(long orderId, OrderStateEnum state)
        {
            try
            {
                var result = await billbeeClient.UpdateAsync<dynamic>(this.EndPoint + "/" + orderId + "/orderstate", new { NewStateId = (int)state });
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


        public async Task<dynamic> SendMailAsync(long orderId, SendMessage message)
        {
            try
            {
                var result = await billbeeClient.AddAsync<dynamic>(this.EndPoint + "/" + orderId + "/send-message", message);
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

        public async Task<dynamic> CreateEventAsync(long orderId, string eventName, uint delayInMinutes = 0)
        {
            var model = new TriggerEventContainer
            {
                DelayInMinutes = delayInMinutes,
                Name = eventName
            };

            try
            {
                var result = await billbeeClient.AddAsync<dynamic>(this.EndPoint + "/" + orderId + "/trigger-event", model);
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

