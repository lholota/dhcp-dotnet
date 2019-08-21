using System;
using System.Net;
using System.Text;
using LH.Dhcp.vNext.Options;

namespace LH.Dhcp.vNext
{
    public class DhcpPacketBuilder
    {
        public static DhcpPacketBuilder CreateFromExisting(DhcpPacket existingPacket)
        {
            throw new NotImplementedException();
        }

        public static DhcpPacketBuilder Create(DhcpMessageType messageType)
        {
            return new DhcpPacketBuilder(messageType);
        }

        private byte[] _buffer;
        private int _nextOptionIndex = 240;

        private DhcpPacketBuilder(DhcpMessageType messageType)
        {
            _buffer = new byte[360];

            // TODO: Default BOOTP operation
            // TODO: Default other BOOTP fields

            // TODO: Transaction ID defaults to random value
        }

        public DhcpPacketBuilder WithTransactionId()
        {
            throw new NotImplementedException();
        }

        public DhcpPacketBuilder WithClientHardwareAddress(ClientHardwareAddress clientHardwareAddress)
        {
            throw new NotImplementedException();
        }

        public DhcpPacketBuilder WithHops(byte hops)
        {
            throw new NotImplementedException();
        }

        public DhcpPacketBuilder WithSecondsElapsed(byte hops)
        {
            throw new NotImplementedException();
        }

        public DhcpPacketBuilder WithBroadcast(bool isBroadcast)
        {
            throw new NotImplementedException();
        }

        public DhcpPacketBuilder WithClientIp(IPAddress clientIp)
        {
            throw new NotImplementedException();
        }

        public DhcpPacketBuilder WithYourIp(IPAddress yourIp)
        {
            throw new NotImplementedException();
        }

        public DhcpPacketBuilder WithServerIp(IPAddress serverIp)
        {
            throw new NotImplementedException();
        }

        public DhcpPacketBuilder WithGatewayIp(IPAddress gatewayIp)
        {
            throw new NotImplementedException();
        }

        public DhcpPacketBuilder WithBootFile(string bootFile)
        {
            throw new NotImplementedException();
        }

        public DhcpPacketBuilder WithServerName(string bootFile)
        {
            throw new NotImplementedException();
        }

        /*
         * TODO: Options
         * - Split long options (only applicable to variable length options)
         * - Resizable buffer (1,5 resize?)
         * - 
         */

        public DhcpPacketBuilder WithOption(byte optionCode, string value)
        {
            var valueBytes = Encoding.ASCII.GetBytes(value);

            for (var i = 0; i < Math.Ceiling(valueBytes.Length / 255m); i++)
            {

            }

            // _stream.Write();

            throw new NotImplementedException();
        }

        public DhcpPacketBuilder WithOption(IDhcpOption semanticOption)
        {
            throw new NotImplementedException();
        }

        public DhcpPacket Build()
        {
            throw new NotImplementedException();
        }

        // TODO: Validate the packet
        // TODO: Check for array size overflow (int max?)
        // TODO: If user specifies the file name and the BootFileName option? - this doesn't make sense. Do not allow the filename option at all, same goes for server name!
    }
}