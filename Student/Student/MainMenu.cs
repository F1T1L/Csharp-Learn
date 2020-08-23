using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public class MainMenu
    {
        private int choice;
        private string ans;

        public int Choice
        {
            get { return choice; }
        }

        public string Ans
        {
            get { return ans; }
        }

        public void Dialog()
        {
            Console.Write("\n> Вернуться в меню (y/n)? - ");
            ans = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("\t ====================================================");
            Console.WriteLine("\t  Спасибо, что воспользовались нашей программой :).");
            Console.WriteLine("\t ====================================================");
            Console.WriteLine();
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t ====================================================");
            ConsoleColor tmpColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\t\t Жми вариант сортировки(цифру).");
            Console.ForegroundColor = tmpColor;
            Console.WriteLine("\t ====================================================");
            Console.WriteLine();
            Console.WriteLine();
            ConsoleColor tmpColor1 = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t 1. SearchByFaculty.");
            Console.ForegroundColor = tmpColor1;
            ConsoleColor tmpColor2 = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t 2. SortByFaculty.");
            Console.ForegroundColor = tmpColor2;
            ConsoleColor tmpColor3 = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t 3. SortByCourse");
            Console.ForegroundColor = tmpColor3;
            ConsoleColor tmpColor4 = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t 4. SortByYear.");
            Console.ForegroundColor = tmpColor4;
            ConsoleColor tmpColor5 = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t 5. SortByGroup.");
            Console.ForegroundColor = tmpColor5;
            
            Console.Write("\t> Сделайте выбор: ");
           
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException err)
            {
                Console.WriteLine("\n > Error, man!!! {0}", err.Message);
            }
        }
    }
}
