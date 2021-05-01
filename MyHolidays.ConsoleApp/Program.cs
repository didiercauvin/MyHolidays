using MyHolidays.ConsoleApp.Items;
using System;

namespace MyHolidays.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new InMemoryDatabase();
            var itemRepository = new ItemRepository(database);
            var createItemCommandHandler = new CreateItemCommand.Handler(itemRepository);
            var renameItemCommandHandler = new RenameItemCommand.Handler(itemRepository);
            var queryAllItemsHandler = new GetAllItemsQuery.Handler(database);

            do
            {
                Console.WriteLine("Saisir un item:");
                Console.Write("Label: ");
                var label = Console.ReadLine();
                Console.Write("Recurrent: ");
                var recurring = bool.Parse(Console.ReadLine());

                createItemCommandHandler.Handle(new CreateItemCommand { ItemId = Guid.NewGuid(), Label = label, Recurring = recurring });
                Liste(queryAllItemsHandler);

                Console.WriteLine("Renommer un item");
                Console.Write("Id: ");
                var id = Console.ReadLine();
                Console.Write("Label: ");
                var newLabel = Console.ReadLine();
                renameItemCommandHandler.Handle(new RenameItemCommand { Id = Guid.Parse(id), NewLabel = newLabel });

                Liste(queryAllItemsHandler);

            } while (Console.ReadLine() != "exit");

            Console.ReadLine();
            
        }

        private static void Liste(GetAllItemsQuery.Handler queryAllItemsHandler)
        {
            Console.WriteLine("Voici tous les items saisis:");
            var result = queryAllItemsHandler.Execute(new GetAllItemsQuery());

            foreach (var item in result.Items)
            {
                Console.WriteLine($"Id: {item.Id}");
                Console.WriteLine($"Label: {item.Label}");
                Console.WriteLine($"Récurrent: {item.Recurring.ToString()}");
            }
        }
    }
}
