using System;

namespace LH.Dhcp.Serialization
{
    internal class DhcpTaggedValueCollectionReader
    {
        private const byte PadByte = 0x00;
        private const byte EndByte = 0xff;

        private readonly DhcpBinaryReader _reader;

        public DhcpTaggedValueCollectionReader(DhcpBinaryReader reader)
        {
            _reader = reader;

            if (reader.PeekByte() == PadByte)
            {
                reader.Seek(1);
            }
        }

        public bool HasNextItem()
        {
            if (IsNextItemEndByte())
            {
                return false;
            }

            return _reader.CanRead(2);
        }

        public DhcpTaggedValue NextItem()
        {
            if (!HasNextItem())
            {
                throw new InvalidOperationException("Cannot get next item, the reader is has already reached the last item.");
            }

            var tag = _reader.ReadValue(DhcpBinaryValue.ByteLength).AsByte();
            var length = _reader.ReadValue(DhcpBinaryValue.ByteLength).AsByte();
            
            return new DhcpTaggedValue(tag, _reader.ReadValue(length));
        }

        private bool IsNextItemEndByte()
        {
            return _reader.CanRead() && _reader.PeekByte() == EndByte;
        }
    }
}
