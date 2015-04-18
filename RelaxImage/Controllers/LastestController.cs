using System;
using System.Web.Mvc;
using RelaxImage.Models;

namespace RelaxImage.Controllers
{
    public class LastestController : Controller
    {
        //
        // GET: /Lastest/

        public ActionResult Index()
        {
            var bolService = new BOLService.BOLService();
            var obj = new ImageDisplay();
            obj.PageIndex = 0;
            obj.PageSize = 1000;
            obj.ListImg = bolService.GetImgLinks(obj.PageIndex, obj.PageSize);
            return View(obj);
        }

        public ActionResult TestDomain(string id)
        {
            int i = 0;
            int.TryParse(id, out i);
            string strDomain = GetDomainName(i);
             
            var bolService = new BOLService.BOLService();
            var obj = new ImageDisplay();
            obj.PageIndex = 0;
            obj.PageSize = 1000;
            obj.ListImg = bolService.GetImgLinksByDomain(obj.PageIndex, obj.PageSize, strDomain);
            obj.ListImg.Shuffle();
            return View(obj);
        }

        public ActionResult Review(int? id)
        {
            var bolService = new BOLService.BOLService();
            var obj = new ImageDisplay();
            
            int domainId = id.HasValue ? id.Value : 0;
            if (domainId == 0)
            {
                obj.ListImg = bolService.GetBadURL(string.Empty);
            }
            else
            {
                string domainName = GetDomainName(domainId);
                obj.ListImg = bolService.GetBadURL(domainName);
            }
            return View(obj);
        }

        private string GetDomainName(int domainId)
        {
            string strDomain = string.Empty;
            switch (domainId.ToString())
            {
                case "1":
                    {
                        strDomain = "depvd.com";
                    } break;
                case "2":
                    {
                        strDomain = "chandai.tv";
                    } break;
                case "3":
                    {
                        strDomain = "photo.hoanvu.net";
                    } break;
                case "4":
                    {
                        strDomain = "xinh.hay.la";
                    } break;
                case "5":
                    {
                        strDomain = "tructiepso.com";
                    } break;
                case "6":
                    {
                        strDomain = "xinhvl.com";
                    } break;
                case "7":
                    {
                        strDomain = "xemlasuong.org";
                    } break;
                case "8":
                    {
                        strDomain = "phunuvn.net";
                    } break;
                case "9":
                    {
                        strDomain = "xemanh.net";
                    } break;
                case "10":
                    {
                        strDomain = "xiuren.org";
                    } break;
                case "11":
                    {
                        strDomain = "ugirls.com";
                    } break;
            }
            return strDomain;
        }
    }
}
