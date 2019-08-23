﻿using System.Collections.Generic;
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
            Transaction ID: 0xc071582c
            Seconds elapsed: 0
            Bootp flags: 0x8000, Broadcast flag (Broadcast)
            Client IP address: 0.0.0.0
            Your (client) IP address: 192.168.1.103
            Next server IP address: 0.0.0.0
            Relay agent IP address: 0.0.0.0
            Client MAC address: de:ad:c0:de:ca:fe (de:ad:c0:de:ca:fe)
            Client hardware address padding: 00000000000000000000
            Server host name: some-server-name
            Boot file name not given
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
                Length: 14
                Host Name: 192.168.1.103
            Option: (15) Domain Name
                Length: 11
                Domain Name: example.org
            Option: (255) End
                Option End: 255
		 */

		/// <summary>
        /// Standard DHCP offer packet which has the server name (or sname) field filled in.
        /// </summary>
        public static readonly DhcpTestPacket OfferWithServerName = new DhcpTestPacket(
            "02010600c071582c0000800000000000c0a801670000000000000000deadc0decafe00000000000000000000736f6d652d7365727665722d6e616d650000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000638253633501023604c0a8010233040000012c0104ffffff000408c0a80167c0a801680708c0a80167c0a801680804c0a8016c0c0e3139322e3136382e312e313033000f0b6578616d706c652e6f7267ff",
            0xc071582c,
            DhcpOperation.BootReply,
            ClientHardwareAddressType.Ethernet,
            new byte[]{ 0xde, 0xad, 0xc0, 0xde, 0xca, 0xfe },
			0,
			0,
			true,
			IPAddress.Parse("0.0.0.0"),
			IPAddress.Parse("192.168.1.103"),
			IPAddress.Parse("0.0.0.0"),
			IPAddress.Parse("0.0.0.0"),
			"some-server-name",
			null,
			new List<IDhcpOption>());
    }
}