using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi.Models.Response
{
    public class BankRes
    {
        [JsonPropertyName("bankCode")]
        public string BankCode { get; set; }

        [JsonPropertyName("bankName")]
        public string BankName { get; set; }

    }
}
