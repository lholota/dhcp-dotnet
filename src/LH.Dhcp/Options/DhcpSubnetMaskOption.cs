using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.SubnetMask)]
    public class DhcpSubnetMaskOption : IDhcpOption
    {
        public DhcpSubnetMaskOption(IPAddress value)
        {
            SubnetMask = value;
            CidrPrefix = GetCidrPrefix(value);
        }

        public IPAddress SubnetMask { get; }

        public uint CidrPrefix { get; }

        private uint GetCidrPrefix(IPAddress ipAddress)
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

            return (uint)result;
        }
    }
}
