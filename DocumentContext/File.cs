using BuildingBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentContext
{
    public class File : AggregateRoot
    {
        private string _filename;
        private byte[] _fileContent;

        public File(string filename, byte[] fileContent)
        {
            this._filename = filename;
            this._fileContent = fileContent;
        }

        protected override void RegisterAppliers()
        {
            
        }
    }
}
