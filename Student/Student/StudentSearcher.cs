using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public static class StudentSearcher
    {
        public static void PrintStudentList(this List<Student> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{nameof(item.ID)} : {item.ID}");
                Console.WriteLine($"{nameof(item.FirstName)} : {item.FirstName}");
                Console.WriteLine($"{nameof(item.LastName)} : {item.LastName}");
                Console.WriteLine($"{nameof(item.Course)} : {item.Course}");
                Console.WriteLine($"{nameof(item.Group)} : {item.Group}");
                Console.WriteLine($"{nameof(item.Faculty)} : {item.Faculty}");
                Console.WriteLine( new string('-',50));
            }
        }

        public static List<Student> SearchByFaculty(this List<Student> self, string facultyForSearching)
        {
            return self.FindAll(s => s.Faculty == facultyForSearching);
        }
    }
}
