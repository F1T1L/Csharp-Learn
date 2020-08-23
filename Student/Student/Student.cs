using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public class Student
    {
        static public int Counter = 0;  
        public int ID { get; }
        public int YearOfBirth { get; set; }
        public string Group { get; set; }
        public string Course { get; set; }
        public string Faculty { get; set; }
        public string MiddleName { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Adress { set; get; }
        public string PhoneNumber { set; get; }

        public Student()
        {
            ID = ++Counter;
        }
        public Student(string lastName, string firstName, string middleName, int dateOfBirth, string group,
            string faculty, string course)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            YearOfBirth = dateOfBirth;
            Group = group;
            Faculty = faculty;
            Course = course;            
            ID = ++ Counter;
        }
        public override string ToString()
        {
            Console.WriteLine(new string('*',60));
            return String.Format("Фамилия: {0},  Имя: {1},  Отчество: {2},\nДата Рождения: {3},  Группа: {4},\n" +
                "Факультет: {5},  Курс: {6},\nАдресс: {7}, Телефон: {8}",
                LastName, FirstName, MiddleName, YearOfBirth, Group, Faculty, Course, Adress, PhoneNumber);
        }
        
        
    }
}
