using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo1.Models;
using log4net;

namespace Demo1.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private static readonly ILog log = LogManager.GetLogger(typeof (Program)) ;

        public ActionResult Index()
        {
            var bolService = new BOLService.BOLService();
            var obj = new ImageDisplay();
            obj.PageIndex = new Random().Next(0, 5);
            obj.PageSize = 500;
            obj.ListImg = bolService.GetImgLinks(obj.PageIndex, obj.PageSize);
            if (obj.ListImg.Count == 0)
            {
                obj.ListImg = bolService.GetImgLinks(0, obj.PageSize);
            }
            return View(obj);
        }

        public ActionResult GetNewImages(int iPageIndex, int iPageSize)
        {
            var bolService = new BOLService.BOLService();
            if (iPageIndex < 0)
                iPageIndex = bolService.TotalImages()/iPageIndex;
            
            var data = bolService.GetImgLinks(iPageIndex, iPageSize).Select(o => new ListItem()
            {
                Id = o.ID,
                Name = o.linkimg
            });

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GenerateRandomImage(int? id)
        {
            var v = id.HasValue ? id.Value : 15;
            var bolService = new BOLService.BOLService();
            var result = bolService.GetRandomImage(v);
            var data = result.Select(o => new ListItem()
            {
                Id = o.ID,
                Name = o.linkimg
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Application Starting");
            ViewBag.Message = "Your app description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Detail(int id)
        {
            var bolService = new BOLService.BOLService();
            var obj = new ImageDisplay();
            obj.ListImg.Add(bolService.GetImgLinkById(id));
            return View(obj);
        }
    }
}
