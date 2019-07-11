using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Options;
using Xunit;

namespace LH.Dhcp.UnitTests.Options
{
    public class DhcpSubnetMaskOptionShould
    {
        public static IEnumerable<object[]> SubnetCidrData = new List<object[]>
        {
            new object[] { IPAddress.Parse("255.255.255.255"), 32 },
            new object[] { IPAddress.Parse("255.255.255.0"), 24 }
        };

        [Theory]
        [MemberData(nameof(SubnetCidrData))]
        public void ConvertSubnetMaskToCidrPrefix(IPAddress ipAddress, uint expectedCidrPrefix)
        {
            var option = new DhcpSubnetMaskOption(ipAddress);

            Assert.Equal(expectedCidrPrefix, option.CidrPrefix);
        }
    }
}