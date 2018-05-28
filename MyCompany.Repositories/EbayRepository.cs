using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyCompany.Shared;
using Dapper;

namespace MyCompany.Repositories
{
    public class EbayRepository
    {
        private readonly IDbConnection _conn;

        public EbayRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public int AddApiKey(EbayApi ebay)
        {
            using (var conn = _conn)
            {
                conn.Open();
                return conn.Execute("INSERT INTO appkey (id,api_token,update_time) VALUES (@ID,@ApiKey,@UpdateTime)", ebay);
            }
        }
        public int UpdateApiKey(EbayApi ebay)
        {
            using (var conn = _conn)
            {
                conn.Open();
                return conn.Execute("UPDATE eBay.appKey SET api_token = @ApiKey WHERE id='api-key'", ebay);
            }
        }
        public IEnumerable<EbayApi> GetEbayApiKeys()
        {
            using (var conn = _conn)
            {
                conn.Open();
                return conn.Query<EbayApi>("SELECT id AS ID, api_token AS ApiKey, update_time AS UpdateTime FROM eBay.appKey;");
            }
        }
    }
}
