using System;

namespace TestNetFramework
{
    class Motorcycle
    {
        public int driverlntensity;
        public string dnverName;
        // Связывание конструкторов в цепочку,
        public Motorcycle()
        {
            Console.WriteLine("In default ctor");
            // Внутри стандартного конструктора
        }
        public Motorcycle(int intensity)
        : this(intensity, "")
        {
            Console.WriteLine(" In ctor taking an int");
            // Внутри конструктора, принимающего int
        }
        public Motorcycle(string name)
        : this(0, name)
        {
            Console.WriteLine("In ctor taking a string");
        }
        // Внутри конструктора, принимающего string
        // Это 'главный' конструктор, выполняющий всю реальную работу,
        public Motorcycle(int intensity, string name)
        {
            Console.WriteLine("In master ctor ");
            // Внутри главного конструктора
            if (intensity > 10)
                intensity = 10;
            driverlntensity = intensity;
            dnverName = name;
        }

        internal void PopAWheely()
        {
            Console.WriteLine("Wheely!");
        }

        internal void SetDriverName(string v)
        {
            dnverName = v;
        }
    }
}