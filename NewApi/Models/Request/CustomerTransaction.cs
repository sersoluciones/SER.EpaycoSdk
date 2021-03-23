using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi.Models.Request
{
    public class CustomerTransaction
    {
        public CustomerTransaction() { }
        public CustomerTransaction(string docType, string docNumber, string name, string lastName, string email,
            string cellPhone, string cardTokenId)
        {
            DocType = docType;
            DocNumber = docNumber;
            Name = name;
            LastName = lastName;
            Email = email;
            CellPhone = cellPhone;
            Phone = cellPhone;
            CardTokenId = cardTokenId;
        }

        /// <summary>
        /// CC, CE, NIT
        /// </summary>
        [JsonPropertyName("docType")]
        [Required]
        public string DocType { get; set; }

        [Required]
        [JsonPropertyName("docNumber")]
        public string DocNumber { get; set; }

        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("cellPhone")]
        public string CellPhone { get; set; }

        [Required]
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [Required]
        [JsonPropertyName("cardTokenId")]
        public string CardTokenId { get; set; }


        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }
    }
}
