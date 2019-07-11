namespace LH.Dhcp
{
    public class ClientHardwareAddress
    {
        public ClientHardwareAddress(ClientHardwareAddressType type, byte[] addressBytes)
        {
            Type = type;
            AddressBytes = addressBytes;
        }

        public ClientHardwareAddressType Type { get; }

        public byte[] AddressBytes { get; }
    }
}