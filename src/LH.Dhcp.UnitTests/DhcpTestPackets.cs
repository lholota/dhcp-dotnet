using System.Collections;
using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Options;

namespace LH.Dhcp.UnitTests
{
    public class DhcpTestPackets : IEnumerable<object[]>
    {
        /*
Dynamic Host Configuration Protocol (Discover)
    Message type: Boot Request (1)
    Hardware type: Ethernet (0x01)
    Hardware address length: 6
    Hops: 2
    Transaction ID: 0x5e005030
    Seconds elapsed: 4
    Bootp flags: 0x8000, Broadcast flag (Broadcast)
    Client IP address: 0.0.0.0
    Your (client) IP address: 0.0.0.0
    Next server IP address: 0.0.0.0
    Relay agent IP address: 0.0.0.0
    Client MAC address: Microsof_00:50:30 (00:15:5d:00:50:30)
    Client hardware address padding: 00000000000000000000
    Server host name not given
    Boot file name not given
    Magic cookie: DHCP
    Option: (53) DHCP Message Type (Discover)
        Length: 1
        DHCP: Discover (1)
    Option: (55) Parameter Request List
        Length: 24
        Parameter Request List Item: (1) Subnet Mask
        Parameter Request List Item: (2) Time Offset
        Parameter Request List Item: (3) Router
        Parameter Request List Item: (5) Name Server
        Parameter Request List Item: (6) Domain Name Server
        Parameter Request List Item: (11) Resource Location Server
        Parameter Request List Item: (12) Host Name
        Parameter Request List Item: (13) Boot File Size
        Parameter Request List Item: (15) Domain Name
        Parameter Request List Item: (16) Swap Server
        Parameter Request List Item: (17) Root Path
        Parameter Request List Item: (18) Extensions Path
        Parameter Request List Item: (43) Vendor-Specific Information
        Parameter Request List Item: (54) DHCP Server Identifier
        Parameter Request List Item: (60) Vendor class identifier
        Parameter Request List Item: (67) Bootfile name
        Parameter Request List Item: (128) DOCSIS full security server IP [TODO]
        Parameter Request List Item: (129) PXE - undefined (vendor specific)
        Parameter Request List Item: (130) PXE - undefined (vendor specific)
        Parameter Request List Item: (131) PXE - undefined (vendor specific)
        Parameter Request List Item: (132) PXE - undefined (vendor specific)
        Parameter Request List Item: (133) PXE - undefined (vendor specific)
        Parameter Request List Item: (134) PXE - undefined (vendor specific)
        Parameter Request List Item: (135) PXE - undefined (vendor specific)
    Option: (57) Maximum DHCP Message Size
        Length: 2
        Maximum DHCP Message Size: 1260
    Option: (97) UUID/GUID-based Client Identifier
        Length: 17
        Client Identifier (UUID): de7c2586-dc4e-4e8a-8940-a4847f362d09
    Option: (93) Client System Architecture
        Length: 2
        Client System Architecture: IA x86 PC (0)
    Option: (94) Client Network Device Interface
        Length: 3
        Major Version: 2
        Minor Version: 1
    Option: (60) Vendor class identifier
        Length: 32
        Vendor class identifier: PXEClient:Arch:00000:UNDI:002001
    Option: (255) End
        Option End: 255
    Padding: 000000000000000000000000000000000000000000000000…

         
         */

        public static readonly DhcpTestPacket Discover = new DhcpTestPacket(
            "010106025e005030000480000000000000000000000000000000000000155d0050300000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000063825363350101371801020305060b0c0d0f1011122b363c438081828384858687390204ec61110086257cde4edc8a4e8940a4847f362d095d0200005e030102013c20505845436c69656e743a417263683a30303030303a554e44493a303032303031ff0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000",
            0x5e005030,
            DhcpOperation.BootRequest,
            ClientHardwareAddressType.Ethernet,
            new byte[] { 0x00, 0x15, 0x5d, 0x00, 0x50, 0x30 },
            2,
            4,
            true,
            IPAddress.Parse("0.0.0.0"),
            IPAddress.Parse("0.0.0.0"),
            IPAddress.Parse("0.0.0.0"),
            IPAddress.Parse("0.0.0.0"),
            string.Empty,
            string.Empty,
            new List<IDhcpOption>());


        public static readonly DhcpTestPacket DiscoverWithoutMagicCookie = new DhcpTestPacket(
            "010106005e005030000480000000000000000000000000000000000000155d0050300000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000350101371801020305060b0c0d0f1011122b363c438081828384858687390204ec61110086257cde4edc8a4e8940a4847f362d095d0200005e030102013c20505845436c69656e743a417263683a30303030303a554e44493a303032303031ff0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000",
            0x5e005030,
            DhcpOperation.BootRequest,
            ClientHardwareAddressType.Ethernet,
            new byte[] { 0x00, 0x15, 0x5d, 0x00, 0x50, 0x30 },
            0,
            4,
            true,
            IPAddress.Parse("0.0.0.0"),
            IPAddress.Parse("0.0.0.0"),
            IPAddress.Parse("0.0.0.0"),
            IPAddress.Parse("0.0.0.0"),
            string.Empty,
            string.Empty,
            new List<IDhcpOption>());


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
            new List<IDhcpOption>
            {
                new DhcpSubnetMaskOption(IPAddress.Parse("255.255.255.0"))
            });
        

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { Discover };
            yield return new object[] { Offer };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}