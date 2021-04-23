using MyHolidays.Core.Models;

namespace MyHolidays.Core.ItemUseCases
{
    public class AddItemCommand : ICommand
    {
        public string Label { get; set; }

        public class Handler : ICommandHandler<AddItemCommand>
        {
            private readonly IRepository<Item> _itemRepository;

            public Handler(IRepository<Item> itemRepository)
            {
                _itemRepository = itemRepository;
            }

            public void Handle(AddItemCommand command)
            {
                var id = _itemRepository.GetNextIdentity();
                var item = new Item(id, command.Label);

                _itemRepository.Save(item);
            }
        }
    }
}
