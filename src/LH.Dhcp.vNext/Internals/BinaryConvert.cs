using System;
using System.Net;
using System.Text;

namespace LH.Dhcp.vNext.Internals
{
    internal static class BinaryConvert
    {
        public const int UInt32Length = 4;
        public const int UInt16Length = 2;
        public const int IpAddressLength = 4;

        public static int FromString(byte[] bytes, int startIndex, string value)
        {
            throw new NotImplementedException();
        }

        public static int FromBoolean(byte[] bytes, int startIndex, bool value)
        {
            throw new NotImplementedException();
        }

        public static string ToString(byte[] bytes, int offset, int length)
        {
            ValidateInputs(bytes, offset, length);

            for (; length > 0; length--)
            {
                if (bytes[offset + length - 1] != 0x00)
                {
                    break;
                }
            }

            return Encoding.ASCII.GetString(bytes, offset, length);
        }

        public static bool ToBoolean(byte[] bytes, int startIndex)
        {
            return bytes[startIndex] == 0x01;
        }

        public static uint ToUInt32(byte[] bytes, int offset)
        {
            ValidateInputs(bytes, offset, UInt32Length);

            return
                (Convert.ToUInt32(bytes[offset]) << 24) |
                (Convert.ToUInt32(bytes[offset + 1]) << 16) |
                (Convert.ToUInt32(bytes[offset + 2]) << 8) |
                (Convert.ToUInt32(bytes[offset + 3]));
        }

        public static ushort ToUInt16(byte[] bytes, int offset)
        {
            ValidateInputs(bytes, offset, UInt16Length);

            return (ushort)(
                (Convert.ToUInt16(bytes[offset]) << 8) |
                (Convert.ToUInt16(bytes[offset + 1])));
        }

        public static IPAddress ToIpAddress(byte[] bytes, int offset)
        {
            ValidateInputs(bytes, offset, IpAddressLength);

            var buffer = new byte[IpAddressLength];

            Array.Copy(bytes, offset, buffer, 0, IpAddressLength);

            return new IPAddress(buffer);
        }

        private static void ValidateInputs(byte[] bytes, int offset, int valueLength)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            if (offset < 0 || offset >= bytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), "The offset must be >= 0 and < byte array length.");
            }

            if (valueLength <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), "The length must be > 0.");
            }

            if (offset + valueLength > bytes.Length)
            {
                throw new ArgumentException("The offset is too far in the array, the remaining bytes in the array are shorter than the expected value.", nameof(offset));
            }
        }
    }
}