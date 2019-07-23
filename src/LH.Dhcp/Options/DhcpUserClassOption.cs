using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.UserClass)]
    public class DhcpUserClassOption : IDhcpOption
    {
        public DhcpUserClassOption(IBinaryValue userClass)
        {
            UserClass = userClass;
        }

        /// <summary>
        /// The value structure depends on the specific server implementation.
        /// In ISC DHCP server, this option is always a string.
        /// For further details see <see cref="https://tools.ietf.org/html/rfc3004">RFC3004</see>.
        /// </summary>
        public IBinaryValue UserClass { get; }
    }
}