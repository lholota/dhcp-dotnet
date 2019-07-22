using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LH.Dhcp
{
    public interface IDhcpClient
    {
        Task<IReadOnlyList<DhcpPacket>> Discover(DhcpDiscoveryParameters parameters, CancellationToken ct);
    }
}