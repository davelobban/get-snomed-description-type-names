using NUnit.Framework;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace GetSnomedRelationshipsTests
{
    public class IllustrationOfDeserialisingAStringIntoALongTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void Serialize_Long_SerializesOk()
        {
            var testSubject = new IllustrationOfDeserialisingAStringIntoALong()
            {
                LongValue = 111111111111111111
            };
            var json = JsonSerializer.Serialize(testSubject);
            //We don't really care about serialising so it doesn't matter that it uses LongValue rather than Value.
            const string expected = "{\"LongValue\":111111111111111111,\"IntValue\":0}";
            Assert.AreEqual(expected, json);
        }

        [Test]
        public void Serialize_LongAndInt_SerializesOk()
        {
            var testSubject = new IllustrationOfDeserialisingAStringIntoALong()
            {
                LongValue = 111111111111111111,
                IntValue = 111111111
            };
            var json = JsonSerializer.Serialize(testSubject);
            //We don't really care about serialising so it doesn't matter that it uses LongValue rather than Value.
            const string expected = "{\"LongValue\":111111111111111111,\"IntValue\":111111111}";
            Assert.AreEqual(expected, json);
        }

        [Test]
        public void Deserialize_LongAsString_DeserializesOk()
        {
            var value = 111111111111111111;
            var json = "{\"Value\":\"111111111111111111\"}";
            //Value is supplied as a quote-delimited value so cannot be deserialised into a long without the use of another property with a setter.
            var actual = JsonSerializer.Deserialize<IllustrationOfDeserialisingAStringIntoALong>(json);
            Assert.AreEqual(value, actual.LongValue);
            Assert.AreEqual(0, actual.IntValue);
        }

        [Test]
        public void Deserialize_LongAndIntAsStrings_DeserializesOk()
        {
            var value = 111111111111111111;
            var valueInt = 111111111;
            var json = "{\"Value\":\"111111111111111111\",\"ValueInt\":\"111111111\"}";
            //Value & ValueInt are supplied as quote-delimited values so cannot be deserialised into longs without the use of other properties with setters.
            var actual = JsonSerializer.Deserialize<IllustrationOfDeserialisingAStringIntoALong>(json);
            Assert.AreEqual(value, actual.LongValue);
            Assert.AreEqual(valueInt, actual.IntValue);
        }
       

    }
}