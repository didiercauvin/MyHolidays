namespace MyHolidays.ConsoleApp
{
    public interface ICommand
    {

    }

    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }

}
