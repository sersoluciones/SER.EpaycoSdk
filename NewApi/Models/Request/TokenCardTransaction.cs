using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi.Models.Request
{
    public class TokenCardTransaction
    {
        public TokenCardTransaction(string cardNumber, string cardExpYear, string cardExpMonth, string cardCvc)
        {
            CardNumber = cardNumber;
            CardExpYear = cardExpYear;
            CardExpMonth = cardExpMonth;
            CardCvc = cardCvc;
        }

        [JsonPropertyName("cardNumber")]
        public string CardNumber { get; set; }

        [JsonPropertyName("cardExpYear")]
        public string CardExpYear { get; set; }

        [JsonPropertyName("cardExpMonth")]
        public string CardExpMonth { get; set; }

        [JsonPropertyName("cardCvc")]
        public string CardCvc { get; set; }
    }
}
