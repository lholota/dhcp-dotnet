using System;
using System.Collections.Generic;
using LH.Dhcp.vNext.Options;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacketBuilder
{
    // ReSharper disable once InconsistentNaming
    public class WithOption_ByteArrayValueShould
    {
        public static IEnumerable<object[]> GetOverloads()
        {
            var testCases = new List<object[]>();

            testCases.Add(new object[]
            {
                new AddOptionDelegate<byte[]>((builder, optionCode, value) => builder.WithOption(optionCode, value))
            });

            testCases.Add(new object[]
            {
                new AddOptionDelegate<byte[]>((builder, optionCode, value) => builder.WithOption((DhcpOptionCode)optionCode, value))
            });

            return testCases;
        }

        public static IEnumerable<object[]> GetReservedCodesTestCases(int code)
        {
            foreach (var overload in GetOverloads())
            {
                yield return new[]
                {
                    overload[0],
                    (byte)code
                };
            }
        }

        [Theory]
        [MemberData(nameof(GetOverloads))]
        public void AddOption(AddOptionDelegate<byte[]> addOptionDelegate)
        {
            var expectedValue = CreateByteArray(4);
            
            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);
            addOptionDelegate.Invoke(builder, 10, expectedValue);

            var packet = builder.Build();

            Assert.Equal(expectedValue, packet.GetOption(10).AsBytes());
        }

        [Theory]
        [MemberData(nameof(GetOverloads))]
        public void AddOption_GivenValueLongerThan255Chars(AddOptionDelegate<byte[]> addOptionDelegate)
        {
            var value = CreateByteArray(300);

            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);
            addOptionDelegate.Invoke(builder, 10, value);

            var packet = builder.Build();


            Assert.Equal(value, packet.GetOption(10).AsBytes());
        }

        [Theory]
        [MemberData(nameof(GetOverloads))]
        public void BeAbleToWriteMultipleOptions(AddOptionDelegate<byte[]> addOptionDelegate)
        {
            var value1 = CreateByteArray(10);
            var value2 = CreateByteArray(10);

            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            addOptionDelegate.Invoke(builder, 10, value1);
            addOptionDelegate.Invoke(builder, 20, value2);

            var packet = builder.Build();

            Assert.Equal(value1, packet.GetOption(10).AsBytes());
            Assert.Equal(value2, packet.GetOption(20).AsBytes());
        }

        [Theory]
        [MemberData(nameof(GetOverloads))]
        public void BeAbleToWriteOptionsBeyondInitialBuffer(AddOptionDelegate<byte[]> addOptionDelegate)
        {
            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);
            var optionValue = CreateByteArray(20);

            for (byte i = 68; i < 250; i++)
            {
                addOptionDelegate.Invoke(builder, i, optionValue);
            }

            var packet = builder.Build();

            for (byte i = 68; i < 250; i++)
            {
                Assert.True(packet.HasOption(i));
            }
        }

        [Theory]
        [MemberData(nameof(GetOverloads))]
        public void ThrowArgumentNullException_GivenNullValue(AddOptionDelegate<byte[]> addOptionDelegate)
        {
            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            Assert.Throws<ArgumentNullException>(
                () => addOptionDelegate.Invoke(builder, 10, null));
        }

        [Theory]
        [MemberData(nameof(GetOverloads))]
        public void ThrowArgumentException_GivenEmptyStringValue(AddOptionDelegate<byte[]> addOptionDelegate)
        {
            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            Assert.Throws<ArgumentException>(
                () => addOptionDelegate.Invoke(builder, 10, new byte[0]));
        }

        [Theory]
        [MemberData(nameof(GetReservedCodesTestCases), 0)]
        [MemberData(nameof(GetReservedCodesTestCases), 66)]
        [MemberData(nameof(GetReservedCodesTestCases), 67)]
        [MemberData(nameof(GetReservedCodesTestCases), 255)]
        public void ThrowArgumentOutOfRangeException_GivenReservedCode(AddOptionDelegate<byte[]> addOptionDelegate, byte optionCode)
        {
            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => addOptionDelegate.Invoke(builder, optionCode, new byte[10]));
        }

        private byte[] CreateByteArray(int length)
        {
            var value = new byte[length];

            for (var i = 0; i < value.Length; i++)
            {
                value[i] = 0x0a;
            }

            return value;
        }
    }
}