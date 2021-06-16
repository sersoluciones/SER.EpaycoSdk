using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi.Models.Request
{
    /// <summary>
    ///  "filter": {
    ///     "referencePayco": 52572260
    ///  }
    /// </summary>
    public class DetailTransaction
    {
        [JsonPropertyName("filter")]
        public DetailTransactionData Filter { get; set; }
    }

    public class DetailTransactionData
    {
        [JsonPropertyName("referencePayco")]
        public long ReferencePayco { get; set; }
    }
}
