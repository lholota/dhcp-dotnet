using System;
using System.Collections.Generic;
using System.Net;
using LH.Dhcp.vNext.Internals;
using LH.Dhcp.vNext.Options;

namespace LH.Dhcp.vNext
{
    public class DhcpPacket
    {
        private const int OptionsIndex = 240;
        private const int PacketMinSize = 240;
        private const uint MagicCookie = 0x63825363;
        private const ushort BroadcastFlag = 0x8000;

        private readonly byte[] _packetBytes;
        private readonly Lazy<ClientHardwareAddress> _clientHardwareAddress;
        private readonly Lazy<string> _bootFileName;
        private readonly Lazy<string> _serverName;
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
            _bootFileName = new Lazy<string>(GetBootFileName);
            _serverName = new Lazy<string>(GetServerName);

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

        public ushort SecondsElapsed
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

        public string ServerName
        {
            get => _serverName.Value;
        }

        public string BootFileName
        {
            get => _bootFileName.Value;
        } 

        public bool HasOption(byte optionCode)
        {
            if (IsReservedOptionCode(optionCode))
            {
                throw new ArgumentException(nameof(optionCode), $"The option code {optionCode} is reserved and cannot be accessed directly.");
            }

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
                    if (overloadedOptionsReader.CurrentItemKey == optionCode)
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

        public bool HasOption<T>() where T : IDhcpOption
        {
            var optionCode = SemanticOptionsMapper.Instance.GetOptionCodeByType(typeof(T));

            return HasOption(optionCode);
        }

        public BinaryValue GetOption(byte optionCode)
        {
            if (IsReservedOptionCode(optionCode))
            {
                throw new ArgumentException(nameof(optionCode), $"The option code {optionCode} is reserved and cannot be accessed directly.");
            }

            return GetOptionInternal(optionCode);
        }

        public BinaryValue GetOption(DhcpOptionCode optionCode)
        {
            var byteOptionCode = (byte) optionCode;

            return GetOption(byteOptionCode);
        }

        public T GetOption<T>() where T : IDhcpOption
        {
            var optionType = typeof(T);
            var optionCode = SemanticOptionsMapper.Instance.GetOptionCodeByType(optionType);

            var optionValue = GetOption(optionCode);

            if (optionValue == null)
            {
                return default;
            }

            return (T) SemanticOptionsFactory.Instance.CreateOption(optionType, optionValue);
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

                case DhcpOptionOverloadMode.FileName:
                    return 108;

                case DhcpOptionOverloadMode.ServerName:
                case DhcpOptionOverloadMode.Both:
                    return 44;
            }

            throw new NotSupportedException($"Overload value {_overloadMode} is not supported.");
        }

        private int GetOverloadedOptionsLength()
        {
            switch (_overloadMode)
            {
                case DhcpOptionOverloadMode.None:
                    throw new InvalidOperationException();

                case DhcpOptionOverloadMode.FileName:
                    return 128;

                case DhcpOptionOverloadMode.ServerName:
                    return 64;

                case DhcpOptionOverloadMode.Both:
                    return 128 + 64;
            }

            throw new NotSupportedException($"Overload value {_overloadMode} is not supported.");
        }

        private string GetBootFileName()
        {
            switch (_overloadMode)
            {
                case DhcpOptionOverloadMode.None:
                case DhcpOptionOverloadMode.ServerName:
                    return BinaryConvert.ToString(_packetBytes, 108, 128);

                case DhcpOptionOverloadMode.Both:
                case DhcpOptionOverloadMode.FileName:
                    return GetOptionInternal(67)?.AsString();

                default:
                    throw new NotSupportedException($"The overload mode {_overloadMode} is not supported (because it is not defined by the RFC).");
            }
        }

        private string GetServerName()
        {
            switch (_overloadMode)
            {
                case DhcpOptionOverloadMode.None:
                case DhcpOptionOverloadMode.FileName:
                    return BinaryConvert.ToString(_packetBytes, 44, 64);

                case DhcpOptionOverloadMode.Both:
                case DhcpOptionOverloadMode.ServerName:
                    return GetOptionInternal(66)?.AsString();

                default:
                    throw new NotSupportedException($"The overload mode {_overloadMode} is not supported (because it is not defined by the RFC).");
            }
        }

        private void ValidateMagicCookie()
        {
            if (BinaryConvert.ToUInt32(_packetBytes, 236) != MagicCookie)
            {
                throw new FormatException(
                    "The packet does not contain the DHCP Magic cookie. It may be a BOOTP packet, but it's not a DHCP packet.");
            }
        }

        private bool IsReservedOptionCode(byte optionCode)
        {
            return optionCode == 0 
                   || optionCode == 66
                   || optionCode == 67
                   || optionCode == 255;
        }

        private BinaryValue GetOptionInternal(byte optionCode)
        {
            var optionsReader = new KeyLengthValueReader(_packetBytes, OptionsIndex, _packetBytes.Length - OptionsIndex);

            var results = new List<BinaryValue>(1);

            while (optionsReader.Next())
            {
                if (optionsReader.CurrentItemKey == optionCode)
                {
                    results.Add(optionsReader.GetCurrentItemValue());
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
                    if (overloadedOptionsReader.CurrentItemKey == optionCode)
                    {
                        results.Add(overloadedOptionsReader.GetCurrentItemValue());
                    }
                }
            }

            if (results.Count == 0)
            {
                return null;
            }

            return BinaryValue.Concat(results);
        }
    }
}