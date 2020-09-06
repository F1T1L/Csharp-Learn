using System;
using System.Collections.Generic;

// Для того, чтобы увидеть Техническое Задание, откройте TaskList или нажмите комбинацию (Ctrl + W, T) 
// В выпадающем списке, выберите пункт - Comments

namespace GenericsHW
{   
    class Program
    {
        static void Main()
        {
            MyList<string> list = new MyList<string>();
            list.Add("asd");
            list.Add("asd2");
            list.Add("asd4");
            list.Add("asd3");
            list.Add("asd5e");

            bool isExist = list.Contains("asd2");
            bool isExistnot = list.Contains("asd22");
            Console.WriteLine(isExist.ToString());
            Console.WriteLine(isExistnot.ToString());

            Console.WriteLine(list.Count);

            Console.WriteLine(list.ToString());
            Console.WriteLine(list[4]);
            list.Clear();
            Console.WriteLine( list );
           

        }
    }
}
