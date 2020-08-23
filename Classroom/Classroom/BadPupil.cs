using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom
{
    class BadPupil : Pupil
    {
        public BadPupil(string name)
            : base(name)
        { }
        public void Study() { Console.WriteLine("Pupil.BadPupil Study"); }
        public void Read()  { Console.WriteLine("Pupil.BadPupil Read"); }
        public void Write() { Console.WriteLine("Pupil.BadPupil Write"); }
        public void Relax() { Console.WriteLine("Pupil.BadPupil Relax"); }
        public string Method()
        {
            return string.Empty;
        }
    }
}
