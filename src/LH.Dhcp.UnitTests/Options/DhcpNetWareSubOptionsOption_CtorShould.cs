using System;
using System.Linq;
using System.Net;
using LH.Dhcp.Options;
using LH.Dhcp.Options.NetWare;
using LH.Dhcp.Serialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Options
{
    // ReSharper disable once InconsistentNaming
    public class DhcpNetWareSubOptionsOption_CtorShould
    {
        [Theory]
        [InlineData(0x01, NetWareIpState.NwipDoesNotExist)]
        [InlineData(0x02, NetWareIpState.NwipExistInOptionsArea)]
        [InlineData(0x03, NetWareIpState.NwipExistInSnameFile)]
        [InlineData(0x04, NetWareIpState.NwipExistButTooBig)]
        public void SetStateFromFirstOption(byte firstByte, NetWareIpState expectedState)
        {
            var bytes = new[] {firstByte};
            var binaryValue = new BinaryValue(bytes, 0, bytes.Length);

            var option = new DhcpNetWareSubOptionsOption(binaryValue);

            Assert.Equal(expectedState, option.State);
        }

        [Theory]
        [InlineData(0x05)]
        [InlineData(0x11)]
        [InlineData(0xff)]
        public void ThrowFormatException_GivenValueWithInvalidFirstByte(byte firstByte)
        {
            var bytes = new[] { firstByte };
            var binaryValue = new BinaryValue(bytes, 0, bytes.Length);

            Assert.Throws<FormatException>(
                () => new DhcpNetWareSubOptionsOption(binaryValue));
        }

        [Fact]
        public void SetEmptySubOptions_GivenValueWithNoSubOptions()
        {
            var bytes = new byte[] { 0x01 };
            var binaryValue = new BinaryValue(bytes, 0, bytes.Length);

            var option = new DhcpNetWareSubOptionsOption(binaryValue);

            Assert.NotNull(option.SubOptions);
        }

        [Theory]
        [InlineData(NetWareIpState.NwipDoesNotExist)]
        [InlineData(NetWareIpState.NwipExistButTooBig)]
        public void ThrowFormatException_GivenValueWithFirstByteNotAllowingOtherSubOptionsAndOtherSubOptions(NetWareIpState state)
        {
            var bytes = new byte[] { (byte)state, 0x01, 0xaa, 0xaa };
            var binaryValue = new BinaryValue(bytes, 0, bytes.Length);

            Assert.Throws<FormatException>(
                () => new DhcpNetWareSubOptionsOption(binaryValue));
        }

        [Theory]
        [InlineData(NetWareIpState.NwipExistInOptionsArea)]
        [InlineData(NetWareIpState.NwipExistInSnameFile)]
        public void ReadNsqBroadcastSubOption_GivenFirstByteWhichAllowsSubOptions(NetWareIpState state)
        {
            var bytes = new byte[] { (byte)state, 0x05, 0x01, 0x01 };
            var binaryValue = new BinaryValue(bytes, 0, bytes.Length);

            var option = new DhcpNetWareSubOptionsOption(binaryValue);

            var subOption = option.SubOptions.OfType<NetWareNsqBroadcastSubOption>().Single();

            Assert.True(subOption.ShouldPerformNearestQuery);
        }

        [Theory]
        [InlineData(NetWareIpState.NwipExistInOptionsArea)]
        [InlineData(NetWareIpState.NwipExistInSnameFile)]
        public void ReadPreferredDss_GivenFirstByteWhichAllowsSubOptions(NetWareIpState state)
        {
            var bytes = new byte[] { (byte)state, 0x06, 0x08, 0xc0, 0xa8, 0x01, 0x23, 0xc0, 0xa8, 0x01, 0x24 };
            var binaryValue = new BinaryValue(bytes, 0, bytes.Length);

            var option = new DhcpNetWareSubOptionsOption(binaryValue);

            var subOption = option.SubOptions.OfType<NetWarePreferredDssSubOption>().Single();

            Assert.Equal(IPAddress.Parse("192.168.1.35"), subOption.DssServerAddresses[0]);
            Assert.Equal(IPAddress.Parse("192.168.1.36"), subOption.DssServerAddresses[1]);
        }

        [Theory]
        [InlineData(NetWareIpState.NwipExistInOptionsArea)]
        [InlineData(NetWareIpState.NwipExistInSnameFile)]
        public void ReadNearestNwip_GivenFirstByteWhichAllowsSubOptions(NetWareIpState state)
        {
            var bytes = new byte[] { (byte)state, 0x07, 0x08, 0xc0, 0xa8, 0x01, 0x23, 0xc0, 0xa8, 0x01, 0x24 };
            var binaryValue = new BinaryValue(bytes, 0, bytes.Length);

            var option = new DhcpNetWareSubOptionsOption(binaryValue);

            var subOption = option.SubOptions.OfType<NetWareNearestNwipServerSubOption>().Single();

            Assert.Equal(IPAddress.Parse("192.168.1.35"), subOption.NearestNwipServerAddresses[0]);
            Assert.Equal(IPAddress.Parse("192.168.1.36"), subOption.NearestNwipServerAddresses[1]);
        }

        [Theory]
        [InlineData(NetWareIpState.NwipExistInOptionsArea)]
        [InlineData(NetWareIpState.NwipExistInSnameFile)]
        public void ReadAutoRetries_GivenFirstByteWhichAllowsSubOptions(NetWareIpState state)
        {
            var bytes = new byte[] { (byte)state, 0x08, 0x01, 0xc0 };
            var binaryValue = new BinaryValue(bytes, 0, bytes.Length);

            var option = new DhcpNetWareSubOptionsOption(binaryValue);

            var subOption = option.SubOptions.OfType<NetWareAutoRetriesSubOption>().Single();

            Assert.Equal((byte)192, subOption.RetryCount);
        }

        [Theory]
        [InlineData(NetWareIpState.NwipExistInOptionsArea)]
        [InlineData(NetWareIpState.NwipExistInSnameFile)]
        public void ReadAutoRetriesSeconds_GivenFirstByteWhichAllowsSubOptions(NetWareIpState state)
        {
            var bytes = new byte[] { (byte)state, 0x09, 0x01, 0xc0 };
            var binaryValue = new BinaryValue(bytes, 0, bytes.Length);

            var option = new DhcpNetWareSubOptionsOption(binaryValue);

            var subOption = option.SubOptions.OfType<NetWareAutoRetriesDelaySubOption>().Single();

            Assert.Equal((byte)192, subOption.RetryDelay.TotalSeconds);
        }

        [Theory]
        [InlineData(NetWareIpState.NwipExistInOptionsArea)]
        [InlineData(NetWareIpState.NwipExistInSnameFile)]
        public void ReadSupportVersion11_GivenFirstByteWhichAllowsSubOptions(NetWareIpState state)
        {
            var bytes = new byte[] { (byte)state, 0x0a, 0x01, 0x01 };
            var binaryValue = new BinaryValue(bytes, 0, bytes.Length);

            var option = new DhcpNetWareSubOptionsOption(binaryValue);

            var subOption = option.SubOptions.OfType<NetWareSupportVersion11SubOption>().Single();

            Assert.True(subOption.ShouldSupport11);
        }

        [Theory]
        [InlineData(NetWareIpState.NwipExistInOptionsArea)]
        [InlineData(NetWareIpState.NwipExistInSnameFile)]
        public void ReadPrimaryDss_GivenFirstByteWhichAllowsSubOptions(NetWareIpState state)
        {
            var bytes = new byte[] { (byte)state, 0x0b, 0x04, 0xc0, 0xa8, 0x01, 0x23 };
            var binaryValue = new BinaryValue(bytes, 0, bytes.Length);

            var option = new DhcpNetWareSubOptionsOption(binaryValue);

            var subOption = option.SubOptions.OfType<NetWarePrimaryDssSubOption>().Single();

            Assert.Equal(IPAddress.Parse("192.168.1.35"), subOption.PrimaryDssServerAddress);
        }
    }
}