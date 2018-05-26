using System;

namespace wish_list.Models
{
    public class EbayApiKey
    {
        public string ID { get; private set;  } = "api-key";
        public string ApiKey { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}