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

        internal DhcpForwardOption(DhcpBinaryValueReader valueReader)
        {
            Forward = valueReader.AsBoolean();
        }


        public bool Forward { get; }
    }
}
