using System;
using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    
    public class DhcpBinaryValue_IsValidShould
    {
        [Theory]
        [InlineData(typeof(bool), 0)]
        [InlineData(typeof(bool), 2)]
        [InlineData(typeof(ushort), 0)]
        [InlineData(typeof(ushort), 1)]
        [InlineData(typeof(ushort), 3)]
        [InlineData(typeof(IReadOnlyList<ushort>), 1)]
        [InlineData(typeof(IReadOnlyList<ushort>), 3)]
        [InlineData(typeof(uint), 0)]
        [InlineData(typeof(uint), 3)]
        [InlineData(typeof(uint), 5)]
        [InlineData(typeof(int), 0)]
        [InlineData(typeof(int), 3)]
        [InlineData(typeof(int), 5)]
        [InlineData(typeof(byte), 0)]
        [InlineData(typeof(byte), 2)]
        [InlineData(typeof(IPAddress), 2)]
        [InlineData(typeof(IPAddress), 5)]
        [InlineData(typeof(IReadOnlyList<IPAddress>), 3)]
        [InlineData(typeof(IReadOnlyList<IPAddress>), 5)]
        [InlineData(typeof(IReadOnlyList<IPAddress>), 9)]
        [InlineData(typeof(IReadOnlyList<Tuple<IPAddress, IPAddress>>), 5)]
        [InlineData(typeof(IReadOnlyList<Tuple<IPAddress, IPAddress>>), 9)]
        [InlineData(typeof(IReadOnlyList<Tuple<IPAddress, IPAddress>>), 23)]
        public void ReturnFalse_GivenInvalidLength(Type outputType, byte length)
        {
            var bytes = new byte[30];

            var valueReader = new DhcpBinaryValue(bytes, 0, length);

            Assert.False(valueReader.IsValid(outputType));
        }

        [Theory]
        [InlineData(typeof(bool), 1)]
        [InlineData(typeof(ushort), 2)]
        [InlineData(typeof(IReadOnlyList<ushort>), 4)]
        [InlineData(typeof(uint), 4)]
        [InlineData(typeof(int), 4)]
        [InlineData(typeof(byte), 1)]
        [InlineData(typeof(IPAddress), 4)]
        [InlineData(typeof(IReadOnlyList<IPAddress>), 4)]
        [InlineData(typeof(IReadOnlyList<IPAddress>), 8)]
        [InlineData(typeof(IReadOnlyList<Tuple<IPAddress, IPAddress>>), 8)]
        [InlineData(typeof(IReadOnlyList<Tuple<IPAddress, IPAddress>>), 16)]
        [InlineData(typeof(byte[]), 9)]
        [InlineData(typeof(string), 9)]
        public void ReturnTrue_GivenValidLength(Type outputType, byte length)
        {
            var bytes = new byte[30];

            var valueReader = new DhcpBinaryValue(bytes, 0, length);

            Assert.True(valueReader.IsValid(outputType));
        }

        [Theory]
        [InlineData(typeof(List<IPAddress>))]
        public void ThrowNotSupportedExceptionWithHints_GivenUnsupportedType(Type type)
        {
            var bytes = new byte[10];

            var valueReader = new DhcpBinaryValue(bytes, 0, 10);

            var ex = Assert.Throws<NotSupportedException>(
                () => valueReader.IsValid(type));

            Assert.Contains("types", ex.Message);
            Assert.Contains("Int32", ex.Message);
            Assert.Contains("Int16", ex.Message);
        }
    }
}
