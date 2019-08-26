﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using LH.Dhcp.vNext.Internals;

namespace LH.Dhcp.vNext
{
    public class BinaryValue
    {
        public static BinaryValue Concat(IReadOnlyList<BinaryValue> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.Count == 0)
            {
                throw new ArgumentException("The values cannot be empty.", nameof(values));
            }

            if (values.Count == 1)
            {
                return values[0];
            }

            var length = values.Sum(x => x.Length);
            var combinedBytes = new byte[length];

            var offset = 0;

            foreach (var binaryValue in values)
            {
                Array.Copy(binaryValue._bytes, binaryValue._offset, combinedBytes, offset, binaryValue.Length);

                offset += binaryValue.Length;
            }

            return new BinaryValue(combinedBytes, 0, combinedBytes.Length);
        }

        private readonly byte[] _bytes;
        private readonly int _offset;

        public BinaryValue(byte[] bytes, int offset, int length)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), "The offset must be >= 0.");
            }

            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "The length must be > 0.");
            }

            if (offset + length > bytes.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "The offset + length must be <= byte array.");
            }

            _bytes = bytes;
            _offset = offset;
            Length = length;
        }

        public int Length { get; }

        public byte AsByte()
        {
            if (Length != 1)
            {
                throw new InvalidOperationException($"The value has length {Length}. Single byte must have length of 1.");
            }

            return _bytes[_offset];
        }

        public byte[] AsBytes()
        {
            var result = new byte[Length];

            Array.Copy(_bytes, _offset, result, 0, Length);

            return result;
        }

        public bool AsBoolean()
        {
            if (!IsValidBoolean())
            {
                throw new InvalidOperationException(
                    $"Cannot read binary value as Boolean. The value has length of {Length} bytes Boolean value must have a length of {BinaryConvert.BooleanLength}.");
            }

            return BinaryConvert.ToBoolean(_bytes, _offset);
        }

        public ushort AsUInt16()
        {
            if (!IsValidUInt16())
            {
                throw new InvalidOperationException(
                    $"Cannot read binary value as UInt16. The value has length of {Length} bytes UInt16 value must have a length of {BinaryConvert.UInt16Length}.");
            }

            return BinaryConvert.ToUInt16(_bytes, _offset);
        }

        public short AsInt16()
        {
            if (!IsValidInt16())
            {
                throw new InvalidOperationException(
                    $"Cannot read binary value as Int16. The value has length of {Length} bytes, Int16 value must have a length of {BinaryConvert.Int16Length}.");
            }

            return BinaryConvert.ToInt16(_bytes, _offset);
        }

        public int AsInt32()
        {
            if (!IsValidInt32())
            {
                throw new InvalidOperationException(
                    $"Cannot read binary value as Int32. The value has length of {Length} bytes, Int16 value must have a length of {BinaryConvert.Int32Length}.");
            }

            return BinaryConvert.ToInt32(_bytes, _offset);
        }

        public IReadOnlyList<uint> AsUInt32List()
        {
            if (!IsValidUInt32List())
            {
                throw new InvalidOperationException(
                    $"Cannot read binary value as a list of UInt32. The value has length of {Length} bytes, list of UInt32 value must have a length divisible by {BinaryConvert.UInt16Length}.");
            }

            return AsList(offset => BinaryConvert.ToUInt32(_bytes, offset), BinaryConvert.UInt32Length);
        }

        public IReadOnlyList<IPAddress> AsIpAddressList()
        {
            if (!IsValidIpAddressList())
            {
                throw new InvalidOperationException(
                    $"Cannot read binary value as a list of IP Addresses. The value has length of {Length} bytes, list of IP Addresses value must have a length divisible by {BinaryConvert.IpAddressLength}.");
            }

            return AsList(offset => BinaryConvert.ToIpAddress(_bytes, offset), BinaryConvert.IpAddressLength);
        }

        public IPAddress AsIpAddress()
        {
            if (!IsValidIpAddress())
            {
                throw new InvalidOperationException(
                    $"Cannot read binary value as an IP Address. The value has length of {Length} bytes IP Address value must have a length of {BinaryConvert.IpAddressLength}.");
            }

            return BinaryConvert.ToIpAddress(_bytes, _offset);
        }

        public string AsString()
        {
            return BinaryConvert.ToString(_bytes, _offset, Length);
        }

        public object As(Type outputType)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<ushort> AsUInt16List()
        {
            if (!IsValidUInt16List())
            {
                throw new InvalidOperationException(
                    $"Cannot read binary value as a list of UInt16. The value has length of {Length} bytes, list of UInt16 value must have a length divisible by {BinaryConvert.UInt16Length}.");
            }

            return AsList(offset => BinaryConvert.ToUInt16(_bytes, offset), BinaryConvert.UInt16Length);
        }

        public uint AsUInt32()
        {
            if (!IsValidUInt32())
            {
                throw new InvalidOperationException(
                    $"Cannot read binary value as UInt32. The value has length of {Length} bytes UInt16 value must have a length of {BinaryConvert.UInt32Length}.");
            }

            return BinaryConvert.ToUInt32(_bytes, _offset);
        }

        public IReadOnlyList<KeyValuePair<byte, BinaryValue>> AsKeyValueCollection()
        {
            throw new NotImplementedException();
        }

        public BinaryValue CreateSubsetValue(int startIndex, int length)
        {
            throw new NotImplementedException();
        }

        public bool IsValidBoolean()
        {
            return Length == BinaryConvert.BooleanLength;
        }

        public bool IsValidByte()
        {
            return Length == 1;
        }

        public bool IsValidInt32()
        {
            return Length == BinaryConvert.Int32Length;
        }

        public bool IsValidIpAddressList()
        {
            return Length % BinaryConvert.IpAddressLength == 0;
        }

        public bool IsValidIpAddress()
        {
            return Length == BinaryConvert.IpAddressLength;
        }

        public bool IsValid(Type type)
        {
            throw new NotImplementedException();
        }

        public bool IsValidUInt16List()
        {
            return Length % BinaryConvert.UInt16Length == 0;
        }

        public bool IsValidInt32List()
        {
            return Length % BinaryConvert.Int32Length == 0;
        }

        public bool IsValidInt16()
        {
            return Length == BinaryConvert.Int16Length;
        }

        public IReadOnlyList<int> AsInt32List()
        {
            if (!IsValidInt32List())
            {
                throw new InvalidOperationException(
                    $"Cannot read binary value as a list of Int32. The value has length of {Length} bytes, list of Int32 value must have a length divisible by {BinaryConvert.Int32Length}.");
            }

            return AsList(offset => BinaryConvert.ToInt32(_bytes, offset), BinaryConvert.Int32Length);
        }

        public bool IsValidUInt16()
        {
            return Length == BinaryConvert.UInt16Length;
        }

        public bool IsValidUInt32()
        {
            return Length == BinaryConvert.UInt32Length;
        }

        public bool IsValidKeyValueCollection()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<short> AsInt16List()
        {
            if (!IsValidInt16List())
            {
                throw new InvalidOperationException(
                    $"Cannot read binary value as a list of Int16. The value has length of {Length} bytes, list of Int16 value must have a length divisible by {BinaryConvert.Int16Length}.");
            }

            return AsList(offset => BinaryConvert.ToInt16(_bytes, offset), BinaryConvert.Int16Length);
        }

        public bool IsValidInt16List()
        {
            return Length % BinaryConvert.Int16Length == 0;
        }

        private IReadOnlyList<T> AsList<T>(Func<int, T> readValueFunc, int itemLength)
        {
            var result = new T[Length / itemLength];

            for (var i = 0; i < Length / itemLength; i++)
            {
                var value = readValueFunc.Invoke(_offset + i * itemLength);

                result[i] = value;
            }

            return result;
        }

        public bool IsValidUInt32List()
        {
            return Length % BinaryConvert.UInt32Length == 0;
        }
    }
}