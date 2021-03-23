using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi.Models.Request
{
    public class TCTransaction : BaseTransaction
    {
        public TCTransaction(string customerId, string cardTokenId, string description, string invoice, 
            string docType, string docNumber, string name, string lastName, string email,
            string cellPhone, string value, decimal tax, decimal taxBase, int typePerson, 
            string ip, string urlResponse, string urlConfirmation)
            : base(docType, docNumber, name, lastName, email, cellPhone, value, tax, taxBase, typePerson, ip, urlResponse, urlConfirmation)
        {
            CustomerId = customerId;
            CardTokenId = cardTokenId;
            Description = description;
            Invoice = invoice;
        }

        [JsonPropertyName("customerId")]
        public string CustomerId { get; set; }

        [JsonPropertyName("cardTokenId")]
        public string CardTokenId { get; set; }      

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("invoice")]
        public string Invoice { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; } = "COP";

    }
}
