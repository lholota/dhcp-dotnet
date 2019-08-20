using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using LH.Dhcp.vNext.Internals;

namespace LH.Dhcp.vNext
{
    public class BinaryValue
    {
        public static BinaryValue Concat(IReadOnlyList<BinaryValue> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.Count == 0)
            {
                throw new ArgumentException("The values cannot be empty.", nameof(values));
            }

            if (values.Count == 1)
            {
                return values[0];
            }

            var length = values.Sum(x => x._length);
            var combinedBytes = new byte[length];

            var offset = 0;

            foreach (var binaryValue in values)
            {
                Array.Copy(binaryValue._bytes, binaryValue._offset, combinedBytes, offset, binaryValue._length);

                offset += binaryValue._length;
            }

            return new BinaryValue(combinedBytes, 0, combinedBytes.Length);
        }

        private readonly byte[] _bytes;
        private readonly int _offset;
        private readonly int _length;

        public BinaryValue(byte[] bytes, int offset, int length)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), "The offset must be >= 0.");
            }

            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "The length must be > 0.");
            }

            if (offset + length > bytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "The offset + length must be <= byte array.");
            }

            _bytes = bytes;
            _offset = offset;
            _length = length;
        }

        public int Length
        {
            get => _length;
        }

        public byte AsByte()
        {
            if (_length != 1)
            {
                throw new InvalidOperationException($"The value has length {_length}. Single byte must have length of 1.");
            }

            return _bytes[_offset];
        }

        public byte[] AsBytes()
        {
            var result = new byte[_length];

            Array.Copy(_bytes, _offset, result, 0, _length);

            return result;
        }

        public bool AsBoolean()
        {
            throw new NotImplementedException();
        }

        public int AsInt32()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<IPAddress> AsIpAddressList()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Tuple<IPAddress, IPAddress>> AsIpAddressPairList()
        {
            throw new NotImplementedException();
        }

        public IPAddress AsIpAddress()
        {
            throw new NotImplementedException();
        }

        public string AsString()
        {
            return BinaryConvert.ToString(_bytes, _offset, _length);
        }

        public object As(Type outputType)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<ushort> AsUInt16List()
        {
            throw new NotImplementedException();
        }

        public ushort AsUnsignedInt16()
        {
            throw new NotImplementedException();
        }

        public uint AsUInt32()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<KeyValuePair<byte, BinaryValue>> AsKeyValueCollection()
        {
            throw new NotImplementedException();
        }

        public BinaryValue CreateSubsetValue(int startIndex, int length)
        {
            throw new NotImplementedException();
        }

        public bool IsValidBoolean()
        {
            throw new NotImplementedException();
        }

        public bool IsValidByte()
        {
            throw new NotImplementedException();
        }

        public bool IsValidInt32()
        {
            throw new NotImplementedException();
        }

        public bool IsValidIpAddressList()
        {
            throw new NotImplementedException();
        }

        public bool IsValidIpAddressPairList()
        {
            throw new NotImplementedException();
        }

        public bool IsValidIpAddress()
        {
            throw new NotImplementedException();
        }

        public bool IsValid(Type type)
        {
            throw new NotImplementedException();
        }

        public bool IsValidUInt16List()
        {
            throw new NotImplementedException();
        }

        public bool IsValidUInt16()
        {
            throw new NotImplementedException();
        }

        public bool IsValidUInt32()
        {
            throw new NotImplementedException();
        }

        public bool IsValidKeyValueCollection()
        {
            throw new NotImplementedException();
        }
    }
}
