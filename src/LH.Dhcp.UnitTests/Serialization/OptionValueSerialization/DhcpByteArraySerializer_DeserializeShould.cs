using System;
using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization.OptionSerialization.OptionValueSerialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpByteArraySerializer_DeserializeShould
    {
        private readonly DhcpByteArrayOptionSerializer _serializer;

        public DhcpByteArraySerializer_DeserializeShould()
        {
            _serializer = new DhcpByteArrayOptionSerializer();
        }

        [Fact]
        public void ReturnAllBytes()
        {
            var random = new Random();
            var bytes = new byte[255];

            random.NextBytes(bytes);

            var reader = new DhcpBinaryReader(bytes);

            var actual = (byte[])_serializer.Deserialize(reader, (byte)bytes.Length);

            Assert.Equal(bytes, actual);
        }

        /*
         * Value types
         * ====================
         *  String              => Any
         *  ByteArray           => Any
         *  Byte                => 1
         *  UnsignedInt32       => 4
         *  UnsignedInt16       => 2
         *  SignedInt32         => 4
         *  SignedInt16         => 2
         *  Bool                => 1
         *  IPAddress           => 4
         *  Array<all the above>
         */
    }
}