using System;
using System.Net;
using LH.Dhcp.Options.NetWare;
using Xunit;

namespace LH.Dhcp.UnitTests.Options.NetWare
{
    
    public class NetWarePreferredDssSubOption_CtorShould
    {
        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenMoreThanFiveIpAddresses()
        {
            var ipAddresses = new[]
            {
                IPAddress.Parse("192.168.1.1"),
                IPAddress.Parse("192.168.1.2"),
                IPAddress.Parse("192.168.1.3"),
                IPAddress.Parse("192.168.1.4"),
                IPAddress.Parse("192.168.1.5"),
                IPAddress.Parse("192.168.1.6")
            };

            Assert.Throws<ArgumentOutOfRangeException>(
                () => new NetWarePreferredDssSubOption(ipAddresses));
        }
    }
}