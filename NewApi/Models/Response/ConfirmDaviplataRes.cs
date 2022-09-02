using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi.Models.Response
{
    public class ConfirmDaviplataRes
    {
        [JsonPropertyName("refPayco")]
        public string RefEpayco { get; set; }

        /// <summary>
        /// Rechazada
        /// Aprobado
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("numApproval")]
        public string NumApproval { get; set; }

        [JsonPropertyName("idTransactionDaviplata")]
        public string IdTransactionDaviplata { get; set; }

        [JsonPropertyName("idTransactionAutorization")]
        public string IdTransactionAutorization { get; set; }

        [JsonPropertyName("response")]
        public string Response { get; set; }
    }
}
