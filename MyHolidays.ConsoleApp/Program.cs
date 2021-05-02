using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyHolidays.ConsoleApp.Items;
using MyHolidays.Core;
using MyHolidays.Core.Models.Items;
using System;
using System.Threading.Tasks;

namespace MyHolidays.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {

                   services
                   .AddTransient<MyApplication>()
                   .AddTransient<AggregateFactory>()
                   //.AddScoped<IRepository<Item>, EFRepository<Item>>()
                   .AddScoped<IRepository<Item>, EventSourcingRepository<Item>>()
                   .AddScoped<IEventStore, InMemoryEventStore>()
                   .AddScoped<ICommandHandler<RenameItemCommand>, RenameItemCommand.Handler>()
                   .AddScoped<ICommandHandler<CreateItemCommand>, CreateItemCommand.Handler>()
                   .AddScoped<IQueryHandler<GetAllItemsQuery, GetAllItemsQueryResult>, GetAllItemsQuery.EFHandler>()
                   .AddDbContext<MyHolidaysContext>();
               }).UseConsoleLifetime();

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    var myService = services.GetRequiredService<MyApplication>();
                    await myService.Run();

                    Console.WriteLine("Success");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Occured");
                }
            }

            Console.ReadLine();

        }
    }

    public class MyApplication
    {
        private readonly ICommandHandler<CreateItemCommand> createItemCommandHandler;
        private readonly ICommandHandler<RenameItemCommand> renameItemCommandHandler;
        private readonly IQueryHandler<GetAllItemsQuery, GetAllItemsQueryResult> queryAllItemsHandler;

        public MyApplication(
            ICommandHandler<CreateItemCommand> createItemCommandHandler,
            ICommandHandler<RenameItemCommand> renameItemCommandHandler,
            IQueryHandler<GetAllItemsQuery, GetAllItemsQueryResult> queryAllItemsHandler)
        {
            this.createItemCommandHandler = createItemCommandHandler;
            this.renameItemCommandHandler = renameItemCommandHandler;
            this.queryAllItemsHandler = queryAllItemsHandler;
        }

        internal async Task Run()
        {
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
        }

        private static void Liste(IQueryHandler<GetAllItemsQuery, GetAllItemsQueryResult> queryAllItemsHandler)
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
