using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using LH.Dhcp.vNext.Internals;
using LH.Dhcp.vNext.Options;

namespace LH.Dhcp.vNext
{
    public class DhcpPacketBuilder
    {
        public static DhcpPacketBuilder CreateFromExisting(DhcpPacket existingPacket)
        {
            throw new NotImplementedException();
        }

        public static DhcpPacketBuilder Create(DhcpMessageType messageType)
        {
            return new DhcpPacketBuilder(messageType);
        }

        private byte[] _buffer;
        private int _nextOptionIndex = 240;

        private DhcpPacketBuilder(DhcpMessageType messageType)
        {
            _buffer = new byte[360];

            // Set default values
            _buffer[0] = DefaultOperation(messageType);

            BinaryConvert.FromUInt32(_buffer, DhcpConstants.MagicCookieOffset, DhcpConstants.MagicCookie);

            WithTransactionId(Randomizer.Instance.GenerateTransactionId());
            WithOption(53, (byte)messageType);
        }

        public DhcpPacketBuilder WithTransactionId(uint transactionId)
        {
            if (transactionId == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(transactionId), "The transaction id cannot be zero.");
            }

            BinaryConvert.FromUInt32(_buffer, DhcpConstants.TransactionIdOffset, transactionId);

            return this;
        }

        public DhcpPacketBuilder WithClientHardwareAddress(ClientHardwareAddress clientHardwareAddress)
        {
            throw new NotImplementedException();
        }

        public DhcpPacketBuilder WithHops(byte hops)
        {
            _buffer[DhcpConstants.HopsOffset] = hops;

            return this;
        }

        public DhcpPacketBuilder WithSecondsElapsed(ushort secondsElapsed)
        {
            BinaryConvert.FromUInt16(_buffer, DhcpConstants.SecondsElapsedOffset, secondsElapsed);

            return this;
        }

        public DhcpPacketBuilder WithBroadcast(bool isBroadcast)
        {
            var value = isBroadcast ? DhcpConstants.BroadcastFlag : (ushort)0;

            BinaryConvert.FromUInt16(_buffer, DhcpConstants.BroadcastOffset, value);

            return this;
        }

        public DhcpPacketBuilder WithClientIp(IPAddress clientIp)
        {
            if (clientIp == null)
            {
                throw new ArgumentNullException(nameof(clientIp));
            }

            BinaryConvert.FromIpAddress(_buffer, DhcpConstants.ClientIpOffset, clientIp);

            return this;
        }

        public DhcpPacketBuilder WithYourIp(IPAddress yourIp)
        {
            if (yourIp == null)
            {
                throw new ArgumentNullException(nameof(yourIp));
            }

            BinaryConvert.FromIpAddress(_buffer, DhcpConstants.YourIpOffset, yourIp);

            return this;
        }

        public DhcpPacketBuilder WithServerIp(IPAddress serverIp)
        {
            if (serverIp == null)
            {
                throw new ArgumentNullException(nameof(serverIp));
            }

            BinaryConvert.FromIpAddress(_buffer, DhcpConstants.ServerIpOffset, serverIp);

            return this;
        }

        public DhcpPacketBuilder WithGatewayIp(IPAddress gatewayIp)
        {
            if (gatewayIp == null)
            {
                throw new ArgumentNullException(nameof(gatewayIp));
            }

            BinaryConvert.FromIpAddress(_buffer, DhcpConstants.GatewayIpOffset, gatewayIp);

            return this;
        }

        public DhcpPacketBuilder WithBootFile(string bootFile)
        {
            var valueLength = string.IsNullOrEmpty(bootFile) ? 0 : bootFile.Length;

            if (valueLength > DhcpConstants.BootFileLength)
            {
                throw new ArgumentException($"The boot file cannot be longer than {DhcpConstants.BootFileLength}.", nameof(bootFile));
            }

            BinaryConvert.FromString(_buffer, DhcpConstants.BootFileOffset, bootFile);

            ClearRemainingBytes(DhcpConstants.BootFileOffset, valueLength, DhcpConstants.BootFileLength);

            return this;
        }

