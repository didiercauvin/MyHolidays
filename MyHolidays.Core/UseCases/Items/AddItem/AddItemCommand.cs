using MyHolidays.Core.Models;
using System;

namespace MyHolidays.Core.UseCases.Items.AddItem
{
    public class AddItemCommand : ICommand
    {
        public string Label { get; set; }
        public Guid Id { get; set; }

        public class Handler : ICommandHandler<AddItemCommand>
        {
            private readonly IRepository<Item> _itemRepository;

            public Handler(IRepository<Item> itemRepository)
            {
                _itemRepository = itemRepository;
            }

            public void Handle(AddItemCommand command)
            {
                var item = new Item(command.Id, command.Label);

                _itemRepository.Save(item);
            }
        }
    }
}
