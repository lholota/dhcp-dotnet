namespace LH.Dhcp.vNext.UnitTests.Extensions
{
    public static class ByteArrayExtensions
    {
        public static byte[] SetTo(this byte[] array, byte value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }

            return array;
        }
    }
}