        public DhcpPacketBuilder WithServerName(string serverName)
        {
            var valueLength = string.IsNullOrEmpty(serverName) ? 0 : serverName.Length;

            if (valueLength > DhcpConstants.ServerNameLength)
            {
                throw new ArgumentException($"The server name cannot be longer than {DhcpConstants.ServerNameLength}.", nameof(serverName));
            }

            BinaryConvert.FromString(_buffer, DhcpConstants.ServerNameOffset, serverName);

            ClearRemainingBytes(DhcpConstants.ServerNameOffset, valueLength, DhcpConstants.ServerNameLength);

            return this;
        }

        /*
         * TODO: Options
         * - Split long options (only applicable to variable length options)
         * - Resizable buffer (1,5 resize?)
         * - Do not allow setting reserved options (in this case also 53 !!!)
         */

        #region Boolean

        public DhcpPacketBuilder WithOption(DhcpOptionCode optionCode, bool value)
        {
            return WithOption((byte)optionCode, value);
        }

        public DhcpPacketBuilder WithOption(byte optionCode, bool value)
        {
            VerifyReservedOptionCode(optionCode);

            const int optionLength = 3;

            EnsureBufferSpace(optionLength);

            _buffer[_nextOptionIndex] = optionCode;
            _buffer[_nextOptionIndex + 1] = 1;

            BinaryConvert.FromBoolean(_buffer, _nextOptionIndex + 2, value);

            _nextOptionIndex += optionLength;

            return this;
        }

        #endregion

        #region Byte

        public DhcpPacketBuilder WithOption(DhcpOptionCode optionCode, byte value)
        {
            return WithOption((byte)optionCode, value);
        }

        public DhcpPacketBuilder WithOption(byte optionCode, byte value)
        {
            VerifyReservedOptionCode(optionCode);

            const int optionLength = 3;

            EnsureBufferSpace(optionLength);

            _buffer[_nextOptionIndex] = optionCode;
            _buffer[_nextOptionIndex + 1] = 1;
            _buffer[_nextOptionIndex + 2] = value;

            _nextOptionIndex += optionLength;

            return this;
        }

        #endregion

        #region Int16

        public DhcpPacketBuilder WithOption(DhcpOptionCode optionCode, short value)
        {
            return WithOption((byte)optionCode, value);
        }

        public DhcpPacketBuilder WithOption(byte optionCode, short value)
        {
            VerifyReservedOptionCode(optionCode);

            const int optionLength = 2 + BinaryConvert.Int16Length;

            EnsureBufferSpace(optionLength);

            _buffer[_nextOptionIndex] = optionCode;
            _buffer[_nextOptionIndex + 1] = BinaryConvert.Int16Length;

            BinaryConvert.FromInt16(_buffer, _nextOptionIndex + 2, value);

            _nextOptionIndex += optionLength;

            return this;
        }

        public DhcpPacketBuilder WithOption(DhcpOptionCode optionCode, IReadOnlyList<short> value)
        {
            return WithOption((byte)optionCode, value);
        }

        public DhcpPacketBuilder WithOption(byte optionCode, IReadOnlyList<short> value)
        {
            WriteCollectionOption(
                optionCode, 
                value, 
                BinaryConvert.Int16Length,
                (item, offset) => BinaryConvert.FromInt16(_buffer, offset, item));

            return this;
        }

        #endregion

        #region UInt16

        public DhcpPacketBuilder WithOption(DhcpOptionCode optionCode, ushort value)
        {
            return WithOption((byte)optionCode, value);
        }

        public DhcpPacketBuilder WithOption(byte optionCode, ushort value)
        {
            VerifyReservedOptionCode(optionCode);

            const int optionLength = 2 + BinaryConvert.UInt16Length;

            EnsureBufferSpace(optionLength);

            _buffer[_nextOptionIndex] = optionCode;
            _buffer[_nextOptionIndex + 1] = BinaryConvert.UInt16Length;

            BinaryConvert.FromUInt16(_buffer, _nextOptionIndex + 2, value);

            _nextOptionIndex += optionLength;

            return this;
        }

        public DhcpPacketBuilder WithOption(DhcpOptionCode optionCode, IReadOnlyList<ushort> value)
        {
            return WithOption((byte)optionCode, value);
        }

