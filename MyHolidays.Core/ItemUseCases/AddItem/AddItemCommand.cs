using MyHolidays.Core.Models;

namespace MyHolidays.Core.ItemUseCases
{
    public class AddItemCommand : ICommand
    {
        public string Label { get; set; }

        public class Handler : ICommandHandler<AddItemCommand>
        {
            private readonly IItemRepository _itemRepository;

            public Handler(IItemRepository itemRepository)
            {
                _itemRepository = itemRepository;
            }

            public void Handle(AddItemCommand command)
            {
                var id = _itemRepository.NextIdentity();
                var item = new Item(id, command.Label);

                _itemRepository.Add(item);
            }
        }
    }
}
