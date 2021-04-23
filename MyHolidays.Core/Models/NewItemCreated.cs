using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHolidays.Core.Models
{
    public class NewItemCreated : IDomainEvent
    {
        public NewItemCreated(Guid id, string label)
        {
            Id = id;
            Label = label;
        }

        public Guid Id { get; }
        public string Label { get; }
    }
}
