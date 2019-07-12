using System;
using LH.Dhcp.Serialization;

namespace LH.Dhcp.Options.VendorSpecificInformation
{
    public class UnknownValue
    {
        private readonly DhcpBinaryReader _reader;

        internal UnknownValue(DhcpBinaryReader reader)
        {
            _reader = reader;
        }

        public bool CanReadAsBoolean()
        {
            throw new NotImplementedException();
        }

        public bool CanReadAsUnsignedInt16()
        {
            throw new NotImplementedException();
        }

        public bool CanReadAsUnsignedInt32()
        {
            throw new NotImplementedException();
        }

        public string ReadAsAsciiString()
        {
            throw new NotImplementedException();
        }

        public byte[] ReadAsByteArray()
        {
            throw new NotImplementedException();
        }
    }
}