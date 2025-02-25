using System;
using Xunit;

namespace SSega.Utils.Guid256.XUnitTest
{

    public class Guid256Tests
    {
        [Fact]
        public void NewGuid256_ShouldReturnUniqueInstances()
        {
            var guid1 = Guid256.NewGuid256();
            var guid2 = Guid256.NewGuid256();

            Assert.NotEqual(guid1, guid2);
        }

        [Fact]
        public void ToByteArray_ShouldReturnExact32Bytes()
        {
            var guid = Guid256.NewGuid256();
            var bytes = guid.ToByteArray();

            Assert.Equal(32, bytes.Length);
        }

        [Fact]
        public void Parse_ValidHexString_ShouldReturnGuid256()
        {
            var original = Guid256.NewGuid256();
            var hex = original.ToString();
            var parsed = Guid256.Parse(hex);

            Assert.Equal(original, parsed);
        }

        [Fact]
        public void Parse_NullOrEmptyString_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Guid256.Parse(null));
            Assert.Throws<ArgumentNullException>(() => Guid256.Parse(" "));
        }

        [Fact]
        public void Parse_InvalidHexString_ShouldThrowFormatException()
        {
            Assert.Throws<FormatException>(() => Guid256.Parse("InvalidHexString"));
        }

        [Fact]
        public void Equals_ShouldReturnTrueForIdenticalGuids()
        {
            var guid = Guid256.NewGuid256();
            var sameGuid = Guid256.Parse(guid.ToString());

            Assert.True(guid.Equals(sameGuid));
            Assert.True(guid == sameGuid);
        }

        [Fact]
        public void Equals_ShouldReturnFalseForDifferentGuids()
        {
            var guid1 = Guid256.NewGuid256();
            var guid2 = Guid256.NewGuid256();

            Assert.False(guid1.Equals(guid2));
            Assert.True(guid1 != guid2);
        }

        [Fact]
        public void CompareTo_ShouldReturnZeroForIdenticalGuids()
        {
            var guid = Guid256.NewGuid256();
            var sameGuid = Guid256.Parse(guid.ToString());

            Assert.Equal(0, guid.CompareTo(sameGuid));
        }

        [Fact]
        public void CompareTo_ShouldReturnCorrectOrder()
        {
            var bytes1 = new byte[32];
            var bytes2 = new byte[32];
            bytes2[31] = 1; // Make second GUID larger

            var guid1 = Guid256.Parse(Convert.ToHexString(bytes1));
            var guid2 = Guid256.Parse(Convert.ToHexString(bytes2));

            Assert.True(guid1 < guid2);
            Assert.True(guid2 > guid1);
        }

        [Fact]
        public void GetHashCode_IdenticalGuids_ShouldReturnSameHash()
        {
            var guid = Guid256.NewGuid256();
            var sameGuid = Guid256.Parse(guid.ToString());

            Assert.Equal(guid.GetHashCode(), sameGuid.GetHashCode());
        }

        [Fact]
        public void ToString_ShouldReturnValidHexString()
        {
            var guid = Guid256.NewGuid256();
            var hex = guid.ToString();

            Assert.Equal(64, hex.Length); // 32 bytes * 2 chars per byte
            Assert.Matches("^[0-9a-f]{64}$", hex);
        }


        [Fact]
        public void ToString_ShouldStayUnchangedUnmutable()
        {
            //arrange
            string hex1 = "55edb966e354170b4c0c607f0c99e40d135dddfdee0e55c193b5e2ab7b04a26b";
            string hex2 = "4d7cf58eae3f0a3e9d3a526ec7f382df8e0a8a1c93da6e5164c0f09a773f240a";
            string hex3 = "56d90f686b6c2372160e2b5b73766eb8a4b9a2073e5f37676a2d286cb600de9c";
            string hex4 = "ffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";
            string hex5 = "0000000000000000000000000000000000000000000000000000000000000000";
            
            //act
            Guid256 guid1 = Guid256.Parse(hex1);
            Guid256 guid2 = Guid256.Parse(hex2);
            Guid256 guid3 = Guid256.Parse(hex3);
            Guid256 guid4 = Guid256.Parse(hex4);
            Guid256 guid5 = Guid256.Parse(hex5);

            string resHex1 = guid1.ToString();
            string resHex2 = guid2.ToString();
            string resHex3 = guid3.ToString();
            string resHex4 = guid4.ToString();
            string resHex5 = guid5.ToString();

            //assert
            Assert.Equal(hex1, resHex1);
            Assert.Equal(hex2, resHex2);
            Assert.Equal(hex3, resHex3);
            Assert.Equal(hex4, resHex4);
            Assert.Equal(hex5, resHex5);
        }
    }
}
