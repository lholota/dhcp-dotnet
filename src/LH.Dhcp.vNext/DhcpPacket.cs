using System;
using System.Net;
using LH.Dhcp.vNext.Internals;

namespace LH.Dhcp.vNext
{
    // Consider adding options cache -> HasOption -> GetOption will do the search twice

    public class DhcpPacket
    {
        private const int OptionsIndex = 240;
        private const int PacketMinSize = 240;
        private const uint MagicCookie = 0x63825363;
        private const ushort BroadcastFlag = 0x8000;

        private readonly byte[] _packetBytes;
        private readonly Lazy<ClientHardwareAddress> _clientHardwareAddress;
        private readonly DhcpOptionOverloadMode _overloadMode;

        public DhcpPacket(byte[] packetBytes)
        {
            if (packetBytes == null)
            {
                throw new ArgumentNullException(nameof(packetBytes));
            }

            if (packetBytes.Length < PacketMinSize)
            {
                throw new ArgumentOutOfRangeException(nameof(packetBytes), $"The DHCP packet must be at least {PacketMinSize} bytes long.");
            }

            _packetBytes = packetBytes;

            _clientHardwareAddress = new Lazy<ClientHardwareAddress>(GetClientHardwareAddress);

            ValidateMagicCookie();

            _overloadMode = DetermineOverloadMode();
        }

        public uint TransactionId
        {
            get => BinaryConvert.ToUInt32(_packetBytes, 4);
        }

        public DhcpOperation Operation
        {
            get => (DhcpOperation)_packetBytes[0];
        }

        public ClientHardwareAddress ClientHardwareAddress
        {
            get => _clientHardwareAddress.Value;
        }

        public byte Hops
        {
            get => _packetBytes[3];
        }

        public ushort Secs
        {
            get => BinaryConvert.ToUInt16(_packetBytes, 8);
        }

        public bool IsBroadcast
        {
            get => BinaryConvert.ToUInt16(_packetBytes, 10) == BroadcastFlag;
        }

        public IPAddress ClientIp
        {
            get => BinaryConvert.ToIpAddress(_packetBytes, 12);
        }

        public IPAddress YourIp
        {
            get => BinaryConvert.ToIpAddress(_packetBytes, 16);
        }

        public IPAddress ServerIp
        {
            get => BinaryConvert.ToIpAddress(_packetBytes, 20);
        }

        public IPAddress GatewayIp
        {
            get => BinaryConvert.ToIpAddress(_packetBytes, 24);
        }

        public string ServerName { get; } // TODO: Handle overloading

        public string BootFile { get; } // TODO: Handle overloading

        public bool HasOption(byte optionCode)
        {
            // TODO: If control code => throw argument exception

            var optionsReader = new KeyLengthValueReader(_packetBytes, OptionsIndex, _packetBytes.Length - OptionsIndex);

            while (optionsReader.Next())
            {
                if (optionsReader.CurrentItemKey == optionCode)
                {
                    return true;
                }
            }

            if (_overloadMode != DhcpOptionOverloadMode.None)
            {
                var overloadedOptionsReader = new KeyLengthValueReader(
                    _packetBytes, 
                    GetOverloadedOptionsStartIndex(), 
                    GetOverloadedOptionsLength());

                while (overloadedOptionsReader.Next())
                {
                    if (optionsReader.CurrentItemKey == optionCode)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool HasOption(DhcpOptionCode optionCode)
        {
            return HasOption((byte) optionCode);
        }

        public bool HasOption<T>() // where T : IDhcpOption
        {
            // TODO: Find option code

            throw new NotImplementedException();
        }

        public BinaryValue GetOption(byte optionCode)
        {
            // TODO: Join long options
            // TODO: If control code => throw argument exception

            throw new NotImplementedException();
        }

        public BinaryValue GetOption(DhcpOptionCode optionCode)
        {
            // TODO: Join long options
            // TODO: If control code => throw argument exception

            throw new NotImplementedException();
        }

        public T GetOption<T>() // where T : IDhcpOption
        {
            // TODO: Join long options
            // TODO: If control code => throw argument exception

            throw new NotImplementedException();
        }

        private DhcpOptionOverloadMode DetermineOverloadMode()
        {
            var overloadOptionCode = (byte) DhcpOptionCode.Overload;

            var optionsReader = new KeyLengthValueReader(_packetBytes, OptionsIndex, _packetBytes.Length - OptionsIndex);

            while (optionsReader.Next())
            {
                if (optionsReader.CurrentItemKey == overloadOptionCode)
                {
                    return (DhcpOptionOverloadMode)optionsReader.GetCurrentItemValue().AsByte();
                }
            }

            return DhcpOptionOverloadMode.None;
        }

        private ClientHardwareAddress GetClientHardwareAddress()
        {
            var addressType = (ClientHardwareAddressType) _packetBytes[1];

            var addressBytes = new byte[_packetBytes[2]];

            Array.Copy(_packetBytes, 28, addressBytes, 0, _packetBytes[2]);
            
            return new ClientHardwareAddress(addressType, addressBytes);
        }

        private int GetOverloadedOptionsStartIndex()
        {
            switch (_overloadMode)
            {
                case DhcpOptionOverloadMode.None:
                    throw new InvalidOperationException();

                case DhcpOptionOverloadMode.BootFile:
                    return 128;

                case DhcpOptionOverloadMode.ServerName:
                    return 256;

                case DhcpOptionOverloadMode.Both:
                    return 128;
            }

            throw new NotSupportedException($"Overload value {_overloadMode} is not supported.");
        }

        private int GetOverloadedOptionsLength()
        {
            switch (_overloadMode)
            {
                case DhcpOptionOverloadMode.None:
                    throw new InvalidOperationException();

                case DhcpOptionOverloadMode.BootFile:
                    return 128;

                case DhcpOptionOverloadMode.ServerName:
                    return 256;

                case DhcpOptionOverloadMode.Both:
                    return 128;
            }

            throw new NotSupportedException($"Overload value {_overloadMode} is not supported.");
        }

        private void ValidateMagicCookie()
        {
            if (BinaryConvert.ToUInt32(_packetBytes, 236) != MagicCookie)
            {
                throw new FormatException(
                    "The packet does not contain the DHCP Magic cookie. It may be a BOOTP packet, but it's not a DHCP packet.");
            }
        }
    }
}