        public DhcpPacketBuilder WithOption(byte optionCode, IReadOnlyList<ushort> value)
        {
            WriteCollectionOption(
                optionCode,
                value,
                BinaryConvert.Int16Length,
                (item, offset) => BinaryConvert.FromUInt16(_buffer, offset, item));

            return this;
        }

        #endregion

        #region UInt32

        public DhcpPacketBuilder WithOption(DhcpOptionCode optionCode, uint value)
        {
            return WithOption((byte)optionCode, value);
        }

        public DhcpPacketBuilder WithOption(byte optionCode, uint value)
        {
            VerifyReservedOptionCode(optionCode);

            const int optionLength = 2 + BinaryConvert.UInt32Length;

            EnsureBufferSpace(optionLength);

            _buffer[_nextOptionIndex] = optionCode;
            _buffer[_nextOptionIndex + 1] = BinaryConvert.UInt32Length;

            BinaryConvert.FromUInt32(_buffer, _nextOptionIndex + 2, value);

            _nextOptionIndex += optionLength;

            return this;
        }

        #endregion

        #region Int32

        public DhcpPacketBuilder WithOption(DhcpOptionCode optionCode, int value)
        {
            return WithOption((byte)optionCode, value);
        }

        public DhcpPacketBuilder WithOption(byte optionCode, int value)
        {
            VerifyReservedOptionCode(optionCode);

            const int optionLength = 2 + BinaryConvert.Int32Length;

            EnsureBufferSpace(optionLength);

            _buffer[_nextOptionIndex] = optionCode;
            _buffer[_nextOptionIndex + 1] = BinaryConvert.Int32Length;

            BinaryConvert.FromInt32(_buffer, _nextOptionIndex + 2, value);

            _nextOptionIndex += optionLength;

            return this;
        }

        #endregion

        #region IpAddress

        public DhcpPacketBuilder WithOption(DhcpOptionCode optionCode, IPAddress value)
        {
            return WithOption((byte)optionCode, value);
        }

        public DhcpPacketBuilder WithOption(byte optionCode, IPAddress value)
        {
            VerifyReservedOptionCode(optionCode);

            const int optionLength = 2 + BinaryConvert.IpAddressLength;

            EnsureBufferSpace(optionLength);

            _buffer[_nextOptionIndex] = optionCode;
            _buffer[_nextOptionIndex + 1] = BinaryConvert.IpAddressLength;

            BinaryConvert.FromIpAddress(_buffer, _nextOptionIndex + 2, value);

            _nextOptionIndex += optionLength;

            return this;
        }

        #endregion

        #region String

        public DhcpPacketBuilder WithOption(DhcpOptionCode optionCode, string value)
        {
            return WithOption((byte)optionCode, value);
        }

        public DhcpPacketBuilder WithOption(byte optionCode, string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("The option value cannot be an empty string.", nameof(value));
            }

            VerifyReservedOptionCode(optionCode);

            var segments = (int)Math.Ceiling(value.Length / 255m);

            var totalLength = value.Length + segments * 2;

            EnsureBufferSpace(totalLength);

            for (var i = 0; i < segments; i++)
            {
                var segmentValueLength = (byte)Math.Min(255, value.Length - i * 255);

                _buffer[_nextOptionIndex] = optionCode;
                _buffer[_nextOptionIndex + 1] = segmentValueLength;

                BinaryConvert.FromString(_buffer, _nextOptionIndex + 2, value, i * 255, segmentValueLength);

                _nextOptionIndex += segmentValueLength + 2;
            }

