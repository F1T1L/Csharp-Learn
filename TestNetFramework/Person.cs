using System;


namespace TestNetFramework
{

    public class Person
    {
        public string personName;
        public string personSecondName;
        public int personAge;
        public Person():this("", "", 0) { }
        public Person(string s2name)
        :this("", s2name, 0)
        {            
        }
        public Person(int age)
       : this("", "", age)
        {            
        }
        // Конструкторы.
        public Person(string name, string sname, int age)
        {
            personSecondName = sname;
            personName = name;
            personAge = age;
        }
        public void Display()
        {
            Console.WriteLine("Name : {0}, Age: {1} ", personName, personAge);
        }
    }

}
