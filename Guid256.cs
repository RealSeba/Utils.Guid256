using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace Utils.Guid256
{

    /// <summary>
    /// Guid256 is a lightweight .NET package that provides a custom implementation for working with 256-bit GUIDs.
    /// It is a struct with a custom JSON converter that handles serialization and deserialization of Guid256 values.
    /// internally it is stored in a 32 bytes array.
    /// RandomNumberGenerator.GetBytes(32) is used for random and secure bit distribution
    /// Use Guid256.NewGuid256() to generate new Guid256 values.
    /// 
    /// to bring it in perspective: assuming we create 1 000 000 000 000 ids EVERY day and somehow store them,
    /// it will take more than 1 000 000 000 000 000 000 000 000 YEARS to get the first collision on average.
    /// Do not use the default constructor. Use Guid256.NewGuid256()
    /// </summary>
    [JsonConverter(typeof(Guid256Converter))]
    public readonly struct Guid256 : IEquatable<Guid256>, IComparable<Guid256>
    {
        private readonly byte[] _bytes = new byte[32];
        #region Constructors
        public Guid256()
        {
            RandomNumberGenerator.Fill(_bytes.AsSpan());
        }
        private Guid256(ReadOnlySpan<byte> bytes)
        {
            if (bytes.IsEmpty == true) throw new ArgumentNullException(nameof(bytes));
            if (bytes.Length != 32) throw new ArgumentException("Guid256 must be 32 bytes long.", nameof(bytes));
            bytes.CopyTo(_bytes.AsSpan());
        }

        public static Guid256 NewGuid256()
        {
            return new Guid256();
        }
        #endregion

        #region Conversion
        public byte[] ToByteArray() => (byte[])_bytes.Clone();

        public ReadOnlySpan<byte> AsReadOnlySpan() => _bytes.AsSpan();

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

        #endregion

        #region Overrides & Interfaces
        public override string ToString() => Convert.ToHexStringLower(new ReadOnlySpan<byte>( _bytes) );

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            return obj is Guid256 other && Equals(other);
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

        #region Equals Methods

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Guid256 other)
        {
            return this.EqualsVector(other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool EqualsSequenceEqual(Guid256 other)
        {
            return this._bytes.SequenceEqual(other._bytes);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool EqualsVector(Guid256 other)
        {
            Vector<byte> thisVector = new Vector<byte>(this._bytes);
            Vector<byte> otherVector = new Vector<byte>(other._bytes);
            return thisVector == otherVector;
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




