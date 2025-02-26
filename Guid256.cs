using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace Utils.Guid256
{
    [JsonConverter(typeof(Guid256Converter))]
    public readonly struct Guid256 : IEquatable<Guid256>, IComparable<Guid256>
    {
        private readonly byte[] _bytes; // 32 bytes = 256 bits
        #region Constructors
        public Guid256()
        {
            //byte[] bytes = RandomNumberGenerator.GetBytes(32); // Secure random
        }
        private Guid256(byte[] bytes)
        {
            if (bytes is null) throw new ArgumentNullException(nameof(bytes));
            if (bytes.Length != 32) throw new ArgumentException("Guid256 must be 32 bytes long.", nameof(bytes));

            _bytes = new byte[32];
            Array.Copy(bytes, _bytes, 32);
        }

        public static Guid256 NewGuid256()
        {
            byte[] bytes = RandomNumberGenerator.GetBytes(32); // Secure random
            return new Guid256(bytes);
        }
        #endregion

        #region Conversion
        public byte[] ToByteArray() => (byte[])_bytes.Clone();

        public ReadOnlySpan<char> ToSpan() => Encoding.UTF8.GetString(_bytes.AsSpan());

        public static Guid256 Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException(nameof(input));

            try
            {
                byte[] bytes = Convert.FromHexString( input );
                return new Guid256(bytes);
            }
            catch (FormatException ex)
            {
                throw new FormatException("Invalid Guid256 format. Expected hex string.", ex);
            }
        }


        public static Guid256 Parse(ReadOnlySpan<char> input)
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

        #endregion

        #region Overrides & Interfaces
        public override string ToString() => Convert.ToHexStringLower(new ReadOnlySpan<byte>( _bytes) );

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            return obj is Guid256 other && Equals(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Guid256 other)
        {
            return EqualsCore(this, other);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private static bool EqualsCore2(Guid256 self, Guid256 other)
        {
            if (self._bytes == null || other._bytes == null) return false;
            return self._bytes[0] == other._bytes[0]
                && self._bytes[1] == other._bytes[1]
                && self._bytes[2] == other._bytes[2]
                && self._bytes[3] == other._bytes[3]
                && self._bytes[4] == other._bytes[4]
                && self._bytes[5] == other._bytes[5]
                && self._bytes[6] == other._bytes[6]
                && self._bytes[7] == other._bytes[7]
                && self._bytes[8] == other._bytes[8]
                && self._bytes[9] == other._bytes[9]
                && self._bytes[10] == other._bytes[10]
                && self._bytes[11] == other._bytes[11]
                && self._bytes[12] == other._bytes[12]
                && self._bytes[13] == other._bytes[13]
                && self._bytes[14] == other._bytes[14]
                && self._bytes[15] == other._bytes[15]
                && self._bytes[16] == other._bytes[16]
                && self._bytes[17] == other._bytes[17]
                && self._bytes[18] == other._bytes[18]
                && self._bytes[19] == other._bytes[19]
                && self._bytes[20] == other._bytes[20]
                && self._bytes[21] == other._bytes[21]
                && self._bytes[22] == other._bytes[22]
                && self._bytes[23] == other._bytes[23]
                && self._bytes[24] == other._bytes[24]
                && self._bytes[25] == other._bytes[25]
                && self._bytes[26] == other._bytes[26]
                && self._bytes[27] == other._bytes[27]
                && self._bytes[28] == other._bytes[28]
                && self._bytes[29] == other._bytes[29]
                && self._bytes[30] == other._bytes[30]
                && self._bytes[31] == other._bytes[31];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool EqualsCore(Guid256 self, Guid256 other)
        {
            if (self._bytes == null || other._bytes == null) return false;
            for (int i = 0; i < 32; i++)
                if (self._bytes[i] != other._bytes[i])
                    return false;
            return true;
        }

        public override int GetHashCode()
        {
            // Use XOR of integer chunks for a reasonable hash
            return BitConverter.ToInt32(_bytes, 0) ^
                   BitConverter.ToInt32(_bytes, 4) ^
                   BitConverter.ToInt32(_bytes, 8) ^
                   BitConverter.ToInt32(_bytes, 12) ^
                   BitConverter.ToInt32(_bytes, 16) ^
                   BitConverter.ToInt32(_bytes, 20) ^
                   BitConverter.ToInt32(_bytes, 24) ^
                   BitConverter.ToInt32(_bytes, 28);
        }

        public int CompareTo(Guid256 other)
        {
            for (int i = 0; i < 32; i++)
            {
                int comparison = _bytes[i].CompareTo(other._bytes[i]);
                if (comparison != 0) return comparison;
            }
            return 0;
        }
        #endregion

        #region Operators
        public static bool operator ==(Guid256 left, Guid256 right) => left.Equals(right);
        public static bool operator !=(Guid256 left, Guid256 right) => !left.Equals(right);
        public static bool operator <(Guid256 left, Guid256 right) => left.CompareTo(right) < 0;
        public static bool operator >(Guid256 left, Guid256 right) => left.CompareTo(right) > 0;
        #endregion
    }
}




