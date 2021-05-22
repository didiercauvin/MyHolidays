namespace BuildingBlocks
{
    public interface IQuery<TResult>
    {

    }

    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        TResult Execute(TQuery query);
    }
}
