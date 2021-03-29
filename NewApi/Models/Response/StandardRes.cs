using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi.Models.Response
{
    public class StandardRes
    {
        [JsonPropertyName("totalErrors")]
        public int TotalErrores { get; set; }

        [JsonPropertyName("errors")]
        public object Errores { get; set; }

        [JsonPropertyName("error")]
        public BaseError Error { get; set; }

        [JsonPropertyName("refEpayco")]
        public string RefEpayco { get; set; }

        [JsonPropertyName("invoice")]
        public string Invoice { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        /// <summary>
        /// IVA -> 19
        /// </summary>
        [JsonPropertyName("tax")]
        public string Tax { get; set; }

        [JsonPropertyName("taxBase")]
        public string TaxBase { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("bank")]
        public string Bank { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("stateMessage")]
        public string StateMessage { get; set; }

        [JsonPropertyName("authorizationCode")]
        public string AuthorizationCode { get; set; }

        [JsonPropertyName("receipt")]
        public string Receipt { get; set; }

        [JsonPropertyName("dateTime")]
        public string DateTime { get; set; }

        [JsonPropertyName("channel")]
        public string Channel { get; set; }

        [JsonPropertyName("responseCode")]
        public int ResponseCode { get; set; }

        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        [JsonPropertyName("test")]
        public long Test { get; set; }

        [JsonPropertyName("docType")]
        public string DocType { get; set; }

        [JsonPropertyName("docNumber")]
        public string DocNumber { get; set; }

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

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("urlRedirect")]
        public string UrlRedirect { get; set; }
    }
}
