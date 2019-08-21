using System.Collections.Generic;
using System.Net;
using LH.Dhcp.vNext.Options;
using LH.Dhcp.vNext.UnitTests.Extensions;

namespace LH.Dhcp.vNext.UnitTests
{
    public class DhcpTestPacket
    {
        public DhcpTestPacket(
            string hexBytes, 
            uint transactionId, 
            DhcpOperation operation, 
            ClientHardwareAddressType clientHardwareAddressType,
            byte[] clientHardwareAddressBytes,
            byte hops,
            uint secs,
            bool isBroadcast,
            IPAddress clientIp,
            IPAddress yourIp,
            IPAddress serverIp,
            IPAddress gatewayIp,
            string serverName,
            string bootFileName,
            IReadOnlyList<IDhcpOption> options)
        {
            Bytes = hexBytes.AsHexBytes();

            TransactionId = transactionId;
            Operation = operation;
            ClientHardwareAddressType = clientHardwareAddressType;
            ClientHardwareAddressBytes = clientHardwareAddressBytes;
            Hops = hops;
            Secs = secs;
            IsBroadcast = isBroadcast;
            ClientIp = clientIp;
            YourIp = yourIp;
            ServerIp = serverIp;
            GatewayIp = gatewayIp;
            ServerName = serverName;
            BootFileName = bootFileName;
            Options = options;
        }

        public byte[] Bytes { get; }

        public uint TransactionId { get; }

        public DhcpOperation Operation { get; }

        public ClientHardwareAddressType ClientHardwareAddressType { get; }

        public byte[] ClientHardwareAddressBytes { get; }

        public byte Hops { get; }

        public uint Secs { get; }

        public bool IsBroadcast { get; }

        public IPAddress ClientIp { get; }

        public IPAddress YourIp { get; }

        public IPAddress ServerIp { get; }

        public IPAddress GatewayIp { get; }

        public string ServerName { get; }

        public string BootFileName { get; }

        public IReadOnlyList<IDhcpOption> Options { get; }
    }
}