using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Billbee.Net.Enums;
using Billbee.Net.Models;

namespace Billbee.Net.Endpoints
{
    public interface IProductEndpoint : IExtendedEndpoint<Product>
    {
    }

    public class ProductEndpoint : ExtendedEndpoint<Product>, IProductEndpoint
    {
        public ProductEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            EndPoint = "products";
        }
        
        public async Task<List<Stock>> GetStocksAsync(long orderId, List<UpdateStock> updateStockList)
        {
            var result = await billbeeClient.GetAllAsync<Stock>(EndPoint + "/stocks");
            return result;
        }
        
        public async Task<dynamic> UpdateStockMultipleAsync(long orderId, List<UpdateStock> updateStockList)
        {
            var result = await billbeeClient.UpdateAsync<dynamic>(EndPoint + "/updatestockmultiple", updateStockList);
            return result;
        }

        public async Task<dynamic> UpdateStockAsync(long orderId, UpdateStock updateStockModel)
        {
            var result = await billbeeClient.UpdateAsync<dynamic>(EndPoint + "/updatestock", updateStockModel);
            return result;
        }

        public async Task<GetReservedAmountResult> GetReservedAmountAsync(string idOrSku, string lookupBy = "id",
            long? stockId = null)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("id", idOrSku);
            queryParams.Add("lookupBy", lookupBy);

            if (stockId != null) queryParams.Add("stockId", stockId.Value.ToString());

            var result =
                await billbeeClient.GetAsync<GetReservedAmountResult>(EndPoint + "/reservedamount", queryParams);
            return result;
        }


        public async Task<object> UpdateStockCodeAsync(UpdateStockCode updateStockCodeModel)
        {
            var result = await billbeeClient.UpdateAsync<object>(EndPoint + "/updatestockcode", updateStockCodeModel);
            return result;
        }


        public async Task<List<Product>> GetAllAsync(int page = 0, int pageSize = 50, DateTime? minCreatedAt = null)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("page", page.ToString());
            queryParams.Add("pageSize", pageSize.ToString());

            if (minCreatedAt != null) queryParams.Add("minCreatedAt", minCreatedAt.Value.ToString("yyyy-MM-dd"));

            var result = await billbeeClient.GetAllAsync<Product>(EndPoint, queryParams);
            return result;
        }


        public async Task<Product> GetAsync(long id, ProductIdType type = ProductIdType.id)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("lookupBy", type.ToString());

            var result = await billbeeClient.GetAsync<Product>(EndPoint + "/" + id, queryParams);
            return result;
        }


        public async Task<List<ArticleCustomFieldDefinition>> GetCustomFieldsAsync(int page = 0, int pageSize = 50)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("page", page.ToString());
            queryParams.Add("pageSize", pageSize.ToString());

            var result =
                await billbeeClient.GetAllAsync<ArticleCustomFieldDefinition>(EndPoint + "/custom-fields", queryParams);
            return result;
        }

        public async Task<ArticleCustomFieldDefinition> GetCustomFieldAsync(long id)
        {
            var result = await billbeeClient.GetAsync<ArticleCustomFieldDefinition>(EndPoint + "/custom-fields/" + id);
            return result;
        }

        public async Task<List<string>> GetPatchableProductFieldsAsync(long id)
        {
            var result = await billbeeClient.GetAllAsync<string>(EndPoint + "/PatchableFields");
            return result;
        }


        public async Task<Product> PatchAsync(long id, Dictionary<string, object> fields)
        {
            var result = await billbeeClient.PatchAsync<Product>(EndPoint + "/" + id, fields);
            return result;
        }


        public async Task<List<ArticleImage>> GetProductImagesAsync(long id)
        {
            var result = await billbeeClient.GetAllAsync<ArticleImage>(EndPoint + "/" + id + "/images");
            return result;
        }

        public async Task<ArticleImage> GetProductImageAsync(long productId, long imageId)
        {
            var result = await billbeeClient.GetAsync<ArticleImage>(EndPoint + "/" + productId + "/images/" + imageId);
            return result;
        }

        public async Task<ArticleImage> GetProductImageAsync(long imageId)
        {
            var result = await billbeeClient.GetAsync<ArticleImage>(EndPoint + "/images/" + imageId);
            return result;
        }

        public async Task<ArticleImage> AddProductImageAsync(ArticleImage image)
        {
            if (image.Id != 0) throw new Exception("To add a new image, only 0 as Id is allowed.");

            var result =
                await billbeeClient.UpdateAsync(EndPoint + "/" + image.ArticleId + "/images/" + image.Id, image);
            return result;
        }

        public async Task<ArticleImage> UpdateProductImageAsync(ArticleImage image)
        {
            if (image.Id != 0) throw new Exception("To update a new image, only 0 as Id is allowed.");

            var result =
                await billbeeClient.UpdateAsync(EndPoint + "/" + image.ArticleId + "/images/" + image.Id, image);
            return result;
        }


        public async Task<List<ArticleImage>> AddMultipleProductImageAsync(long productId, List<ArticleImage> images,
            bool replace = false)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("replace", replace.ToString());

            var result = await billbeeClient.UpdateAsync(EndPoint + "/" + productId + "/images", images, queryParams);
            return result;
        }


        public async Task DeleteProductImageAsync(long productId, long imageId)
        {
            await billbeeClient.DeleteAsync<dynamic>(EndPoint + "/" + productId + "/images/" + imageId);
        }


        public async Task DeleteProductImageAsync(long imageId)
        {
            await billbeeClient.DeleteAsync<dynamic>(EndPoint + "/images/" + imageId);
        }


        public async Task DeleteMultipleProductImageAsync(List<long> imageIds)
        {
            await billbeeClient.DeleteAsync<dynamic>(EndPoint + "/images/delete", imageIds);
        }
    }
}