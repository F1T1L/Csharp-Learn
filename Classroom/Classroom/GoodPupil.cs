using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom
{
    class GoodPupil : Pupil
    {
        public GoodPupil(string name)
               : base(name)
        { }
        public void Study() { Console.WriteLine("Pupil.GoodPupil Study"); }
        public void Read() { Console.WriteLine("Pupil.GoodPupil Read"); } 
        public void Write() { Console.WriteLine("Pupil.GoodPupil Write"); }
        public void Relax() { Console.WriteLine("Pupil.GoodPupil Relax"); }
    }
}
