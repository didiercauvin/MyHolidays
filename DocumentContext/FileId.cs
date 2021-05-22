namespace DocumentContext
{
    public class FileId
    {
        private FileId()
        {

        }

        public FileId(string fileLink)
        {
            FileLink = fileLink;
        }

        public string FileLink { get; }
    }
}