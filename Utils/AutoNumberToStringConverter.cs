using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.Utils
{
    public class AutoNumberToStringConverter : JsonConverter<object>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(string) == typeToConvert;
        }

        public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                object obj;
                if (reader.TryGetInt64(out long l)) obj = l;
                else if (reader.TryGetInt32(out int n)) obj = n;
                else if (reader.TryGetDouble(out double d)) obj = d;
                else obj = reader.GetString();
                return obj?.ToString();
            }
            if (reader.TokenType == JsonTokenType.String)
            {
                return reader.GetString();
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return document.RootElement.Clone().ToString();
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
