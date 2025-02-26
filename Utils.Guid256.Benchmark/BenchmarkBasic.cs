using BenchmarkDotNet.Attributes;
using System.Security.Cryptography;


namespace Utils.Guid256.Benchmark
{
    public class BenchmarkBasic
    {

        public BenchmarkBasic()
        {
        }


        
        [Benchmark]
        public Guid Guid_Create()
        {
            Guid ng = Guid.NewGuid();
            return ng;
        }

        [Benchmark]
        public Guid256 Guid256_Create()
        {
            Guid256 gn = Guid256.NewGuid256();
            return gn;
        }



        [Benchmark]
        public bool Guid_Compare_Unequal_Guid()
        {
            Guid ng1 = Guid.NewGuid();
            Guid ng2 = Guid.NewGuid();
            return ng1 == ng2;
        }

        [Benchmark]
        public bool Guid256_Compare_Unequal_Guid256()
        {
            Guid256 ng1 = Guid256.NewGuid256();
            Guid256 ng2 = Guid256.NewGuid256();
            return (ng1 == ng2);
        }
        



        Guid ng1 = new Guid("abcdef12-3456-7890-1234-567890abcdef");
        Guid ng2 = new Guid("abcdef12-3456-7890-1234-567890abcdef");

        [Benchmark]
        public bool Guid_Compare_Equal_Guid()
        {
            return ng1 == ng2;
        }
        

        Guid256 ng3 = Guid256.Parse("abcdef12345678901234567890abcdefabcdef12345678901234567890abcdef");
        Guid256 ng4 = Guid256.Parse("abcdef12345678901234567890abcdefabcdef12345678901234567890abcdef");
        [Benchmark]
        public bool Guid256_Compare_Equal_Guid256()
        {
            return ng3 == ng4;
        }
        

        [Benchmark]
        public bool Guid_Create_ToString_ParseBack()
        {
            Guid ng = Guid.NewGuid();
            string s = ng.ToString();
            Guid ng2 = Guid.Parse(s);
            return ng == ng2;
        }

        [Benchmark]
        public bool Guid256_Create_ToString_ParseBack()
        {
            Guid256 gn = Guid256.NewGuid256();
            string guid256String = gn.ToString();
            Guid256 gn2 = Guid256.Parse(guid256String);
            return gn == gn2;
        }


        /*
        [Benchmark]
        public bool Guid256_Create_ToSpan_SpanParseBack()
        {
            Guid256 gn = Guid256.NewGuid256();
            ReadOnlySpan<char> guid256String = gn.ToSpan();
            Guid256 gn2 = Guid256.Parse(guid256String);
            return gn == gn2;
        }*/

    }
}

