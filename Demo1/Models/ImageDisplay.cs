using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOLService;

namespace Demo1.Models
{
    public class ImageDisplay
    {
        public List<ImgLink> ListImg { get; set;}

        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public ImageDisplay()
        {
            ListImg = new List<ImgLink>();
        }
    }
}