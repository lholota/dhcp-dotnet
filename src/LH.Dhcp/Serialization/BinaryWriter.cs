using System;
using System.IO;

namespace LH.Dhcp.Serialization
{
    internal class BinaryWriter : IDisposable
    {
        private readonly MemoryStream _memoryStream;

        public BinaryWriter()
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