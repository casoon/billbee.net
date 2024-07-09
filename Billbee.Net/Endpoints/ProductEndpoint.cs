using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Billbee.Net.Models;
using Billbee.Net.Responses;

namespace Billbee.Net.Endpoints;

/// <summary>
///     Represents the endpoint for handling product-related operations.
/// </summary>
public class ProductEndpoint
{
    private readonly ApiClient _apiClient;
    private readonly string _endpointPath = "products";

    /// <summary>
    ///     Initializes a new instance of the <see cref="ProductEndpoint" /> class.
    /// </summary>
    /// <param name="apiClient">The API client used to make requests.</param>
    public ProductEndpoint(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    /// <summary>
    ///     Adds a new product asynchronously.
    /// </summary>
    /// <param name="entity">The product to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddAsync(Product entity)
    {
        await _apiClient.PostAsync(_endpointPath, entity);
    }

    /// <summary>
    ///     Retrieves a specific product by ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the product.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the requested product.</returns>
    public async Task<Product> GetAsync(long id)
    {
        return await _apiClient.GetAsync<Product>($"{_endpointPath}/{id}");
    }

    /// <summary>
    ///     Updates an existing product asynchronously.
    /// </summary>
    /// <param name="id">The ID of the product to update.</param>
    /// <param name="entity">The updated product data.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task UpdateAsync(long id, Product entity)
    {
        await _apiClient.PutAsync($"{_endpointPath}/{id}", entity);
    }

    /// <summary>
    ///     Retrieves all products asynchronously with pagination and optional filters.
    /// </summary>
    /// <param name="page">The page number to retrieve.</param>
    /// <param name="pageSize">The number of products per page.</param>
    /// <param name="minCreatedAt">The minimum creation date filter.</param>
    /// <param name="minimumBillBeeArticleId">The minimum BillBee article ID filter.</param>
    /// <param name="maximumBillBeeArticleId">The maximum BillBee article ID filter.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a paged response with the products.</returns>
    public async Task<PagedResponse<Product>> GetAllAsync(int page = 1, int pageSize = 50,
        DateTime? minCreatedAt = null, long? minimumBillBeeArticleId = null, long? maximumBillBeeArticleId = null)
    {
        var queryParams = new QueryParameterBuilder();
        queryParams.Add("page", page);
        queryParams.Add("pageSize", pageSize);
        queryParams.AddDate("minCreatedAt", minCreatedAt);
        queryParams.Add("minimumBillBeeArticleId", minimumBillBeeArticleId);
        queryParams.Add("maximumBillBeeArticleId", maximumBillBeeArticleId);

        return await _apiClient.GetPagedAsync<Product>(_endpointPath, queryParams.Build());
    }

    /// <summary>
    ///     Retrieves stocks for a specific order asynchronously.
    /// </summary>
    /// <param name="orderId">The ID of the order.</param>
    /// <param name="updateStockList">The list of stock updates.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a list of stocks.</returns>
    public async Task<List<Stock>> GetStocksAsync(long orderId, List<UpdateStock> updateStockList)
    {
        return await _apiClient.GetAsync<List<Stock>>($"{_endpointPath}/stocks");
    }

    /// <summary>
    ///     Updates multiple stocks asynchronously.
    /// </summary>
    /// <param name="orderId">The ID of the order.</param>
    /// <param name="updateStockList">The list of stock updates.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task UpdateStockMultipleAsync(long orderId, List<UpdateStock> updateStockList)
    {
        if (updateStockList == null) throw new ArgumentNullException(nameof(updateStockList));
        await _apiClient.PutAsync($"{_endpointPath}/updatestockmultiple", updateStockList);
    }

    /// <summary>
    ///     Updates a specific stock asynchronously.
    /// </summary>
    /// <param name="orderId">The ID of the order.</param>
    /// <param name="updateStockModel">The stock update model.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task UpdateStockAsync(long orderId, UpdateStock updateStockModel)
    {
        if (updateStockModel == null) throw new ArgumentNullException(nameof(updateStockModel));
        await _apiClient.PutAsync($"{_endpointPath}/updatestock", updateStockModel);
    }

    /// <summary>
    ///     Retrieves the reserved amount of a product asynchronously.
    /// </summary>
    /// <param name="idOrSku">The ID or SKU of the product.</param>
    /// <param name="lookupBy">The lookup type (default is "id").</param>
    /// <param name="stockId">The stock ID to filter by, if applicable.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the reserved amount result.</returns>
    public async Task<GetReservedAmountResult> GetReservedAmountAsync(string idOrSku, string lookupBy = "id",
        long? stockId = null)
    {
        var queryParams = new QueryParameterBuilder();
        queryParams.Add("id", idOrSku);
        queryParams.Add("lookupBy", lookupBy);
        if (stockId != null) queryParams.Add("stockId", stockId.Value);

        return await _apiClient.GetAsync<GetReservedAmountResult>($"{_endpointPath}/reservedamount",
            queryParams.Build());
    }

    /// <summary>
    ///     Updates the stock code of a product asynchronously.
    /// </summary>
    /// <param name="updateStockCodeModel">The stock code update model.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task UpdateStockAsync(UpdateStockCode updateStockCodeModel)
    {
        if (updateStockCodeModel == null) throw new ArgumentNullException(nameof(updateStockCodeModel));
        await _apiClient.PutAsync($"{_endpointPath}/updatestockcode", updateStockCodeModel);
    }

    /// <summary>
    ///     Retrieves custom fields for products asynchronously with pagination.
    /// </summary>
    /// <param name="page">The page number to retrieve.</param>
    /// <param name="pageSize">The number of custom fields per page.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a list of custom field definitions.</returns>
    public async Task<List<ArticleCustomFieldDefinition>> GetCustomFieldsAsync(int page = 0, int pageSize = 50)
    {
        var queryParams = new QueryParameterBuilder();
        queryParams.Add("page", page);
        queryParams.Add("pageSize", pageSize);
        return await _apiClient.GetAsync<List<ArticleCustomFieldDefinition>>($"{_endpointPath}/custom-fields",
            queryParams.Build());
    }

    /// <summary>
    ///     Retrieves a specific custom field by ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the custom field.</param>
    /// <returns>
    ///     A task representing the asynchronous operation. The task result contains the requested custom field
    ///     definition.
    /// </returns>
    public async Task<ArticleCustomFieldDefinition> GetCustomFieldAsync(long id)
    {
        return await _apiClient.GetAsync<ArticleCustomFieldDefinition>($"{_endpointPath}/custom-fields/{id}");
    }

    /// <summary>
    ///     Retrieves the patchable fields for a product asynchronously.
    /// </summary>
    /// <param name="id">The ID of the product.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a list of patchable fields.</returns>
    public async Task<List<string>> GetPatchableProductFieldsAsync(long id)
    {
        return await _apiClient.GetAsync<List<string>>($"{_endpointPath}/PatchableFields");
    }

    /// <summary>
    ///     Patches a product with specified fields asynchronously.
    /// </summary>
    /// <param name="id">The ID of the product.</param>
    /// <param name="fields">The fields to patch.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task PatchAsync(long id, Dictionary<string, object> fields)
    {
        await _apiClient.PatchAsync<Product>($"{_endpointPath}/{id}", fields);
    }

    /// <summary>
    ///     Retrieves images for a specific product asynchronously.
    /// </summary>
    /// <param name="id">The ID of the product.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a list of product images.</returns>
    public async Task<List<ArticleImage>> GetProductImagesAsync(long id)
    {
        return await _apiClient.GetAsync<List<ArticleImage>>($"{_endpointPath}/{id}/images");
    }

    /// <summary>
    ///     Retrieves a specific product image by product ID and image ID asynchronously.
    /// </summary>
    /// <param name="productId">The ID of the product.</param>
    /// <param name="imageId">The ID of the image.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the requested product image.</returns>
    public async Task<ArticleImage> GetProductImageAsync(long productId, long imageId)
    {
        return await _apiClient.GetAsync<ArticleImage>($"{_endpointPath}/{productId}/images/{imageId}");
    }

    /// <summary>
    ///     Adds a new product image asynchronously.
    /// </summary>
    /// <param name="image">The product image to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddProductImageAsync(ArticleImage image)
    {
        if (image.Id != 0) throw new Exception("To add a new image, only 0 as Id is allowed.");
        await _apiClient.PostAsync($"{_endpointPath}/{image.ArticleId}/images/{image.Id}", image);
    }

    /// <summary>
    ///     Updates an existing product image asynchronously.
    /// </summary>
    /// <param name="image">The product image to update.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task UpdateProductImageAsync(ArticleImage image)
    {
        if (image.Id != 0) throw new Exception("To add a new image, only 0 as Id is allowed.");
        await _apiClient.PutAsync($"{_endpointPath}/{image.ArticleId}/images/{image.Id}", image);
    }

    /// <summary>
    ///     Adds multiple product images asynchronously.
    /// </summary>
    /// <param name="productId">The ID of the product.</param>
    /// <param name="images">The list of product images to add.</param>
    /// <param name="replace">Whether to replace existing images.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddMultipleProductImageAsync(long productId, List<ArticleImage> images, bool replace = false)
    {
        var queryParams = new QueryParameterBuilder();
        queryParams.Add("replace", replace);
        await _apiClient.PutAsync($"{_endpointPath}/{productId}/images", images, queryParams.Build());
    }

    /// <summary>
    ///     Deletes a specific product image by product ID and image ID asynchronously.
    /// </summary>
    /// <param name="productId">The ID of the product.</param>
    /// <param name="imageId">The ID of the image.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task DeleteProductImageAsync(long productId, long imageId)
    {
        await _apiClient.DeleteAsync($"{_endpointPath}/{productId}/images/{imageId}");
    }

    /// <summary>
    ///     Deletes a specific product image by image ID asynchronously.
    /// </summary>
    /// <param name="imageId">The ID of the image.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task DeleteProductImageAsync(long imageId)
    {
        await _apiClient.DeleteAsync($"{_endpointPath}/images/{imageId}");
    }

    /// <summary>
    ///     Deletes multiple product images asynchronously.
    /// </summary>
    /// <param name="imageIds">The list of image IDs to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task DeleteMultipleProductImageAsync(List<long> imageIds)
    {
        await _apiClient.DeleteAsync($"{_endpointPath}/images/delete", imageIds);
    }
}