using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VietLottVNAPI.Models
{
    public class VietlottvnRandom
    {
        public int NumberOne { get; set; }
        public int NumberTwo { get; set; }
        public int NumberThree { get; set; }
        public int NumberFour { get; set; }
        public int NumberFive { get; set; }
        public int NumberSix { get; set; }

        public string BlogNumber { get; set; }
        public List<int> listNumbers { get; set; }

        public VietlottvnRandom()
        {
            listNumbers = new List<int>();
        }
    }
}