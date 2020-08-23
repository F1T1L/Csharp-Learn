using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public class Person
    {
        private string _privateName;
        private string _privateFakeName;
        public string Name
        {
            get { return _privateName; }
            set { this._privateName = value; this._privateFakeName = $"{value }Fake"; }
        }
        public string FakeName { get { return _privateFakeName; } set => _privateFakeName = value; }
        public string SurName { get; set; }
        public Person(string name)
        {
            this._privateName = name;
        }
        public Person()
        {

        }
    }
}
