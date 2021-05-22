using BuildingBlocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentContext
{
    public class CreateDocumentCommand : ICommand
    {
        public string Label { get; set; }
        public byte[] FileContent { get; set; }

        public class Handler : ICommandHandler<CreateDocumentCommand>
        {
            private readonly DocumentDbContext _context;
            private readonly IHandleFile _fileHandler;

            public Handler(
                IHandleFile fileHandler,
                DocumentDbContext context)
            {
                _context = context;
                _fileHandler = fileHandler;
            }

            public void Handle(CreateDocumentCommand command)
            {
                var link = _fileHandler.Save("text.txt", command.FileContent);
                var document = new Document(command.Label, link);

                _context.Add(document);
                _context.SaveChanges();
            }
        }
    }
}
