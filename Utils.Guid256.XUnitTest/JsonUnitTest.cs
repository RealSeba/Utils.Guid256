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
    }
}