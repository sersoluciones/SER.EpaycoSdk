using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi.Models.Request
{
    public class AddTokenToCustomer
    {
        [JsonPropertyName("cardToken")]
        public string CardToken { get; set; }


        [JsonPropertyName("customerId")]
        public string CustomerId { get; set; }

    }
}
