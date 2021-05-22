using BuildingBlocks;
using MyHolidays.Core;
using MyHolidays.Core.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHolidays.ConsoleApp.Items
{
    public class CreateItemCommand : ICommand
    {
        public Guid ItemId { get; set; }
        public string Label { get; set; }
        public bool Recurring { get; set; }

        public class Handler : ICommandHandler<CreateItemCommand>
        {
            private readonly IRepository<Item> _repository;
            
            public Handler(IRepository<Item> repository)
            {
                _repository = repository;
            }

            public void Handle(CreateItemCommand command)
            {
                var item = Item.CreateItem(command.ItemId, command.Label, command.Recurring);

                _repository.Save(item);
            }
        }
    }
}
