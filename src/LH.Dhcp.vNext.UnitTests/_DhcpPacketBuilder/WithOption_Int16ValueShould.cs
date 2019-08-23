using System;
using System.Collections.Generic;
using LH.Dhcp.vNext.Options;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacketBuilder
{
    // ReSharper disable once InconsistentNaming
    public class WithOption_Int16ValueShould
    {
        public static IEnumerable<object[]> GetOverloads()
        {
            var testCases = new List<object[]>();

            testCases.Add(new object[]
            {
                new AddOptionDelegate<short>((builder, optionCode, value) => builder.WithOption(optionCode, value))
            });

            testCases.Add(new object[]
            {
                new AddOptionDelegate<short>((builder, optionCode, value) => builder.WithOption((DhcpOptionCode)optionCode, value))
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
        public void AddOption(AddOptionDelegate<short> addOptionDelegate)
        {
            const short expectedValue = 895;

            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);
            addOptionDelegate.Invoke(builder, 10, expectedValue);

            var packet = builder.Build();
            

            Assert.Equal(expectedValue, packet.GetOption(10).AsInt16());
        }

        [Theory]
        [MemberData(nameof(GetOverloads))]
        public void BeAbleToWriteMultipleOptions(AddOptionDelegate<short> addOptionDelegate)
        {
            const short value1 = -895;
            const short value2 = -896;

            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            addOptionDelegate.Invoke(builder, 10, value1);
            addOptionDelegate.Invoke(builder, 20, value2);

            var packet = builder.Build();

            Assert.Equal(value1, packet.GetOption(10).AsInt16());
            Assert.Equal(value2, packet.GetOption(20).AsInt16());
        }

        [Theory]
        [MemberData(nameof(GetOverloads))]
        public void BeAbleToWriteOptionsBeyondInitialBuffer(AddOptionDelegate<short> addOptionDelegate)
        {
            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            for (byte i = 68; i < 250; i++)
            {
                addOptionDelegate.Invoke(builder, i, 0x0a);
            }

            var packet = builder.Build();

            for (byte i = 68; i < 250; i++)
            {
                Assert.True(packet.HasOption(i));
            }
        }

        [Theory]
        [MemberData(nameof(GetReservedCodesTestCases), 0)]
        [MemberData(nameof(GetReservedCodesTestCases), 66)]
        [MemberData(nameof(GetReservedCodesTestCases), 67)]
        [MemberData(nameof(GetReservedCodesTestCases), 255)]
        public void ThrowArgumentOutOfRangeException_GivenReservedCode(AddOptionDelegate<short> addOptionDelegate, byte optionCode)
        {
            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => addOptionDelegate.Invoke(builder, optionCode, 895));
        }
    }
}