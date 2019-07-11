using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.ForwardOnOff, typeof(DhcpBooleanOptionSerializer))]
    public class DhcpForwardOption : IDhcpOption
    {
        public bool Forward { get; }

        public DhcpForwardOption(bool forward)
        {
            Forward = forward;
        }
    }
}
