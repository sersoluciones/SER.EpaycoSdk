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
    public class StandardTransaction : BaseTransaction
    {
        public StandardTransaction(StandarChannel channelEnum, string department, string city,
            string description, string invoice, string docType, string docNumber, string name, string lastName, string email,
            string cellPhone, string value, decimal tax, decimal taxBase, int typePerson, string ip, string urlResponse, string urlConfirmation)
             : base(docType, docNumber, name, lastName, email, cellPhone, value, tax, taxBase, typePerson, ip, urlResponse, urlConfirmation)
        {
            ChannelEnum = channelEnum;
            Country = "CO";
            Department = department;
            City = city;
            Description = description;
            Invoice = invoice;
        }

        [JsonPropertyName("channel")]
        public string Channel { get => ChannelEnum.ToString(); }

        [Required]
        public StandarChannel ChannelEnum { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("department")]
        public string Department { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("invoice")]
        public string Invoice { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; } = "COP";

        [JsonPropertyName("openPayment")]
        public bool OpenPayment { get; set; } = true;

    }
}
