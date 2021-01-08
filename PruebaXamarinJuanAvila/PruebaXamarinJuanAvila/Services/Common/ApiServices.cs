using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PruebaXamarinJuanAvila.Utils
{
    public class ApiServices
    {
        private readonly string _xRapidAPIKey = Properties.Resources.X_RapidAPI_Key;
        private readonly string _baseUrl = Properties.Resources.BaseUrl;

        public async Task<T> GetAsync<T>(string uri)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"{_baseUrl}{uri}"),
                    Headers =
                    {
                        { "x-rapidapi-key", _xRapidAPIKey },
                        { "x-rapidapi-host", "restcountries-v1.p.rapidapi.com" },
                    },
                };
                string jsonResult = string.Empty;

                using (var response = await httpClient.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        jsonResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var json = JsonConvert.DeserializeObject<T>(jsonResult);
                        return json;
                    }

                    if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new ApplicationException(jsonResult);
                    }

                    throw new ApplicationException("Error al consultar");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
                throw e;
            }
        }

        public async Task<T> GetToCacheAsync<T>(string uri)
        {
            if (!Xamarin.Forms.Application.Current.Properties.TryGetValue(uri, out object Json))
            {
                var result = await GetAsync<T>(uri);
                Xamarin.Forms.Application.Current.Properties[uri] = JsonConvert.SerializeObject(result);
                await Xamarin.Forms.Application.Current.SavePropertiesAsync();
                return result;
            }
            return JsonConvert.DeserializeObject<T>(Json.ToString());
        }

    }
}
