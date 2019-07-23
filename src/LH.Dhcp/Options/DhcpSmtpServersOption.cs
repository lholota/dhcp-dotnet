using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.SMTPServer)]
    public class DhcpSmtpServersOption : IDhcpOption
    {
        public IReadOnlyList<IPAddress> SmtpServerAddresses { get; }

        public DhcpSmtpServersOption(IReadOnlyList<IPAddress> smtpServerAddresses)
        {
            SmtpServerAddresses = smtpServerAddresses;
        }
    }
}