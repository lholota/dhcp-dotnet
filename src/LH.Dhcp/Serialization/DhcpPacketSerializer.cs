using System;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Serialization
{
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
            throw new System.NotImplementedException();
        }

        public DhcpPacket Deserialize(byte[] bytes)
        {
            var reader = new DhcpBinaryReader(bytes);
            var packetBuilder = DhcpPacketBuilder.Create();
            uint magicCookie;

            try
            {
                packetBuilder.WithOperation((DhcpOperation) reader.ReadValue(DhcpBinaryValue.ByteLength).AsByte());

                var clientHardwareAddressType =
                    (ClientHardwareAddressType) reader.ReadValue(DhcpBinaryValue.ByteLength).AsByte();
                var clientHardwareAddressLength = reader.ReadValue(DhcpBinaryValue.ByteLength).AsByte();

                packetBuilder.WithHops(reader.ReadValue(DhcpBinaryValue.ByteLength).AsByte());
                packetBuilder.WithTransactionId(reader.ReadValue(DhcpBinaryValue.UnsignedInt32Length)
                    .AsUnsignedInt32());
                packetBuilder.WithSecs(reader.ReadValue(DhcpBinaryValue.UnsignedInt16Length).AsUnsignedInt16());
                packetBuilder.WithBroadcastFlag(
                    reader.ReadValue(DhcpBinaryValue.UnsignedInt16Length).AsUnsignedInt16() == BroadcastFlag);
                packetBuilder.WithClientIp(reader.ReadValue(DhcpBinaryValue.IpAddressLength).AsIpAddress());
                packetBuilder.WithYourIp(reader.ReadValue(DhcpBinaryValue.IpAddressLength).AsIpAddress());
                packetBuilder.WithServerIp(reader.ReadValue(DhcpBinaryValue.IpAddressLength).AsIpAddress());
                packetBuilder.WithGatewayIp(reader.ReadValue(DhcpBinaryValue.IpAddressLength).AsIpAddress());

                var clientHardwareAddressBytes = ReadClientHardwareAddress(reader, clientHardwareAddressLength);

                packetBuilder.WithClientHardwareAddress(clientHardwareAddressType, clientHardwareAddressBytes);

                packetBuilder.WithServerName(reader.ReadValue(64).AsString());
                packetBuilder.WithBootFile(reader.ReadValue(128).AsString());

                magicCookie = reader.ReadValue(DhcpBinaryValue.UnsignedInt32Length).AsUnsignedInt32();

                var options = _optionsSerializer.DeserializeOptions(reader);

                packetBuilder.WithOptions(options);
            }
            catch (InvalidOperationException e)
            {
                throw new DhcpSerializationException("The packet is not a valid DHCP packet.", e);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new DhcpSerializationException("The packet is not a valid DHCP packet.", e);
            }

            if (magicCookie != MagicCookie)
            {
                throw new DhcpSerializationException("The packet does not contain the Magic cookie. It can be a valid BOOTP packet, but it is not a DHCP packet.");
            }

            return packetBuilder.Build();
        }

        private byte[] ReadClientHardwareAddress(DhcpBinaryReader reader, byte addressLength)
        {
            const byte addressMaxLength = 16;

            var clientHardwareAddress = reader.ReadValue(Math.Min(addressLength, addressMaxLength));

            // Jump over padding bytes of the ClientHardwareAddress
            var paddingLength = addressMaxLength - Math.Min(addressLength, addressMaxLength);

            reader.Seek(paddingLength);

            return clientHardwareAddress.AsBytes();
        }
    }
}