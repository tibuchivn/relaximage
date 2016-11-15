using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo1.Models;

namespace Demo1.Controllers
{
    public class LastedController : Controller
    {
        //
        // GET: /Lasted/

        public ActionResult Index()
        {
            var bolService = new BOLService.BOLService();
            var obj = new ImageDisplay();
            obj.PageIndex = 0;
            obj.PageSize = 1000;
            obj.ListImg = bolService.GetImgLinks(obj.PageIndex, obj.PageSize);
            return View(obj);
        }
    }
}
