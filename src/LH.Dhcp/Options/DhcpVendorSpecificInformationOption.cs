using System;
using LH.Dhcp.Serialization;

namespace LH.Dhcp.Options
{
    public class DhcpVendorSpecificInformationOption : IDhcpOption
    {
        public DhcpVendorSpecificInformationOption(byte[] bytes)
        {
            
        }

        public SingleValueReader CreateSingleValueReader()
        {
            throw new NotImplementedException();
        }

        public MultiValueReader CreateMultiValueReader()
        {
            // MultiValue reader -> move option by option, pass a delegate

            throw new NotImplementedException();
        }
    }

    public class MultiValueReader
    {
        private readonly DhcpBinaryReader _reader;

        public MultiValueReader(byte[] bytes)
        {
            _reader = new DhcpBinaryReader(bytes);
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

    public class MultiValueItemReader : SingleValueReader
    {
        public MultiValueItemReader(byte itemCode, byte[] valueBytes) 
            : base(valueBytes)
        {
            ItemCode = itemCode;
        }

        public byte ItemCode { get; }
    }

    public class SingleValueReader
    {
        private readonly DhcpBinaryReader _reader;

        public SingleValueReader(byte[] bytes)
        {
            _reader = new DhcpBinaryReader(bytes);
        }

        public byte ItemLength { get; }

        public string ReadAsString()
        {
            throw new NotImplementedException();
        }

        public byte[] ReadAsByteArray()
        {
            throw new NotImplementedException();
        }

        // ....
    }
}