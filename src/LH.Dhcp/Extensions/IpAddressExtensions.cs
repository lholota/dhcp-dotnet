using System.Net;

namespace LH.Dhcp.Extensions
{
    internal static class IpAddressExtensions
    {
        public static byte ToCidrPrefix(this IPAddress ipAddress)
        {
            var result = 0;
            var bytes = ipAddress.GetAddressBytes();

            for (int i = 0; i < bytes.Length; i++)
            {
                var octetByte = bytes[i];

                while (octetByte != 0)
                {
                    result += octetByte & 1;

                    octetByte >>= 1;
                }
            }

            return (byte)result;
        }
    }
}