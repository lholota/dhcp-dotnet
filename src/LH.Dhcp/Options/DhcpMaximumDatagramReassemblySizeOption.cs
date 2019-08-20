using System;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.MaxDGAssembly)]
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
