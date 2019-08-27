using System;

namespace LH.Dhcp.vNext
{
    public class ClientHardwareAddress
    {
        public ClientHardwareAddress(ClientHardwareAddressType type, byte[] addressBytes)
        {
            if (addressBytes == null)
            {
                throw new ArgumentNullException(nameof(addressBytes));
            }

            if (addressBytes.Length == 0)
            {
                throw new ArgumentException("The Client Hardware Address bytes length must be > 0.");
            }

            if (addressBytes.Length > 16)
            {
                throw new ArgumentException("The Client Hardware Address bytes must be <= 16 bytes long.");
            }

            if (type == ClientHardwareAddressType.Ethernet && addressBytes.Length != 6)
            {
                throw new ArgumentException("The Client Hardware Address bytes must be exactly 6 bytes long for Ethernet addresses.");
            }

            Type = type;
            AddressBytes = addressBytes;
        }

        public ClientHardwareAddressType Type { get; }

        public byte[] AddressBytes { get; }
    }
}