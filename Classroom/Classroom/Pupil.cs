using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom
{
    class Pupil
    {
        private string name;
        public string Name { get; }
        public Pupil() { }
        public Pupil(string name)
        {
            this.name = name;
            Console.WriteLine("Costructor Pupil: name: \"{0}\"", name);
        }
        public void Study() { Console.WriteLine("Pupil.BASECLASS Study"); }
        public void Read()  { Console.WriteLine("Pupil.BASECLASS Read"); }
        public void Write() { Console.WriteLine("Pupil.BASECLASS Write"); }
        public void Relax() { Console.WriteLine("Pupil.BASECLASS Relax"); }
        public string Method()
        {
            return string.Empty;
        }
    }
        
}
