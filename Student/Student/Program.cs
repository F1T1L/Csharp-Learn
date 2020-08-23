using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Program
    {
        const int StudentCount = 100;
        static List<string> AllFaculty = new List<string> { "Философия", "Экономика", "ИТ", "Физика", "Математика" };
        
        static void Main(string[] args)
        {  
            List<Student> students = new List<Student>();
            
            for (int i = 0; i < StudentCount; i++)
            {
                students.Add(new Student
                {
                    Adress = $"Улица {i}",
                    Course = $"Курс {i % 5 + 1}",
                    Faculty = $"{AllFaculty[i % AllFaculty.Count]}",
                    FirstName = $"Студент {i}",
                    Group = $"Группа {i % 3 + 1}",
                    LastName = $"Отчество {i}",
                    MiddleName = $"Фамилия {i}",
                    YearOfBirth = (1900 + i)
                });

            }
            
            MainMenu m = new MainMenu();
            
            do
            {
                m.Display();
                switch (m.Choice)
                {
                    case 1:
                        SearchByFaculty();
                        break;
                    case 2:
                        SortByFaculty();
                        break;
                    case 3:
                        SortByCourse();
                        break;
                    case 4:
                        SortByYear();
                        break;
                    case 5:
                        SortByGroup();
                        break;
                    default:
                        Console.WriteLine("\n> Ошибка выбора!");
                        break;
                }
                m.Dialog();
            }
            while (m.Ans == "y");

            void SearchByFaculty() 
            {
                students.SearchByFaculty(AllFaculty[0]).PrintStudentList();
                
            }

            void SortByFaculty()
            {
                for (int i = 0; i < AllFaculty.Count; i++)
                {
                    Console.WriteLine("Список студентов факультета {0}", AllFaculty[i]);
                    foreach (var item in students)
                    {
                        if (item.Faculty == AllFaculty[i]) { Console.WriteLine("ID: {0}", item.ID); }
                    }
                }
            }
            void SortByCourse()
            {
                for (int i = 1; i < 5 + 1; i++)
                {
                    Console.WriteLine("Список студентов курса: {0}", i);
                    foreach (var item in students)
                    {
                        if (item.Course.Substring(5, 1) == i.ToString()) { Console.WriteLine("ID: {0}, {1}", item.ID, item.Course); }
                    }
                }
            }

            void SortByYear()
            {
                Console.WriteLine("Список студентов рожденных после 1950г. ");
                foreach (var item in students)
                {
                    if (item.YearOfBirth >= (int)1950) { Console.WriteLine(item.ID); }
                }
            }
            void SortByGroup()
            {
                for (int i = 1; i < 3 + 1; i++)
                {
                    Console.WriteLine("Список студентов Группы: {0}", i);
                    foreach (var item in students)
                    {
                        if (item.Group.Substring(7, 1) == i.ToString()) { Console.WriteLine("ID: {0}, {1}", item.ID, item.Group); }
                    }
                }
            }
            
            
        }
    }
}
