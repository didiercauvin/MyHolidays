namespace DocumentContext
{
    public interface IHandleFile
    {
        string Save(string filename, byte[] fileContent);
    }
}