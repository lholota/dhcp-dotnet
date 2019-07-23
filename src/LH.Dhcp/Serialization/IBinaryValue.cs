using System;
using System.Collections.Generic;
using System.Net;

namespace LH.Dhcp.Serialization
{
    public interface IBinaryValue
    {
        bool AsBoolean();
        uint AsUnsignedInt32();
        int AsInt32();
        ushort AsUnsignedInt16();
        IReadOnlyList<ushort> AsUnsignedInt16List();
        IPAddress AsIpAddress();
        byte AsByte();
        string AsString();
        IReadOnlyList<IPAddress> AsIpAddressList();
        IReadOnlyList<Tuple<IPAddress, IPAddress>> AsIpAddressPairList();
        IReadOnlyDictionary<byte, IBinaryValue> AsTaggedValueCollection();
        byte[] AsBytes();
        object As(Type optionType);
        bool IsValid(Type optionType);
        bool IsValidBoolean();
        bool IsValidTaggedValueCollection();
        bool IsValidByte();
        bool IsValidUnsignedInt16();
        bool IsValidUnsignedInt16List();
        bool IsValidUnsignedInt32();
        bool IsValidInt32();
        bool IsValidIpAddress();
        bool IsValidIpAddressList();
        bool IsValidIpAddressPairList();
    }
}