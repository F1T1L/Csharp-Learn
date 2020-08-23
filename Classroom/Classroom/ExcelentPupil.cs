using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom
{
    class ExcelentPupil : Pupil
    {
        public ExcelentPupil(string name)
            : base(name)
        { }
        public void Study() { Console.WriteLine("Pupil.ExcelentPupil Study"); }
        public void Read() { Console.WriteLine("Pupil.ExcelentPupil Read"); }
        public void Write() { Console.WriteLine("Pupil.ExcelentPupil Write"); }
        public void Relax() { Console.WriteLine("Pupil.ExcelentPupil Relax"); }
    }
}
