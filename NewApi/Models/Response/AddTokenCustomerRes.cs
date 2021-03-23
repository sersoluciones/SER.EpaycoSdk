using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi.Models.Response
{
    public class AddTokenCustomerRes
    {
        [JsonPropertyName("totalErrors")]
        public int TotalErrores { get; set; }

        [JsonPropertyName("errors")]
        public object Errores { get; set; }

        [JsonPropertyName("error")]
        public AddTokenCustomerError error { get; set; }

        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("object")]
        public string Object { get; set; }
    }

    public class AddTokenCustomerError
    {
        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("object")]
        public string Object { get; set; }
    }
}
