using MyHolidays.Core;
using MyHolidays.Core.Models;
using MyHolidays.Core.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHolidays.ConsoleApp.Items
{
    public class Repository<T> : IRepository<T>
        where T : Aggregate
    {
        private MyHolidaysContext context;

        public Repository(MyHolidaysContext context)
        {
            this.context = context;
        }

        public T GetById(Guid id)
        {
            return context.Set<T>().First(x => x.Id == id);
        }

        public void Save(T aggregate)
        {
            if (!context.Set<T>().Any(x => x.Id == aggregate.Id))
            {
                context.Set<T>().Add(aggregate);
            }

            context.SaveChanges();
        }
    }

    //public class ItemRepository : IRepository<Item>
    //{
    //    private MyHolidaysContext context;

    //    public ItemRepository(MyHolidaysContext context)
    //    {
    //        this.context = context;
    //    }

    //    public Item GetById(Guid id)
    //    {
            
    //    }

    //    public void Save(Item item)
    //    {
    //        if (!context.Items.Any(x => x.Id == item.Id))
    //        {
    //            context.Items.Add(item);
    //        }

    //        context.SaveChanges();
    //    }
    //}
}
