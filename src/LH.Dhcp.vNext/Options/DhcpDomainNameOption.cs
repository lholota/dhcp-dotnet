namespace LH.Dhcp.vNext.Options
{
    [DhcpOption(DhcpOptionCode.DomainName)]
    public class DhcpDomainNameOption : IDhcpOption
    {
        public DhcpDomainNameOption(string domainName)
        {
            DomainName = domainName;
        }

        public string DomainName { get; }
    }
}
