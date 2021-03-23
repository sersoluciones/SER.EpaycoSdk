using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi.Models
{
    public class BaseError
    {
        [JsonPropertyName("totalerrores")]
        public int TotalErrores { get; set; }

        [JsonPropertyName("idfactura")]
        public string IdFactura { get; set; }

        [JsonPropertyName("errores")]
        public ItemError[] Errores { get; set; }
    }

    public class ItemError
    {
        [JsonPropertyName("codError")]
        public string CodError { get; set; }

        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; set; }
    }
}
