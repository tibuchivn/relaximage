using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLService
{
    public class VietlottVNRandom
    {
        public int NumberOne { get; set; }
        public int NumberTwo { get; set; }
        public int NumberThree { get; set; }
        public int NumberFour { get; set; }
        public int NumberFive { get; set; }
        public int NumberSix { get; set; }

        public string BlogNumber { get; set; }
        public List<int> listNumbers { get; set; }

        public VietlottVNRandom  ()
        {
            listNumbers = new List<int>();
        }
    }
}
