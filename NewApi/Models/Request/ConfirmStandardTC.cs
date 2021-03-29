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
    public class ConfirmStandardTC
    {
        public ConfirmStandardTC(StandarChannel channelEnum, string value, string currentStatusTransaction, string refEpayco, string authorizationCode)
        {
            ChannelEnum = channelEnum;
            Value = value;
            CurrentStatusTransaction = currentStatusTransaction;
            RefEpayco = refEpayco;
            AuthorizationCode = authorizationCode;
        }

        [JsonPropertyName("channel")]
        public string Channel { get => ChannelEnum.ToString(); }

        [Required]
        public StandarChannel ChannelEnum { get; set; }


        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("currentStatusTransaction")]
        public string CurrentStatusTransaction { get; set; }

        [JsonPropertyName("statusTransaction")]
        public string StatusTransaction { get; set; } = "Aceptada";

        [JsonPropertyName("refEpayco")]
        public string RefEpayco { get; set; }

        [JsonPropertyName("authorizationCode")]
        public string AuthorizationCode { get; set; }

        [JsonPropertyName("openPayment")]
        public bool OpenPayment { get; set; } = true;

        [JsonPropertyName("bank")]
        public bool Bank { get; set; } = false;
    }
}
