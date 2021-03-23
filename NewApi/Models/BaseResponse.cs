using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi.Models
{
    public class BaseResponse<T> where T : class
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("titleResponse")]
        public string TitleResponse { get; set; }

        [JsonPropertyName("textResponse")]
        public string TextResponse { get; set; }

        [JsonPropertyName("lastAction")]
        public string LastAction { get; set; }

        [JsonPropertyName("data")]
        public T Data { get; set; }

    }
}
