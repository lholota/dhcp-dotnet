using System;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Serialization
{
    public interface IDhcpPacketSerializer
    {
        byte[] Serialize(DhcpPacket packet);

        DhcpPacket Deserialize(byte[] bytes);
    }

    public class DhcpPacketSerializer : IDhcpPacketSerializer
    {
        private const ushort BroadcastFlag = 0x8000;
        private const uint MagicCookie = 0x63825363;

        private readonly DhcpOptionsSerializer _optionsSerializer;

        public DhcpPacketSerializer()
        {
            _optionsSerializer = new DhcpOptionsSerializer();
        }

        public byte[] Serialize(DhcpPacket packet)
        {
            using (var writer = new BinaryWriter())
            {
                /*
                 * Bootp fields
                 * Options
                 */

                throw new System.NotImplementedException();

                return writer.GetBytes();
            }
        }

        public DhcpPacket Deserialize(byte[] bytes)
        {
            var reader = new DhcpBinaryReader(bytes);
            var packetBuilder = DhcpPacketBuilder.Create();
            uint magicCookie;

            try
            {
                packetBuilder.WithOperation((DhcpOperation)reader.ReadByte());

                var clientHardwareAddressType = (ClientHardwareAddressType)reader.ReadByte();
                var clientHardwareAddressLength = (int)reader.ReadByte();

                packetBuilder.WithHops(reader.ReadByte());
                packetBuilder.WithTransactionId(reader.ReadUnsignedInt32());
                packetBuilder.WithSecs(reader.ReadUnsignedInt16());
                packetBuilder.WithBroadcastFlag(reader.ReadUnsignedInt16() == BroadcastFlag);
                packetBuilder.WithClientIp(reader.ReadIpAddress());
                packetBuilder.WithYourIp(reader.ReadIpAddress());
                packetBuilder.WithServerIp(reader.ReadIpAddress());
                packetBuilder.WithGatewayIp(reader.ReadIpAddress());

                var clientHardwareAddressBytes = ReadClientHardwareAddress(reader, clientHardwareAddressLength);

                packetBuilder.WithClientHardwareAddress(clientHardwareAddressType, clientHardwareAddressBytes);

                packetBuilder.WithServerName(reader.ReadString(64));
                packetBuilder.WithBootFile(reader.ReadString(128));

                magicCookie = reader.ReadUnsignedInt32();

                var options = _optionsSerializer.DeserializeOptions(reader);

                packetBuilder.WithOptions(options);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new DhcpSerializationException("The packet is too short to be a valid DHCP packet.", e);
            }

            if (magicCookie != MagicCookie)
            {
                throw new DhcpSerializationException("The packet does not contain the Magic cookie. It can be a valid BOOTP packet, but it is not a DHCP packet.");
            }

            return packetBuilder.Build();
        }

        private byte[] ReadClientHardwareAddress(DhcpBinaryReader reader, int addressLength)
        {
            const int addressFixedLength = 16;

            var clientHardwareAddressBytes = reader.ReadBytes(Math.Min(addressLength, addressFixedLength));

            // Jump over padding bytes of the ClientHardwareAddress
            var paddingLength = addressFixedLength - Math.Min(addressLength, 16);

            reader.Seek(paddingLength);

            return clientHardwareAddressBytes;
        }
    }
}