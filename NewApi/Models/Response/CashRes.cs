using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi.Models.Response
{
    public class CashRes
    {
        [JsonPropertyName("totalErrors")]
        public int TotalErrores { get; set; }

        [JsonPropertyName("errors")]
        public ItemError[] Errores { get; set; }

        [JsonPropertyName("error")]
        public BaseError Error { get; set; }

        [JsonPropertyName("transaction")]
        public Transaction Transaction { get; set; }
    }

    public class Transaction
    {
        [JsonPropertyName("refPayco")]
        public string RefPayco { get; set; }

        [JsonPropertyName("invoice")]
        public string Invoice { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("value")]
        public decimal Value { get; set; }

        [JsonPropertyName("tax")]
        public decimal Tax { get; set; }

        [JsonPropertyName("ico")]
        public decimal Ico { get; set; }

        [JsonPropertyName("taxBase")]
        public int TaxBase { get; set; }

        [JsonPropertyName("valueNeto")]
        public decimal ValueNeto { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("bank")]
        public string Bank { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("response")]
        public string Response { get; set; }

        [JsonPropertyName("autorization")]
        public string Autorization { get; set; }

        [JsonPropertyName("receipt")]
        public long Receipt { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("paymentMethod")]
        public string PaymentMethod { get; set; }

        [JsonPropertyName("codResponse")]
        public string CodResponse { get; set; }

        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        [JsonPropertyName("testMode")]
        public long TestMode { get; set; }

        [JsonPropertyName("docType")]
        public string DocType { get; set; }

        [JsonPropertyName("document")]
        public string Document { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("indCountry")]
        public object IndCountry { get; set; }

        [JsonPropertyName("pin")]
        public string Pin { get; set; }

        [JsonPropertyName("codeProject")]
        public object CodeProject { get; set; }

        [JsonPropertyName("paymentDate")]
        public string PaymentDate { get; set; }

        [JsonPropertyName("expirationDate")]
        public string ExpirationDate { get; set; }

        [JsonPropertyName("conversionFactor")]
        public double ConversionFactor { get; set; }

        [JsonPropertyName("valuePesos")]
        public long ValuePesos { get; set; }
    }
}
