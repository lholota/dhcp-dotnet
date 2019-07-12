﻿using System;
using System.Linq;
using System.Net;
using LH.Dhcp.Options;
using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;
// ReSharper disable StringLiteralTypo

namespace LH.Dhcp.UnitTests.Serialization.DhcpOptionSerializerTests
{
    // ReSharper disable once InconsistentNaming
    public class DhcpOptionSerializer_DeserializeOptionsShould
    {
        private readonly DhcpOptionsSerializer _optionsSerializer;

        public DhcpOptionSerializer_DeserializeOptionsShould()
        {
            _optionsSerializer = new DhcpOptionsSerializer();
        }

        [Fact]
        public void SkipUnsupportedOptions()
        {
            var packetBytes = new byte[]
            {
                (byte)DhcpOptionTypeCode.Etherboot,
                2, // length
                1, // If the serializer does not skip this byte, it would try to parse it as a SubnetMask
                0,
                0,
                (byte)DhcpOptionTypeCode.End
            };

            var reader = new DhcpBinaryReader(packetBytes);

            _optionsSerializer.DeserializeOptions(reader);

            Assert.False(reader.CanRead());
        }

        [Fact]
        public void SkipPadOption()
        {
            var packetBytes = new byte[]
            {
                (byte)DhcpOptionTypeCode.Pad,
                (byte)DhcpOptionTypeCode.SubnetMask,
                4, // length
                255, // If the serializer does not skip this byte, it would try to parse it as a SubnetMask
                255,
                255,
                0,
                (byte)DhcpOptionTypeCode.End
            };

            var reader = new DhcpBinaryReader(packetBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            Assert.IsType<DhcpSubnetMaskOption>(options.Single());
        }

        [Fact]
        public void DeserializeSubnetMaskOption()
        {
            var optionsBytes = "0104ffffff00ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var subnetMaskOption = options.OfType<DhcpSubnetMaskOption>().Single();

            Assert.Equal(IPAddress.Parse("255.255.255.0"), subnetMaskOption.SubnetMask);
        }

        [Fact]
        public void DeserializeTimeOffsetOption()
        {
            var optionsBytes = "0204fffffda8ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var subnetMaskOption = options.OfType<DhcpTimeOffsetOption>().Single();

            Assert.Equal(-600, subnetMaskOption.Offset.TotalSeconds);
        }

        [Fact]
        public void DeserializeRouterOption()
        {
            var optionsBytes = "0304c0a80101ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var routerOption = options.OfType<DhcpRouterOption>().Single();

            Assert.Equal(IPAddress.Parse("192.168.1.1"), routerOption.RouterAddresses.Single());
        }

        [Fact]
        public void DeserializeTimeServerOption()
        {
            var optionsBytes = "0404c0a80101ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var routerOption = options.OfType<DhcpTimeServerOption>().Single();

            Assert.Equal(IPAddress.Parse("192.168.1.1"), routerOption.TimeServerAddresses.Single());
        }

        [Fact]
        public void DeserializeNameServerOption()
        {
            var optionsBytes = "0504c0a80101ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var routerOption = options.OfType<DhcpNameServerOption>().Single();

            Assert.Equal(IPAddress.Parse("192.168.1.1"), routerOption.NameServerAddresses.Single());
        }

        [Fact]
        public void DeserializeDomainNameServerOption()
        {
            var optionsBytes = "0604c0a80101ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var routerOption = options.OfType<DhcpDomainNameServerOption>().Single();

            Assert.Equal(IPAddress.Parse("192.168.1.1"), routerOption.DnsServerAddresses.Single());
        }

        [Fact]
        public void DeserializeLogServerOption()
        {
            var optionsBytes = "0704c0a80101ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var routerOption = options.OfType<DhcpLogServerOption>().Single();

            Assert.Equal(IPAddress.Parse("192.168.1.1"), routerOption.LogServerAddresses.Single());
        }

        [Fact]
        public void DeserializeQuotesServerOption()
        {
            var optionsBytes = "0804c0a80101ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var routerOption = options.OfType<DhcpQuotesServerOption>().Single();

            Assert.Equal(IPAddress.Parse("192.168.1.1"), routerOption.QuotesServerAddresses.Single());
        }

        [Fact]
        public void DeserializePrintServerOption()
        {
            var optionsBytes = "0904c0a80101ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var routerOption = options.OfType<DhcpPrintServerOption>().Single();

            Assert.Equal(IPAddress.Parse("192.168.1.1"), routerOption.PrintServerAddresses.Single());
        }

        [Fact]
        public void DeserializeImpressServerOption()
        {
            var optionsBytes = "0a04c0a80101ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var routerOption = options.OfType<DhcpImpressServerOption>().Single();

            Assert.Equal(IPAddress.Parse("192.168.1.1"), routerOption.ImpressServerAddresses.Single());
        }

        [Fact]
        public void DeserializeResourceLocationServerOption()
        {
            var optionsBytes = "0b04c0a80101ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var routerOption = options.OfType<DhcpResourceLocationServerOption>().Single();

            Assert.Equal(IPAddress.Parse("192.168.1.1"), routerOption.RlpServerAddresses.Single());
        }

        [Fact]
        public void DeserializeHostNameOption()
        {
            var optionsBytes = "0c1168656c6c6f2e6578616d706c652e636f6dff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var hostNameOption = options.OfType<DhcpHostNameOption>().Single();

            Assert.Equal("hello.example.com", hostNameOption.HostName);
        }

        [Fact]
        public void DeserializeBootFileSizeOption()
        {
            var optionsBytes = "0d020095ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var hostNameOption = options.OfType<DhcpBootFileSizeOption>().Single();

            Assert.Equal(149, hostNameOption.BootFileSize);
        }

        [Fact]
        public void DeserializeMeritDumpFileOption()
        {
            var optionsBytes = "0e1168656c6c6f2e6578616d706c652e636f6dff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var dumpFileOption = options.OfType<DhcpMeritDumpFileOption>().Single();

            Assert.Equal("hello.example.com", dumpFileOption.DumpFilePath);
        }

        [Fact]
        public void DeserializeDomainNameOption()
        {
            var optionsBytes = "0f1168656c6c6f2e6578616d706c652e636f6dff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var domainNameOption = options.OfType<DhcpDomainNameOption>().Single();

            Assert.Equal("hello.example.com", domainNameOption.DomainName);
        }

        [Fact]
        public void DeserializeSwapServerOption()
        {
            var optionsBytes = "1004c0a80101ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var swapServerOption = options.OfType<DhcpSwapServerOption>().Single();

            Assert.Equal(IPAddress.Parse("192.168.1.1"), swapServerOption.SwapServerAddress);
        }

        [Fact]
        public void DeserializeRootPathOption()
        {
            var optionsBytes = "111168656c6c6f2e6578616d706c652e636f6dff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var rootPathOption = options.OfType<DhcpRootPathOption>().Single();

            Assert.Equal("hello.example.com", rootPathOption.RootPath);
        }

        [Fact]
        public void DeserializeExtensionsFileOption()
        {
            var optionsBytes = "121168656c6c6f2e6578616d706c652e636f6dff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var extensionsFileOption = options.OfType<DhcpExtensionsFileOption>().Single();

            Assert.Equal("hello.example.com", extensionsFileOption.ExtensionsFile);
        }

        [Fact]
        public void DeserializeForwardOption()
        {
            var optionsBytes = "130101ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var extensionsFileOption = options.OfType<DhcpForwardOption>().Single();

            Assert.True(extensionsFileOption.Forward);
        }

        [Fact]
        public void DeserializeLocalSourceRoutingOption()
        {
            var optionsBytes = "140101ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var localSourceRoutingOption = options.OfType<DhcpLocalSourceRoutingOption>().Single();

            Assert.True(localSourceRoutingOption.Enabled);
        }

        [Fact]
        public void DeserializePolicyFilterOption()
        {
            var optionsBytes = "1510c0a80100ffffff00c0a80102ffff0000ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var policyFilterOption = options.OfType<DhcpPolicyFilterOption>().Single();

            Assert.Equal(2, policyFilterOption.Filters.Count());

            Assert.Equal(IPAddress.Parse("192.168.1.0"), policyFilterOption.Filters.First().Destination);
            Assert.Equal(IPAddress.Parse("255.255.255.0"), policyFilterOption.Filters.First().SubnetMask);

            Assert.Equal(IPAddress.Parse("192.168.1.2"), policyFilterOption.Filters.Last().Destination);
            Assert.Equal(IPAddress.Parse("255.255.0.0"), policyFilterOption.Filters.Last().SubnetMask);
        }

        [Fact]
        public void DeserializeMaximumDatagramReassemblySizeOption()
        {
            var optionsBytes = "16020384ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var option = options.OfType<DhcpMaximumDatagramReassemblySizeOption>().Single();

            Assert.Equal(900, option.MaximumSize);
        }

        [Fact]
        public void DeserializeDefaultIpTtlOption()
        {
            var optionsBytes = "170178ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var option = options.OfType<DhcpDefaultIpTtlOption>().Single();

            Assert.Equal(120, option.Ttl);
        }

        [Fact]
        public void DeserializeMtuTimeoutOption()
        {
            var optionsBytes = "180400000096ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var option = options.OfType<DhcpMtuTimeoutOption>().Single();

            Assert.Equal(150U, option.MtuTimeout);
        }

        [Fact]
        public void DeserializeMtuPlateauOption()
        {
            var optionsBytes = "1906004500550080ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var option = options.OfType<DhcpMtuPlateauOption>().Single();

            Assert.Equal(69U, option.Sizes[0]);
            Assert.Equal(85U, option.Sizes[1]);
            Assert.Equal(128U, option.Sizes[2]);
        }

        [Fact]
        public void DeserializeMtuInterfaceOption()
        {
            var optionsBytes = "1a020079ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var option = options.OfType<DhcpMtuInterfaceOption>().Single();

            Assert.Equal(121U, option.Mtu);
        }

        [Fact]
        public void DeserializeMtuSubnetOption()
        {
            var optionsBytes = "1b0101ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var option = options.OfType<DhcpMtuSubnetOption>().Single();

            Assert.True(option.AllSubnetsLocal);
        }

        [Fact]
        public void DeserializeBroadcastAddressOption()
        {
            var optionsBytes = "1c04c0a801ffff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var option = options.OfType<DhcpBroadcastAddressOption>().Single();

            Assert.Equal(IPAddress.Parse("192.168.1.255"), option.BroadcastAddress);
        }

        [Fact]
        public void DeserializePerformMaskDiscoveryOption()
        {
            var optionsBytes = "1d0101ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var option = options.OfType<DhcpPerformMaskDiscoveryOption>().Single();

            Assert.True(option.PerformMaskDiscovery);
        }

        [Fact]
        public void DeserializeMaskSupplierOption()
        {
            var optionsBytes = "1e0101ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var option = options.OfType<DhcpMaskSupplierOption>().Single();

            Assert.True(option.IsMaskSupplier);
        }

        [Fact]
        public void DeserializePerformRouterDiscoveryOption()
        {
            var optionsBytes = "1f0101ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var option = options.OfType<DhcpPerformRouterDiscovery>().Single();

            Assert.True(option.PerformRouterDiscovery);
        }

        [Fact]
        public void DeserializeRouterSolicitationAddressOption()
        {
            var optionsBytes = "2004c0a801ffff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var option = options.OfType<DhcpRouterSolicitationAddressOption>().Single();

            Assert.Equal(IPAddress.Parse("192.168.1.255"), option.RouterSolicitationAddress);
        }

        [Fact]
        public void DeserializeStaticRoutesOption()
        {
            var optionsBytes = "2110c0a80100ffffff00c0a8050cffff0000ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var option = options.OfType<DhcpStaticRoutesOption>().Single();

            Assert.Equal(IPAddress.Parse("192.168.1.0"), option.StaticRoutes[0].Destination);
            Assert.Equal(IPAddress.Parse("255.255.255.0"), option.StaticRoutes[0].Router);

            Assert.Equal(IPAddress.Parse("192.168.5.12"), option.StaticRoutes[1].Destination);
            Assert.Equal(IPAddress.Parse("255.255.0.0"), option.StaticRoutes[1].Router);
        }

        [Fact]
        public void DeserializeTrailerEncapsulationOption()
        {
            var optionsBytes = "220101ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var option = options.OfType<DhcpTrailerEncapsulationOption>().Single();

            Assert.True(option.NegotiateTrailerEncapsulation);
        }

        [Fact]
        public void DeserializeArpCacheTimeoutOption()
        {
            var optionsBytes = "2304000003d4ff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var option = options.OfType<DhcpArpCacheTimeoutOption>().Single();

            Assert.Equal(980, option.Timeout.TotalSeconds);
        }

        [Theory]
        [InlineData("240101ff", EthernetEncapsulation.Rfc1042)]
        [InlineData("240100ff", EthernetEncapsulation.Rfc894)]
        public void DeserializeEthernetEncapsulationOption(string hexBytes, EthernetEncapsulation expectedEncapsulation)
        {
            var optionsBytes = hexBytes.AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var option = options.OfType<DhcpEthernetEncapsulationOption>().Single();

            Assert.Equal(expectedEncapsulation, option.EthernetEncapsulation);
        }

        [Fact]
        public void DeserializeDefaultTcpTtlOption()
        {
            var optionsBytes = "25017dff".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var option = options.OfType<DhcpDefaultTcpTtlOption>().Single();

            Assert.Equal(125, option.Ttl);
        }

        [Fact]
        public void DeserializeTcpKeepAliveIntervalOption()
        {
            var optionsBytes = "26040000001e".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var option = options.OfType<DhcpTcpKeepAliveIntervalOption>().Single();

            Assert.Equal(30, option.Interval.TotalSeconds);
        }

        [Fact]
        public void DeserializeTcpKeepAliveGarbageOption()
        {
            var optionsBytes = "270101".AsHexBytes();

            var reader = new DhcpBinaryReader(optionsBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var option = options.OfType<DhcpTcpKeepAliveGarbageOption>().Single();

            Assert.True(option.KeepAliveGarbage);
        }
    }
}