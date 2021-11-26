using System;
using System.Collections.Generic;
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
        public static Task<T> Get<T>(this Url url, string apiKey, string clientId, string clientSecret) => new FlurlRequest(url).Get<T>(apiKey, clientId, clientSecret);
        public static Task<T> Get<T>(this Uri uri, string apiKey, string clientId, string clientSecret) => new FlurlRequest(uri).Get<T>(apiKey, clientId, clientSecret);
        public static Task<T> Get<T>(this string url, string apiKey, string clientId, string clientSecret) => new FlurlRequest(url).Get<T>(apiKey, clientId, clientSecret);


        public async static Task<T> Get<T>(this IFlurlRequest req, string apiKey, string clientId, string clientSecret)
        {
            Response<T> result = null;

            string userAgent = $"Billbee.Net/{typeof(BillbeeClient).Assembly.GetName().Version}";

            try
            {
                req
                    .WithHeader("X-Billbee-Api-Key", apiKey)
                    .WithHeader("User-Agent", userAgent)
                    .WithBasicAuth(clientId, clientSecret);
                result = await req.GetJsonAsync<Response<T>>();
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Error attempting to query Billbee", e);
            }

         
            if (result.ErrorCode == 0 && result.Data != null)
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(result.Data));
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }

            }
            else
            {
                var errorMessage = $"{result.ErrorCode} - {result.ErrorMessage}";

                switch (result.ErrorCode)
                {
                    default:
                        throw new Exception($"{errorMessage}");

                }

            }
        }


        public static Task<T> Post<T>(this Url url, string apiKey, string clientId, string clientSecret, T t) => new FlurlRequest(url).Post<T>(apiKey, clientId, clientSecret, t);
        public static Task<T> Post<T>(this Uri uri, string apiKey, string clientId, string clientSecret, T t) => new FlurlRequest(uri).Post<T>(apiKey, clientId, clientSecret, t);
        public static Task<T> Post<T>(this string url, string apiKey, string clientId, string clientSecret, T t) => new FlurlRequest(url).Post<T>(apiKey, clientId, clientSecret, t);


        public async static Task<T> Post<T>(this IFlurlRequest req, string apiKey, string clientId, string clientSecret, T t)
        {
            var json = JsonConvert.SerializeObject(t);

            Response<T> result = null;

            string userAgent = $"Billbee.Net/{typeof(BillbeeClient).Assembly.GetName().Version}";

            try
            {
                req
                    .WithHeader("X-Billbee-Api-Key", apiKey)
                    .WithHeader("User-Agent", userAgent)
                    .WithBasicAuth(clientId, clientSecret);
                //result = await req.PostJsonAsync(json).ReceiveJson();
                var test = await req.PostJsonAsync(t).ReceiveJson<Response<T>>();
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Error attempting to query Billbee", e);
            }


            if (result.ErrorCode == 0 && result.Data != null)
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(result.Data));
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }

            }
            else
            {
                var errorMessage = $"{result.ErrorCode} - {result.ErrorMessage}";

                switch (result.ErrorCode)
                {
                    default:
                        throw new Exception($"{errorMessage}");

                }

            }
        }


        public static Task<T> Put<T>(this Url url, string apiKey, string clientId, string clientSecret, T t) => new FlurlRequest(url).Put<T>(apiKey, clientId, clientSecret, t);
        public static Task<T> Put<T>(this Uri uri, string apiKey, string clientId, string clientSecret, T t) => new FlurlRequest(uri).Put<T>(apiKey, clientId, clientSecret, t);
        public static Task<T> Put<T>(this string url, string apiKey, string clientId, string clientSecret, T t) => new FlurlRequest(url).Put<T>(apiKey, clientId, clientSecret, t);


        public async static Task<T> Put<T>(this IFlurlRequest req, string apiKey, string clientId, string clientSecret, T t)
        {
            var json = JsonConvert.SerializeObject(t);

            Response<T> result = null;

            string userAgent = $"Billbee.Net/{typeof(BillbeeClient).Assembly.GetName().Version}";

            try
            {
                req
                    .WithHeader("X-Billbee-Api-Key", apiKey)
                    .WithHeader("User-Agent", userAgent)
                    .WithBasicAuth(clientId, clientSecret);
                //result = await req.PostJsonAsync(json).ReceiveJson();
                var test = await req.PutJsonAsync(t).ReceiveJson<Response<T>>();
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Error attempting to query Billbee", e);
            }


            if (result.ErrorCode == 0 && result.Data != null)
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(result.Data));
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }

            }
            else
            {
                var errorMessage = $"{result.ErrorCode} - {result.ErrorMessage}";

                switch (result.ErrorCode)
                {
                    default:
                        throw new Exception($"{errorMessage}");

                }

            }
        }


        public static Task<T> Patch<T>(this Url url, string apiKey, string clientId, string clientSecret, Dictionary<string, object> fields) => new FlurlRequest(url).Patch<T>(apiKey, clientId, clientSecret, fields);
        public static Task<T> Patch<T>(this Uri uri, string apiKey, string clientId, string clientSecret, Dictionary<string, object> fields) => new FlurlRequest(uri).Patch<T>(apiKey, clientId, clientSecret, fields);
        public static Task<T> Patch<T>(this string url, string apiKey, string clientId, string clientSecret, Dictionary<string, object> fields) => new FlurlRequest(url).Patch<T>(apiKey, clientId, clientSecret, fields);


        public async static Task<T> Patch<T>(this IFlurlRequest req, string apiKey, string clientId, string clientSecret, Dictionary<string, object> fields)
        {

            JObject obj = new JObject();
            foreach (var element in fields)
            {
                JProperty prop = new JProperty(element.Key, element.Value);
                obj.Add(prop);
            }

            var json = JsonConvert.SerializeObject(obj);

            Response<T> result = null;

            string userAgent = $"Billbee.Net/{typeof(BillbeeClient).Assembly.GetName().Version}";

            try
            {
                req
                    .WithHeader("X-Billbee-Api-Key", apiKey)
                    .WithHeader("User-Agent", userAgent)
                    .WithBasicAuth(clientId, clientSecret);
                //result = await req.PostJsonAsync(json).ReceiveJson();
                var test = await req.PatchJsonAsync(json).ReceiveJson<Response<T>>();
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Error attempting to query Billbee", e);
            }


            if (result.ErrorCode == 0 && result.Data != null)
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(result.Data));
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }

            }
            else
            {
                var errorMessage = $"{result.ErrorCode} - {result.ErrorMessage}";

                switch (result.ErrorCode)
                {
                    default:
                        throw new Exception($"{errorMessage}");

                }

            }
        }



        public static Task<List<T>> GetAll<T>(this Url url, string apiKey, string clientId, string clientSecret) => new FlurlRequest(url).GetAll<T>(apiKey, clientId, clientSecret);
        public static Task<List<T>> GetAll<T>(this Uri uri, string apiKey, string clientId, string clientSecret) => new FlurlRequest(uri).GetAll<T>(apiKey, clientId, clientSecret);
        public static Task<List<T>> GetAll<T>(this string url, string apiKey, string clientId, string clientSecret) => new FlurlRequest(url).GetAll<T>(apiKey, clientId, clientSecret);


        public async static Task<List<T>> GetAll<T>(this IFlurlRequest req, string apiKey, string clientId, string clientSecret)
        {
            PagedResponse<T> result = null;

            string userAgent = $"Billbee.Net/{typeof(BillbeeClient).Assembly.GetName().Version}";

            try
            {
                req
                    .WithHeader("X-Billbee-Api-Key", apiKey)
                    .WithHeader("User-Agent", userAgent)
                    .WithBasicAuth(clientId, clientSecret);
                result = await req.GetJsonAsync<PagedResponse<T>>();
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Error attempting to query Billbee", e);
            }


            if (result.ErrorCode == 0 && result.Data != null)
            {
                try
                {
                    return JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(result.Data));
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }

            }
            else
            {
                var errorMessage = $"{result.ErrorCode} - {result.ErrorMessage}";

                switch (result.ErrorCode)
                {
                    default:
                        throw new Exception($"{errorMessage}");

                }

            }
        }


        public static Task<T> Delete<T>(this Url url, string apiKey, string clientId, string clientSecret) => new FlurlRequest(url).Delete<T>(apiKey, clientId, clientSecret);
        public static Task<T> Delete<T>(this Uri uri, string apiKey, string clientId, string clientSecret) => new FlurlRequest(uri).Delete<T>(apiKey, clientId, clientSecret);
        public static Task<T> Delete<T>(this string url, string apiKey, string clientId, string clientSecret) => new FlurlRequest(url).Delete<T>(apiKey, clientId, clientSecret);


        public async static Task<T> Delete<T>(this IFlurlRequest req, string apiKey, string clientId, string clientSecret)
        {
            Response<T> result = null;

            string userAgent = $"Billbee.Net/{typeof(BillbeeClient).Assembly.GetName().Version}";

            try
            {
                req
                    .WithHeader("X-Billbee-Api-Key", apiKey)
                    .WithHeader("User-Agent", userAgent)
                    .WithBasicAuth(clientId, clientSecret);
                //result = await req.PostJsonAsync(json).ReceiveJson();
                var test = await req.DeleteAsync();
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Error attempting to query Billbee", e);
            }


            if (result.ErrorCode == 0 && result.Data != null)
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(result.Data));
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }

            }
            else
            {
                var errorMessage = $"{result.ErrorCode} - {result.ErrorMessage}";

                switch (result.ErrorCode)
                {
                    default:
                        throw new Exception($"{errorMessage}");

                }

            }
        }


    }
}

