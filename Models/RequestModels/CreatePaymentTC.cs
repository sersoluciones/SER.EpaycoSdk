using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.Models.RequestModels
{
    //"{\r\n\"token_card\": \"" + token_card + "\",\r" +
    //               "\n\"customer_id\": \"" + customer_id + "\",\r" +
    //               "\n\"doc_type\": \"" + doc_type + "\",\r" +
    //               "\n\"doc_number\": \"" + doc_number + "\",\r" +
    //               "\n\"name\": \"" + name + "\",\r" +
    //               "\n\"last_name\": \"" + last_name + "\",\r" +
    //               "\n\"email\": \"" + email + "\",\r" +
    //               "\n\"bill\": \"" + bill + "\",\r" +
    //               "\n\"description\": \"" + description + "\",\r" +
    //               "\n\"value\": \"" + value + "\",\r" +
    //               "\n\"tax\": \"" + tax + "\",\r" +
    //               "\n\"tax_base\": \"" + tax_base + "\",\r" +
    //               "\n\"phone\": \"" + phone + "\",\r" +
    //               "\n\"cell_phone\": \"" + cell_phone + "\",\r" +
    //               "\n\"currency\": \"" + currency + "\",\r" +
    //               "\n\"dues\": \"" + dues + "\",\r" +
    //               "\n\"address\": \"" + address + "\",\r" +
    //               "\n\"url_response\": \"" + url_response + "\",\r" +
    //               "\n\"url_confirmation\": \"" + url_confirmation + "\",\r" +
    //               "\n\"ip\": \"" + ip + "\"\r\n}";
    public class CreatePaymentTC
    {
        public CreatePaymentTC(string tokenCard, string customerId, string docType, string docNumber, string name, string lastName, string email, string bill, 
            string description, string value, string tax, string taxBase, string currency, string dues, string address, string phone, string cellPhone, 
            string urlResponse, string urlConfirmation, string ip)
        {
            TokenCard = tokenCard;
            CustomerId = customerId;
            DocType = docType;
            DocNumber = docNumber;
            Name = name;
            LastName = lastName;
            Email = email;
            Bill = bill;
            Description = description;
            Value = value;
            Tax = tax;
            TaxBase = taxBase;
            Phone = phone;
            CellPhone = cellPhone;
            Currency = currency;
            Dues = dues;
            Address = address;
            UrlResponse = urlResponse;
            UrlConfirmation = urlConfirmation;
            Ip = ip;
        }

        [JsonPropertyName("token_card")]
        public string TokenCard { get; set; }
        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }
        [JsonPropertyName("doc_type")]
        public string DocType { get; set; }
        [JsonPropertyName("doc_number")]
        public string DocNumber { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("bill")]
        public string Bill { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
        [JsonPropertyName("tax")]
        public string Tax { get; set; }
        [JsonPropertyName("tax_base")]
        public string TaxBase { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; } = "";
        [JsonPropertyName("cell_phone")]
        public string CellPhone { get; set; }
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        [JsonPropertyName("dues")]
        public string Dues { get; set; }
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("url_response")]
        public string UrlResponse { get; set; } = "";
        [JsonPropertyName("url_confirmation")]
        public string UrlConfirmation { get; set; } = "";
        [JsonPropertyName("ip")]
        public string Ip { get; set; } = "";

    }
}
