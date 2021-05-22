using BuildingBlocks;
using System;

namespace DocumentContext
{

    public class Document : AggregateRoot
    {
        private readonly string _label;
        private readonly FileId _fileId;

        private Document()
        {

        }

        public Document(string label, string fileLink)
        {
            _label = label;
            _fileId = new FileId(fileLink);
        }

        protected override void RegisterAppliers()
        {
            
        }
    }
}
