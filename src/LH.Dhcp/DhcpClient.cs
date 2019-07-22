using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using LH.Dhcp.Extensions;
using LH.Dhcp.Serialization;
using Microsoft.Extensions.Logging;

namespace LH.Dhcp
{
    public class DhcpClient : IDhcpClient
    {
        private const int DhcpServerPort = 67;

        private static readonly IPEndPoint BroadcastEndpoint = new IPEndPoint(IPAddress.Broadcast, DhcpServerPort);

        private readonly RNGCryptoServiceProvider _rngCryptoServiceProvider;
        private readonly IDhcpListener _dhcpListener;
        private readonly IDhcpPacketSerializer _serializer;
        private readonly ILogger<DhcpClient> _logger;

        public DhcpClient(IDhcpListener dhcpListener, IDhcpPacketSerializer serializer, ILogger<DhcpClient> logger)
        {
            _dhcpListener = dhcpListener;
            _serializer = serializer;
            _logger = logger;
            _rngCryptoServiceProvider = new RNGCryptoServiceProvider();
        }

        public async Task<IReadOnlyList<DhcpPacket>> Discover(DhcpDiscoveryParameters parameters, CancellationToken ct)
        {
            var results = new List<DhcpPacket>();
            var transactionId = GenerateTransactionId();

            void ReceptionCallback(object sender, DhcpPacketEventArgs args)
            {
                HandleDhcpResponseReceived(results, args, transactionId);
            }

            _dhcpListener.PacketReceived += ReceptionCallback;
            _dhcpListener.StartIfNotRunning();

            using (var udpClient = new UdpClient())
            {
                var broadcastPacket = CreateBroadcastPacket(parameters, transactionId);
                var broadcastPacketBytes = _serializer.Serialize(broadcastPacket);

                _logger.LogDebug("Sending broadcast DHCP Packet for transaction {0}", transactionId);

                await udpClient
                    .SendAsync(broadcastPacketBytes, broadcastPacketBytes.Length, BroadcastEndpoint)
                    .WithCancellation(ct)
                    .ConfigureAwait(false);
            }

            await Task.Delay(parameters.Timeout, ct).ConfigureAwait(false);

            _dhcpListener.PacketReceived -= ReceptionCallback;

            if (results.Count == 0)
            {
                throw new TimeoutException($"No DHCP response recieved for transaction {transactionId}.");
            }

            return results;
        }

        private uint GenerateTransactionId()
        {
            var bytes = new byte[4];

            _rngCryptoServiceProvider.GetBytes(bytes);

            return BitConverter.ToUInt32(bytes, 0);
        }

        private void HandleDhcpResponseReceived(IList<DhcpPacket> results, DhcpPacketEventArgs args, uint transactionId)
        {
            if (args.Packet.TransactionId == transactionId)
            {
                _logger.LogDebug("Received a DHCP Packet for transaction {0}", transactionId);

                results.Add(args.Packet);
            }
        }

        private DhcpPacket CreateBroadcastPacket(DhcpDiscoveryParameters parameters, uint transactionId)
        {
            // TODO: Use builder

            throw new NotImplementedException();
        }
    }
}
