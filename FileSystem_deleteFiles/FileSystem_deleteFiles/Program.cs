using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

// Создание/удаление файла.

namespace InputOutput
{
    class Program
    {
        static void Main()
        {
            var dir = @"C:\Test";
            Directory.CreateDirectory(dir);
            Console.WriteLine("СОЗДАЮ ПАПКУ ПО ПУТИ: {0}", dir);
            var file = new FileInfo(@"C:\Test\Test.txt").Create();
            file.Close(); //Закрыть поток, иначе удалить нельзя!

            for (int i = 0; i < 3; i++)
            {
                new FileInfo(dir + @"\TXT" + i + ".txt").Create().Close();
                new FileInfo(dir + @"\NWM" + i + ".nwm").Create().Close();
                new FileInfo(dir + @"\PPP" + i + ".ppp").Create().Close();
            }

            //var searchPattern = "*.txt";
            var filteredFiles = Directory.EnumerateFiles(dir)
                .Where(f => string.Equals(Path.GetExtension(f), ".txt", StringComparison.OrdinalIgnoreCase) ||
                            string.Equals(Path.GetExtension(f), ".ppp", StringComparison.OrdinalIgnoreCase));

            string[] files = Directory.GetFiles(dir);
            foreach (var item in files)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Создано {0} файлов.", files.Length);
            Console.ReadKey();

            foreach (var item in filteredFiles)
            {
                File.Delete(item);
            }

            Console.WriteLine(new string('=', 30));
            filteredFiles = Directory.EnumerateFiles(dir)
                .Where(f => string.Equals(Path.GetExtension(f), ".txt", StringComparison.OrdinalIgnoreCase) ||
                            string.Equals(Path.GetExtension(f), ".nwm", StringComparison.OrdinalIgnoreCase));
            // files = Directory.GetFiles(@"C:\Test", "*.*");
            if (filteredFiles.Count() != 0)
            {
                foreach (var item in filteredFiles)
                {
                    Console.WriteLine(item);
                }
            }
            else { Console.WriteLine("ПУСТО!"); }

            Console.WriteLine(new string('=', 30));

            foreach (var f in GetFilesToProcess(dir, new[] { ".nwm", ".ppp", ".txt" }))
            {
                Debug.WriteLine(f);
                Console.WriteLine(f);
            }

            IEnumerable<string> GetFilesToProcess(string path, IEnumerable<string> extensions)
            {
                return Directory.GetFiles(path, "*.*")
                    .Where(f => extensions.Contains(Path.GetExtension(f).ToLower()));
            }
            Console.WriteLine("УДАЛЕНИЕ ПАПКИ {0}", dir);
            Console.ReadKey();

            Directory.Delete(dir, true);
            Console.ReadKey();
            //new DirectoryInfo(path).GetFiles().Where(Current => Regex.IsMatch(Current.Extension, "\\.(aspx|ascx)", RegexOptions.IgnoreCase)
        }
    }
}
