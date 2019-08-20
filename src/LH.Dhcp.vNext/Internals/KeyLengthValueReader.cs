using System;

namespace LH.Dhcp.vNext.Internals
{
    internal class KeyLengthValueReader
    {
        private const int InitialIndex = -1;

        private readonly byte[] _bytes;
        private readonly int _offset;
        private readonly int _limit;

        private int _currentIndex;

        public KeyLengthValueReader(byte[] bytes, int offset, int length)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            if (bytes.Length < 2)
            {
                throw new ArgumentException("The byte array must be at least two bytes long.");
            }

            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), "The offset must be >= 0 and < length of byte array.");
            }

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), "The length must be >= 0.");
            }

            if (offset + length > bytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "The offset + length must be <= byte array length.");
            }

            _bytes = bytes;
            _offset = offset;
            _limit = offset + length;
            _currentIndex = InitialIndex;
        }

        public bool Next()
        {
            var nextIndex = _currentIndex == InitialIndex
                ? _offset
                : _currentIndex + 2 + _bytes[_currentIndex + 1];

            if (nextIndex >= _limit)
            {
                return false;
            }

            if (_bytes[nextIndex] == 0xff)
            {
                return false;
            }

            if (nextIndex + 1 >= _limit)
            {
                throw new FormatException("The byte array ended unexpectedly.");
            }

            var nextItemLength = _bytes[nextIndex + 1];

            if (nextIndex + 2 + nextItemLength > _limit)
            {
                throw new FormatException("The byte array ended unexpectedly.");
            }

            _currentIndex = nextIndex;

            return true;
        }

        public byte CurrentItemKey
        {
            get
            {
                if (_currentIndex == InitialIndex)
                {
                    throw new InvalidOperationException($"The {nameof(Next)} method must be called before using {nameof(CurrentItemKey)}");
                }

                return _bytes[_offset];
            }
        }

        public BinaryValue GetCurrentItemValue()
        {
            if (_currentIndex == InitialIndex)
            {
                throw new InvalidOperationException($"The {nameof(Next)} method must be called before using {nameof(CurrentItemKey)}");
            }

            return new BinaryValue(_bytes, _currentIndex + 2, _bytes[_currentIndex + 1]);
        }
    }
}