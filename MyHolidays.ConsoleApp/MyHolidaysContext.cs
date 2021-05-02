using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MyHolidays.Core.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHolidays.ConsoleApp
{
    public class MyHolidaysContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public MyHolidaysContext() : base(new DbContextOptionsBuilder<MyHolidaysContext>().UseSqlite("Data Source=:memory:").Options)
        {
            Database.OpenConnection();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Item>().ToTable("Items");
            builder.Entity<Item>().HasKey(x => x.Id);
            builder.Entity<Item>().Property<string>("_label").HasColumnName("Label");
            builder.Entity<Item>().Property<bool>("_recurring").HasColumnName("Recurring");
        }
    }
}
