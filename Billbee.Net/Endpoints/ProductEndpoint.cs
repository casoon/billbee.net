using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
using Billbee.Net.Models;
using Billbee.Net.Enums;

namespace Billbee.Net.Endpoints
{
    public interface IProductEndpoint : IExtendedEndpoint<Product>
    {

    }

    public class ProductEndpoint : ExtendedEndpoint<Product>, IProductEndpoint
    {
        public ProductEndpoint(IBillbeeClient billbeeClient) : base(billbeeClient)
        {
            this.EndPoint = "products";
        }


        public async Task<dynamic> UpdateStockMultipleAsync(long orderId, List<UpdateStock> updateStockList)
        {
            try
            {
                var result = await billbeeClient.UpdateAsync<dynamic>(this.EndPoint + "/updatestockmultiple", updateStockList);
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

        public async Task<dynamic> UpdateStockAsync(long orderId, UpdateStock updateStockModel)
        {
            try
            {
                var result = await billbeeClient.UpdateAsync<dynamic>(this.EndPoint + "/updatestock", updateStockModel);
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

        public async Task<GetReservedAmountResult> GetReservedAmountAsync(string idOrSku, string lookupBy = "id", long? stockId = null)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("id", idOrSku);
            queryParams.Add("lookupBy", lookupBy);

            if (stockId != null)
            {
                queryParams.Add("stockId", stockId.Value.ToString());
            }

            try
            {
                var result = await billbeeClient.GetAsync<GetReservedAmountResult>(this.EndPoint + "/reservedamount", queryParams);
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


        public async Task<object> UpdateStockCodeAsync(UpdateStockCode updateStockCodeModel)
        {
            try
            {
                var result = await billbeeClient.UpdateAsync<object>(this.EndPoint + "/updatestockcode", updateStockCodeModel);
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


        public async Task<List<Product>> GetAllAsync(int page = 0, int pageSize = 50, DateTime? minCreatedAt = null)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("page", page.ToString());
            queryParams.Add("pageSize", pageSize.ToString());

            if (minCreatedAt != null)
            {
                queryParams.Add("minCreatedAt", minCreatedAt.Value.ToString("yyyy-MM-dd"));
            }

            try
            {
                var result = await billbeeClient.GetAllAsync<Product>(this.EndPoint, queryParams);
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


        public async Task<Product> GetAsync(long id, ProductIdType type = ProductIdType.id)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("lookupBy", type.ToString());

            try
            {
                var result = await billbeeClient.GetAsync<Product>(this.EndPoint + "/" + id, queryParams);
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


        public async Task<List<ArticleCustomFieldDefinition>> GetCustomFieldsAsync(int page = 0, int pageSize = 50)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("page", page.ToString());
            queryParams.Add("pageSize", pageSize.ToString());

            try
            {
                var result = await billbeeClient.GetAllAsync<ArticleCustomFieldDefinition>(this.EndPoint + "/custom-fields", queryParams);
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

        public async Task<ArticleCustomFieldDefinition> GetCustomFieldAsync(long id)
        {
            try
            {
                var result = await billbeeClient.GetAsync<ArticleCustomFieldDefinition>(this.EndPoint + "/custom-fields/" + id);
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

        public async Task<List<string>> GetPatchableProductFieldsAsync(long id)
        {
            try
            {
                var result = await billbeeClient.GetAllAsync<string>(this.EndPoint + "/PatchableFields");
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


        public async Task<Product> PatchAsync(long id, Dictionary<string, object> fields)
        {
            try
            {
                var result = await billbeeClient.PatchAsync<Product>(this.EndPoint + "/" + id.ToString(), fields);
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


        public async Task<List<ArticleImage>> GetProductImagesAsync(long id)
        {
            try
            {
                var result = await billbeeClient.GetAllAsync<ArticleImage>(this.EndPoint + "/" + id.ToString() + "/images");
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

        public async Task<ArticleImage> GetProductImageAsync(long productId, long imageId)
        {
            try
            {
                var result = await billbeeClient.GetAsync<ArticleImage>(this.EndPoint + "/" + productId.ToString() + "/images/" + imageId.ToString());
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

        public async Task<ArticleImage> GetProductImageAsync(long imageId)
        {
            try
            {
                var result = await billbeeClient.GetAsync<ArticleImage>(this.EndPoint + "/images/" + imageId.ToString());
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

        public async Task<ArticleImage> AddProductImageAsync(ArticleImage image)
        {
            if (image.Id != 0)
            {
                throw new Exception("To add a new image, only 0 as Id is allowed.");
            }

            try
            {
                var result = await billbeeClient.UpdateAsync<ArticleImage>(this.EndPoint + "/" + image.ArticleId.ToString() + "/images/" + image.Id.ToString(), image);
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

        public async Task<ArticleImage> UpdateProductImageAsync(ArticleImage image)
        {
            if (image.Id != 0)
            {
                throw new Exception("To update a new image, only 0 as Id is allowed.");
            }

            try
            {
                var result = await billbeeClient.UpdateAsync<ArticleImage>(this.EndPoint + "/" + image.ArticleId.ToString() + "/images/" + image.Id.ToString(), image);
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


        public async Task<List<ArticleImage>> AddMultipleProductImageAsync(long productId, List<ArticleImage> images, bool replace = false)
        {
            var queryParams = new Dictionary<string, string>();
            queryParams.Add("replace", replace.ToString());

            try
            {
                var result = await billbeeClient.UpdateAsync<List<ArticleImage>>(this.EndPoint + "/" + productId.ToString() + "/images", images, queryParams);
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


        public async Task DeleteProductImageAsync(long productId, long imageId)
        {
            try
            {
                await billbeeClient.DeleteAsync<dynamic>(this.EndPoint + "/" + productId.ToString() + "/images/" + imageId.ToString());
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


        public async Task DeleteProductImageAsync(long imageId)
        {
            try
            {
                await billbeeClient.DeleteAsync<dynamic>(this.EndPoint + "/images/" + imageId.ToString());
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


        public async Task DeleteMultipleProductImageAsync(List<long> imageIds)
        {
            try
            {
                await billbeeClient.DeleteAsync<dynamic>(this.EndPoint + "/images/delete", imageIds);
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

