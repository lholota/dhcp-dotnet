namespace LH.Dhcp.Options
{
    internal enum DhcpOptionTypeCode
    {
        Pad = 0,

        /// <summary>
        /// Subnet Mask Value
        /// </summary>
        SubnetMask = 1,

        /// <summary>
        /// Time Offset in Seconds from UTC (note: deprecated by 100 and 101)
        /// </summary>
        TimeOffset = 2,

        /// <summary>
        /// N/4 Router addresses
        /// </summary>
        Router = 3,

        /// <summary>
        /// N/4 Timeserver addresses
        /// </summary>
        TimeServer = 4,

        /// <summary>
        /// N/4 IEN-116 Server addresses
        /// </summary>
        NameServer = 5,

        /// <summary>
        /// N/4 DNS Server addresses
        /// </summary>
        DomainServer = 6,

        /// <summary>
        /// N/4 Logging Server addresses
        /// </summary>
        LogServer = 7,

        /// <summary>
        /// N/4 Quotes Server addresses
        /// </summary>
        QuotesServer = 8,

        /// <summary>
        /// N/4 Printer Server addresses
        /// </summary>
        LPRServer = 9,
        /// <summary>
        /// N/4 Impress Server addresses
        /// </summary>
        ImpressServer = 10,
        /// <summary>
        /// N/4 RLP Server addresses
        /// </summary>
        RLPServer = 11,
        /// <summary>
        /// Hostname string
        /// </summary>
        Hostname = 12,
        /// <summary>
        /// Size of boot file in 512 byte chunks
        /// </summary>
        BootFileSize = 13,
        /// <summary>
        /// Client to dump and name the file to dump it to
        /// </summary>
        MeritDumpFile = 14,
        /// <summary>
        /// The DNS domain name of the client
        /// </summary>
        DomainName = 15,
        /// <summary>
        /// Swap Server address
        /// </summary>
        SwapServer = 16,
        /// <summary>
        /// Path name for root disk
        /// </summary>
        RootPath = 17,
        /// <summary>
        /// Path name for more BOOTP info
        /// </summary>
        ExtensionFile = 18,
        /// <summary>
        /// Enable/Disable IP Forwarding
        /// </summary>
        ForwardOnOff = 19,
        /// <summary>
        /// Enable/Disable Source Routing
        /// </summary>
        SrcRteOnOff = 20,
        /// <summary>
        /// Routing Policy Filters
        /// </summary>
        PolicyFilter = 21,
        /// <summary>
        /// Max Datagram Reassembly Size
        /// </summary>
        MaxDGAssembly = 22,
        /// <summary>
        /// Default IP Time to Live
        /// </summary>
        DefaultIPTTL = 23,
        /// <summary>
        /// Path MTU Aging Timeout
        /// </summary>
        MTUTimeout = 24,
        /// <summary>
        /// Path MTU Plateau Table
        /// </summary>
        MTUPlateau = 25,
        /// <summary>
        /// Interface MTU Size
        /// </summary>
        MTUInterface = 26,
        /// <summary>
        /// All Subnets are Local
        /// </summary>
        MTUSubnet = 27,
        /// <summary>
        /// Broadcast Address
        /// </summary>
        BroadcastAddress = 28,
        /// <summary>
        /// Perform Mask Discovery
        /// </summary>
        MaskDiscovery = 29,
        /// <summary>
        /// Provide Mask to Others
        /// </summary>
        MaskSupplier = 30,
        /// <summary>
        /// Perform Router Discovery
        /// </summary>
        RouterDiscovery = 31,
        /// <summary>
        /// Router Solicitation Address
        /// </summary>
        RouterRequest = 32,
        /// <summary>
        /// Static Routing Table
        /// </summary>
        StaticRoute = 33,
        /// <summary>
        /// Trailer Encapsulation
        /// </summary>
        Trailers = 34,
        /// <summary>
        /// ARP Cache Timeout
        /// </summary>
        ARPTimeout = 35,
        /// <summary>
        /// Ethernet Encapsulation
        /// </summary>
        Ethernet = 36,
        /// <summary>
        /// Default TCP Time to Live
        /// </summary>
        DefaultTCPTTL = 37,
        /// <summary>
        /// TCP Keepalive Interval
        /// </summary>
        KeepaliveTime = 38,
        /// <summary>
        /// TCP Keepalive Garbage
        /// </summary>
        KeepaliveData = 39,
        /// <summary>
        /// NIS Domain Name
        /// </summary>
        NISDomain = 40,
        /// <summary>
        /// NIS Server Addresses
        /// </summary>
        NISServers = 41,
        /// <summary>
        /// NTP Server Addresses
        /// </summary>
        NTPServers = 42,
        /// <summary>
        /// Vendor Specific Information
        /// </summary>
        VendorSpecific = 43,
        /// <summary>
        /// NETBIOS Name Servers
        /// </summary>
        NETBIOSNameSrv = 44,
        /// <summary>
        /// NETBIOS Datagram Distribution
        /// </summary>
        NETBIOSDistSrv = 45,
        /// <summary>
        /// NETBIOS Node Type
        /// </summary>
        NETBIOSNodeType = 46,
        /// <summary>
        /// NETBIOS Scope
        /// </summary>
        NETBIOSScope = 47,
        /// <summary>
        /// X Window Font Server
        /// </summary>
        XWindowFont = 48,
        /// <summary>
        /// X Window Display Manager
        /// </summary>
        XWindowManager = 49,
        /// <summary>
        /// Requested IP Address
        /// </summary>
        AddressRequest = 50,
        /// <summary>
        /// IP Address Lease Time
        /// </summary>
        AddressTime = 51,
        /// <summary>
        /// Overload sname or file
        /// </summary>
        Overload = 52,
        /// <summary>
        /// DHCP Message Type
        /// </summary>
        DHCPMsgType = 53,
        /// <summary>
        /// DHCP Server Identification
        /// </summary>
        DHCPServerId = 54,
        /// <summary>
        /// Parameter Request List
        /// </summary>
        ParameterList = 55,
        /// <summary>
        /// DHCP Error Message
        /// </summary>
        DHCPMessage = 56,
        /// <summary>
        /// DHCP Maximum Message Size
        /// </summary>
        DHCPMaxMsgSize = 57,
        /// <summary>
        /// DHCP Renewal (T1) Time
        /// </summary>
        RenewalTime = 58,
        /// <summary>
        /// DHCP Rebinding (T2) Time
        /// </summary>
        RebindingTime = 59,
        /// <summary>
        /// Class Identifier
        /// </summary>
        ClassId = 60,
        /// <summary>
        /// Client Identifier
        /// </summary>
        ClientId = 61,
        /// <summary>
        /// NetWare/IP Domain Name
        /// </summary>
        NetWareIPDomain = 62,
        /// <summary>
        /// NetWare/IP sub Options
        /// </summary>
        NetWareIPOption = 63,
        /// <summary>
        /// NIS+ v3 Client Domain Name
        /// </summary>
        NISDomainName = 64,
        /// <summary>
        /// NIS+ v3 Server Addresses
        /// </summary>
        NISServerAddr = 65,
        /// <summary>
        /// TFTP Server Name
        /// </summary>
        ServerName = 66,
        /// <summary>
        /// Boot File Name
        /// </summary>
        BootfileName = 67,
        /// <summary>
        /// Home Agent Addresses
        /// </summary>
        HomeAgentAddrs = 68,
        /// <summary>
        /// Simple Mail Server Addresses
        /// </summary>
        SMTPServer = 69,
        /// <summary>
        /// Post Office Server Addresses
        /// </summary>
        POP3Server = 70,
        /// <summary>
        /// Network News Server Addresses
        /// </summary>
        NNTPServer = 71,
        /// <summary>
        /// WWW Server Addresses
        /// </summary>
        WWWServer = 72,
        /// <summary>
        /// Finger Server Addresses
        /// </summary>
        FingerServer = 73,
        /// <summary>
        /// Chat Server Addresses
        /// </summary>
        IRCServer = 74,
        /// <summary>
        /// StreetTalk Server Addresses
        /// </summary>
        StreetTalkServer = 75,
        /// <summary>
        /// ST Directory Assist. Addresses
        /// </summary>
        STDAServer = 76,
        /// <summary>
        /// User Class Information
        /// </summary>
        UserClass = 77,
        /// <summary>
        /// directory agent information
        /// </summary>
        DirectoryAgent = 78,
        /// <summary>
        /// service location agent scope
        /// </summary>
        ServiceScope = 79,
        /// <summary>
        /// Rapid Commit
        /// </summary>
        RapidCommit = 80,
        /// <summary>
        /// Fully Qualified Domain Name
        /// </summary>
        ClientFQDN = 81,
        /// <summary>
        /// Relay Agent Information
        /// </summary>
        RelayAgentInformation = 82,
        /// <summary>
        /// Internet Storage Name Service
        /// </summary>
        iSNS = 83,
        /// <summary>
        /// Novell Directory Services
        /// </summary>
        NDSServers = 85,
        /// <summary>
        /// Novell Directory Services
        /// </summary>
        NDSTreeName = 86,
        /// <summary>
        /// Novell Directory Services
        /// </summary>
        NDSContext = 87,
        /// <summary>
        /// 
        /// </summary>
        BCMCSControllerDomainNamelist = 88,
        /// <summary>
        /// 
        /// </summary>
        BCMCSControllerIPv4addressoption = 89,
        /// <summary>
        /// Authentication
        /// </summary>
        Authentication = 90,
        /// <summary>
        /// 
        /// </summary>
        ClientLastTransactionTimeoption = 91,
        /// <summary>
        /// 
        /// </summary>
        AssociatedIpOption = 92,
        /// <summary>
        /// Client System Architecture
        /// </summary>
        ClientSystem = 93,
        /// <summary>
        /// Client Network Device Interface
        /// </summary>
        ClientNDI = 94,
        /// <summary>
        /// Lightweight Directory Access Protocol
        /// </summary>
        LDAP = 95,
        /// <summary>
        /// UUID/GUID-based Client Identifier
        /// </summary>
        UUID_GUID = 97,
        /// <summary>
        /// Open Group's User Authentication
        /// </summary>
        UserAuth = 98,
        /// <summary>
        /// 
        /// </summary>
        GEOCONF_CIVIC = 99,
        /// <summary>
        /// IEEE 1003.1 TZ String
        /// </summary>
        PCode = 100,
        /// <summary>
        /// Reference to the TZ Database
        /// </summary>
        TCode = 101,
        /// <summary>
        /// DHCPv4 over DHCPv6 Softwire Source Address Option
        /// </summary>
        OPTION_DHCP4O6_S46_SADDR = 109,
        /// <summary>
        /// NetInfo Parent Server Address
        /// </summary>
        NetinfoAddress = 112,
        /// <summary>
        /// NetInfo Parent Server Tag
        /// </summary>
        NetinfoTag = 113,
        /// <summary>
        /// URL
        /// </summary>
        URL = 114,
        /// <summary>
        /// DHCP Auto-Configuration
        /// </summary>
        AutoConfig = 116,
        /// <summary>
        /// Name Service Search
        /// </summary>
        NameServiceSearch = 117,
        /// <summary>
        /// Subnet Selection Option
        /// </summary>
        SubnetSelectionOption = 118,
        /// <summary>
        /// DNS domain search list
        /// </summary>
        DomainSearch = 119,
        /// <summary>
        /// SIP Servers DHCP Option
        /// </summary>
        SIPServersDHCPOption = 120,
        /// <summary>
        /// Classless Static Route Option
        /// </summary>
        ClasslessStaticRouteOption = 121,
        /// <summary>
        /// CableLabs Client Configuration
        /// </summary>
        CCC = 122,
        /// <summary>
        /// GeoConf Option
        /// </summary>
        GeoConfOption = 123,
        /// <summary>
        /// Vendor-Identifying Vendor Class
        /// </summary>
        VIVendorClass = 124,
        /// <summary>
        /// Vendor-Identifying Vendor-Specific Information
        /// </summary>
        VIVendorSpecificInformation = 125,
        /// <summary>
        /// 
        /// </summary>
        Etherbootsignature = 128,
        /// <summary>
        /// 
        /// </summary>
        DOCSISfullsecurityserverIPaddress = 128,
        /// <summary>
        /// 
        /// </summary>
        TFTPServerIPaddress_forIPPhonesoftwareload = 128,
        /// <summary>
        /// 
        /// </summary>
        KerneloptionsVariableLengthString = 129,
        /// <summary>
        /// 
        /// </summary>
        CallServerIPaddress = 129,
        /// <summary>
        /// 
        /// </summary>
        EthernetInterfaceVariableLengthString = 130,
        /// <summary>
        /// 
        /// </summary>
        DiscriminationString = 130,
        /// <summary>
        /// 
        /// </summary>
        RemotestatisticsserverIPaddress = 131,

        /// <summary>
        /// 
        /// </summary>
        IEEE8021QVLANID = 132,

        /// <summary>
        /// 
        /// </summary>
        IEEE8021D_pLayer2Priority = 133,

        /// <summary>
        /// 
        /// </summary>
        DiffservCodePoint_DSCP_forVoIPsignallingandmediastreams = 134,
        /// <summary>
        /// 
        /// </summary>
        HTTPProxyForPhonSpecificapplications = 135,
        /// <summary>
        /// 
        /// </summary>
        OPTION_PANA_AGENT = 136,
        /// <summary>
        /// 
        /// </summary>
        OPTION_V4_LOST = 137,
        /// <summary>
        /// CAPWAP Access Controller addresses
        /// </summary>
        OPTION_CAPWAP_AC_V4 = 138,
        /// <summary>
        /// a series of suboptions
        /// </summary>
        OPTIONIPv4_Address_MoS = 139,
        /// <summary>
        /// a series of suboptions
        /// </summary>
        OPTION_IPv4_FQDN_MoS = 140,
        /// <summary>
        /// List of domain names to search for SIP User Agent Configuration
        /// </summary>
        SIPUAConfigurationServiceDomains = 141,
        /// <summary>
        /// ANDSF IPv4 Address Option for DHCPv4
        /// </summary>
        OPTION_IPv4_Address_ANDSF = 142,
        /// <summary>
        /// This option provides a list of URIs for SZTP bootstrap servers
        /// </summary>
        OPTION_V4_SZTP_REDIRECT = 143,
        /// <summary>
        /// Geospatial Location with Uncertainty
        /// </summary>
        GeoLoc = 144,
        /// <summary>
        /// Forcerenew Nonce Capable
        /// </summary>
        FORCERENEW_NONCE_CAPABLE = 145,
        /// <summary>
        /// Information for selecting RDNSS
        /// </summary>
        RDNSSSelection = 146,
        /// <summary>
        /// 
        /// </summary>
        Unassigned = 147 - 149,
        /// <summary>
        /// 
        /// </summary>
        TFTPserveraddress = 150,
        /// <summary>
        /// 
        /// </summary>
        Etherboot = 150,
        /// <summary>
        /// 
        /// </summary>
        GRUBconfigurationpathname = 150,
        /// <summary>
        /// Status code and optional N byte text message describing status.
        /// </summary>
        StatusCode = 151,
        /// <summary>
        /// Absolute time (seconds since Jan 1, 1970) message was sent.
        /// </summary>
        BaseTime = 152,
        /// <summary>
        /// Number of seconds in the past when client entered current state.
        /// </summary>
        StartTimeOfState = 153,
        /// <summary>
        /// Absolute time (seconds since Jan 1, 1970) for beginning of query.
        /// </summary>
        QueryStartTime = 154,
        /// <summary>
        /// Absolute time (seconds since Jan 1, 1970) for end of query.
        /// </summary>
        QueryEndTime = 155,
        /// <summary>
        /// State of IP address.
        /// </summary>
        DhcpState = 156,
        /// <summary>
        /// Indicates information came from local or remote server.
        /// </summary>
        DataSource = 157,
        /// <summary>
        /// Includes one or multiple lists of PCP server IP addresses; each list is treated as a separate PCP server.
        /// </summary>
        OPTION_V4_PCP_SERVER = 158,
        /// <summary>
        /// This option is used to configure a set of ports bound to a shared IPv4 address.
        /// </summary>
        OPTION_V4_PORTPARAMS = 159,
        /// <summary>
        /// DHCP Captive-Portal
        /// </summary>
        DHCPCaptivePortal = 160,
        /// <summary>
        /// Manufacturer Usage Descriptions
        /// </summary>
        OPTION_MUD_URL_V4 = 161,
        /// <summary>
        /// 
        /// </summary>
        IPTelephone = 176,
        /// <summary>
        /// Magic String = F1:00:74:7E
        /// </summary>
        PXELINUXMagic = 208,
        /// <summary>
        /// Configuration file
        /// </summary>
        ConfigurationFile = 209,
        /// <summary>
        /// Path Prefix Option
        /// </summary>
        PathPrefix = 210,
        /// <summary>
        /// Reboot Time
        /// </summary>
        RebootTime = 211,
        /// <summary>
        /// OPTION_6RD with N/4 6rd BR addresses
        /// </summary>
        OPTION_6RD = 212,
        /// <summary>
        /// Access Network Domain Name
        /// </summary>
        OPTION_V4_ACCESS_DOMAIN = 213,
        /// <summary>
        /// Subnet Allocation Option
        /// </summary>
        SubnetAllocationOption = 220,
        /// <summary>
        /// 
        /// </summary>
        VirtualSubnetSelection_VSS_Option = 221,
        /// <summary>
        /// 
        /// </summary>
        Reserved_PrivateUse = 224-254,
        /// <summary>
        /// None
        /// </summary>
        End = 255
    }
}