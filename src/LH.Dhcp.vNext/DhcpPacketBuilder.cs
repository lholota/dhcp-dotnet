using System;
using System.Text;

namespace LH.Dhcp.vNext
{
    public class DhcpPacketBuilder
    {
        public static DhcpPacketBuilder Create() // TODO: Add message type (?)
        {
            return new DhcpPacketBuilder();
        }

        private int _nextOptionIndex = 240;

        private DhcpPacketBuilder()
        {
        }

        public DhcpPacketBuilder WithFileName()
        {
            // If value longer than expected space -> option

            throw new NotImplementedException();
        }

        public DhcpPacketBuilder WithOption(byte optionCode, string value)
        {
            var valueBytes = Encoding.ASCII.GetBytes(value);

            for (var i = 0; i < Math.Ceiling(valueBytes.Length / 255m); i++)
            {

            }

            // _stream.Write();

            throw new NotImplementedException();
        }

        // TODO: Check for array size overflow (int max?)
        // TODO: If user specifies the file name and the BootFileName option? - this doesn't make sense. Do not allow the filename option at all, same goes for server name!
    }

    internal class DhcpPacketStream
    {
        // Ensure there's space in byte array buffer
        // Keep index of Options?
        // Make sure the value doesn't overload the allocated space?

        public void WriteFixedValue(int startIndex, int maxLength, ushort value)
        {

        }

        public void WriteOption(byte code, ushort value)
        {

        }
    }
}