using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VietLottVNAPI.Models
{
    public class VietlottvnAppearance
    {
        public int Number { get; set; }
        public int Appearance { get; set; }

        public VietlottvnAppearance()
        {
            Number = 0;
            Appearance = 0;
        }
    }
}