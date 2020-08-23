using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom
{
    class Program
    {
        
        static void Main(string[] args)
        {                      
            ClassRoom p1 = new ClassRoom(new Pupil("Дурак"));
            p1.Stats();
            
        }
    }
}
