using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Neutrino.Seyren.Domain
{
    public class SeyrenDateConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if ( reader.TokenType == JsonToken.Integer )
            {
                return DateTime.FromBinary((long) reader.ReadAsInt32());
            }
            else if ( reader.TokenType == JsonToken.String )
            {
                return DateTime.Parse(reader.ReadAsString());
            }

            throw new InvalidOperationException($"Unable to parse ${reader.ReadAsString()} to DateTiime.");
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTimeOffset);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(((DateTimeOffset) value).ToUnixTimeMilliseconds().ToString());
        }
    }
}
