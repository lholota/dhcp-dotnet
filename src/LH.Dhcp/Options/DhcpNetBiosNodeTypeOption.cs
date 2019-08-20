using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    public enum NetBiosNodeType : byte
    {
        /// <summary>
        /// Broadcast, no WINS
        /// </summary>
        BNode = 0x1,

        /// <summary>
        /// WINS only
        /// </summary>
        PNode = 0x2,

        /// <summary>
        /// Broadcast, then WINS
        /// </summary>
        MNode = 0x4,

        /// <summary>
        /// WINS, then broadcast
        /// </summary>
        HNode = 0x8
    }

    [DhcpOption(DhcpOptionCode.NETBIOSNodeType)]
    public class DhcpNetBiosNodeTypeOption : IDhcpOption
    {
        public DhcpNetBiosNodeTypeOption(NetBiosNodeType nodeType)
        {
            NodeType = nodeType;
        }

        [CreateOptionConstructor]
        internal DhcpNetBiosNodeTypeOption(byte value)
        {
            NodeType = (NetBiosNodeType) value;
        }

        public NetBiosNodeType NodeType { get; }
    }
}