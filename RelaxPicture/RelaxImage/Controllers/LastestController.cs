﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BOLService;
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
                case "12":
                    {
                        strDomain = "tgod.me";
                    } break;
            }
            return strDomain;
        }

        public ActionResult FastCheckImage(int? id)
        {
            int domainId= id ?? 12;
            var bolService = new BOLService.BOLService();
            var obj = new ImageDisplay();
            int pageSize = 10;
            int pageIndex = 1;
            int? totals = 0;
            string domainName = GetDomainName(domainId);
            obj.PageSize = pageSize;
            obj.PageIndex = pageIndex;
            obj.CurrentPage = 1;
            obj.ListImg = bolService.GetTopLastest(domainName, pageSize, (pageIndex - 1) * pageSize, ref  totals);
            obj.TotalRecords = totals.GetValueOrDefault();
            return View(obj);
        }

        public ActionResult PagingImage(int? domaind, int pageSize, int pageIndex)
        {
            var bolService = new BOLService.BOLService();
            var obj = new ImageDisplay();
            int domainId = domaind ?? 12;
            string domainName = GetDomainName(domainId);
            int? totals = 0; 
            obj.ListImg = bolService.GetTopLastest(domainName, pageSize, (pageIndex -1)* pageSize, ref  totals);
            obj.TotalRecords = totals.GetValueOrDefault();
            return Json(new { success = true, data = obj.ListImg }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult MakeBadURL(int idImage)
        {
            var bolService = new BOLService.BOLService();
            bolService.UpdateBadURL(idImage);
            return Json(true);
        }
    }
}
