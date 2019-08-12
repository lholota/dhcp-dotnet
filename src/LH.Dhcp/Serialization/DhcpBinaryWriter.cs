using System;
using System.IO;

namespace LH.Dhcp.Serialization
{
    internal sealed class DhcpBinaryWriter : IDisposable
    {
        private readonly MemoryStream _memoryStream;

        public DhcpBinaryWriter()
        {
            _memoryStream = new MemoryStream();
        }

        public void WriteByte(byte value)
        {
            throw new NotImplementedException();
        }

        public void Write(BinaryValue value)
        {
            throw new NotImplementedException();
        }

        public void Write(BinaryValue value, int fixedLength)
        {
            throw new NotImplementedException();
        }

        public byte[] ToByteArray()
        {
            return _memoryStream.ToArray();
        }

        public void Dispose()
        {
            _memoryStream.Dispose();
        }
    }
}