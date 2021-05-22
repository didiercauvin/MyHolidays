using BuildingBlocks;
using System;

namespace DocumentContext
{

    public class Document : AggregateRoot
    {
        private readonly string _label;
        private readonly string _fileLink;

        public Document(string label, string fileLink)
        {
            _label = label;
            _fileLink = fileLink;
        }

        protected override void RegisterAppliers()
        {
            
        }
    }
}
