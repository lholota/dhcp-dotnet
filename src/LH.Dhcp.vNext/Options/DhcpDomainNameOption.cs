using LH.Dhcp.vNext.Internals;

namespace LH.Dhcp.vNext.Options
{
    [DhcpOptionCode(DhcpOptionCode.DomainName)]
    public class DhcpDomainNameOption : IDhcpOption
    {
        public DhcpDomainNameOption(string domainName)
        {
            DomainName = domainName;
        }

        [SemanticOptionsFactoryConstructor]
        internal DhcpDomainNameOption(BinaryValue value)
        {
            DomainName = value.AsString();
        }

        public string DomainName { get; }
    }
}
