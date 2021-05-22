using Microsoft.EntityFrameworkCore;

namespace DocumentContext
{
    public class DocumentDbContext : DbContext
    {
        public DbSet<Document> Documents { get; set; }
        public DbSet<File> Files { get; set; }

        public DocumentDbContext() : base(new DbContextOptionsBuilder<DocumentDbContext>().UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDocument;Trusted_Connection=True;").Options)
        {
            Database.OpenConnection();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Document>().ToTable("Documents");
            builder.Entity<Document>().HasKey(x => x.Id);
            builder.Entity<Document>().Property<string>("_label").HasColumnName("Label");
            builder.Entity<Document>().OwnsOne<FileId>("_fileId", x => { x.Property(p => p.FileLink).HasColumnName("FileLink"); });

            builder.Entity<File>().ToTable("Files");
            builder.Entity<File>().HasKey(x => x.Id);
            builder.Entity<File>().Property<string>("_filename").HasColumnName("FileName");
            builder.Entity<File>().Property<byte[]>("_fileContent").HasColumnName("Content");
        }
    }
}
