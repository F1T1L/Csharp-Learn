using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNetFramework
{
    public struct GenericPoint<T>
    {
        private T xPos;
        private T yPos;
        public T X { get=> xPos; set=> xPos=value; }
        public T Y { get=> yPos; set=> yPos=value; }
        public GenericPoint(T X,T Y)
        {
            xPos = X;
            yPos = Y;
        }
        public void ResetPoint()
        {
            xPos = default(T); 
            yPos = default(T);
        }
        public override string ToString() => $"[{xPos}, {yPos}]";
    }
}
