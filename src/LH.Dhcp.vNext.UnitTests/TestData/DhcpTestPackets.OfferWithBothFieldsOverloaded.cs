using System.Collections.Generic;
using System.Net;
using LH.Dhcp.vNext.Options;

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
            Transaction ID: 0x4486302d
            Seconds elapsed: 0
            Bootp flags: 0x8000, Broadcast flag (Broadcast)
            Client IP address: 0.0.0.0
            Your (client) IP address: 192.168.1.103
            Next server IP address: 0.0.0.0
            Relay agent IP address: 0.0.0.0
            Client MAC address: de:ad:c0:de:ca:fe (de:ad:c0:de:ca:fe)
            Client hardware address padding: 00000000000000000000
            Server name option overloaded by DHCP
                [Expert Info (Note/Protocol): Server name option overloaded by DHCP]
            Boot file name option overloaded by DHCP
                [Expert Info (Note/Protocol): Boot file name option overloaded by DHCP]
            Magic cookie: DHCP
            Option: (53) DHCP Message Type (Offer)
                Length: 1
                DHCP: Offer (2)
            Option: (54) DHCP Server Identifier (192.168.1.2)
                Length: 4
                DHCP Server Identifier: 192.168.1.2
            Option: (51) IP Address Lease Time
                Length: 4
                IP Address Lease Time: (300s) 5 minutes
            Option: (1) Subnet Mask (255.255.255.0)
                Length: 4
                Subnet Mask: 255.255.255.0
            Option: (4) Time Server
                Length: 8
                Time Server: 192.168.1.103
                Time Server: 192.168.1.104
            Option: (7) Log Server
                Length: 8
                Log Server: 192.168.1.103
                Log Server: 192.168.1.104
            Option: (8) Quotes Server
                Length: 4
                Quotes Server: 192.168.1.108
            Option: (12) Host Name
                Length: 248
                Host Name [truncated]: dummy-hostnameaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbccccccccccccccccccccccccccccccccccccccdddddddddddddddddddddddddddddddddddeeeeeeeeeee
            Option: (23) Default IP Time-to-Live
                Length: 1
                Default IP Time-to-Live: 120
            Option: (37) TCP Default TTL
                Length: 1
                TCP Default TTL: 125
            Option: (52) Option Overload
                Length: 1
                Option Overload: Boot file and server host names hold options (3)
                Server host name option overload
                    Option: (67) Bootfile name
                        Length: 24
                        Bootfile name: some-file-name-in-option
                    Option: (66) TFTP Server Name
                        Length: 26
                        TFTP Server Name: some-server-name-in-option
                    Option: (255) End
                        Option End: 255
                Boot file name option overload
                    Option: (15) Domain Name
                        Length: 11
                        Domain Name: example.org
                    Option: (28) Broadcast Address (192.168.1.255)
                        Length: 4
                        Broadcast Address: 192.168.1.255
                    Option: (38) TCP Keepalive Interval
                        Length: 4
                        TCP Keepalive Interval: (30s) 30 seconds
                    Option: (39) TCP Keepalive Garbage
                        Length: 1
                        TCP Keepalive Garbage: Enabled
                    Option: (40) Network Information Service Domain
                        Length: 11
                        Network Information Service Domain: example.com
                    Option: (41) Network Information Service Servers
                        Length: 8
                        Network Information Service Server: 192.168.1.25
                        Network Information Service Server: 192.168.1.26
                    Option: (42) Network Time Protocol Servers
                        Length: 4
                        Network Time Protocol Server: 192.168.1.27
                    Option: (44) NetBIOS over TCP/IP Name Server
                        Length: 8
                        NetBIOS over TCP/IP Name Server: 192.168.1.28
                        NetBIOS over TCP/IP Name Server: 192.168.1.29
                    Option: (45) NetBIOS over TCP/IP Datagram Distribution Name Server
                        Length: 8
                        NetBIOS over TCP/IP Datagram Distribution Name Server: 192.168.1.30
                        NetBIOS over TCP/IP Datagram Distribution Name Server: 192.168.1.31
                    Option: (46) NetBIOS over TCP/IP Node Type
                        Length: 1
                        NetBIOS over TCP/IP Node Type: M-node (4)
                    Option: (47) NetBIOS over TCP/IP Scope
                        Length: 9
                        NetBIOS over TCP/IP Scope: hello.com
                    Option: (48) X Window System Font Server
                        Length: 8
                        X Window System Font Server: 192.168.1.32
                        X Window System Font Server: 192.168.1.33
                    Option: (49) X Window System Display Manager
                        Length: 8
                        X Window System Display Manager: 192.168.1.34
                        X Window System Display Manager: 192.168.1.35
                    Option: (255) End
                        Option End: 255
            Option: (255) End
                Option End: 255

         */

        public static readonly DhcpTestPacket OfferWithBothFieldsOverloaded = new DhcpTestPacket(
            "020106004486302d0000800000000000c0a801670000000000000000deadc0decafe000000000000000000004318736f6d652d66696c652d6e616d652d696e2d6f7074696f6e421a736f6d652d7365727665722d6e616d652d696e2d6f7074696f6eff0000000000000000000f0b6578616d706c652e6f72671c04c0a801ff26040000001e270101280b6578616d706c652e636f6d2908c0a80119c0a8011a2a04c0a8011b2c08c0a8011cc0a8011d2d08c0a8011ec0a8011f2e01042f0968656c6c6f2e636f6d3008c0a80120c0a801213108c0a80122c0a80123ff00000000000000000000000000000000638253633501023604c0a8010233040000012c0104ffffff000408c0a80167c0a801680708c0a80167c0a801680804c0a8016c0cf864756d6d792d686f73746e616d6561616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616262626262626262626262626262626262626262626262626262626262626263636363636363636363636363636363636363636363636363636363636363636363636363636464646464646464646464646464646464646464646464646464646464646464646464656565656565656565656565656565656565656565656565656565656565656565656565656565656565656517017825017d340103ff",
            0x4486302d,
            DhcpOperation.BootReply,
            ClientHardwareAddressType.Ethernet,
            new byte[] { 0xde, 0xad, 0xc0, 0xde, 0xca, 0xfe },
            0,
            0,
            true,
            IPAddress.Parse("0.0.0.0"),
            IPAddress.Parse("192.168.1.103"),
            IPAddress.Parse("0.0.0.0"),
            IPAddress.Parse("0.0.0.0"),
            "some-server-name-in-option",
            "some-file-name-in-option",
            new List<IDhcpOption>());
    }
}