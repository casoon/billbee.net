using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Billbee.Net.Responses;
using Microsoft.Extensions.Logging;

namespace Billbee.Net;

public class ApiClient(HttpClient httpClient, ILogger<ApiClient> logger)
{
    public async Task<PagedResponse<T>> GetPagedAsync<T>(string endpoint, int pageNumber, int pageSize)
    {
        try
        {
            var response = await httpClient.GetAsync($"{endpoint}?pageNumber={pageNumber}&pageSize={pageSize}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PagedResponse<T>>(content);

            return result;
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex, "An error occurred while making a GET request to {Endpoint}", endpoint);
            throw new ApiException("An error occurred while making a GET request", ex);
        }
    }

    public async Task<PagedResponse<T>> GetPagedAsync<T>(string endpoint, Dictionary<string, string> parameters)
    {
        try
        {
            var query = string.Join("&",
                parameters.Select(kvp => $"{HttpUtility.UrlEncode(kvp.Key)}={HttpUtility.UrlEncode(kvp.Value)}"));
            var response = await httpClient.GetAsync($"{endpoint}?{query}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PagedResponse<T>>(content);

            return result;
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex, "An error occurred while making a GET request to {Endpoint}", endpoint);
            throw new ApiException("An error occurred while making a GET request", ex);
        }
    }

    public async Task<T> GetAsync<T>(string endpoint)
    {
        try
        {
            var response = await httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<T>(content);

            return result;
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex, "An error occurred while making a GET request to {Endpoint}", endpoint);
            throw new ApiException("An error occurred while making a GET request", ex);
        }
    }

    public async Task<T> GetAsync<T>(string endpoint, Dictionary<string, string> parameters = null)
    {
        try
        {
            var url = endpoint;
            if (parameters != null && parameters.Count > 0)
            {
                var query = string.Join("&",
                    parameters.Select(kvp => $"{HttpUtility.UrlEncode(kvp.Key)}={HttpUtility.UrlEncode(kvp.Value)}"));
                url = $"{endpoint}?{query}";
            }

            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<T>(content);

            return result;
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex, "An error occurred while making a GET request to {Endpoint}", endpoint);
            throw new ApiException("An error occurred while making a GET request", ex);
        }
    }


    public async Task PostAsync<T>(string endpoint, T entity)
    {
        try
        {
            var content = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex, "An error occurred while making a POST request to {Endpoint}", endpoint);
            throw new ApiException("An error occurred while making a POST request", ex);
        }
    }

    public async Task PostAsync<T>(string endpoint, T entity, Dictionary<string, string> parameters = null)
    {
        if (parameters == null) PostAsync(endpoint, entity);
        try
        {
            var url = endpoint;
            if (parameters != null && parameters.Count > 0)
            {
                var query = string.Join("&",
                    parameters.Select(kvp => $"{HttpUtility.UrlEncode(kvp.Key)}={HttpUtility.UrlEncode(kvp.Value)}"));
                url = $"{endpoint}?{query}";
            }

            var content = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex, "An error occurred while making a POST request to {Endpoint}", endpoint);
            throw new ApiException("An error occurred while making a POST request", ex);
        }
    }

    public async Task PutAsync<T>(string endpoint, T entity)
    {
        try
        {
            var content = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(endpoint, content);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex, "An error occurred while making a PUT request to {Endpoint}", endpoint);
            throw new ApiException("An error occurred while making a PUT request", ex);
        }
    }

    public async Task PutAsync<T>(string endpoint, T entity, Dictionary<string, string> parameters = null)
    {
        try
        {
            var url = endpoint;
            if (parameters != null && parameters.Count > 0)
            {
                var query = string.Join("&",
                    parameters.Select(kvp => $"{HttpUtility.UrlEncode(kvp.Key)}={HttpUtility.UrlEncode(kvp.Value)}"));
                url = $"{endpoint}?{query}";
            }

            var content = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex, "An error occurred while making a PUT request to {Endpoint}", endpoint);
            throw new ApiException("An error occurred while making a PUT request", ex);
        }
    }

    public async Task PatchAsync<T>(string endpoint, Dictionary<string, object> changes,
        Dictionary<string, string> parameters = null)
    {
        try
        {
            var url = endpoint;
            if (parameters != null && parameters.Count > 0)
            {
                var query = string.Join("&",
                    parameters.Select(kvp => $"{HttpUtility.UrlEncode(kvp.Key)}={HttpUtility.UrlEncode(kvp.Value)}"));
                url = $"{endpoint}?{query}";
            }

            var content = new StringContent(JsonSerializer.Serialize(changes), Encoding.UTF8, "application/json");
            var response = await httpClient.PatchAsync(url, content);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex, "An error occurred while making a PATCH request to {Endpoint}", endpoint);
            throw new ApiException("An error occurred while making a PATCH request", ex);
        }
    }

    public async Task DeleteAsync(string endpoint)
    {
        try
        {
            var response = await httpClient.DeleteAsync(endpoint);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex, "An error occurred while making a DELETE request to {Endpoint}", endpoint);
            throw new ApiException("An error occurred while making a DELETE request", ex);
        }
    }

    public async Task DeleteAsync(string endpoint, List<long> ids)
    {
        try
        {
            var query = string.Join("&", ids.Select(id => $"ids={id}"));
            var url = $"{endpoint}?{query}";

            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            logger.LogError(ex, "An error occurred while making a DELETE request to {Endpoint}", endpoint);
            throw new ApiException("An error occurred while making a DELETE request", ex);
        }
    }
}