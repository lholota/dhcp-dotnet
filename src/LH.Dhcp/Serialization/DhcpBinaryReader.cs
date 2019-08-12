using System;

namespace LH.Dhcp.Serialization
{
    internal class DhcpBinaryReader
    {
        private int _offset;
        
        private readonly byte[] _data;
        private readonly int _limit;
        private readonly int _initialOffset;

        public DhcpBinaryReader(byte[] data)
        {
            _data = data;
            _offset = 0;
            _initialOffset = 0;
            _limit = data.Length;
        }

        public DhcpBinaryReader(byte[] data, int offset, int length)
        {
            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), "The offset must be >= 0");
            }

            if (offset >= data.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), "The offset must be < byte array length");
            }

            if (offset + length > data.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "The offset + lengthLimit must be =< byte array length");
            }

            _data = data;
            _offset = offset;
            _initialOffset = offset;
            _limit = offset + length;
        }

        public bool CanRead()
        {
            return _offset < _limit;
        }

        public void Seek(int length)
        {
            var newOffset = _offset + length;

            if (newOffset < _initialOffset || newOffset > _limit)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Cannot seek outside of the byte array length.");
            }

            _offset += length;
        }

        public bool CanRead(int length)
        {
            return (_offset + length) <= _limit;
        }

        public BinaryValue ReadValue(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "The length must be > 0.");
            }

            VerifyCanRead(length);

            var result = new BinaryValue(_data, _offset, length);

            _offset += length;

            return result;
        }

        public BinaryValue ReadValueToEnd()
        {
            VerifyCanRead(1);

            return ReadValue(_limit - _offset);
        }

        private void VerifyCanRead(int length)
        {
            if (!CanRead())
            {
                throw new InvalidOperationException("The reader is at the end of byte array and cannot read further.");
            }

            if (!CanRead(length))
            {
                throw new InvalidOperationException($"The reader has left less than {length} bytes before the end of byte array.");
            }
        }
    }
}