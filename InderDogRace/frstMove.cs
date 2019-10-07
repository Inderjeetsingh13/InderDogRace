using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InderDogRace
{
   public class frstMove
    {
        public int move() {
            Random rd = new Random();
            return rd.Next(1, 30);
        }
    }
}
