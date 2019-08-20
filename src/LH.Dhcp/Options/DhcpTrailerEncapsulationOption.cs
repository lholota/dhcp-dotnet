using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.Trailers)]
    public class DhcpTrailerEncapsulationOption : IDhcpOption
    {
        public DhcpTrailerEncapsulationOption(bool negotiateTrailerEncapsulation)
        {
            NegotiateTrailerEncapsulation = negotiateTrailerEncapsulation;
        }

        public bool NegotiateTrailerEncapsulation { get; }
    }
}