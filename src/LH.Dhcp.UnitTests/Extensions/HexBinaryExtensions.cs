using System;
using System.Linq;

namespace LH.Dhcp.UnitTests.Extensions
{
    public static class HexBinaryExtensions
    {
        public static byte[] AsHexBytes(this string hex)
        {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }
    }
}
