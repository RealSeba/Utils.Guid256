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
            return this._bytes.SequenceEqual(other._bytes);
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




