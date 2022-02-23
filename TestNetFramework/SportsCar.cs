using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestNetFramework
{
    public class SportsCar : Car
    {
        public string GetPetName(out string petName)
        {
            petName = "Fred";
            return    petName;
        }
    }
}