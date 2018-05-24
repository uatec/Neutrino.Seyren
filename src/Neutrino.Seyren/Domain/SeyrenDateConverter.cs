using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Neutrino.Seyren.Domain
{
    public class SeyrenDateConverter : JsonConverter
    {
        private readonly Type[] _types;

        public SeyrenDateConverter(params Type[] types)
        {
            _types = types;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JToken t = JToken.FromObject(value);

            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
            }
            else
            {
                JObject o = (JObject)t;
                IList<string> propertyNames = o.Properties().Select(p => p.Name).ToList();

                o.AddFirst(new JProperty("Keys", new JArray(propertyNames)));

                o.WriteTo(writer);
            }
        }

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
            return _types.Any(t => t == objectType);
        }
    }
}
