using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Newtonsoft.Json;
using Dapper;

//using System.Json;
namespace MyCompany.Repositories
{
    public class EbaySearchRepository
    {
        private static readonly string _token;
        private readonly string _apiKey = "api-key";
        private readonly string _api = "https://api.ebay.com/buy/browse/v1/item_summary/search";
        private readonly string _apiKeyFileName = $"{Environment.CurrentDirectory}/apiKey";
        private readonly EbayRepository _ebayRepo;

        private readonly string _header1 = "Authorization";
        private readonly string _header1Value = $"Bearer {_token}";
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
            var _token = GetApiToken(_apiKey);
            var options = $"?q={item}&limit=15";
            HttpGet(_api + options);
            return new List<ItemSummary>();
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
    }





}