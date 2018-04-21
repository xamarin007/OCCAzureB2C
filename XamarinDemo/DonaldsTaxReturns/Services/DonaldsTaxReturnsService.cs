using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using DonaldsTaxReturns.Constants;
using DonaldsTaxReturns.Models;
using Newtonsoft.Json;

namespace DonaldsTaxReturns.Services
{
    public class DonaldsTaxReturnsService
    {
        static HttpClient client = new HttpClient();
        static readonly JsonSerializer _serializer = new JsonSerializer();

        public static async Task<List<TaxReturns>> GetAllTaxReturns(string authToken , bool useAzureFunction)
        {

            bool _useAzureFunction = useAzureFunction;

            if (!_useAzureFunction)
            {
                var apiUrl = B2CConstants.DonaldsTaxReturnsUrl;
                try
                {
                    using (var request = new HttpRequestMessage(HttpMethod.Get, apiUrl))
                    {
                        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

                        using (var response = await client.SendAsync(request).ConfigureAwait(false))
                        {
                            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

                            using (var reader = new StreamReader(stream))
                            using (var json = new JsonTextReader(reader))
                            {
                                if (json == null)
                                    return default(List<TaxReturns>);

                                return await Task.Run(() => _serializer.Deserialize<List<TaxReturns>>(json)).ConfigureAwait(false);

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"*** ERROR in HTTPService GET!! {ex.Message}");
                    return default(List<TaxReturns>);
                }

            }
            else
            {
                //using function App 
                string funAppLocation = "https://occdemofuncapp.azurewebsites.net/";

                var baseAddr = new Uri(funAppLocation);
                client = new HttpClient { BaseAddress = baseAddr };

                //review the full address of the function needed to be invoked.

                //var reviewUri = new Uri(baseAddr, "api/HttpTriggerCSharp1?code=W/pZBCd3l6zHPG/DyR08s9qG9YTXQKA7HYANmZDWQitbNMaQ3vGa4A==");
                var reviewUri = new Uri(baseAddr, "api/HttpTriggerCSharp1?code=httptrigger1");
                var request = new HttpRequestMessage(HttpMethod.Get, reviewUri);

                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken);

                //call the function

                using (var response = await client.SendAsync(request).ConfigureAwait(false))
                {
                    var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

                    using (var reader = new StreamReader(stream))
                    using (var json = new JsonTextReader(reader))
                    {
                        if (json == null)
                            return default(List<TaxReturns>);

                        return await Task.Run(() => _serializer.Deserialize<List<TaxReturns>>(json)).ConfigureAwait(false);

                    }
                }

            }



        }
    }
}
