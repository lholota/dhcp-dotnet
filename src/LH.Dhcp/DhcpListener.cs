using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using LH.Dhcp.Extensions;
using LH.Dhcp.Serialization;
using Microsoft.Extensions.Logging;

namespace LH.Dhcp
{
    public class DhcpListener : IDhcpListener
    {
        private const int DhcpClientPort2 = 68;

        private Task _listeningTask;

        private readonly ILogger<DhcpListener> _logger;
        private readonly IDhcpPacketSerializer _serializer;
        private readonly object _listeningTaskLock = new object();
        private readonly UdpClient _udpClient;
        private readonly IPEndPoint _udpClientEndpoint;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public DhcpListener(ILogger<DhcpListener> logger, IDhcpPacketSerializer serializer)
        {
            _logger = logger;
            _serializer = serializer;

            _cancellationTokenSource = new CancellationTokenSource();

            _udpClientEndpoint = new IPEndPoint(IPAddress.Any, DhcpClientPort2);

            _udpClient = new UdpClient();
            _udpClient.EnableBroadcast = true;
            _udpClient.ExclusiveAddressUse = false;
        }

        public event EventHandler<DhcpPacketEventArgs> PacketReceived;

        public void StartIfNotRunning()
        {
            if (_listeningTask == null)
            {
                lock (_listeningTaskLock)
                {
                    if (_listeningTask == null)
                    {
                        _udpClient.Client.Bind(_udpClientEndpoint);

                        _listeningTask = ListenContinously(_cancellationTokenSource.Token);
                    }
                }
            }
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();

            WaitForListeningTaskToComplete();

            _udpClient.Dispose();

            _cancellationTokenSource.Dispose();
        }

        private void OnPacketReceived(DhcpPacket packet)
        {
            var args = new DhcpPacketEventArgs(packet);

            PacketReceived?.Invoke(this, args);
        }

        private async Task ListenContinously(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                var receivedBytes = await _udpClient
                    .ReceiveAsync()
                    .WithCancellation(ct);

                try
                {
                    var dhcpPacket = _serializer.Deserialize(receivedBytes.Buffer);

                    OnPacketReceived(dhcpPacket);
                }
                catch (DhcpSerializationException e)
                {
                    _logger.LogDebug(e, "Received invalid UDP packet which could not be parsed as DHCP packet.");
                }
            }
        }

        private void WaitForListeningTaskToComplete()
        {
            try
            {
                _listeningTask?.Wait();
            }
            catch (AggregateException e)
            {
                if (!(e.InnerException is TaskCanceledException))
                {
                    throw;
                }
            }
        }
    }
}