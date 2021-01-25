using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.Models.RequestModels
{
    //"{\r\n\"factura\": \"" + invoice + "\",\r" +
    //               "\n\"descripcion\": \"" + description + "\",\r" +
    //               "\n\"valor\": \"" + value + "\",\r" +
    //               "\n\"iva\": \"" + tax + "\",\r" +
    //               "\n\"baseiva\": \"" + tax_base + "\",\r" +
    //               "\n\"moneda\": \"" + currency + "\",\r" +
    //               "\n\"tipo_persona\": \"" + type_person + "\",\r" +
    //               "\n\"tipo_doc\": \"" + doc_type + "\",\r" +
    //               "\n\"documento\": \"" + doc_number + "\",\r" +
    //               "\n\"nombres\": \"" + name + "\",\r" +
    //               "\n\"apellidos\": \"" + last_name + "\",\r" +
    //               "\n\"email\": \"" + email + "\",\r" +
    //               "\n\"celular\": \"" + cell_phone + "\",\r" +
    //               "\n\"fechaexpiracion\": \"" + end_date + "\",\r" +
    //               "\n\"url_respuesta\": \"" + url_response + "\",\r" +
    //               "\n\"url_confirmacion\": \"" + url_confirmation + "\",\r" +
    //               "\n\"metodoconfirmacion\": \"" + method_confirmation + "\",\r" +
    //               "\n\"public_key\": \"" + public_key + "\",\r" +
    //               "\n\"enpruebas\": \"" + test + "\",\r" +
    //               "\n\"ip\": \"" + localIP + "\",\r" +
    //               "\n\"i\": \"" + I + "\",\r" +
    public class CreatePaymentCash : BasePayment
    {
        public CreatePaymentCash(string invoice, string description, string value, string tax, string taxBase, 
            string currency, string typePerson, string docType, string docNumber, string name, string lastName, 
            string email, string phone, string endDate, string urlResponse, string urlConfirmation, string methodConfirmation, string type)
        {
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
            Phone = phone;
            EndDate = endDate;
            UrlResponse = urlResponse;
            UrlConfirmation = urlConfirmation;
            MethodConfirmation = methodConfirmation;
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            LocalIP = host.AddressList.First(i => i.AddressFamily.ToString() == "InterNetwork").ToString();
            Type = type;
        }

        [JsonPropertyName("fechaexpiracion")]
        public string EndDate { get; set; }


        [JsonIgnore]
        public string Type { get; set; }
    }
}
