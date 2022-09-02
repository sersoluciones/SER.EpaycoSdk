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
    public class CashTransaction : BaseTransaction
    {
        public CashTransaction(CashPaymentEnum paymentMethod, string description, string invoice, 
            string docType, string docNumber, string name, string lastName, string email,
            string cellPhone, string value, decimal tax, decimal taxBase, int typePerson, string ip, string urlConfirmation)
             : base(docType, docNumber, name, lastName, email, cellPhone, value, tax, taxBase, typePerson, ip, "", urlConfirmation)
        {
            PaymentMethodEnum = paymentMethod;
            Description = description;
            Invoice = invoice;
        }

        [JsonPropertyName("paymentMethod")]
        public string PaymentMethod { get => PaymentMethodEnum.ToString(); }

        [Required]
        public CashPaymentEnum PaymentMethodEnum { get; set; }

        /// <summary>
        /// fecha max para vencimiento del pago, Fecha en formato yy-mm-dd.
        /// </summary>
        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }


        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("invoice")]
        public string Invoice { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; } = "COP";

    }
}
