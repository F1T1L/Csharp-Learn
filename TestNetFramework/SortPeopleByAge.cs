using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNetFramework
{
    internal class SortPeopleByAge : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x?.personAge>y?.personAge)
            {
                return 1;
            }
            if (x?.personAge < y?.personAge)
            {
                return -1;
            }
            return 0;
        }
    }
}
