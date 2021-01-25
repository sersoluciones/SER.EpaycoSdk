using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.Models.RequestModels
{
    //"{\n\"token_card\":\"" + token_card + "\"," +
    //            "\n\"name\":\"" + name + "\"," +
    //            "\n\"last_name\":\"" + last_name + "\"," +
    //            "\n\"email\":\"" + email + "\"," +
    //            "\n\"default\":\"" + isDefault + "\"," +
    //            "\n\"city\":\"" + city + "\"," +
    //            "\n\"address\":\"" + address + "\"," +
    //            "\n\"phone\":\"" + phone + "\"," +
    //            "\n\"cell_phone\":\"" + cell_phone + "\"\n}";
    public class CreateCustomer
    {
        public CreateCustomer(string tokenCard, string name, string lastName, string email, string isDefault, string city, 
            string address, string phone, string cellPhone)
        {
            TokenCard = tokenCard;
            Name = name;
            LastName = lastName;
            Email = email;
            IsDefault = isDefault;
            City = city;
            Address = address;
            Phone = phone;
            CellPhone = cellPhone;
        }

        [JsonPropertyName("token_card")]
        public string TokenCard { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("default")]
        public string IsDefault { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("address")]
        public string Address { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("cell_phone")]
        public string CellPhone { get; set; }

    }
}
