using System;
using System.Collections.Generic;
using System.Net;

namespace LH.Dhcp.Serialization
{
    public interface IBinaryValue
    {
        bool IsValidBoolean();

        bool AsBoolean();

        uint AsUnsignedInt32();

        ushort AsUnsignedInt16();

        IPAddress AsIpAddress();

        byte AsByte();

        string AsString();

        IReadOnlyList<IPAddress> AsIpAddressList();

        object As(Type optionType);

        bool IsValid(Type optionType);
        IReadOnlyDictionary<byte, IBinaryValue> AsTaggedValueCollection();
        bool IsValidTaggedValueCollection();
    }
}