using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi.Models.Request
{
    public class TCTransactionFull : BaseTransaction
    {
        public TCTransactionFull(string description, string invoice, string cardNumber, string cardExpYear, string cardExpMonth, string cardCvc,
            string docType, string docNumber, string name, string lastName, string email,
            string cellPhone, string value, decimal tax, decimal taxBase, int typePerson, 
            string ip, string urlResponse, string urlConfirmation)
            : base(docType, docNumber, name, lastName, email, cellPhone, value, tax, taxBase, typePerson, ip, urlResponse, urlConfirmation)
        {
            Description = description;
            Invoice = invoice;
            CardNumber = cardNumber;
            CardExpYear = cardExpYear;
            CardExpMonth = cardExpMonth;
            CardCvc = cardCvc;
        }
  

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("invoice")]
        public string Invoice { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; } = "COP";
      

        [JsonPropertyName("_cardNumber")]
        public string CardNumber { get; set; }

        [JsonPropertyName("_cardExpYear")]
        public string CardExpYear { get; set; }

        [JsonPropertyName("_cardExpMonth")]
        public string CardExpMonth { get; set; }

        [JsonPropertyName("_cardCvc")]
        public string CardCvc { get; set; }

    }
}
