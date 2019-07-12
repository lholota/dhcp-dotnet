using System;
using System.Net;
using System.Text;

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

        public DhcpBinaryReader(byte[] data, int offset, int lengthLimit)
        {
            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), "The offset must be >= 0");
            }

            if (offset >= data.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), "The offset must be < byte array length");
            }

            if (offset + lengthLimit >= data.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(lengthLimit), "The offset + lengthLimit must be < byte array length");
            }

            _data = data;
            _offset = offset;
            _initialOffset = offset;
            _limit = offset + lengthLimit;
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
                throw new IndexOutOfRangeException("Cannot seek outside of the byte array length.");
            }

            _offset += length;
        }

        public bool CanReadByte()
        {
            throw new NotImplementedException();
        }

        public byte ReadByte()
        {
            VerifyCanRead(1);

            var result = _data[_offset];

            _offset++;

            return result;
        }

        public bool CanReadBytes(int length)
        {
            throw new NotImplementedException();
        }

        public byte[] ReadBytes(int length)
        {
            VerifyCanRead(length);

            var result = new byte[length];

            Array.Copy(_data, _offset, result, 0, length);

            Seek(length);

            return result;
        }

        public bool CanReadUnsignedInt32()
        {
            throw new NotImplementedException();
        }

        public uint ReadUnsignedInt32()
        {
            // Big Endian encoded

            var result =
                (Convert.ToUInt32(_data[_offset]) << 24) |
                (Convert.ToUInt32(_data[_offset + 1]) << 16) |
                (Convert.ToUInt32(_data[_offset + 2]) << 8) |
                (Convert.ToUInt32(_data[_offset + 3]));

            Seek(4);

            return result;
        }

        public bool CanReadInt32()
        {
            throw new NotImplementedException();
        }

        public int ReadInt32()
        {
            VerifyCanRead(4);

            return
                (Convert.ToInt32(_data[_offset]) << 24) |
                (Convert.ToInt32(_data[_offset + 1]) << 16) |
                (Convert.ToInt32(_data[_offset + 2]) << 8) |
                (Convert.ToInt32(_data[_offset + 3]));
        }

        public bool CanReadUnsignedInt16()
        {
            throw new NotImplementedException();
        }

        public ushort ReadUnsignedInt16()
        {
            var result = (ushort)(
                (Convert.ToUInt16(_data[_offset]) << 8) |
                (Convert.ToUInt16(_data[_offset + 1])));

            Seek(2);

            return result;
        }

        public bool CanReadIpAddress()
        {
            throw new NotImplementedException();
        }

        public IPAddress ReadIpAddress()
        {
            var ipBytes = ReadBytes(4);

            return new IPAddress(ipBytes);
        }

        public bool CanReadString(int length)
        {
            throw new NotImplementedException();
        }

        public string ReadString(int length)
        {
            VerifyCanRead(length);

            var result = Encoding.ASCII.GetString(_data, _offset, length).TrimEnd('\0');

            Seek(length);

            return result;
        }

        public DhcpBinaryReader CreateSubsetReader(int length)
        {
            VerifyCanRead(length);

            return new DhcpBinaryReader(_data, _offset, length);
        }

        public DhcpBinaryReader Clone()
        {
            return new DhcpBinaryReader(_data, _offset, _limit - _offset);
        }

        private bool CanRead(int length)
        {
            return (_offset + length) <= _limit;
        }

        private void VerifyCanRead(int length)
        {
            if (!CanRead())
            {
                throw new IndexOutOfRangeException("The reader is at the end of byte array and cannot read further.");
            }

            if (!CanRead(length))
            {
                throw new IndexOutOfRangeException($"The reader has left less than {length} bytes before the end of byte array.");
            }
        }
    }
}