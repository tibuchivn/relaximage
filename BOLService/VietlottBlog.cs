using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLService
{
    public class VietlottBlog
    {
        public string StrBlog { get; set; }
        public List<int> ListVietLottNumbers { get; set; }

        public int NumberOne { get; set; }
        public int NumberTwo { get; set; }
        public int NumberThree { get; set; }
        public int NumberFour { get; set; }
        public int NumberFive { get; set; }
        public int NumberSix { get; set; }

        public VietlottBlog()
        {
            StrBlog = string.Empty;
            ListVietLottNumbers = new List<int>();
        }
    }

    public class VietlottUseTo
    {
        public VietlottBlog VLUseTo { get; set; }
        public DateTime VLDatePublish { get; set; }

        public VietlottUseTo()
        {
            VLUseTo = new VietlottBlog();
            VLDatePublish = DateTime.MinValue;
        }
    }
}
