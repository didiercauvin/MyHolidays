using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHolidays.Core.Models
{
    public class StreamIdentifier : ValueObject<StreamIdentifier>
    {
        private readonly string _name;
        private readonly Guid _id;

        public StreamIdentifier(string name, Guid id)
        {
            _name = name;
            _id = id;
        }

        public string Value => $"{_name}_{_id}";
    }
}
