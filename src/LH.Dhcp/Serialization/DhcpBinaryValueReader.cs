using System;
using System.Collections.Generic;
using System.Net;

namespace LH.Dhcp.Serialization
{
    internal class DhcpBinaryValueReader : IBinaryValueReader
    {
        private const int BooleanLength = 1;
        private const int ByteLength = 1;
        private const int Int32Length = 4;
        private const int UnsignedInt16Length = 2;
        private const int UnsignedInt32Length = 4;
        private const int IpAddressLength = 4;

        private readonly byte[] _data;
        private readonly int _offset;
        private readonly int _length;

        public DhcpBinaryValueReader(byte[] data, int offset, int length)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), "The offset must be greater or equal to zero.");
            }

            if (offset + length > data.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "The length end outside of the bounds of the data array.");
            }

            _data = data;
            _offset = offset;
            _length = length;
        }

        public bool AsBoolean()
        {
            if (!IsValidBoolean())
            {
                throw new InvalidOperationException("Cannot read binary value as Boolean. The value is not a valid Boolean.");
            }

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

        public int AsInt32()
        {
            if (!IsValidInt32())
            {
                throw new InvalidOperationException("Cannot read binary value as Int32. The value is not a valid Int32.");
            }

            return
                (Convert.ToInt32(_data[_offset]) << 24) |
                (Convert.ToInt32(_data[_offset + 1]) << 16) |
                (Convert.ToInt32(_data[_offset + 2]) << 8) |
                (Convert.ToInt32(_data[_offset + 3]));
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
            if (!IsValidByte())
            {
                throw new InvalidOperationException("Cannot read binary value as Byte. The value is not a valid Byte.");
            }

            return _data[_offset];
        }

        public string AsString()
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyList<IPAddress> AsIpAddressList()
        {
            throw new System.NotImplementedException();
        }

        public IReadOnlyList<Tuple<IPAddress, IPAddress>> AsIpAddressPairList()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyDictionary<int, IBinaryValueReader> AsValueCollection()
        {
            throw new NotImplementedException();
        }

        public object As(Type optionType)
        {
            throw new NotImplementedException();
        }

        public bool IsValid(Type optionType)
        {
            throw new NotImplementedException();
        }

        public bool IsValidBoolean()
        {
            return _length == BooleanLength;
        }

        public bool IsValidValueCollection()
        {
            var index = _offset;
            var limit = _offset + _length - 1;
            var valueTags = new bool[byte.MaxValue];

            while (index <= limit)
            {
                var valueTag = _data[index];

                if (valueTag == 0)
                {
                    index++; //Skip padding byte

                    continue;
                }

                if (valueTag == 255)
                {
                    break;
                }

                if (valueTags[valueTag])
                {
                    return false; // Tag has already been seen once
                }

                valueTags[valueTag] = true;

                index++; // Jump to the value length

                if (index >= limit)
                {
                    return false;
                }

                var valueLength = _data[index];

                index += valueLength;

                if (index > limit)
                {
                    return false;
                }

                index++;
            }

            return true;
        }

        public bool IsValidByte()
        {
            return _length == ByteLength;
        }

        public bool IsValidUnsignedInt16()
        {
            return _length == UnsignedInt16Length;
        }

        public bool IsValidUnsignedInt32()
        {
            return _length == UnsignedInt32Length;
        }

        public bool IsValidInt32()
        {
            return _length == Int32Length;
        }

        public bool IsValidIpAddress()
        {
            return _length == IpAddressLength;
        }

        public bool IsValidIpAddressList()
        {
            return _length > 0 && _length % IpAddressLength == 0;
        }
    }
}