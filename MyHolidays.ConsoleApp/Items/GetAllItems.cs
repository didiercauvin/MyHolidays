using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHolidays.ConsoleApp.Items
{
    public class GetAllItemsQuery : IQuery<GetAllItemsQueryResult>
    {
        public class Handler : IQueryHandler<GetAllItemsQuery, GetAllItemsQueryResult>
        {
            private MyHolidaysContext context;

            public Handler(MyHolidaysContext context)
            {
                this.context = context;
            }

            public GetAllItemsQueryResult Execute(GetAllItemsQuery query)
            {
                var items = new List<ResultItem>();
                var sql = "select * from Items";
                var connection = context.Database.GetDbConnection();
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = sql;

                using (var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new ResultItem { Id = Guid.Parse((string)reader[0]), Label = (string)reader[1], Recurring = (long)reader[2] == 1 ? true : false });
                    }
                }

                return new GetAllItemsQueryResult(items);
            }
        }
    }

    public class ResultItem
    {

        public Guid Id { get; set; }
        public string Label { get; set; }
        public bool Recurring { get; set; }
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
