#region ...

// TODO: Главная задача: Реализовать в простейшем приближении возможность использования экземпляра вашего класса аналогично экземпляру класса List<T>

// TODO: 1) Создайте класс с именем MyList и унаследуйте его от интерфейса MList<T>. Нажмите F6. С какими проблемами вы столкнулись? Сделайте соответствующие исправления.
// TODO: 2) В теле класса MyList, создайте пустую ссылку массив элементов типа Т с именем array и присвойте ей - null.
// TODO: 3) Создайте конструктор по умолчанию. В теле конструктора, создайте массив элементов типа Т размерностью в 0 элементов и запишите его в массив array
// TODO: 4) Реализуйте свойство Count из базового интерфейса, оно должно возвращать количество элементов массива array
// TODO: 5) Реализуйте метод Add из базового интерфейса. При вызове данного метода, массив array должен увеличиваться на 1 элемент и в его последний элемент должно записываться значение аргумента метода
// Для тех кто ВНИМАТЕЛЕН! Чтобы справиться с данной задачей. В теле метода создайте "промежуточный" массив с именем arr размером на 1 элемент больше чем массив array т.е. T[] arr = new T[array.Lenght + 1]; Используйте метод CopyTo, для того, чтобы скопировать все данные записанные в вашем массиве array в массив arr  - array.CopyTo(arr,0); или реализуйте это копирование через цикл for. Присвойте значение массива arr массиву array: array = arr; Теперь осталось только дописать аргумент метода Add в последний элемент массива array: array[array.Lenght-1] = a;  
// TODO: 6) Реализуйте индексатор из базового интерфейса, он должен возвращать значение элемента массива array по указанному индексу
// TODO: 7) Реализуйте метод Clear из базового интерфейса, он должен сбрасывать(очищать) массив array в первоначальное состояние, т.е. делать его пустым состоящим из 0 элементов.
// TODO: 8) Реализуйте метод Contains, который должен позвалять вам находить элемент массива array по указанному значению и если такой элемент имеется возвращать true иначе false.
// Для реализации этой задачи, в теле метода создайте цикл for, который сравнивает значение каждого элемента массива array со значением аргумента метода item, и если искомое значение будет найдено пользователь получит true: if(array[i]==item) return true; Если цикл отработал, а искомое значение так и не было найдено, тогда (т.к. все ветви кода должны возвращать значение) return false; 
// TODO: 9) Переопределите метод ToString() из базового класса Object таким образом, чтобы при его вызове, можно было увидеть подробную информацию о вашем массиве: его размер и все элементы. Т.е. Предположим вы в теле метода Main создали эклемпляр класса MyList с именем userList, заполнили его значениями, через вызов метода Add, а далее просто написали Console.WriteLine(userList);

#endregion

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;

namespace GenericsHW
{
    interface MList<T>
    {
        T this[int index] { get; }
        int Count { get; }
        void Add(T a);
        void Clear();
        bool Contains(T item);
    }
    // Mylist[] =
    public class MyList<T> : MList<T>
    {
        public static MyList<T> operator +(MyList<T> list1, T list2)
        {   

        }
        public T this[int index]
        {
            get
            {
                if (index >= this.array.Length)
                {
                    throw new IndexOutOfRangeException($"{nameof(index)} Index must be less then list length.");
                }

                return this.array[index];
            }
        }

        public int Count => array.Length;

        private T[] array = null;
        public MyList()
        {
            this.array = new T[0];
        }
        public void Add(T a)
        {
            T[] newArr = new T[this.array.Length + 1];
            this.array.CopyTo(newArr, 0);
            this.array = newArr;
            this.array[this.array.Length-1] = a;
        }

        public void Clear()
        {
            this.array = new T[0];
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (this.array[i].Equals(item) )
                {
                    return true;
                }
            }

            return false;
        }
        public override string ToString()
        {
            string resultText =$"{this.GetType()} [{this.array.Length}] :";
           
            foreach (var item in this.array)
            {
                resultText += item;
            }

            return resultText;
        }
    }
}
