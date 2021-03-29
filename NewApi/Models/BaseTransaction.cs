using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi.Models
{
    public class BaseTransaction
    {
        public BaseTransaction(string docType, string docNumber, string name, string lastName, string email, 
            string cellPhone, string value, decimal tax, decimal taxBase, int typePerson, 
            string ip, string urlResponse, string urlConfirmation)
        {
            DocType = docType;
            DocNumber = docNumber;
            Name = name;
            LastName = lastName;
            Email = email;
            CellPhone = cellPhone;
            Value = value;
            Tax = tax;
            TaxBase = taxBase;
            TypePerson = typePerson;
            Ip = ip;
            UrlResponse = urlResponse;
            UrlConfirmation = urlConfirmation;
        }

        /// <summary>
        /// CC, CE, NIT
        /// </summary>
        [JsonPropertyName("docType")]
        [Required]
        public string DocType { get; set; }

        [JsonPropertyName("docNumber")]
        [Required]
        public string DocNumber { get; set; }

        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }

        [JsonPropertyName("lastName")]
        [Required]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        [Required]
        public string Email { get; set; }

        [JsonPropertyName("cellPhone")]
        [Required]
        [StringLength(15, MinimumLength = 10)]
        public string CellPhone { get; set; }

        [JsonPropertyName("phone")]
        [StringLength(15, MinimumLength = 10)]
        public string Phone { get; set; }


        [JsonPropertyName("value")]
        [Required]
        public string Value { get; set; }

        /// <summary>
        /// IVA -> 19
        /// </summary>
        [JsonPropertyName("tax")]
        public decimal Tax { get; set; }

        [JsonPropertyName("taxBase")]
        public decimal TaxBase { get; set; }

        /// <summary>
        /// 1 -> persona
        /// 2 -> juridica
        /// </summary>
        [JsonPropertyName("typePerson")]
        public int TypePerson { get; set; } = 1;

        [JsonPropertyName("address")]
        public string Address { get; set; }



        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        [JsonPropertyName("urlResponse")]
        public string UrlResponse { get; set; }
        [JsonPropertyName("urlConfirmation")]
        public string UrlConfirmation { get; set; }
        /// <summary>
        /// GET or POST
        /// </summary>
        [JsonPropertyName("methodConfimation")]
        public string MethodConfimation { get; set; }



        [JsonPropertyName("extra1")]
        public string Extra1 { get; set; }

        [JsonPropertyName("extra2")]
        public string Extra2 { get; set; }

        [JsonPropertyName("extra3")]
        public string Extra3 { get; set; }
    }
}
