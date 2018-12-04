using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using searchfight.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Configuration;

namespace searchfight.Service
{
    public class BingSearch
    {
        const string uriBase = "https://api.cognitive.microsoft.com/bing/v7.0/search?q=";

        public async Task<ResultSearch> searchAsync(string language)
        {
            ResultSearch result = new ResultSearch();
            var accessKey = ConfigurationManager.AppSettings["BingApiKey"];

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", accessKey);

                var httpResponse = await client.GetAsync(uriBase + language);
                var json = await httpResponse.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<BingResponse>(json);

                result.Engine = "BING";
                result.Language = language;
                result.Total = response.WebPages.TotalEstimatedMatches;
                return result;
            }
        }
    }
}
