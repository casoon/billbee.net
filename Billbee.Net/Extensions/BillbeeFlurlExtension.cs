using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
using Billbee.Net.Responses;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Billbee.Net.Extensions
{
    public static class BillbeeFlurlExtension
    {
        private static readonly string UserAgent = $"Billbee.Net/{typeof(BillbeeClient).Assembly.GetName().Version}";

        public static Task<T> Get<T>(this Url url, string apiKey, string clientId, string clientSecret)
        {
            return new FlurlRequest(url).Get<T>(apiKey, clientId, clientSecret);
        }

        public static Task<T> Get<T>(this Uri uri, string apiKey, string clientId, string clientSecret)
        {
            return new FlurlRequest(uri).Get<T>(apiKey, clientId, clientSecret);
        }

        public static Task<T> Get<T>(this string url, string apiKey, string clientId, string clientSecret)
        {
            return new FlurlRequest(url).Get<T>(apiKey, clientId, clientSecret);
        }

        private static async Task<T> Get<T>(this IFlurlRequest req, string apiKey, string clientId, string clientSecret)
        {
            Response<T> result = null;

            req
                .WithHeader("X-Billbee-Api-Key", apiKey)
                .WithHeader("User-Agent", UserAgent)
                .WithBasicAuth(clientId, clientSecret);
            result = await req.GetJsonAsync<Response<T>>();

            if (result == null || result.ErrorCode != 0 || result.Data == null)
                throw new ApiException($"{result?.ErrorMessage ?? "Unknown error"} (ErrCode: {result?.ErrorCode ?? -1})");
            try
            {
                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(result.Data));
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static Task<T> Post<T>(this Url url, string apiKey, string clientId, string clientSecret, T t)
        {
            return new FlurlRequest(url).Post(apiKey, clientId, clientSecret, t);
        }

        public static Task<T> Post<T>(this Uri uri, string apiKey, string clientId, string clientSecret, T t)
        {
            return new FlurlRequest(uri).Post(apiKey, clientId, clientSecret, t);
        }

        public static Task<T> Post<T>(this string url, string apiKey, string clientId, string clientSecret, T t)
        {
            return new FlurlRequest(url).Post(apiKey, clientId, clientSecret, t);
        }


        private static async Task<T> Post<T>(this IFlurlRequest req, string apiKey, string clientId,
            string clientSecret,
            T t)
        {
            var json = JsonConvert.SerializeObject(t);

            Response<T> result = null;

            req
                .WithHeader("X-Billbee-Api-Key", apiKey)
                .WithHeader("User-Agent", UserAgent)
                .WithBasicAuth(clientId, clientSecret);

            result = await req.PostJsonAsync(t).ReceiveJson<Response<T>>();


            if (result == null || result.ErrorCode != 0 || result.Data == null)
                throw new ApiException($"{result?.ErrorMessage ?? "Unknown error"} (ErrCode: {result?.ErrorCode ?? -1})");
            try
            {
                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(result.Data));
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static Task<T> Put<T>(this Url url, string apiKey, string clientId, string clientSecret, T t)
        {
            return new FlurlRequest(url).Put(apiKey, clientId, clientSecret, t);
        }

        public static Task<T> Put<T>(this Uri uri, string apiKey, string clientId, string clientSecret, T t)
        {
            return new FlurlRequest(uri).Put(apiKey, clientId, clientSecret, t);
        }

        public static Task<T> Put<T>(this string url, string apiKey, string clientId, string clientSecret, T t)
        {
            return new FlurlRequest(url).Put(apiKey, clientId, clientSecret, t);
        }


        private static async Task<T> Put<T>(this IFlurlRequest req, string apiKey, string clientId, string clientSecret,
            T t)
        {
            var json = JsonConvert.SerializeObject(t);

            Response<T> result = null;

            req
                .WithHeader("X-Billbee-Api-Key", apiKey)
                .WithHeader("User-Agent", UserAgent)
                .WithBasicAuth(clientId, clientSecret);
            result = await req.PutJsonAsync(t).ReceiveJson<Response<T>>();


            if (!(result is {ErrorCode: 0}) || result.Data == null) return default;
            try
            {
                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(result.Data));
            }
            catch (Exception e)
            {
                throw e;
            }

            return default;
        }


        public static Task<T> Patch<T>(this Url url, string apiKey, string clientId, string clientSecret,
            Dictionary<string, object> fields)
        {
            return new FlurlRequest(url).Patch<T>(apiKey, clientId, clientSecret, fields);
        }

        public static Task<T> Patch<T>(this Uri uri, string apiKey, string clientId, string clientSecret,
            Dictionary<string, object> fields)
        {
            return new FlurlRequest(uri).Patch<T>(apiKey, clientId, clientSecret, fields);
        }

        public static Task<T> Patch<T>(this string url, string apiKey, string clientId, string clientSecret,
            Dictionary<string, object> fields)
        {
            return new FlurlRequest(url).Patch<T>(apiKey, clientId, clientSecret, fields);
        }


        private static async Task<T> Patch<T>(this IFlurlRequest req, string apiKey, string clientId,
            string clientSecret, Dictionary<string, object> fields)
        {
            var obj = new JObject();
            foreach (var prop in fields.Select(element => new JProperty(element.Key, element.Value))) obj.Add(prop);

            var json = JsonConvert.SerializeObject(obj);

            Response<T> result = null;

            req
                .WithHeader("X-Billbee-Api-Key", apiKey)
                .WithHeader("User-Agent", UserAgent)
                .WithBasicAuth(clientId, clientSecret);
            result = await req.PatchJsonAsync(json).ReceiveJson<Response<T>>();


            if (result != null && result.ErrorCode == 0 && result.Data != null)
                try
                {
                    return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(result.Data));
                }
                catch (Exception e)
                {
                    throw e;
                }

            return default;
        }


        public static Task<List<T>> GetAll<T>(this Url url, string apiKey, string clientId, string clientSecret)
        {
            return new FlurlRequest(url).GetAll<T>(apiKey, clientId, clientSecret);
        }

        public static Task<List<T>> GetAll<T>(this Uri uri, string apiKey, string clientId, string clientSecret)
        {
            return new FlurlRequest(uri).GetAll<T>(apiKey, clientId, clientSecret);
        }

        public static Task<List<T>> GetAll<T>(this string url, string apiKey, string clientId, string clientSecret)
        {
            return new FlurlRequest(url).GetAll<T>(apiKey, clientId, clientSecret);
        }


        public static async Task<List<T>> GetAll<T>(this IFlurlRequest req, string apiKey, string clientId,
            string clientSecret)
        {
            var resultList = new List<T>();


            req
                .WithHeader("X-Billbee-Api-Key", apiKey)
                .WithHeader("User-Agent", UserAgent)
                .WithBasicAuth(clientId, clientSecret);

            var result = await req.GetJsonAsync<PagedResponse<T>>();
            if (result.ErrorCode != 0 || result.Data == null) return default;

            try
            {
                return JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(result.Data));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static Task Delete<T>(this Url url, string apiKey, string clientId, string clientSecret)
        {
            return new FlurlRequest(url).Delete<T>(apiKey, clientId, clientSecret);
        }

        public static Task Delete<T>(this Uri uri, string apiKey, string clientId, string clientSecret)
        {
            return new FlurlRequest(uri).Delete<T>(apiKey, clientId, clientSecret);
        }

        public static Task Delete<T>(this string url, string apiKey, string clientId, string clientSecret)
        {
            return new FlurlRequest(url).Delete<T>(apiKey, clientId, clientSecret);
        }


        public static async Task Delete<T>(this IFlurlRequest req, string apiKey, string clientId, string clientSecret)
        {
            req
                .WithHeader("X-Billbee-Api-Key", apiKey)
                .WithHeader("User-Agent", UserAgent)
                .WithBasicAuth(clientId, clientSecret);
            await req.DeleteAsync();
        }
    }
}