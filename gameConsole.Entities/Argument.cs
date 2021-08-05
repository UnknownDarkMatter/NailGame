using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameConsole.Entities
{
    public class Argument
    {
        public string Name { get; set; }
        public List<string> Values { get; set;}

        public Argument(string name, List<string> values)
        {
            Name = name;
            Values = values;
        }

        public List<TResult> GetValues<TResult>()
        {
            List<TResult> results = new List<TResult>();
            foreach(var valueAsString in Values)
            {
                TResult value = (TResult)Convert.ChangeType(valueAsString, typeof(TResult));
                results.Add(value);
            }
            return results;
        }
    }
}
