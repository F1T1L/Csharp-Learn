using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom
{
    class ClassRoom
    {
        const int maxPupils = 4;
        Pupil[] pupils = new Pupil[maxPupils];
        Pupil temp = null;
        Random rand = new Random();

        public ClassRoom(Pupil p1)
        {
            this.pupils[0] = p1;
            this.pupils[1] = CreatePupil();
            this.pupils[2] = CreatePupil();
            this.pupils[3] = CreatePupil();

            Console.WriteLine("Costructor ClassRoom \t\tp1");
            Console.WriteLine(new string('-', 50));
        }
        public ClassRoom(Pupil p1, Pupil p2)
        {
            this.pupils[0] = p1;
            this.pupils[1] = p2;
            this.pupils[2] = CreatePupil();
            this.pupils[3] = CreatePupil();
            Console.WriteLine("Costructor ClassRoom \t\tp1 + p2");
            Console.WriteLine(new string('-', 50));
        }
        public ClassRoom(Pupil p1, Pupil p2, Pupil p3)
        {
            this.pupils[0] = p1;
            this.pupils[1] = p2;
            this.pupils[2] = p3;
            this.pupils[3] = CreatePupil();
            Console.WriteLine("Costructor ClassRoom \t\tp1 + p2+p3");
            Console.WriteLine(new string('-', 50));
        }
        public ClassRoom(Pupil p1, Pupil p2, Pupil p3, Pupil p4)
        {
            this.pupils[0] = p1;
            this.pupils[1] = p2;
            this.pupils[2] = p3;
            this.pupils[3] = p4;            
            Console.WriteLine("Costructor ClassRoom \t\tp1+p2+p3+p4");
            Console.WriteLine(new string('-', 50));
        }
        private Pupil CreatePupil()
        {
            int r = rand.Next(1, maxPupils);
            switch (r)
            {
                case 1:
                    temp = new BadPupil("Ivan");
                    Console.WriteLine("CreatePupil();");
                    break;
                case 2:
                    temp = new BadPupil("Petr");
                    Console.WriteLine("CreatePupil();");
                    break;
                case 3:
                    temp = new BadPupil("Alesha");
                    Console.WriteLine("CreatePupil();");
                    break;
                default:
                    Console.WriteLine("!!!!!!CreatePupil() = ОШИБКА!");
                    break;
            }
            return temp;
        }
        public void Stats()
        {
            foreach (var item in pupils)
            {
                Console.WriteLine("Pupil \"{0}\" have stats:", item.Name);               
                item.Study();
                item.Read();
                item.Write();
                item.Relax();
                Console.WriteLine(new string('*',30));
            }
        }
    }

}
