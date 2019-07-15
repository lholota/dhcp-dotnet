using System;
using System.IO;

namespace LH.Dhcp.Serialization
{
    internal class DhcpBinaryWriter : IDisposable
    {
        private readonly MemoryStream _memoryStream;

        public DhcpBinaryWriter()
        {
            _memoryStream = new MemoryStream();
        }

        public byte[] GetBytes()
        {
            return _memoryStream.ToArray();
        }

        public void Dispose()
        {
            _memoryStream.Dispose();
        }
    }
}