using System;
using System.Threading.Tasks;
using Billbee.Net.Exceptions;
using Billbee.Net.Responses;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace Billbee.Net.Extensions
{
    public static class BillbeeFlurlExtension
    {
        public static Task<T> GetSingleResponse<T>(this Url url, string apiKey, string clientId, string clientSecret) => new FlurlRequest(url).GetSingleResponse<T>(apiKey, clientId, clientSecret);
        public static Task<T> GetSingleResponse<T>(this Uri uri, string apiKey, string clientId, string clientSecret) => new FlurlRequest(uri).GetSingleResponse<T>(apiKey, clientId, clientSecret);
        public static Task<T> GetSingleResponse<T>(this string url, string apiKey, string clientId, string clientSecret) => new FlurlRequest(url).GetSingleResponse<T>(apiKey, clientId, clientSecret);


        public async static Task<T> GetSingleResponse<T>(this IFlurlRequest req, string apiKey, string clientId, string clientSecret)
        {
            SingleResponse<T> result = null;

            string userAgent = $"Billbee.Net/{typeof(BillbeeClient).Assembly.GetName().Version}";

            try
            {
                req
                    .WithHeader("X-Billbee-Api-Key", apiKey)
                    .WithHeader("User-Agent", userAgent)
                    .WithBasicAuth(clientId, clientSecret);
                result = await req.GetJsonAsync<SingleResponse<T>>();
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

