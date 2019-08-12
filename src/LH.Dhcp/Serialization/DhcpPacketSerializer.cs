using System;
using System.Collections.Generic;
using LH.Dhcp.Options;

namespace LH.Dhcp.Serialization
{
    internal class DhcpPacketOverloadResolver
    {
        public void ResolveOverloadedFields(DhcpPacketBuilder builder, )
        {

        }
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
            using (var writer = new DhcpBinaryWriter())
            {
                writer.Write(BinaryValue.FromByte((byte)packet.Operation));

                // Other BOOTP fields

                foreach (var option in packet.RawOptions)
                {
                    writer.WriteByte(option.Key);
                    writer.WriteByte((byte)option.Value.Length); // TODO: Split the value if it's longer than 255 !!!

                    writer.Write(option.Value);
                }

                writer.Write(BinaryValue.FromByte(255)); // End option

                return writer.ToByteArray();
            }
        }

        public DhcpPacket Deserialize(byte[] bytes)
        {
            var reader = new DhcpBinaryReader(bytes);
            var packetBuilder = DhcpPacketBuilder.Create();

            try
            {
                // TODO: Validate length of the packet (< 240 is not a valid packet)

                if (BinaryValue.AsUInt32(bytes, 236) != MagicCookie)
                {
                    throw new DhcpSerializationException("The packet does not contain the Magic cookie. It can be a valid BOOTP packet, but it is not a DHCP packet.");
                }

                DeserializeBootpFields(bytes, packetBuilder);

                var options = BinaryValue.AsTaggedValueCollection(bytes, 240, bytes.Length - 240); // This MUST return IEnumerable !!!

                var overloadMode = GetOverloadMode(options);

                if (overloadMode != OptionOverloadMode.None)
                {
                    var optionsInOverloadedFields = DeserializeOptionsInOverloadedFields(bytes, overloadMode);

                    // TODO: Merge options
                }

                NormalizeLongOptions(options);
            }
            catch (InvalidOperationException e)
            {
                throw new DhcpSerializationException("The packet is not a valid DHCP packet.", e);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new DhcpSerializationException("The packet is not a valid DHCP packet.", e);
            }

            return packetBuilder.Build();
        }

        private void NormalizeLongOptions(IDictionary<byte, BinaryValue> options)
        {
            throw new NotImplementedException();
        }

        private IDictionary<byte, BinaryValue> DeserializeOptionsInOverloadedFields(byte[] bytes, OptionOverloadMode overloadMode)
        {
            throw new NotImplementedException();
        }

        private void DeserializeBootpFields(byte[] bytes, DhcpPacketBuilder builder)
        {
            builder.WithOperation((DhcpOperation)bytes[0]);

            var clientHardwareAddressType = (ClientHardwareAddressType)bytes[1];
            var clientHardwareAddressLength = bytes[2];

            builder.WithHops(bytes[3]);
            builder.WithTransactionId(BinaryValue.AsUInt32(bytes, 4)); // 8
            builder.WithSecs(BinaryValue.AsUInt16(bytes, 8));
            builder.WithBroadcastFlag(BinaryValue.AsUInt16(bytes, 10) == BroadcastFlag);
            builder.WithClientIp(BinaryValue.AsIpAddress(bytes, 14));
            builder.WithYourIp(BinaryValue.AsIpAddress(bytes, 18));
            builder.WithServerIp(BinaryValue.AsIpAddress(bytes, 22));
            builder.WithGatewayIp(BinaryValue.AsIpAddress(bytes, 26));

            var clientHardwareAddressBytes = ReadClientHardwareAddress(bytes, clientHardwareAddressLength);

            builder.WithClientHardwareAddress(clientHardwareAddressType, clientHardwareAddressBytes);

            var possiblyOverloadedFields = reader.ReadValue(64 + 128);

            magicCookie = reader.ReadValue(BinaryValue.UnsignedInt32Length).AsUnsignedInt32();
        }

        private byte[] ReadClientHardwareAddress(byte[] packetBytes, byte addressLength)
        {
            const byte addressMaxLength = 16;

            var result = new byte[addressMaxLength];

            Array.Copy(packetBytes, 30, result, 0, addressLength);

            return result;
        }

        private OptionOverloadMode GetOverloadMode(IDictionary<byte, BinaryValue> options)
        {
            if (options.TryGetValue((byte)DhcpOptionTypeCode.Overload, out var overloadMode))
            {
                return (OptionOverloadMode)overloadMode.AsByte();
            }

            return OptionOverloadMode.None;
        }
    }

    internal enum OptionOverloadMode
    {
        None = 0,
        FileName = 1,
        ServerName = 2,
        Both = 3
    }
}