using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Demo1.Controllers
{
    public class ClipController : Controller
    {
        //
        // GET: /Clip/

        public ActionResult Index()
        {
            var bolService = new BOLService.BOLService();
            var vImg = bolService.GetRandomImage(1);
            string str = vImg.First().linkimg;
            int index = str.LastIndexOf('.');
            string strExtension = str.Substring(index + 1);
            var webClient = new WebClient();
            webClient.DownloadFile(str, "D:\\Public\\Project_Tools_\\DemoDepVDWeb\\Demo1\\Download_\\" + vImg.First().ID + "." + strExtension);
            return View();
        }

    }
}
