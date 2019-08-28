namespace LH.Dhcp.vNext.Internals
{
    internal class KeyValueCollectionBuilder : IKeyValueCollectionBuilder
    {
        private int _currentSegmentOffset;
        private int _currentSegmentLengthByteOffset;

        private readonly byte _parentOptionCode;
        private readonly PacketStream _packetStream;

        public KeyValueCollectionBuilder(PacketStream packetStream, byte parentOptionCode)
        {
            _packetStream = packetStream;
            _parentOptionCode = parentOptionCode;

            StartNewSegment();
        }

        public IKeyValueCollectionBuilder WithItem(byte code, int value)
        {
            var itemLength = 2 + BinaryConvert.Int32Length;

            StartNewSegmentIfRequired(itemLength);

            var writeOffset = _packetStream.WriteOffset;

            _packetStream.Allocate(itemLength);

            _packetStream.Buffer[writeOffset] = code;
            _packetStream.Buffer[writeOffset + 1] = BinaryConvert.Int32Length;

            BinaryConvert.FromInt32(
                _packetStream.Buffer, 
                writeOffset + 2, 
                value);

            _currentSegmentOffset += itemLength;

            return this;
        }

        public IKeyValueCollectionBuilder WithItem(byte code, string value)
        {
            throw new System.NotImplementedException();
        }

        private void StartNewSegmentIfRequired(int valueLength)
        {
            if (255 - _currentSegmentOffset < valueLength)
            {
                // Not enough remaining space, start new segment

                CloseCurrentSegment();
                StartNewSegment();
            }
        }

        private void CloseCurrentSegment()
        {
            _packetStream.Buffer[_currentSegmentLengthByteOffset] = (byte)_currentSegmentOffset;
        }

        private void StartNewSegment()
        {
            var startOffset = _packetStream.WriteOffset;

            _packetStream.Allocate(2);

            _packetStream.Buffer[startOffset] = _parentOptionCode;

            _currentSegmentLengthByteOffset = startOffset + 1;
            _currentSegmentOffset = 0;
        }
    }
}