using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LH.Dhcp.Serialization
{
    public class BinaryValue
    {
        internal static BinaryValue FromByte(byte value)
        {
            throw new NotImplementedException();
        }

        internal static uint AsUInt32(byte[] bytes, int index)
        {
            throw new NotImplementedException();
        }

        internal static ushort AsUInt16(byte[] bytes, int index)
        {
            throw new NotImplementedException();
        }

        internal static IPAddress AsIpAddress(byte[] bytes, int index)
        {
            throw new NotImplementedException();
        }

        internal static IDictionary<byte, BinaryValue> AsTaggedValueCollection(byte[] bytes, int index, int length)
        {
            throw new NotImplementedException();
        }

        public const int BooleanLength = 1;
        public const int ByteLength = 1;
        public const int Int32Length = 4;
        public const int UnsignedInt16Length = 2;
        public const int UnsignedInt32Length = 4;
        public const int IpAddressLength = 4;

        private readonly byte[] _data;
        private readonly int _offset;
        private readonly int _length;

        public BinaryValue(byte[] data, int offset, int length)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), "The offset must be greater or equal to zero.");
            }

            if (offset + length > data.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "The length end outside of the bounds of the data array.");
            }

            _data = data;
            _offset = offset;
            _length = length;
        }

        public int Length
        {
            get => _length;
        }

        public bool AsBoolean()
        {
            if (!IsValidBoolean())
            {
                throw new InvalidOperationException("Cannot read binary value as Boolean. The value is not a valid Boolean.");
            }

            return _data[_offset] == 0x01;
        }

        public uint AsUnsignedInt32()
        {
            if (!IsValidUnsignedInt32())
            {
                throw new InvalidOperationException("Cannot read binary value as UInt32. The value is not a valid UInt32.");
            }

            return
                (Convert.ToUInt32(_data[_offset]) << 24) |
                (Convert.ToUInt32(_data[_offset + 1]) << 16) |
                (Convert.ToUInt32(_data[_offset + 2]) << 8) |
                (Convert.ToUInt32(_data[_offset + 3]));
        }

        public int AsInt32()
        {
            if (!IsValidInt32())
            {
                throw new InvalidOperationException("Cannot read binary value as Int32. The value is not a valid Int32.");
            }

            return
                (Convert.ToInt32(_data[_offset]) << 24) |
                (Convert.ToInt32(_data[_offset + 1]) << 16) |
                (Convert.ToInt32(_data[_offset + 2]) << 8) |
                (Convert.ToInt32(_data[_offset + 3]));
        }

        public ushort AsUnsignedInt16()
        {
            if (!IsValidUnsignedInt16())
            {
                throw new InvalidOperationException("Cannot read binary value as UInt16. The value is not a valid UInt16.");
            }

            return AsUnsignedInt16(_offset);
        }

        public IReadOnlyList<ushort> AsUnsignedInt16List()
        {
            if (!IsValidUnsignedInt16List())
            {
                throw new InvalidOperationException("Cannot read binary value as a list of UInt16. The value is not a valid list of UInt16.");
            }

            var itemsCount = _length / UnsignedInt16Length;
            var result = new ushort[itemsCount];

            for (var i = 0; i < itemsCount; i++)
            {
                result[i] = AsUnsignedInt16(_offset + i * UnsignedInt16Length);
            }

            return result;
        }

        public IPAddress AsIpAddress()
        {
            if (!IsValidIpAddress())
            {
                throw new InvalidOperationException("Cannot read binary value as IpAddress. The value is not a valid IpAddress.");
            }

            var buffer = new byte[IpAddressLength];

            Array.Copy(_data, _offset, buffer, 0, IpAddressLength);

            return new IPAddress(buffer);
        }

        public byte AsByte()
        {
            if (!IsValidByte())
            {
                throw new InvalidOperationException("Cannot read binary value as Byte. The value is not a valid Byte.");
            }

            return _data[_offset];
        }

        public string AsString()
        {
            return Encoding.ASCII.GetString(_data, _offset, _length).TrimEnd('\0');
        }

        public IReadOnlyList<IPAddress> AsIpAddressList()
        {
            if (!IsValidIpAddressList())
            {
                throw new InvalidOperationException("Cannot read binary value as a list of IpAddresses. The value is not a valid list of IpAddresses.");
            }

            var itemsCount = _length / IpAddressLength;
            var result = new IPAddress[itemsCount];

            var buffer = new byte[IpAddressLength];

            for (int i = 0; i < itemsCount; i++)
            {
                Array.Copy(_data, _offset + i * IpAddressLength, buffer, 0, IpAddressLength);

                result[i] = new IPAddress(buffer);
            }

            return result;
        }

        public IReadOnlyList<Tuple<IPAddress, IPAddress>> AsIpAddressPairList()
        {
            if (!IsValidIpAddressPairList())
            {
                throw new InvalidOperationException("Cannot read binary value as a list of IpAddress pairs. The value is not a valid list of IpAddress pairs.");
            }

            var itemsCount = _length / (2 * IpAddressLength);
            var result = new Tuple<IPAddress, IPAddress>[itemsCount];

            var buffer = new byte[IpAddressLength];

            for (int i = 0; i < itemsCount; i++)
            {
                var startIndex = _offset + (i * 2 * IpAddressLength);

                Array.Copy(_data, startIndex, buffer, 0, IpAddressLength);

                var ip1 = new IPAddress(buffer);

                Array.Copy(_data, startIndex + IpAddressLength, buffer, 0, IpAddressLength);

                var ip2 = new IPAddress(buffer);

                result[i] = new Tuple<IPAddress, IPAddress>(ip1, ip2);
            }

            return result;
        }

        public IReadOnlyDictionary<byte, BinaryValue> AsTaggedValueCollection()
        {
            throw new NotImplementedException();

            //var reader = new DhcpBinaryReader(_data, _offset, _length);
            //var collectionReader = new TaggedKeyValueCollectionSerializer(reader);

            //var result = new Dictionary<byte, IBinaryValue>();

            //while (collectionReader.HasNextItem())
            //{
            //    var item = collectionReader.NextItem();

            //    if (result.ContainsKey(item.Tag))
            //    {
            //        throw new InvalidOperationException("Cannot read binary value as a TaggedValueCollection. The value is not a valid TaggedValueCollection.");
            //    }

            //    result.Add(item.Tag, item.Value);
            //}

            //return result;
        }

        public byte[] AsBytes()
        {
            var result = new byte[_length];

            Array.Copy(_data, _offset, result, 0, _length);

            return result;
        }

        public object As(Type optionType)
        {
            switch (optionType)
            {
                case var type when type == typeof(string):
                    return AsString();

                case var type when type == typeof(byte[]):
                    return AsBytes();

                case var type when type == typeof(bool):
                    return AsBoolean();

                case var type when type == typeof(byte):
                    return AsByte();

                case var type when type == typeof(int):
                    return AsInt32();

                case var type when type == typeof(uint):
                    return AsUnsignedInt32();

                case var type when type == typeof(ushort):
                    return AsUnsignedInt16();

                case var type when type == typeof(IReadOnlyList<ushort>):
                    return AsUnsignedInt16List();

                case var type when type == typeof(IPAddress):
                    return AsIpAddress();

                case var type when type == typeof(IReadOnlyList<IPAddress>):
                    return AsIpAddressList();

                case var type when type == typeof(IReadOnlyList<Tuple<IPAddress, IPAddress>>):
                    return AsIpAddressPairList();
            }

            throw new NotSupportedException($"The type {optionType} is not supported. " +
                                            $"Supported types are String, Byte[], Byte, Int32, UInt32, UInt16, " +
                                            $"Boolean, IPAddress, IReadOnlyList<IPAddress>, IReadOnlyList<Tuple<IPAddress, IPAddress>>.");
        }

        public bool IsValid(Type optionType)
        {
            switch (optionType)
            {
                case var type when type == typeof(string) || type == typeof(byte[]):
                    return true;

                case var type when type == typeof(bool):
                    return IsValidBoolean();

                case var type when type == typeof(byte):
                    return IsValidByte();

                case var type when type == typeof(int):
                    return IsValidInt32();

                case var type when type == typeof(uint):
                    return IsValidUnsignedInt32();

                case var type when type == typeof(ushort):
                    return IsValidUnsignedInt16();

                case var type when type == typeof(IReadOnlyList<ushort>):
                    return IsValidUnsignedInt16List();

                case var type when type == typeof(IPAddress):
                    return IsValidIpAddress();

                case var type when type == typeof(IReadOnlyList<IPAddress>):
                    return IsValidIpAddressList();

                case var type when type == typeof(IReadOnlyList<Tuple<IPAddress, IPAddress>>):
                    return IsValidIpAddressPairList();
            }

            throw new NotSupportedException($"The type {optionType} is not supported. " +
                                            $"Supported types are String, Byte[], Byte, Int32, UInt32, UInt16, " +
                                            $"Boolean, IPAddress, IReadOnlyList<IPAddress>, IReadOnlyList<Tuple<IPAddress, IPAddress>>.");
        }

        public bool IsValidBoolean()
        {
            return _length == BooleanLength;
        }

        public bool IsValidTaggedValueCollection()
        {
            throw new NotImplementedException();

            //var reader = new DhcpBinaryReader(_data, _offset, _length);
            //var collectionReader = new TaggedKeyValueCollectionSerializer(reader);

            //var seenTags = new HashSet<byte>();

            //try
            //{
            //    while (collectionReader.HasNextItem())
            //    {
            //        var item = collectionReader.NextItem();

            //        if (seenTags.Contains(item.Tag))
            //        {
            //            return false;
            //        }

            //        seenTags.Add(item.Tag);
            //    }

            //    return true;
            //}
            //catch (InvalidOperationException)
            //{
            //    return false;
            //}
        }

        public bool IsValidByte()
        {
            return _length == ByteLength;
        }

        public bool IsValidUnsignedInt16()
        {
            return _length == UnsignedInt16Length;
        }

        public bool IsValidUnsignedInt16List()
        {
            return _length > 0 && _length % UnsignedInt16Length == 0;
        }

        public bool IsValidUnsignedInt32()
        {
            return _length == UnsignedInt32Length;
        }

        public bool IsValidInt32()
        {
            return _length == Int32Length;
        }

        public bool IsValidIpAddress()
        {
            return _length == IpAddressLength;
        }

        public bool IsValidIpAddressList()
        {
            return _length > 0 && _length % IpAddressLength == 0;
        }

        public bool IsValidIpAddressPairList()
        {
            return _length > 0 && _length % (2 * IpAddressLength) == 0;
        }

        public BinaryValue CreateSubsetValue(int offset, byte length)
        {
            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(offset), "The offset must be >= 0.");
            }

            if (offset + length > _length)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "The offset + length < total length of the value.");
            }

            return new BinaryValue(_data, _offset + offset, length);
        }

        private ushort AsUnsignedInt16(int offset)
        {
            return (ushort)(
                (Convert.ToUInt16(_data[offset]) << 8) |
                (Convert.ToUInt16(_data[offset + 1])));
        }
    }
}