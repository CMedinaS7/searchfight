using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using searchfight.Model;
using System.Configuration;

namespace searchfight.Service
{
    public class GoogleSearch
    {
        const string uriBase = "https://www.googleapis.com/customsearch/v1";

        public async Task<ResultSearch> searchAsync(string language)
        {
            ResultSearch result = new ResultSearch();
            string apiKey = ConfigurationManager.AppSettings["GoogleApiKey"];
            string context = ConfigurationManager.AppSettings["GoogleApiContext"];

            var queryString = string.Format("{0}?cx={1}&key={2}&q={3}", uriBase, context, apiKey, language);

            using (var client = new HttpClient())
            {
                var httpResponse = await client.GetAsync(queryString);
                var content = await httpResponse.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<GoogleResponse>(content);

                result.Engine = "GOOGLE";
                result.Language = language;
                result.Total = response.SearchInformation.TotalResults;
                return result;
            }
        }
    }
}
