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
            private readonly IRepository repository;

            public Handler(IRepository repository)
            {
                this.repository = repository;
            }

            public void Handle(AddItemCommand command)
            {
                var item = Item.Create(command.Id, command.Label);

                repository.Save(item);
            }
        }
    }
}
