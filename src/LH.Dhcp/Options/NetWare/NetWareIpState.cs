namespace LH.Dhcp.Options.NetWare
{
    public enum NetWareIpState : byte
    {
        NwipDoesNotExist = 1,
        NwipExistInOptionsArea = 2,
        NwipExistInSnameFile = 3,
        NwipExistButTooBig = 4
    }
}