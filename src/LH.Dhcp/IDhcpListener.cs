using System;

namespace LH.Dhcp
{
    public interface IDhcpListener : IDisposable
    {
        event EventHandler<DhcpPacketEventArgs> PacketReceived;

        void StartIfNotRunning();
    }
}