using System;
using System.Net;
using System.Text;

namespace LH.Dhcp.vNext.Internals
{
    internal static class BinaryConvert
    {
        public const int BooleanLength = 1;
        public const int UInt32Length = 4;
        public const int UInt16Length = 2;
        public const int IpAddressLength = 4;
        public const int Int16Length = 2;

        public static void FromString(byte[] bytes, int offset, string value)
        {
            if (value == null)
            {
                value = string.Empty;
            }

            FromString(bytes, offset, value, 0, value.Length);
        }

        public static void FromString(byte[] bytes, int offset, string value, int valueOffset, int valueLength)
        {
            if (value == null)
            {
                value = string.Empty;
            }

            ValidateInputs(bytes, offset, valueLength);

            Encoding.ASCII.GetBytes(value, valueOffset, valueLength, bytes, offset);
        }

        public static void FromBoolean(byte[] bytes, int offset, bool value)
        {
            ValidateInputs(bytes, offset, BooleanLength);

            if (value)
            {
                bytes[offset] = 0x01;
            }
            else
            {
                bytes[offset] = 0x00;
            }
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

        public static bool ToBoolean(byte[] bytes, int offset)
        {
            ValidateInputs(bytes, offset, BooleanLength);

            return bytes[offset] == 0x01;
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

        public static short ToInt16(byte[] bytes, int offset)
        {
            ValidateInputs(bytes, offset, Int16Length);

            return (short)(
                Convert.ToInt16(bytes[offset]) << 8 |
                Convert.ToInt16(bytes[offset + 1]));
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

        public static void FromUInt32(byte[] buffer, int offset, uint value)
        {
            ValidateInputs(buffer, offset, UInt32Length);

            buffer[offset] = (byte)((value >> 24) & 0xff);
            buffer[offset + 1] = (byte)((value >> 16) & 0xff);
            buffer[offset + 2] = (byte)((value >> 8) & 0xff);
            buffer[offset + 3] = (byte)(value & 0xff);
        }

        public static void FromInt16(byte[] buffer, int offset, short value)
        {
            ValidateInputs(buffer, offset, Int16Length);

            buffer[offset] = (byte)((value >> 8) & 0xff);
            buffer[offset + 1] = (byte)(value & 0xff);
        }

        public static void FromUInt16(byte[] buffer, int offset, ushort value)
        {
            ValidateInputs(buffer, offset, UInt16Length);

            buffer[offset] = (byte)((value >> 8) & 0xff);
            buffer[offset + 1] = (byte)(value & 0xff);
        }

        public static void FromIpAddress(byte[] buffer, int offset, IPAddress value)
        {
            ValidateInputs(buffer, offset, IpAddressLength);

            var addressBytes = value.GetAddressBytes();

            Array.Copy(addressBytes, 0, buffer, offset, IpAddressLength);
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

            if (valueLength < 0)
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