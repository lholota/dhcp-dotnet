using System;
using LH.Dhcp.Serialization;

namespace LH.Dhcp.Options.VendorSpecificInformation
{
    public class MultiValueReader
    {
        private readonly DhcpBinaryReader _reader;

        internal MultiValueReader(DhcpBinaryReader reader)
        {
            _reader = reader;
        }

        public bool HasNextItem()
        {
            throw new NotImplementedException();
        }

        public MultiValueItemReader NextItem()
        {
            throw new NotImplementedException();
        }
    }
}