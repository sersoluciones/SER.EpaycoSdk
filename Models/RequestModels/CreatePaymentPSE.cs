using EpaycoSdk.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.Models.RequestModels
{
    //"{\r\n\"banco\": \"" + Auxiliars.AESEncrypt(bank, private_key) + "\",\r" +
    //               "\n\"factura\": \"" + Auxiliars.AESEncrypt(invoice, private_key) + "\",\r" +
    //               "\n\"descripcion\": \"" + Auxiliars.AESEncrypt(description, private_key) + "\",\r" +
    //               "\n\"valor\": \"" + Auxiliars.AESEncrypt(value, private_key) + "\",\r" +
    //               "\n\"iva\": \"" + Auxiliars.AESEncrypt(tax, private_key) + "\",\r" +
    //               "\n\"baseiva\": \"" + Auxiliars.AESEncrypt(tax_base, private_key) + "\",\r" +
    //               "\n\"moneda\": \"" + Auxiliars.AESEncrypt(currency, private_key) + "\",\r" +
    //               "\n\"tipo_persona\": \"" + Auxiliars.AESEncrypt(type_person, private_key) + "\",\r" +
    //               "\n\"tipo_doc\": \"" + Auxiliars.AESEncrypt(doc_type, private_key) + "\",\r" +
    //               "\n\"documento\": \"" + Auxiliars.AESEncrypt(doc_number, private_key) + "\",\r" +
    //               "\n\"nombres\": \"" + Auxiliars.AESEncrypt(name, private_key) + "\",\r" +
    //               "\n\"apellidos\": \"" + Auxiliars.AESEncrypt(last_name, private_key) + "\",\r" +
    //               "\n\"email\": \"" + Auxiliars.AESEncrypt(email, private_key) + "\",\r" +
    //               "\n\"pais\": \"" + Auxiliars.AESEncrypt(country, private_key) + "\",\r" +
    //               "\n\"celular\": \"" + Auxiliars.AESEncrypt(cell_phone, private_key) + "\",\r" +
    //               "\n\"url_respuesta\": \"" + Auxiliars.AESEncrypt(url_response, private_key) + "\",\r" +
    //               "\n\"url_confirmacion\": \"" + Auxiliars.AESEncrypt(url_confirmation, private_key) + "\",\r" +
    //               "\n\"metodoconfirmacion\": \"" + Auxiliars.AESEncrypt(method_confirmation, private_key) + "\",\r" +
    //               "\n\"extra1\": \"" + Auxiliars.AESEncrypt(extra1, private_key) + "\",\r" +
    //               "\n\"extra2\": \"" + Auxiliars.AESEncrypt(extra2, private_key) + "\",\r" +
    //               "\n\"extra3\": \"" + Auxiliars.AESEncrypt(extra3, private_key) + "\",\r" +
    //               "\n\"extra4\": \"" + Auxiliars.AESEncrypt(extra4, private_key) + "\",\r" +
    //               "\n\"extra5\": \"" + Auxiliars.AESEncrypt(extra5, private_key) + "\",\r" +
    //               "\n\"extra6\": \"" + Auxiliars.AESEncrypt(extra6, private_key) + "\",\r" +
    //               "\n\"extra7\": \"" + Auxiliars.AESEncrypt(extra7, private_key) + "\",\r" +
    //               "\n\"public_key\": \"" + public_key + "\",\r" +
    //               "\n\"enpruebas\": \"" + Auxiliars.AESEncrypt(test.ToString(), private_key) + "\",\r" +
    //               "\n\"ip\": \"" + Auxiliars.AESEncrypt(localIP, private_key) + "\",\r" +
    //               "\n\"i\": \"" + I + "\",\r" +
    //               "\n\"lenguaje\": \"" + ".net" + "\"\r\n}";
    public class CreatePaymentPSE : BasePayment
    {
        public CreatePaymentPSE(string bank, string invoice, string description, string value, string tax, string taxBase, string currency,
            string typePerson, string docType, string docNumber, string name, string lastName, string email, string country, string phone, string urlResponse,
            string urlConfirmation, string methodConfirmation)
        {
            Bank = bank;
            Invoice = invoice;
            Description = description;
            Value = value;
            Tax = tax;
            TaxBase = taxBase;
            Currency = currency;
            TypePerson = typePerson;
            DocType = docType;
            DocNumber = docNumber;
            Name = name;
            LastName = lastName;
            Email = email;
            Country = country;
            Phone = phone;
            UrlResponse = urlResponse;
            UrlConfirmation = urlConfirmation;
            MethodConfirmation = methodConfirmation;
        }

        public void ToEncrypt(string i, bool test, string publicKey, string privateKey)
        {
            PublicKey = publicKey;
            PrivateKey = privateKey;
            Test = Auxiliars.AESEncrypt(test.ToString(), privateKey);
            I = i;

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            LocalIP = host.AddressList.First(i => i.AddressFamily.ToString() == "InterNetwork").ToString();

            Bank = Auxiliars.AESEncrypt(this.Bank, privateKey);
            Invoice = Auxiliars.AESEncrypt(this.Invoice, privateKey);
            Description = Auxiliars.AESEncrypt(this.Description, privateKey);
            Value = Auxiliars.AESEncrypt(this.Value, privateKey);
            Tax = Auxiliars.AESEncrypt(this.Tax, privateKey);
            TaxBase = Auxiliars.AESEncrypt(this.TaxBase, privateKey);
            Currency = Auxiliars.AESEncrypt(this.Currency, privateKey);
            TypePerson = Auxiliars.AESEncrypt(this.TypePerson, privateKey);
            DocType = Auxiliars.AESEncrypt(this.DocType, privateKey);
            DocNumber = Auxiliars.AESEncrypt(this.DocNumber, privateKey);
            Name = Auxiliars.AESEncrypt(this.Name, privateKey);
            LastName = Auxiliars.AESEncrypt(this.LastName, privateKey);
            Email = Auxiliars.AESEncrypt(this.Email, privateKey);
            Country = Auxiliars.AESEncrypt(this.Country, privateKey);
            Phone = Auxiliars.AESEncrypt(this.Phone, privateKey);
            UrlResponse = Auxiliars.AESEncrypt(this.UrlResponse, privateKey);
            UrlConfirmation = Auxiliars.AESEncrypt(this.UrlConfirmation, privateKey);
            MethodConfirmation = Auxiliars.AESEncrypt(this.MethodConfirmation, privateKey);           
        }

        [JsonPropertyName("banco")]
        public string Bank { get; set; }
        [JsonPropertyName("pais")]
        public string Country { get; set; }      
        [JsonPropertyName("lenguaje")]
        public string Lenguaje { get; set; } = ".net";


        [JsonPropertyName("extra1")]
        public string Extra1 { get; set; } = "";
        [JsonPropertyName("extra2")]
        public string Extra2 { get; set; } = "";
        [JsonPropertyName("extra3")]
        public string Extra3 { get; set; } = "";
        [JsonPropertyName("extra4")]
        public string Extra4 { get; set; } = "";
        [JsonPropertyName("extra5")]
        public string Extra5 { get; set; } = "";
        [JsonPropertyName("extra6")]
        public string Extra6 { get; set; } = "";
        [JsonPropertyName("extra7")]
        public string Extra7 { get; set; } = "";


        [JsonIgnore]
        public string PrivateKey { get; set; }


    }
}
