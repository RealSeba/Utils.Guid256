using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Utils.Guid256.XUnitTest
{
    public class JsonUnitTest
    {

        [Fact]
        public void NewGuid256_JSON_SerializeDeserilize()
        {
            var guid1 = Guid256.NewGuid256();
            string guid1HexString = guid1.ToString();

            string json = JsonSerializer.Serialize(guid1);
            Guid256 guid2 = JsonSerializer.Deserialize<Guid256>(json);
            string guid2HexString = guid2.ToString();

            Assert.Equal(guid1HexString, guid2HexString);
        }

        [Fact]
        public void NewGuid256_JSON_SerializeDeserilize_DictionaryValue()
        {
            //arrange
            var guid1 = Guid256.NewGuid256();
            
            Dictionary<string, Guid256> dict = new Dictionary<string, Guid256>();
            dict.Add("guid1", guid1);

            string json = JsonSerializer.Serialize<Dictionary<string, Guid256>>(dict);
            Dictionary<string, Guid256> dictDeser = JsonSerializer.Deserialize<Dictionary<string, Guid256>>(json);

            //the first value guid256 string should be the same as the second one
            Assert.Equal(guid1.ToString(), dictDeser["guid1"].ToString());
        }


        [Fact]
        public void NewGuid256_JSON_SerializeDeserilize_DictionaryKey()
        {
            //arrange
            var guid1 = Guid256.NewGuid256();

            Dictionary<Guid256, string> dict = new Dictionary<Guid256, string>();
            dict.Add(guid1, "guid1");

            string json = JsonSerializer.Serialize<Dictionary<Guid256, string>>(dict);
            Dictionary<Guid256, string> dictDeser = JsonSerializer.Deserialize<Dictionary<Guid256, string>>(json);

            //the first value guid256 string should be the same as the second one
            Assert.Equal(dict.Keys.First().ToString(), dictDeser.Keys.First().ToString());
        }

    }
}