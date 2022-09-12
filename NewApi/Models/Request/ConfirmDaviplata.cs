using SER.EpaycoSdk.NewApi.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi.Models.Request
{
    public class ConfirmDaviplata
    {
        [Required]
        [JsonPropertyName("refPayco")]
        public string RefPayco { get; set; }
        [Required]
        [JsonPropertyName("idSessionToken")]
        public string IdSessionToken { get; set; }
        [Required]
        [JsonPropertyName("otp")]
        public string Otp { get; set; }
    }
}
