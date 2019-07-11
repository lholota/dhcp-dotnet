using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Options;
using LH.Dhcp.UnitTests.Extensions;

namespace LH.Dhcp.UnitTests
{
    public class DhcpTestPacket
    {
        public DhcpTestPacket(
            string hexBytes, 
            uint transactionId, 
            DhcpOperation operation, 
            ClientHardwareAddressType clientHardwareAddressType,
            byte[] clientHardwareAddressBytes,
            uint hops,
            uint secs,
            bool isBroadcast,
            IPAddress clientIp,
            IPAddress yourIp,
            IPAddress serverIp,
            IPAddress gatewayIp,
            string serverName,
            string bootFile,
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
            BootFile = bootFile;
            Options = options;
        }

        public byte[] Bytes { get; }

        public uint TransactionId { get; }

        public DhcpOperation Operation { get; }

        public ClientHardwareAddressType ClientHardwareAddressType { get; }

        public byte[] ClientHardwareAddressBytes { get; }

        public uint Hops { get; }

        public uint Secs { get; }

        public bool IsBroadcast { get; }

        public IPAddress ClientIp { get; }

        public IPAddress YourIp { get; }

        public IPAddress ServerIp { get; }

        public IPAddress GatewayIp { get; }

        public string ServerName { get; }

        public string BootFile { get; }

        public IReadOnlyList<IDhcpOption> Options { get; }
    }
}