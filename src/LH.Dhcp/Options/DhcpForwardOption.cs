using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.ForwardOnOff)]
    public class DhcpForwardOption : IDhcpOption
    {
        public DhcpForwardOption(bool forward)
        {
            Forward = forward;
        }

        public bool Forward { get; }
    }
}
