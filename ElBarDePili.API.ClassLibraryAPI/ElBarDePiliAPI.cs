using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElBarDePili.API.ClassLibraryAPI
{
    public class ElBarDePiliAPI
    {
        private readonly HttpClient _httpClient;

        public ElBarDePiliAPI()
        {
            /* API LOCALHOST */
            //HttpClientHandler handler = new();
            //handler.ServerCertificateCustomValidationCallback = (message, cert, chain, error) => { return true; };
            //_httpClient = new HttpClient(handler);
            //_httpClient.BaseAddress = new Uri(APIConfiguration.APIURL_LOCALHOST_HTTPS);
            //_httpClient.DefaultRequestHeaders.Add("APIKey", APIConfiguration.APIKEY);

            /* API AZURE */
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(APIConfiguration.APIURL_AZURE);
            _httpClient.DefaultRequestHeaders.Add("APIKey", APIConfiguration.APIKEY);
        }

        public async Task<string> HolaMundo()
        {
            HttpRequestMessage request = new(HttpMethod.Get, new Uri($"/HolaMundo", UriKind.Relative));

            var response = await _httpClient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