            return this;
        }

        #endregion

        #region ByteArray

        public DhcpPacketBuilder WithOption(DhcpOptionCode optionCode, byte[] value)
        {
            return WithOption((byte)optionCode, value);
        }

        public DhcpPacketBuilder WithOption(byte optionCode, byte[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (value.Length == 0)
            {
                throw new ArgumentException("The option value cannot be an empty array.", nameof(value));
            }

            VerifyReservedOptionCode(optionCode);

            var segments = (int)Math.Ceiling(value.Length / 255m);

            var totalLength = value.Length + segments * 2;

            EnsureBufferSpace(totalLength);

            for (var i = 0; i < segments; i++)
            {
                var segmentValueLength = (byte)Math.Min(255, value.Length - i * 255);

                _buffer[_nextOptionIndex] = optionCode;
                _buffer[_nextOptionIndex + 1] = segmentValueLength;

                Array.Copy(_buffer, _nextOptionIndex + 2, value, i * 255, segmentValueLength);

                _nextOptionIndex += segmentValueLength + 2;
            }

            return this;
        }

        #endregion

        public DhcpPacketBuilder WithOption(IDhcpOption semanticOption)
        {
            throw new NotImplementedException();
        }

        public DhcpPacket Build()
        {
            var trimmedBytes = new byte[_nextOptionIndex + 1];

            Array.Copy(_buffer, 0, trimmedBytes, 0, _nextOptionIndex);

            trimmedBytes[_nextOptionIndex] = 0xff;

            return new DhcpPacket(trimmedBytes);
        }

        private byte DefaultOperation(DhcpMessageType msgType)
        {
            switch (msgType)
            {
                case DhcpMessageType.Discover:
                case DhcpMessageType.Decline:
                case DhcpMessageType.Inform:
                case DhcpMessageType.Request:
                case DhcpMessageType.Release:
                    return (byte)DhcpOperation.BootRequest;

                case DhcpMessageType.Ack:
                case DhcpMessageType.NAck:
                case DhcpMessageType.Offer:
                    return (byte)DhcpOperation.BootReply;

                default:
                    throw new NotSupportedException($"The message type {msgType} is not supported.");
            }
        }

        // TODO: Validate the packet
        // TODO: Check for array size overflow (int max?)
        // TODO: If user specifies the file name and the BootFileName option? - this doesn't make sense. Do not allow the filename option at all, same goes for server name!

        private bool IsReservedOptionCode(byte optionCode)
        {
            return DhcpConstants.ReservedOptionCodes.Contains(optionCode);
        }

        private void EnsureBufferSpace(int requiredOptionBytes)
        {
            var newLength = (decimal)_buffer.Length;

            while (newLength - _nextOptionIndex <= requiredOptionBytes)
            {
                newLength *= 1.5m;
            }

            if (newLength > _buffer.Length)
            {
                Array.Resize(ref _buffer, (int)newLength);
            }
        }

        private void ClearRemainingBytes(int offset, int valueLength, int fixedValueLength)
        {
            for (var i = valueLength; i < fixedValueLength - valueLength; i++)
            {
                _buffer[offset + valueLength + i] = 0x00;
            }
        }

        private void VerifyReservedOptionCode(byte optionCode)
        {
            if (IsReservedOptionCode(optionCode))
            {
                throw new ArgumentOutOfRangeException(nameof(optionCode),
                    $"The option code {optionCode} is reserved and cannot be accessed directly.");
            }
        }

        private void WriteCollectionOption<T>(byte optionCode, IReadOnlyList<T> value, int itemLength, Action<T, int> writeItemAction)
        {
            VerifyReservedOptionCode(optionCode);

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "The option value cannot be null.");
            }

            if (!value.Any())
            {
                throw new ArgumentException("The option value cannot be an empty collection.", nameof(value));
            }

            var maxItemsInSegmentDec = Math.Floor(255m / itemLength);
            var segments = (int)Math.Ceiling(value.Count / maxItemsInSegmentDec);

            var maxItemsInSegment = (int)maxItemsInSegmentDec;

            var totalLength = value.Count * itemLength + segments * 2;

            EnsureBufferSpace(totalLength);

            for (var i = 0; i < segments; i++)
            {
                var itemsInSegment = Math.Min(maxItemsInSegment, value.Count - i * maxItemsInSegment);
                var valueLength = (byte)(itemsInSegment * itemLength);

                _buffer[_nextOptionIndex] = optionCode;
                _buffer[_nextOptionIndex + 1] = valueLength;

                for (var j = 0; j < itemsInSegment; j++)
                {
                    var index = _nextOptionIndex + 2 + j * itemLength;

                    writeItemAction(value[maxItemsInSegment * i + j], index);
                }

                _nextOptionIndex += 2 + valueLength;
            }
        }

        // TODO: WithFlagOption (without value)
    }
}