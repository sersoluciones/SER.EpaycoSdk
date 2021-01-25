using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.Models.RequestModels
{
    //{\n\"card[number]\":\"" + cardNumber + "\"," +
    //               "\n\"card[exp_year]\":\"" + expYear + "\"," +
    //               "\n\"card[exp_month]\":\"" + expMonth + "\"," +
    //               "\n\"card[cvc]\":\"" + cvc + "\"\n}";
    public class CreateToken
    {
        public CreateToken(string cardNumber, string expYear, string expMonth, string cvc)
        {
            CardNumber = cardNumber;
            ExpYear = expYear;
            ExpMonth = expMonth;
            Cvc = cvc;
        }

        [JsonPropertyName("card[number]")]
        public string CardNumber { get; set; }
        [JsonPropertyName("card[exp_year]")]
        public string ExpYear { get; set; }
        [JsonPropertyName("card[exp_month]")]
        public string ExpMonth { get; set; }
        [JsonPropertyName("card[cvc]")]
        public string Cvc { get; set; }
    }
}
