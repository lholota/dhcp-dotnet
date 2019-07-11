using System;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.MaxDGAssembly, typeof(DhcpUnsignedInt16OptionSerializer))]
    public class DhcpMaximumDatagramReassemblySizeOption : IDhcpOption
    {
        public ushort MaximumSize { get; }

        public DhcpMaximumDatagramReassemblySizeOption(ushort maximumSize)
        {
            if (maximumSize < 576)
            {
                throw new ArgumentOutOfRangeException(nameof(maximumSize), "The maximum datagram reassembly size must be at least 576.");
            }

            MaximumSize = maximumSize;
        }
    }
}
