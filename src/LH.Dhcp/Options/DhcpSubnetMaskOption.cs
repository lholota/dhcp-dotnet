using System;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.SubnetMask, typeof(DhcpIpAddressOptionSerializer))]
    public class DhcpSubnetMaskOption : DhcpOptionBase<IPAddress>
    {
        public DhcpSubnetMaskOption(IPAddress value) 
            : base(value)
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
