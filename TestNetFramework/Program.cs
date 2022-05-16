using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace TestNetFramework
{
    internal partial class Program
    {
        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("***********************************\n");
        }
        public delegate void Varp<T>(T arg);
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            LambdaExpressionSyntax();

            //DelegatesAndEvents();
            //NewSwitchIsAwsome();         
            //Add(90, 90, out int ans);
            //DayTimeMagic();//кортеж
            //LinksAndLocalVars();        
            //Tuples(); //кортежи
            //ChainCtors();
            //TimeUtilClass.PrintTime();
            // UseGenenericList();
            //SortPplByAge();
            //DictionaryPpl();
            //ObservableCollectionPpls();
            //GenericPoint<int> point = new GenericPoint<int>();
            //StopWatchTest();
        }

        private static void DelegatesAndEvents()
        {
            CarDelegate carDelegate = new CarDelegate("SlugBug", 100, 10);
            CarDelegate.CarEngineHandler carHandler = new CarDelegate.CarEngineHandler(OnCarEngineEvent);
            //carDelegate.RegisterWithCarEngineHandler(new CarDelegate.CarEngineHandler(OnCarEngineEvent));           
            carDelegate.RegisterWithCarEngineHandler(carHandler);
            carDelegate.RegisterWithCarEngineHandler(OnCarEngineEvent);
            carDelegate.UnRegisterWithCarEngineHandler(OnCarEngineEvent);


            for (int i = 0; i < 20; i++)
            {
                carDelegate.Accelerate(5);

            }
        }

        static void LambdaExpressionSyntax()
        {
            // Создать список целочисленных значений.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            // Теперь использовать лямбда-выражение С#.
            List<int> evenNumbers = list.FindAll(x => (x % 2) == 0);
            // Вывести четные числа.
            Console.WriteLine("Here are your even numbers:");
            foreach (var evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }
        public int LimitInclusive(int value, int min, int max)
        {
            return Math.Min(max, Math.Max(value, min));
        }
        static void StopWatchTest()
        {
            const int size = 10000;
            Stopwatch sw = new Stopwatch();

            sw.Start();
            int[,] array = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = 1;
                }
            }
            sw.Stop();
            Console.WriteLine("Первый: " + sw.ElapsedMilliseconds);

            sw.Reset();

            sw.Start();
            int[,] array2 = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array2[j, i] = 1;
                }
            }
            sw.Stop();
            Console.WriteLine("Второй: " + sw.ElapsedMilliseconds);
        }
        static void ObservableCollectionPpls()
        {
            ObservableCollection<Person> ppls = new ObservableCollection<Person>()
            {
            new Person("1asd","asd",22),
            new Person("2asd","1asd",45),
            new Person(){personName="2qwe",personSecondName="dasd",personAge=25},
            new Person{personAge=21,personName="qwe",personSecondName="2dasd"}
            };
            ppls.CollectionChanged += Ppls_CollectionChanged;
            ppls.Add(new Person("2aasdasdd", "1asdasd", 45));
            // ppls.Clear();
        }

        private static void Ppls_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (Person item in e.NewItems)
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine(item.personName);
                }

            }
            // Console.WriteLine(e.OldItems);
            // e.Action
            //public enum NotifyCollectionChangedAction
            //{
            //    Add = 0,
            //    Remove = 1,
            //    Replace = 2,
            //    Move = 3,
            //    Reset = 4,
            //}
        }

        static void DictionaryPpl()
        {
            Dictionary<string, Person> persons = new Dictionary<string, Person>()
            {
             // ["Fata"]= new Person("asd", "asd", 25),
                {"Homer", new Person("asd", "asd", 25) }
            };
            persons.Add("one", new Person("asd", "asd", 25));
            persons.Add("two", new Person("asd", "asd", 25));
            persons.Add("three", new Person("zxc", "asd", 25));
            Console.WriteLine(persons["one"].personName);
        }
        static void SortPplByAge()
        {
            SortedSet<Person> setOfPeople = new SortedSet<Person>(new SortPeopleByAge())
            {
            new Person("1asd","asd",22),
            new Person("2asd","1asd",45),
            new Person(){personName="2qwe",personSecondName="dasd",personAge=25},
            new Person{personAge=21,personName="qwe",personSecondName="2dasd"}
            };
            foreach (var item in setOfPeople)
            {
                Console.WriteLine(item.personAge);
            }
        }
        void SendAPersonByReference(ref Person p)
        {
            // Изменить некоторые данные в р.
            p.personAge = 555;
            // р теперь указывает на новый объект в куче!
            p = new Person(999);
        }
        static void UseGenenericList()
        {
            List<Person> list = new List<Person>() {
            new Person("asd","asd",25),
            new Person("2asd","1asd",45),
            new Person(){personName="qwe",personSecondName="dasd",personAge=25},
            new Person{personAge=25,personName="qwe",personSecondName="dasd"}
            };
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            list.Insert(2, new Person("New", "NEWsd", 15));
            Console.WriteLine(list.Count);
            Person[] arrayOfPeople = list.ToArray();
            foreach (var item in arrayOfPeople) Console.WriteLine($"first name:{item.personName}");
        }
        void UseGenencList()
        {

            // Этот объект List<> может хранить только объекты Person.
            List<Person> morePeople = new List<Person>();
            morePeople.Add(new Person("Frank", "Black", 50));
            Console.WriteLine(morePeople[0]);
            // Этот объект Lis to может хранить только целые числа.
            List<int> morelnts = new List<int>();
            morelnts.Add(10);
            morelnts.Add(2);
            int sum = morelnts[0] + morelnts[1];
            // Ошибка на этапе компиляции! Объект Person
            //не может быть добавлен в список элементов int!
            //morelnts.Add(new Person());}
        }
        private void ChainCtors()
        {
            Console.WriteLine(" *****Fun with class Types *****\n");
            // Создать объект Motorcycle.
            Motorcycle c = new Motorcycle(5);
            c.SetDriverName(" Tiny ");
            c.PopAWheely();
            Console.WriteLine(" Rider name is {0} ", c.dnverName); //вывод имени гонщика
            Console.ReadLine();
        }

        (string first, string middle, string last) SplitNames(string fullName)
        {
            // Действия, необходимые для расщепления полного имени,
            return ("Philip", "F", "Japikse");
        }
        static (int a, string b, bool c) FillTheseValues()
        {
            return (9, "Enjoy your string .", true);
        }
        private void Tuples()
        {
            var values = ("a ", 5, "c"); // .itemX
            (string FirstLetter, int TheNumber, string SecondLetter)
            valuesWithNames = ("a", 5, "c");
            var valuesWithNames2 = (FirstLetter: "a", TheNumber: 5, SecondLetter: "c");
            Console.WriteLine(valuesWithNames2.FirstLetter);
            Console.WriteLine(valuesWithNames.FirstLetter);
            Console.WriteLine(values.Item3);
            (int, int) example = (Customl: 5, Custom2: 7);
            (int Fieldl, int Field2) example2 = (Customl: 5, Custom2: 7);
            Console.WriteLine("=> Inferred Tuple Names 1 ");
            var foo = new { Propl = "first", Prop2 = "second" };
            var bar = (foo.Propl, foo.Prop2);
            Console.WriteLine($" {bar.Propl} ; {bar.Prop2} ");
            Console.WriteLine(new string('-', 50));
            var samples = FillTheseValues();
            Console.WriteLine($"Int is: { samples.a }");
            Console.WriteLine($"Stnng is: {samples.b}");
            Console.WriteLine($"Boolean is: { samples.c} ");
            //var (first, _, last) = SplitNames(" Philip F Japikse");
            //   Console.WriteLine($" {first} : {last}");
        }

        #region Ссылочные локальные переменные и возвращаемые ссылочные значения
        private static void LinksAndLocalVars()
        {
            string[] stringArray = { "one", "two", "three" };
            int pos = 1;
            Console.WriteLine("=> Use Ref Return");
            Console.WriteLine("Before: {0}, {1}, {2}",
                                stringArray[0], stringArray[1], stringArray[2]);
            ref var refOutput = ref SampleRefReturn(stringArray, pos);
            refOutput = "new";
            Console.WriteLine("After : {0}, {1}, {2} ", stringArray[0],
                                stringArray[1], stringArray[2]);
            Console.WriteLine(refOutput);
        }

        public static ref string SampleRefReturn(string[] strArray, int position)
        {
            return ref strArray[position];
        }
        #endregion
        private static void DayTimeMagic()
        {
            (string dateAsString, string description)[] dateInfo = { ("08/18/2018 07:22:16", "String with a date and time component"),
                                                                ("08/18/2018", "String with a date component only"),
                                                                ("8/2018", "String with a month and year component only"),
                                                                ("8/18", "String with a month and day component only"),
                                                                ("07:22:16", "String with a time component only"),
                                                                ("7 PM", "String with an hour and AM/PM designator only"),
                                                                ("2018-08-18T07:22:16.0000000Z", "UTC string that conforms to ISO 8601"),
                                                                ("2018-08-18T07:22:16.0000000-07:00", "Non-UTC string that conforms to ISO 8601"),
                                                                ("Sat, 18 Aug 2018 07:22:16 GMT", "String that conforms to RFC 1123"),
                                                                ("08/18/2018 07:22:16 -5:00", "String with date, time, and time zone information" ) };

            //Console.WriteLine(dateInfo.GetType());
            Console.WriteLine($"Today is {DateTime.Now:d}\n");
            foreach (var item in dateInfo)
            {
                Console.WriteLine($"{item.description + ":",-52} '{item.dateAsString}' --> {DateTime.Parse(item.dateAsString)}");
            }
        }

        static void Add(int x, int y, out int ans)
        {
            ans = x + y;
        }
        private void NewSwitchIsAwsome()
        {
            Console.WriteLine("1 [C#], 2 [VB]");
            do
            {
                Console.Write(" Please pick your language preference: ");
                object langChoice = Console.ReadLine();
                var choice = int.TryParse(langChoice.ToString(), out int pint) ? pint : langChoice;

                switch (choice)
                {
                    case int i when i == 2:
                    case string s when s.Equals("VB", StringComparison.OrdinalIgnoreCase):
                        Console.WriteLine("VB : OOP, multithreading, and more!");
                        // VB: ООП, многопоточность и многое другое!
                        break;
                    case int i when i == 1:
                    case string s when s.Equals("C#", StringComparison.OrdinalIgnoreCase):
                        Console.WriteLine("Good choice, C# is a fine language.");
                        // Хороший выбор. C# - замечательный язык.
                        break;
                    default:
                        Console.WriteLine("Well ... good luck with that !");
                        // Хорошо, удачи с этим!
                        break;
                }
            } while (true);
        }
    }
}
