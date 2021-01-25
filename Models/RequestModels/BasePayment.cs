using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.Models.RequestModels
{
    public class BasePayment
    {
        [JsonPropertyName("factura")]
        public string Invoice { get; set; }
        [JsonPropertyName("descripcion")]
        public string Description { get; set; }
        [JsonPropertyName("valor")]
        public string Value { get; set; }
        [JsonPropertyName("iva")]
        public string Tax { get; set; }
        [JsonPropertyName("baseiva")]
        public string TaxBase { get; set; }
        [JsonPropertyName("moneda")]
        public string Currency { get; set; }
        [JsonPropertyName("tipo_persona")]
        public string TypePerson { get; set; }

        [JsonPropertyName("tipo_doc")]
        public string DocType { get; set; }
        [JsonPropertyName("documento")]
        public string DocNumber { get; set; }
        [JsonPropertyName("nombres")]
        public string Name { get; set; }
        [JsonPropertyName("apellidos")]
        public string LastName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("celular")]
        public string Phone { get; set; }


        [JsonPropertyName("url_respuesta")]
        public string UrlResponse { get; set; }
        [JsonPropertyName("url_confirmacion")]
        public string UrlConfirmation { get; set; }
        [JsonPropertyName("metodoconfirmacion")]
        public string MethodConfirmation { get; set; }



        [JsonPropertyName("public_key")]
        public string PublicKey { get; set; }
        [JsonPropertyName("enpruebas")]
        public string Test { get; set; }
        [JsonPropertyName("ip")]
        public string LocalIP { get; set; }
        [JsonPropertyName("i")]
        public string I { get; set; }
    }
}
