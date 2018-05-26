using System;

namespace MyCompany.Shared
{
    public class EbayApi
    {
        public string ID { get; private set;  } = "api-key";
        public string ApiKey { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}