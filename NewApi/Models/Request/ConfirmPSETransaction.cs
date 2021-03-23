using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi.Models.Request
{
    public class ConfirmPSETransaction
    {
        [JsonPropertyName("transactionID")]
        public long TransactionID { get; set; }

    }
}
