using System.Net;

namespace LH.Dhcp.vNext.UnitTests.TestData
{
    public partial class DhcpTestPackets
    {
        /*
            Dynamic Host Configuration Protocol (Offer)
            Message type: Boot Reply (2)
            Hardware type: Ethernet (0x01)
            Hardware address length: 6
            Hops: 0
            Transaction ID: 0x5e005030
            Seconds elapsed: 4
            Bootp flags: 0x8000, Broadcast flag (Broadcast)
            Client IP address: 0.0.0.0
            Your (client) IP address: 192.168.1.100
            Next server IP address: 192.168.1.13
            Relay agent IP address: 0.0.0.0
            Client MAC address: Microsof_00:50:30 (00:15:5d:00:50:30)
            Client hardware address padding: 00000000000000000000
            Server host name not given
            Boot file name: undionly.kpxe
            Magic cookie: DHCP
            Option: (53) DHCP Message Type (Offer)
               Length: 1
               DHCP: Offer (2)
            Option: (54) DHCP Server Identifier (192.168.1.2)
               Length: 4
               DHCP Server Identifier: 192.168.1.2
            Option: (51) IP Address Lease Time
               Length: 4
               IP Address Lease Time: (600s) 10 minutes
            Option: (1) Subnet Mask (255.255.255.0)
               Length: 4
               Subnet Mask: 255.255.255.0
            Option: (3) Router
               Length: 4
               Router: 192.168.1.1
            Option: (6) Domain Name Server
               Length: 4
               Domain Name Server: 8.8.8.8
            Option: (255) End
               Option End: 255
            Padding: 000000000000000000000000000000000000000000000000…
        */

		/// <summary>
        /// DHCP Offer packet returned by ISC DHCP server. The packet has options internally, but they have not been set to the TestPacket (TBA when required)
        /// </summary>
        public static readonly DhcpTestPacket Offer = new DhcpTestPacket(
            "020106005e0050300004800000000000c0a80164c0a8010d0000000000155d0050300000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000756e64696f6e6c792e6b70786500000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000638253633501023604c0a801023304000002580104ffffff000304c0a80101060408080808ff0000000000000000000000000000000000000000000000000000",
            0x5e005030,
            DhcpOperation.BootReply,
            ClientHardwareAddressType.Ethernet,
            new byte[] { 0x00, 0x15, 0x5d, 0x00, 0x50, 0x30 },
            0,
            4,
            true,
            IPAddress.Parse("0.0.0.0"),
            IPAddress.Parse("192.168.1.100"),
            IPAddress.Parse("192.168.1.13"),
            IPAddress.Parse("0.0.0.0"),
            string.Empty,
            "undionly.kpxe",
            null);
    }
}