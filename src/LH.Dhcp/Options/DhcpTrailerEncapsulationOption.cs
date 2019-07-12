using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.Trailers, typeof(DhcpBooleanOptionSerializer))]
    public class DhcpTrailerEncapsulationOption : IDhcpOption
    {
        public DhcpTrailerEncapsulationOption(bool negotiateTrailerEncapsulation)
        {
            NegotiateTrailerEncapsulation = negotiateTrailerEncapsulation;
        }

        public bool NegotiateTrailerEncapsulation { get; }
    }
}