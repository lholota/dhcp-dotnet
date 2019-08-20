using System;
using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Options;
using LH.Dhcp.Serialization;

namespace LH.Dhcp
{
    public class DhcpPacketBuilder
    {
        public static DhcpPacketBuilder Create()
        {
            return new DhcpPacketBuilder();
        }

        private uint _hops;
        private ushort _secs;
        private uint _transactionId;
        private DhcpOperation _operation;
        private ClientHardwareAddress _clientHardwareAddress;
        private bool _isBroadcast;
        private IPAddress _clientIp;
        private IPAddress _yourIp;
        private IPAddress _serverIp;
        private IPAddress _gatewayIp;
        private string _serverName;
        private string _bootFile;

        private readonly Dictionary<byte, IBinaryValue> _options;

        private DhcpPacketBuilder()
        {
            _options = new Dictionary<byte, IBinaryValue>();
        }

        internal DhcpPacketBuilder WithOperation(DhcpOperation operation)
        {
            _operation = operation;

            return this;
        }

        public DhcpPacketBuilder WithClientHardwareAddress(ClientHardwareAddressType addressType, byte[] addressBytes)
        {
            _clientHardwareAddress = new ClientHardwareAddress(addressType, addressBytes);

            return this;
        }

        public DhcpPacketBuilder WithHops(uint hops)
        {
            _hops = hops;

            return this;
        }

        public DhcpPacketBuilder WithTransactionId(uint transactionId)
        {
            _transactionId = transactionId;

            return this;
        }

        public DhcpPacketBuilder WithSecs(ushort secs)
        {
            _secs = secs;

            return this;
        }

        public DhcpPacketBuilder WithBroadcastFlag(bool isBroadcast)
        {
            _isBroadcast = isBroadcast;

            return this;
        }

        public DhcpPacketBuilder WithClientIp(IPAddress clientIp)
        {
            _clientIp = clientIp;

            return this;
        }

        public DhcpPacketBuilder WithYourIp(IPAddress yourIp)
        {
            _yourIp = yourIp;

            return this;
        }

        public DhcpPacketBuilder WithServerIp(IPAddress serverIp)
        {
            _serverIp = serverIp;

            return this;
        }

        public DhcpPacketBuilder WithGatewayIp(IPAddress gatewayIp)
        {
            _gatewayIp = gatewayIp;

            return this;
        }

        public DhcpPacketBuilder WithServerName(string serverName)
        {
            _serverName = serverName;

            return this;
        }

        public DhcpPacketBuilder WithBootFile(string bootFile)
        { 
            _bootFile = bootFile;

            return this;
        }

        public DhcpPacketBuilder WithOption(byte optionCode, IBinaryValue value)
        {
            if (_options.ContainsKey(optionCode))
            {
                _options.Remove(optionCode);
            }

            _options.Add(optionCode, value);

            return this;
        }

        public DhcpPacketBuilder WithOption(IDhcpOption semanticOption)
        {
            throw new NotImplementedException();
        }

        public DhcpPacketBuilder WithOptions(IEnumerable<KeyValuePair<byte, IBinaryValue>> optionsToAdd)
        {
            foreach (var optionToAdd in optionsToAdd)
            {
                WithOption(optionToAdd.Key, optionToAdd.Value);
            }

            return this;
        }

        public DhcpPacketBuilder WithOptions(IEnumerable<IDhcpOption> optionsToAdd)
        {
            throw new NotImplementedException();
        }

        public DhcpPacket Build()
        {
            return new DhcpPacket(
                _transactionId,
                _operation,
                _clientHardwareAddress,
                _hops,
                _secs,
                _isBroadcast,
                _clientIp,
                _yourIp,
                _serverIp,
                _gatewayIp,
                _serverName,
                _bootFile,
                _options);
        }
    }
}