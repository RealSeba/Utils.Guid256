using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Utils.Guid256
{
    public class Guid256Converter : JsonConverter<Guid256>
    {
        public override void Write(Utf8JsonWriter writer, Guid256 value, JsonSerializerOptions options)
        {
            // Serialize as hex string (using the ToString method of Guid256)
            writer.WriteStringValue(value.ToString());
        }

        public override Guid256 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Deserialize from hex string to Guid256
            string hexString = reader.GetString() ?? string.Empty;
            return Guid256.Parse(hexString);
        }
    }

}