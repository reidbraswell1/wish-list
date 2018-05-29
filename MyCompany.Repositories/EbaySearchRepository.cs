using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using Dapper;
using MyCompany.Shared;

//using System.Json;
namespace MyCompany.Repositories
{
    public class EbaySearchRepository
    {
       // private string token;
        private readonly string _apiKey = "api-key";
        private readonly string _api = "https://api.ebay.com/buy/browse/v1/item_summary/search";
        private readonly string _apiKeyFileName = $"{Environment.CurrentDirectory}/apiKey";
        private readonly EbayRepository _ebayRepo;

        private readonly string _header1 = "Authorization";
        private string _header1Value = "Bearer ";
        private readonly string _header2 = "Content-Type";
        private readonly string _header2Value = "application/json";
        private readonly string _header3 = "X-EBAY-C-ENDUSERCTX";
        private readonly string _header3Value = "affiliateCampaignId=<ePNCampaignId>,affiliateReferenceId=<referenceId>";
        public EbaySearchRepository(EbayRepository ebayRepo)
        {
            _ebayRepo = ebayRepo;
        }
        public IEnumerable<ItemSummary> GetSearchItemResults(string item)
        {
            var token = GetApiToken(_apiKey);
            this._header1Value = _header1Value + token;
            var options = $"?q={item}&limit=15";
            var webResponse = HttpGet(_api + options);
            return ParseWebResponse(webResponse);
            //return new List<ItemSummary>();
        }
        private string GetApiToken(string key)
        {
            var ebayApi = _ebayRepo.GetEbayApiKey(_apiKey);
            if (ebayApi == null)
            {
                throw new Exception("Ebay Api Token Is Null");
            }
            return ebayApi.ApiKey;
        }
        private WebResponse HttpGet(string url)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);

                request.Headers.Add(_header1, _header1Value);
                request.Headers.Add(_header2, _header2Value);
                request.Headers.Add(_header3, _header3Value);

                WebResponse response = request.GetResponse();
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private IEnumerable<ItemSummary> ParseWebResponse(WebResponse response)
        {
            try
            {
                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                var json = reader.ReadToEnd();
                var items = JsonConvert.DeserializeObject<RootObject>(json);
                response.Dispose();
                return items.itemSummaries;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}