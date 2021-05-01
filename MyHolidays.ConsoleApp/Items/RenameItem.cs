using MyHolidays.Core;
using MyHolidays.Core.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHolidays.ConsoleApp.Items
{
    public class RenameItemCommand : ICommand
    {
        public Guid Id { get; set; }
        public string NewLabel { get; set; }

        public class Handler : ICommandHandler<RenameItemCommand>
        {
            private readonly IRepository<Item> _repository;

            public Handler(IRepository<Item> repository)
            {
                _repository = repository;
            }

            public void Handle(RenameItemCommand command)
            {
                var item = _repository.GetById(command.Id);
                item.Rename(command.NewLabel);
            }
        }
    }
}
