using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLService
{
    public class VietlottVNDto
    {
        public string DatePize { get; set; }
        public List<string> ListNumbers { get; set; }

        public string StrNumber { get; set; }

        public VietlottVNDto()
        {
            ListNumbers = new List<string>();
        }
    }
}
