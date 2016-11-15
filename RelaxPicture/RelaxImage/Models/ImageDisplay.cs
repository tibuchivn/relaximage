using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOLService;

namespace RelaxImage.Models
{
    public class ImageDisplay
    {
        public List<ImgLink> ListImg { get; set; }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public int TotalRecords { get; set; }

        public int CurrentPage { get; set; }

        public ImageDisplay()
        {
            ListImg = new List<ImgLink>();
        }
    }
}