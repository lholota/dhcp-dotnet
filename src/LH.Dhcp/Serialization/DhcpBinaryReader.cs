using System;
using System.Net;
using System.Text;

namespace LH.Dhcp.Serialization
{
    internal class DhcpBinaryReader
    {
        private int _offset;

        private readonly byte[] _data;

        public DhcpBinaryReader(byte[] data)
        {
            _data = data;
            _offset = 0;
        }

        public bool CanRead()
        {
            return _offset < _data.Length;
        }

        public byte ReadByte()
        {
            var result = _data[_offset];

            _offset++;

            return result;
        }

        public void Seek(int length)
        {
            _offset += length;
        }

        public byte[] ReadBytes(int length)
        {
            var result = new byte[length];

            Array.Copy(_data, _offset, result, 0, length);

            Seek(length);

            return result;
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

        public int ReadInt32()
        {
            return
                (Convert.ToInt32(_data[_offset]) << 24) |
                (Convert.ToInt32(_data[_offset + 1]) << 16) |
                (Convert.ToInt32(_data[_offset + 2]) << 8) |
                (Convert.ToInt32(_data[_offset + 3]));
        }

        public ushort ReadUnsignedInt16()
        {
            var result = (ushort)(
                (Convert.ToUInt16(_data[_offset]) << 8) |
                (Convert.ToUInt16(_data[_offset + 1])));

            Seek(2);

            return result;
        }

        public IPAddress ReadIpAddress()
        {
            var ipBytes = ReadBytes(4);

            return new IPAddress(ipBytes);
        }

        public string ReadString(int length)
        {
            var result = Encoding.ASCII.GetString(_data, _offset, length).TrimEnd('\0');

            Seek(length);

            return result;
        }
    }
}