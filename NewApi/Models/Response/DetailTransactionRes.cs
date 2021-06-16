using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi.Models.Response
{   
    public class DetailTransactionRes
    {
        [JsonPropertyName("referencePayco")]
        public string ReferencePayco { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("tax")]
        public string Tax { get; set; }

        [JsonPropertyName("transactionDate")]
        public string TransactionDate { get; set; }

        [JsonPropertyName("taxBaseClient")]
        public long TaxBaseClient { get; set; }

        [JsonPropertyName("response")]
        public string Response { get; set; }

        [JsonPropertyName("bill")]
        public string Bill { get; set; }

        [JsonPropertyName("authorization")]
        public string Authorization { get; set; }

        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        [JsonPropertyName("paymentMethod")]
        public string PaymentMethod { get; set; }

        [JsonPropertyName("bank")]
        public string Bank { get; set; }

        [JsonPropertyName("numberCard")]
        public string NumberCard { get; set; }

        [JsonPropertyName("document")]
        public string Document { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("department")]
        public string Department { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("telephone")]
        public string Telephone { get; set; }

        [JsonPropertyName("mobilePhone")]
        public string MobilePhone { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("log")]
        public Log Log { get; set; }
    }

    public partial class Log
    {
        [JsonPropertyName("x_cust_id_cliente")]
        public string XCustIdCliente { get; set; }

        [JsonPropertyName("x_ref_payco")]
        public string XRefPayco { get; set; }

        [JsonPropertyName("x_id_factura")]
        public string XIdFactura { get; set; }

        [JsonPropertyName("x_id_invoice")]
        public string XIdInvoice { get; set; }

        [JsonPropertyName("x_description")]
        public string XDescription { get; set; }

        [JsonPropertyName("x_amount")]
        public string XAmount { get; set; }

        [JsonPropertyName("x_amount_country")]
        public string XAmountCountry { get; set; }

        [JsonPropertyName("x_amount_ok")]
        public string XAmountOk { get; set; }

        [JsonPropertyName("x_tax")]
        public string XTax { get; set; }

        [JsonPropertyName("x_amount_base")]
        public string XAmountBase { get; set; }

        [JsonPropertyName("x_currency_code")]
        public string XCurrencyCode { get; set; }

        [JsonPropertyName("x_bank_name")]
        public string XBankName { get; set; }

        [JsonPropertyName("x_cardnumber")]
        public string XCardnumber { get; set; }

        [JsonPropertyName("x_quotas")]
        public string XQuotas { get; set; }

        [JsonPropertyName("x_respuesta")]
        public string XRespuesta { get; set; }

        [JsonPropertyName("x_response")]
        public string XResponse { get; set; }

        [JsonPropertyName("x_approval_code")]
        public string XApprovalCode { get; set; }

        [JsonPropertyName("x_transaction_id")]
        public string XTransactionId { get; set; }

        [JsonPropertyName("x_fecha_transaccion")]
        public string XFechaTransaccion { get; set; }

        [JsonPropertyName("x_transaction_date")]
        public string XTransactionDate { get; set; }

        [JsonPropertyName("x_cod_respuesta")]
        public int CodRespuesta { get; set; }

        [JsonPropertyName("x_cod_response")]
        public int CodResponse { get; set; }
    }
}
