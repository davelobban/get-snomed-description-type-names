using System.Text.Json.Serialization;

namespace GetSnomedRelationshipsTests
{
    internal class IllustrationOfDeserialisingAStringIntoALong
    {
        [JsonPropertyName("Value")]
        // ReSharper disable once UnusedMember.Global
        // This *is* used, for deserialisation
        public string LongValueAsString
        {
            set => long.TryParse(value, out _longValue);
        }
        private long _longValue;
        private int _intValue;

        [JsonPropertyName("ValueInt")]
        // ReSharper disable once UnusedMember.Global
        // This *is* used, for deserialisation
        public string IntValueAsString
        {
            set => int.TryParse(value, out _intValue);
        }
        
        public long LongValue
        {
            get => _longValue;
            set => _longValue = value;
        }

        public int IntValue
        {
            get => _intValue;
            set => _intValue = value;
        }
    }
}