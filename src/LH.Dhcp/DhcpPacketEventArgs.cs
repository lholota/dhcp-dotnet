using System;

namespace LH.Dhcp
{
    public class DhcpPacketEventArgs : EventArgs
    {
        public DhcpPacketEventArgs(DhcpPacket packet)
        {
            Packet = packet;
        }

        public DhcpPacket Packet { get; }
    }
}