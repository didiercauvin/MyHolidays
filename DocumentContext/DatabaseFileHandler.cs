using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentContext
{
    public class LocalFileSystemFileHandler : IHandleFile
    {
        public string Save(string filename, byte[] fileContent)
        {
            var fullpath = @"C:\Temp\" + filename;
            System.IO.File.WriteAllBytes(fullpath, fileContent);

            return fullpath;
        }
    }

    public class DatabaseFileHandler : IHandleFile
    {
        private readonly DocumentDbContext _context;

        public DatabaseFileHandler(DocumentDbContext context)
        {
            _context = context;
        }

        public string Save(string filename, byte[] fileContent)
        {
            var file = new File(filename, fileContent);

            _context.Add(file);

            return filename;
        }
    }
}
