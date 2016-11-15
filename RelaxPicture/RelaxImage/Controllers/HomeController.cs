using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using log4net;
using RelaxImage.Models;

namespace RelaxImage.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private static readonly ILog log = LogManager.GetLogger(typeof (Program)) ;

        //public ActionResult Index()
        //{
        //    var bolService = new BOLService.BOLService();
        //    var obj = new ImageDisplay();
        //    obj.PageIndex = new Random().Next(0, 5);
        //    obj.PageSize = 50;
        //    //obj.ListImg = bolService.GetImgLinks(obj.PageIndex, obj.PageSize);
        //    //if (obj.ListImg.Count == 0)
        //    //{
        //    //    obj.ListImg = bolService.GetImgLinks(0, obj.PageSize);
        //    //}
        //    //obj.ListImg.Shuffle();

        //    obj.ListImg = bolService.GetCoolRandomImgLinks(50);
        //    return View(obj);
        //}

        public ActionResult Index([FromUri]int? amount)
        {
            if (amount.HasValue == false || amount.Value <= 0)
            {
                amount = 50;
            }
            var bolService = new BOLService.BOLService();
            var obj = new ImageDisplay();
            obj.PageIndex = new Random().Next(0, 5);
            obj.PageSize = amount.Value;
            //obj.ListImg = bolService.GetImgLinks(obj.PageIndex, obj.PageSize);
            //if (obj.ListImg.Count == 0)
            //{
            //    obj.ListImg = bolService.GetImgLinks(0, obj.PageSize);
            //}
            //obj.ListImg.Shuffle();

            obj.ListImg = bolService.GetCoolRandomImgLinks(amount.Value);
            return View(obj);
        }

        public ActionResult GetNewImages(int iPageIndex, int iPageSize)
        {
            var bolService = new BOLService.BOLService();

            //obj.ListImg.Shuffle()
            //var v = bolService.GetRandomImage(iPageSize);
            var v = bolService.GetCoolRandomImgLinks(iPageSize);
            v.Shuffle();
            var data = v.Select(o => new ListItem()
            {
                Id = o.ID,
                Name = o.linkimg
            });

            var jsonResult = Json(data, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

            //return Json(data, JsonRequestBehavior.AllowGet);
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
            if (id > 0)
            {
                obj.ListImg.Add(bolService.GetImgLinkById(id));
                //obj.ListImg.Shuffle();
            }
            return View(obj);
        }

        public ActionResult BadURL(int id)
        {
            var bolService = new BOLService.BOLService();
            bolService.UpdateBadURL(id);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult NiceURL(int id)
        {
            var bolService = new BOLService.BOLService();
            bolService.UpdateNiceURL(id);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ReverURL(int id)
        {
            var bolService = new BOLService.BOLService();
            bolService.ReverURL(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FireFoxExtension()
        {
            var amount = 50;
            var bolService = new BOLService.BOLService();
            var obj = new ImageDisplay();
            obj.PageIndex = new Random().Next(0, 5);
            obj.PageSize = amount;

            obj.ListImg = bolService.GetCoolRandomImgLinks(amount);
            return View(obj);
        }

        public ActionResult Game()
        {
            return View();
        }

        public ActionResult Gamev0()
        {
            return View();
        }

        public ActionResult RandomLinkImage(int? id)
        {
            var vAmountRows = id.HasValue ? id.Value : 15;
            var bolService = new BOLService.BOLService();
            var result = bolService.GetRandomImage(vAmountRows, 1, 0, string.Empty);
            var data = result.Select(o => new ListItem()
            {
                Id = o.ID,
                Name = o.linkimg
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DVDV2()
        {
            return View();
        }
    }
}
