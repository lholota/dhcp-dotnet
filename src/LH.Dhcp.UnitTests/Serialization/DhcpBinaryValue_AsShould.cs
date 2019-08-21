using System;
using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    
    public class DhcpBinaryValue_AsShould
    {
        private static readonly byte[] TestBytes = "012233445566778899aabbccddeeffa1a2a3".AsHexBytes();

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
        [InlineData(typeof(IReadOnlyList<Tuple<IPAddress, IPAddress>>), 17)]
        public void ThrowInvalidOperationException_GivenInvalidTypeAndLengthCombination(Type outputType, byte length)
        {
            var valueReader = new DhcpBinaryValue(TestBytes, 0, length);

            Assert.Throws<InvalidOperationException>(
                () => valueReader.As(outputType));
        }

        public static IEnumerable<object[]> ValidLengthAndTypeCombinations = new List<object[]>
        {
            new object[] { typeof(bool), 1, true },
            new object[] { typeof(ushort), 2, (ushort)290 },
            new object[] { typeof(IReadOnlyList<ushort>), 4, new ushort[] { 290, 13124 } },
            new object[] { typeof(uint), 4, 19018564U },
            new object[] { typeof(int), 4, 19018564 },
            new object[] { typeof(byte), 1, (byte)0x01 },
            new object[] { typeof(IPAddress), 4, IPAddress.Parse("1.34.51.68") },
            new object[]
            {
                typeof(IReadOnlyList<IPAddress>),
                8,
                new[]
                {
                    IPAddress.Parse("1.34.51.68"),
                    IPAddress.Parse("85.102.119.136")
                }
            },
            new object[]
            {
                typeof(IReadOnlyList<Tuple<IPAddress, IPAddress>>),
                8,
                new[] 
                {
                    new Tuple<IPAddress, IPAddress>(IPAddress.Parse("1.34.51.68"), IPAddress.Parse("85.102.119.136"))
                }
            }
        };

        [Theory]
        [MemberData(nameof(ValidLengthAndTypeCombinations))]
        public void ReturnValue_GivenValidTypeAndLengthCombination(Type outputType, byte length, object expectedValue)
        {
            var valueReader = new DhcpBinaryValue(TestBytes, 0, length);

            Assert.Equal(expectedValue, valueReader.As(outputType));
        }

        [Theory]
        [InlineData(typeof(List<IPAddress>))]
        public void ReturnFalse_GivenUnsupportedType(Type type)
        {
            var bytes = new byte[10];

            var valueReader = new DhcpBinaryValue(bytes, 0, 10);

            var ex = Assert.Throws<NotSupportedException>(
                () => valueReader.As(type));

            Assert.Contains("types", ex.Message);
            Assert.Contains("Int32", ex.Message);
            Assert.Contains("Int16", ex.Message);
        }
    }
}
