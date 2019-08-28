using System;

namespace LH.Dhcp.vNext.Internals
{
    internal class PacketStream
    {
        private byte[] _buffer;

        public PacketStream(int initialCapacity = 500)
        {
            if (initialCapacity < 240)
            {
                throw new ArgumentException("The packet stream length must be at least 240 bytes.", nameof(initialCapacity));
            }

            _buffer = new byte[initialCapacity];

            WriteOffset = DhcpConstants.OptionsOffset;
        }

        public byte[] Buffer
        {
            get => _buffer;
        }

        public int WriteOffset { get; private set; }

        public void Allocate(int requiredSpace)
        {
            var newLength = (decimal)_buffer.Length;

            while (newLength - WriteOffset <= requiredSpace)
            {
                newLength *= 1.5m;
            }

            if (newLength > _buffer.Length)
            {
                Array.Resize(ref _buffer, (int)newLength);
            }

            WriteOffset += requiredSpace;
        }

        public byte[] ToArray()
        {
            var result = new byte[WriteOffset];

            Array.Copy(Buffer, 0, result, 0, WriteOffset);

            return result;
        }
    }
}