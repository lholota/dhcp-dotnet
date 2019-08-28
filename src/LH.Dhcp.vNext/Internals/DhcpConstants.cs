namespace LH.Dhcp.vNext.Internals
{
    internal static class DhcpConstants
    {
        public const int MagicCookieOffset = 236;
        public const int TransactionIdOffset = 4;
        public const int HopsOffset = 3;
        public const int SecondsElapsedOffset = 8;
        public const int BroadcastOffset = 10;
        public const int ClientIpOffset = 12;
        public const int YourIpOffset = 16;
        public const int ServerIpOffset = 20;
        public const int GatewayIpOffset = 24;
        public const int OptionsOffset = 240;

        public const int BootFileOffset = 108;
        public const int BootFileLength = 128;

        public const int ServerNameOffset = 44;
        public const int ServerNameLength = 64;

        public const uint MagicCookie = 0x63825363;

        public const ushort BroadcastFlag = 0x8000;

        public static readonly byte[] ReservedOptionCodes = new byte[]
        {
            0,
            66,
            67,
            255
        };
    }
}
