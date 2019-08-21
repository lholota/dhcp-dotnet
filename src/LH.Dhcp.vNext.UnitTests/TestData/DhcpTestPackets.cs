using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace LH.Dhcp.vNext.UnitTests.TestData
{
    public partial class DhcpTestPackets : IEnumerable<object[]>
    {
       


      


   

            public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { Discover };
            yield return new object[] { Offer };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}