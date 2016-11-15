using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using RelaxImage.Models;

namespace RelaxImage.Controllers
{
    public class DVDController : Controller
    {
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
            obj.ListImg = bolService.GetCoolRandomImgLinks(amount.Value);
            return View(obj);
        }

        public ActionResult GetNewImages(int iPageIndex, int iPageSize)
        {
            var bolService = new BOLService.BOLService();
 
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
    }
}