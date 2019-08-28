namespace LH.Dhcp.vNext
{
    public interface IKeyValueCollectionBuilder
    {
        IKeyValueCollectionBuilder WithItem(byte code, int value);

        IKeyValueCollectionBuilder WithItem(byte code, string value);
    }
}