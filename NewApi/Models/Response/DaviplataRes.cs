using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi.Models.Response
{
    public class DaviplataRes
    {
        [JsonPropertyName("refPayco")]
        public string RefEpayco { get; set; }

        [JsonPropertyName("invoice")]
        public string Invoice { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("value")]
        public long Value { get; set; }

        [JsonPropertyName("tax")]
        public long Tax { get; set; }

        [JsonPropertyName("ico")]
        public long Ico { get; set; }

        [JsonPropertyName("taxBase")]
        public long TaxBase { get; set; }

        [JsonPropertyName("netoValue")]
        public long NetoValue { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("bank")]
        public string Bank { get; set; }
        /// <summary>
        /// Pendiente
        /// Rechazada
        /// </summary>
        [JsonPropertyName("estatus")]
        public string Estatus { get; set; }

        [JsonPropertyName("response")]
        public string Response { get; set; }

        [JsonPropertyName("autorization")]
        public string Autorization { get; set; }

        [JsonPropertyName("receipt")]
        public string Receipt { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("franchise")]
        public string Franchise { get; set; }
        /// <summary>
        /// empty -> rechazado
        /// 3 -> pendiente
        /// </summary>
        [JsonPropertyName("codResponse")]
        public string CodResponse { get; set; }

        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        [JsonPropertyName("testMode")]
        public int TestMode { get; set; }

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
        public string IndCountry { get; set; }

        [JsonPropertyName("idSessionToken")]
        public string IdSessionToken { get; set; }

        [JsonPropertyName("tokenExpirationDate")]
        public string TokenExpirationDate { get; set; }

        [JsonPropertyName("daviplataOtpLab")]
        public object DaviplataOtpLab { get; set; }



        [JsonPropertyName("totalErrors")]
        public int? TotalErrores { get; set; }

        [JsonPropertyName("errors")]
        public ItemError[] Errores { get; set; }

        [JsonPropertyName("error")]
        public BaseError Error { get; set; }
    }
}
