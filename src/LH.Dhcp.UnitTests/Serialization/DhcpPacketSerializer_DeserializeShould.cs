using System.Linq;
using LH.Dhcp.Options;
using LH.Dhcp.Serialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    
    public class DhcpPacketSerializer_DeserializeShould
    {
        private readonly DhcpPacketSerializer _serializer;

        public DhcpPacketSerializer_DeserializeShould()
        {
            _serializer = new DhcpPacketSerializer();
        }

        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void DeserializeDhcpOperation(DhcpTestPacket testPacket)
        {
            var packet = _serializer.Deserialize(testPacket.Bytes);

            Assert.Equal(testPacket.Operation, packet.Operation);
        }

        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void DeserializeHardwareAddress(DhcpTestPacket testPacket)
        {
            var packet = _serializer.Deserialize(testPacket.Bytes);

            Assert.Equal(testPacket.ClientHardwareAddressType, packet.ClientHardwareAddress.Type);
            Assert.Equal(testPacket.ClientHardwareAddressBytes, packet.ClientHardwareAddress.AddressBytes);
        }

        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void DeserializeHops(DhcpTestPacket testPacket)
        {
            var packet = _serializer.Deserialize(testPacket.Bytes);

            Assert.Equal(testPacket.Hops, packet.Hops);
            Assert.Equal(testPacket.Hops, packet.Hops);
        }

        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void DeserializeTransactionId(DhcpTestPacket testPacket)
        {
            var packet = _serializer.Deserialize(testPacket.Bytes);

            Assert.Equal(testPacket.TransactionId, packet.TransactionId);
        }

        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void DeserializeSecs(DhcpTestPacket testPacket)
        {
            var packet = _serializer.Deserialize(testPacket.Bytes);

            Assert.Equal(testPacket.Secs, packet.Secs);
        }

        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void DeserializeIsBroadcast(DhcpTestPacket testPacket)
        {
            var packet = _serializer.Deserialize(testPacket.Bytes);

            Assert.Equal(testPacket.IsBroadcast, packet.IsBroadcast);
        }

        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void DeserializeClientIp(DhcpTestPacket testPacket)
        {
            var packet = _serializer.Deserialize(testPacket.Bytes);

            Assert.Equal(testPacket.ClientIp, packet.ClientIp);
        }

        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void DeserializeYourIp(DhcpTestPacket testPacket)
        {
            var packet = _serializer.Deserialize(testPacket.Bytes);

            Assert.Equal(testPacket.YourIp, packet.YourIp);
        }

        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void DeserializeServerIp(DhcpTestPacket testPacket)
        {
            var packet = _serializer.Deserialize(testPacket.Bytes);

            Assert.Equal(testPacket.ServerIp, packet.ServerIp);
        }

        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void DeserializeGatewayIp(DhcpTestPacket testPacket)
        {
            var packet = _serializer.Deserialize(testPacket.Bytes);

            Assert.Equal(testPacket.GatewayIp, packet.GatewayIp);
        }

        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void DeserializeServerName(DhcpTestPacket testPacket)
        {
            var packet = _serializer.Deserialize(testPacket.Bytes);

            Assert.Equal(testPacket.ServerName, packet.ServerName);
        }

        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void DeserializeBootFile(DhcpTestPacket testPacket)
        {
            var packet = _serializer.Deserialize(testPacket.Bytes);

            Assert.Equal(testPacket.BootFile, packet.BootFile);
        }

        [Fact]
        public void ThrowDhcpSerializationException_GivenPacketWithoutMagicCookie()
        {
            var ex = Assert.Throws<DhcpSerializationException>(
                () => _serializer.Deserialize(DhcpTestPackets.DiscoverWithoutMagicCookie.Bytes));

            Assert.Contains("Magic", ex.Message);
        }

        [Fact]
        public void DhcpSerializationException_GivenInvalidPacket()
        {
            var packetBytes = new byte[0];

            var ex = Assert.Throws<DhcpSerializationException>(
                () => _serializer.Deserialize(packetBytes));

            Assert.DoesNotContain("magic", ex.Message);
        }

        [Fact]
        public void DeserializeSubnetMaskOption()
        {
            var packet = _serializer.Deserialize(DhcpTestPackets.Offer.Bytes);

            var option = packet.GetOption<DhcpSubnetMaskOption>();
            var expectedOption = DhcpTestPackets.Offer.Options.OfType<DhcpSubnetMaskOption>().Single();

            Assert.Equal(expectedOption.SubnetMask, option.SubnetMask);
        }
    }
}