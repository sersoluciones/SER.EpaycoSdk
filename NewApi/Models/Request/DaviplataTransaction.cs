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
    public class DaviplataTransaction : BaseTransaction
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="document"></param>
        /// <param name="city"></param>
        /// <param name="description"></param>
        /// <param name="invoice"></param>
        /// <param name="docType"></param>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="cellPhone"></param>
        /// <param name="value"></param>
        /// <param name="tax"></param>
        /// <param name="taxBase"></param>
        /// <param name="typePerson"></param>
        /// <param name="ip"></param>
        /// <param name="urlConfirmation"></param>
        /// <param name="testMode"></param>
        public DaviplataTransaction(string document, string city, string description, string invoice, 
            string docType, string name, string lastName, string email,
            string cellPhone, string value, decimal tax, decimal taxBase, int typePerson, string ip, string urlConfirmation,
            bool testMode = false)
             : base(docType, document, name, lastName, email, cellPhone, value, tax, taxBase, typePerson, ip, null, urlConfirmation)
        {
            TestMode = testMode;
            Document = document;
            City = city;
            Description = description;
            Invoice = invoice;
            MethodConfimation = "GET";
        }

        /// <summary>
        /// número de documento del cliente.
        /// </summary>
        [JsonPropertyName("document")]
        public string Document { get; set; }

        /// <summary>
        /// Descripción de la transacción.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Número de Factura. opcional
        /// </summary>
        [JsonPropertyName("invoice")]
        public string Invoice { get; set; }

        /// <summary>
        /// Tipo de moneda (COP o USD) en caso de no enviar este parámetro se asigna COP por default.
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = "COP";


        [JsonPropertyName("country")]
        public string Country { get; set; } = "CO";

        /// <summary>
        /// Código del país (para obtener el código del país puede consultar el endpoint paises)
        /// </summary>
        [JsonPropertyName("indCountry")]
        public string IndCountry { get; set; } = "CO";

        /// <summary>
        /// Ciudad del cliente.
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// Indica si la transacción es una prueba, por defecto tiene el valor false.

        /// </summary>
        [JsonPropertyName("testMode")]
        public bool TestMode { get; set; }

    }
}
