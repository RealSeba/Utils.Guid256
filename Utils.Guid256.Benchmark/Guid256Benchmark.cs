using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Guid256.Benchmark
{
    public class Guid256Benchmark
    {


        /*
        private static Guid256 Parse(ReadOnlySpan<char> input)
        {
            if (input.IsEmpty || input.IsWhiteSpace())
                throw new ArgumentNullException(nameof(input));

            try
            {
                byte[] bytes = Convert.FromHexString(input);
                return new Guid256(bytes);
            }
            catch (FormatException ex)
            {
                throw new FormatException("Invalid Guid256 format. Expected hex string.", ex);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool EqualsSequenceEqual(Guid256 other)
        {
            return this._bytes.SequenceEqual(other._bytes);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool EqualsForLoop(Guid256 other)
        {
            if (this._bytes == null || other._bytes == null) return false;
            for (int i = 0; i < 32; i++)
                if (this._bytes[i] != other._bytes[i])
                    return false;
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals256HardwareVector(Guid256 other)
        {
            if (Vector256.IsHardwareAccelerated)
            {
                return Vector256.LoadUnsafe(ref Unsafe.As<Guid256, byte>(ref Unsafe.AsRef(in this))) == Vector256.LoadUnsafe(ref Unsafe.As<Guid256, byte>(ref Unsafe.AsRef(in other)));
            }

            Vector<byte> thisVector = new Vector<byte>(this._bytes);
            Vector<byte> otherVector = new Vector<byte>(other._bytes);
            return thisVector == otherVector;
        }*/
    }
}
