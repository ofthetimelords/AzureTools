namespace TheQ.Libraries.AzureTools.AutoQueue
{
    public interface ISerializer
    {
        byte[] Serialize(object source);
    }
}
