using System;
using System.Collections.Generic;
using System.Net;

namespace LH.Dhcp.Serialization.OptionSerialization
{
    public interface IValueReader
    {

    }

    internal class DhcpBinaryValueReader : IValueReader
    {
        private readonly byte[] _data;
        private readonly int _offset;
        private readonly int _length;

        public DhcpBinaryValueReader(byte[] data, int offset, int length)
        {
            _data = data;
            _offset = offset;
            _length = length;
        }

        public bool IsValidBoolean()
        {
            return _length == 1;
        }

        public bool AsBoolean()
        {
            return _data[_offset] == 0x01;
        }

        public uint AsUnsignedInt32()
        {
            throw new System.NotImplementedException();
        }

        public int AsSignedInt32()
        {
            throw new System.NotImplementedException();
        }

        public ushort AsUnsignedInt16()
        {
            throw new System.NotImplementedException();
        }

        public IPAddress AsIpAddress()
        {
            throw new System.NotImplementedException();
        }

        public byte AsByte()
        {
            throw new System.NotImplementedException();
        }

        public string AsString()
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyList<IPAddress> AsIpAddressList()
        {
            throw new System.NotImplementedException();
        }

        public object As(Type optionType)
        {
            throw new NotImplementedException();
        }

        public bool IsValid(Type optionType)
        {
            throw new NotImplementedException();
        }

        public bool IsValidValueCollection()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyDictionary<int, IValueReader> AsNestedValueCollection()
        {
            throw new NotImplementedException();
        }
    }
}