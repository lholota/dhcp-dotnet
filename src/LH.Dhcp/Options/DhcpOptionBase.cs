namespace LH.Dhcp.Options
{
    public abstract class DhcpOptionBase<T> : IDhcpOption
    {
        protected DhcpOptionBase(T value)
        {
        }
    }
}