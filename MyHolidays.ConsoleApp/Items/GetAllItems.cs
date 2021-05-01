using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHolidays.ConsoleApp.Items
{
    public class GetAllItemsQuery : IQuery<GetAllItemsQueryResult>
    {
        public class Handler : IQueryHandler<GetAllItemsQuery, GetAllItemsQueryResult>
        {
            private readonly InMemoryDatabase _database;

            public Handler(InMemoryDatabase database)
            {
                _database = database;
            }

            public GetAllItemsQueryResult Execute(GetAllItemsQuery query)
            {
                var items = _database.Items
                    .Select(x => new ResultItem(x.Id, x.Label, x.Recurring))
                    .ToList();

                return new GetAllItemsQueryResult(items);
            }
        }
    }

    public class ResultItem
    {
        public ResultItem(Guid id, string label, bool recurring)
        {
            Id = id;
            Label = label;
            Recurring = recurring;
        }

        public Guid Id { get; }
        public string Label { get; }
        public bool Recurring { get; }
    }

    public class GetAllItemsQueryResult
    {
        public GetAllItemsQueryResult(List<ResultItem> items)
        {
            Items = items;
        }

        public List<ResultItem> Items { get; }
    }
}
