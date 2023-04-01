using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi.Models.Response
{
    public class PseRes
    {
        [JsonPropertyName("totalErrors")]
        public int TotalErrores { get; set; }

        [JsonPropertyName("errors")]
        public object Errores { get; set; }

        [JsonPropertyName("error")]
        public object Error { get; set; }


        [JsonPropertyName("ref_payco")]
        public string RefPayco { get; set; }

        [JsonPropertyName("factura")]
        public string Factura { get; set; }

        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }

        [JsonPropertyName("valor")]
        public string Valor { get; set; }

        [JsonPropertyName("iva")]
        public string Iva { get; set; }

        [JsonPropertyName("baseiva")]
        public string Baseiva { get; set; }

        [JsonPropertyName("moneda")]
        public string Moneda { get; set; }

        [JsonPropertyName("banco")]
        public string Banco { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; }

        [JsonPropertyName("respuesta")]
        public string Respuesta { get; set; }

        [JsonPropertyName("autorizacion")]
        public string Autorizacion { get; set; }

        [JsonPropertyName("recibo")]
        public string Recibo { get; set; }

        [JsonPropertyName("fecha")]
        public string Fecha { get; set; }

        [JsonPropertyName("urlbanco")]
        public string Urlbanco { get; set; }

        [JsonPropertyName("transactionID")]
        public string TransactionId { get; set; }

        [JsonPropertyName("ticketId")]
        public string TicketId { get; set; }


        [JsonPropertyName("franquicia")]
        public string Franquicia { get; set; }

        [JsonPropertyName("cod_respuesta")]
        public long CodRespuesta { get; set; }

        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        [JsonPropertyName("enpruebas")]
        public long Enpruebas { get; set; }

        [JsonPropertyName("tipo_doc")]
        public string TipoDoc { get; set; }

        [JsonPropertyName("documento")]
        public string Documento { get; set; }

        [JsonPropertyName("nombres")]
        public string Nombres { get; set; }

        [JsonPropertyName("apellidos")]
        public string Apellidos { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("ciudad")]
        public string Ciudad { get; set; }

        [JsonPropertyName("direccion")]
        public string Direccion { get; set; }

        [JsonPropertyName("ind_pais")]
        public string IndPais { get; set; }

    }
}
