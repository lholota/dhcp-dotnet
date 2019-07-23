using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.DirectoryAgent)]
    public class DhcpSlpDirectoryAgentOption : IDhcpOption
    {
        internal DhcpSlpDirectoryAgentOption(DhcpBinaryValue binaryValue)
        {
            UseMulticast = ParseIsMultiCast(binaryValue);
            AgentAddresses = ParseAgentAddresses(binaryValue);
        }

        public bool UseMulticast { get; }

        public IReadOnlyList<IPAddress> AgentAddresses { get; }

        private bool ParseIsMultiCast(DhcpBinaryValue binaryValue)
        {
            var firstByte = binaryValue.CreateSubsetValue(0, 1);

            // The negation is as per RFC https://tools.ietf.org/html/rfc2610
            return !firstByte.AsBoolean();
        }

        private IReadOnlyList<IPAddress> ParseAgentAddresses(DhcpBinaryValue binaryValue)
        {
            var addressesValue = binaryValue.CreateSubsetValue(1, binaryValue.Length - 1);

            return addressesValue.AsIpAddressList();
        }
    }
}
