using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    public enum EthernetEncapsulation
    {
        Rfc894,
        Rfc1042
    }

    [DhcpOption(DhcpOptionTypeCode.Ethernet)]
    public class DhcpEthernetEncapsulationOption : IDhcpOption
    {
        [CreateOptionConstructor]
        internal DhcpEthernetEncapsulationOption(bool value)
        {
            EthernetEncapsulation = value
                ? EthernetEncapsulation.Rfc1042 
                : EthernetEncapsulation.Rfc894;
        }

        public DhcpEthernetEncapsulationOption(EthernetEncapsulation ethernetEncapsulation)
        {
            EthernetEncapsulation = ethernetEncapsulation;
        }

        public EthernetEncapsulation EthernetEncapsulation { get; }
    }
}