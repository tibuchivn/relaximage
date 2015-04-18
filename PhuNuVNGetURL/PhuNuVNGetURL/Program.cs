using System;
using System.Collections.Generic;
using System.Linq;
using BOLService;
using HtmlAgilityPack;

namespace PhuNuVNGetURL
{
    class Program
    {
        static void Main(string[] args)
        {
            Bikini_VietNam();
            Bikini_Chau_A();
            Bikini_ChauAu_ChauMy();
        }

        public static void Bikini_VietNam()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start = 0;
            int end = 39; //TODO: current max value 39

            //track counter: id="post-5740"
            for (int i = end; i > start; i--)
            {
                try
                {
                    var doc = web.Load("http://phunuvn.net/forums/anh-girl-xinh-bikini-viet-nam.8/page-" + i);
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//ol[@class = 'discussionListItems']");
                    if (divContainer == null) continue;

                    foreach (HtmlNode htmlNode in divContainer.ChildNodes)
                    {
                        if (htmlNode.Name.Equals("li") && htmlNode.Attributes["id"] != null)
                        {
                            string strClass = htmlNode.Attributes["id"].Value;
                            string strCounter = strClass.Replace("thread-", "");
                            if (strClass.Contains("thread-"))
                            {
                                bool bDownloaded = bolService.CheckLinkDownloaded("phunuvn.net", strCounter);
                                if (!bDownloaded)
                                {
                                    foreach (HtmlNode node in htmlNode.ChildNodes)
                                    {
                                        if (node.Name.Equals("div") && node.Attributes["class"] != null &&
                                            node.Attributes["class"].Value == "listBlock main")
                                        {
                                            HtmlNode nodeTitle = node.ChildNodes.FirstOrDefault(o => o.Name == "div" && o.HasAttributes && o.Attributes["class"].Value == "titleText");
                                            if (nodeTitle != null && nodeTitle.HasChildNodes)
                                            {
                                                HtmlNode nodeh3 = nodeTitle.ChildNodes.FirstOrDefault(o => o.Name == "h3" && o.HasAttributes && o.Attributes["class"].Value == "title");
                                                if (nodeh3 != null && nodeh3.HasChildNodes)
                                                {
                                                    HtmlNode nodeLink = nodeh3.ChildNodes.FirstOrDefault(o => o.Name == "a" && o.HasAttributes && o.Attributes["class"].Value == "PreviewTooltip");
                                                    string strTitle = nodeLink.InnerText;
                                                    string strPage = string.Format("http://phunuvn.net/{0}", nodeLink.Attributes["href"].Value);
                                                    //TODO: call function Get Images
                                                    TestImageOnePage(strPage, strCounter, "Bikini-Viet-Nam", strTitle);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    //log4net.Config.XmlConfigurator.Configure();
                    //log.Info("Error: " + exception);
                    Console.WriteLine(exception.ToString());
                }
            }
            Console.WriteLine("Finish Bikini_VietNam ^_^");
        }

        public static void Bikini_Chau_A()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start = 0;
            int end = 44; //TODO: current max value 39

            //track counter: id="post-5740"
            for (int i = end; i > start; i--)
            {
                try
                {
                    var doc = web.Load("http://phunuvn.net/forums/anh-girl-xinh-bikini-chau-a.9/page-" + i);
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//ol[@class = 'discussionListItems']");
                    if (divContainer == null) continue;

                    foreach (HtmlNode htmlNode in divContainer.ChildNodes)
                    {
                        if (htmlNode.Name.Equals("li") && htmlNode.Attributes["id"] != null)
                        {
                            string strClass = htmlNode.Attributes["id"].Value;
                            string strCounter = strClass.Replace("thread-", "");
                            if (strClass.Contains("thread-"))
                            {
                                bool bDownloaded = bolService.CheckLinkDownloaded("phunuvn.net", strCounter);
                                if (!bDownloaded)
                                {
                                    foreach (HtmlNode node in htmlNode.ChildNodes)
                                    {
                                        if (node.Name.Equals("div") && node.Attributes["class"] != null &&
                                            node.Attributes["class"].Value == "listBlock main")
                                        {
                                            HtmlNode nodeTitle = node.ChildNodes.FirstOrDefault(o => o.Name == "div" && o.HasAttributes && o.Attributes["class"].Value == "titleText");
                                            if (nodeTitle != null && nodeTitle.HasChildNodes)
                                            {
                                                HtmlNode nodeh3 = nodeTitle.ChildNodes.FirstOrDefault(o => o.Name == "h3" && o.HasAttributes && o.Attributes["class"].Value == "title");
                                                if (nodeh3 != null && nodeh3.HasChildNodes)
                                                {
                                                    HtmlNode nodeLink = nodeh3.ChildNodes.FirstOrDefault(o => o.Name == "a" && o.HasAttributes && o.Attributes["class"].Value == "PreviewTooltip");
                                                    string strTitle = nodeLink.InnerText;
                                                    string strPage = string.Format("http://phunuvn.net/{0}", nodeLink.Attributes["href"].Value);
                                                    //TODO: call function Get Images
                                                    TestImageOnePage(strPage, strCounter, "Bikini-Chau-A", strTitle);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    //log4net.Config.XmlConfigurator.Configure();
                    //log.Info("Error: " + exception);
                    Console.WriteLine(exception.ToString());
                }
            }
            Console.WriteLine("Finish Bikini_VietNam ^_^");
        }

        public static void Bikini_ChauAu_ChauMy()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start = 0;
            int end = 11; //TODO: current max value 11

            //track counter: id="post-5740"
            for (int i = end; i > start; i--)
            {
                try
                {
                    var doc = web.Load("http://phunuvn.net/forums/anh-bikini-chau-au-chau-my.10/page-" + i);
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//ol[@class = 'discussionListItems']");
                    if (divContainer == null) continue;

                    foreach (HtmlNode htmlNode in divContainer.ChildNodes)
                    {
                        if (htmlNode.Name.Equals("li") && htmlNode.Attributes["id"] != null)
                        {
                            string strClass = htmlNode.Attributes["id"].Value;
                            string strCounter = strClass.Replace("thread-", "");
                            if (strClass.Contains("thread-"))
                            {
                                bool bDownloaded = bolService.CheckLinkDownloaded("phunuvn.net", strCounter);
                                if (!bDownloaded)
                                {
                                    foreach (HtmlNode node in htmlNode.ChildNodes)
                                    {
                                        if (node.Name.Equals("div") && node.Attributes["class"] != null &&
                                            node.Attributes["class"].Value == "listBlock main")
                                        {
                                            HtmlNode nodeTitle = node.ChildNodes.FirstOrDefault(o => o.Name == "div" && o.HasAttributes && o.Attributes["class"].Value == "titleText");
                                            if (nodeTitle != null && nodeTitle.HasChildNodes)
                                            {
                                                HtmlNode nodeh3 = nodeTitle.ChildNodes.FirstOrDefault(o => o.Name == "h3" && o.HasAttributes && o.Attributes["class"].Value == "title");
                                                if (nodeh3 != null && nodeh3.HasChildNodes)
                                                {
                                                    HtmlNode nodeLink = nodeh3.ChildNodes.FirstOrDefault(o => o.Name == "a" && o.HasAttributes && o.Attributes["class"].Value == "PreviewTooltip");
                                                    string strTitle = nodeLink.InnerText;
                                                    string strPage = string.Format("http://phunuvn.net/{0}", nodeLink.Attributes["href"].Value);
                                                    //TODO: call function Get Images
                                                    TestImageOnePage(strPage, strCounter, "Bikini-ChauAu-ChauMy", strTitle);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    //log4net.Config.XmlConfigurator.Configure();
                    //log.Info("Error: " + exception);
                    Console.WriteLine(exception.ToString());
                }
            }
            Console.WriteLine("Finish Bikini_VietNam ^_^");
        }

        public static void TestImageOnePage(string strPage, string strCounter, string category, string strTitle)
        {
            try
            {
                var bolService = new BOLService.BOLService();
                if (bolService.CheckExistLinkByDomain(strCounter, "phunuvn.net")) return;

                var lst = new List<ImgLink>();
                var web = new HtmlWeb();
                var doc = web.Load(strPage);
                //TODO: Check valid 
                var divContainer = doc.DocumentNode.SelectSingleNode("//blockquote[@class = 'messageText ugc baseHtml']");
                if (divContainer == null)
                {
                    return;
                }

                HtmlNodeCollection nodeImagesCollection = divContainer.SelectNodes("//img[@class = 'bbCodeImage LbImage']");
                foreach (var node in nodeImagesCollection)
                {
                    try
                    {
                        string strLink = node.Attributes["src"].Value;
                        var item = new ImgLink()
                        {
                            Category = category,
                            Counter = strCounter,
                            CreateDate = DateTime.Now,
                            Domain = "phunuvn.net",
                            GroupName = strTitle,
                            linkimg = strLink
                        };
                        lst.Add(item);
                    }
                    catch (Exception ex)
                    {
                        //TODO: show error;
                        Console.WriteLine(ex.ToString());
                    }
                }
                if (lst.Count > 0)
                {
                    bolService.SaveImg(lst);
                    Console.WriteLine(strPage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static string BuildCounter(string str)
        {
            int index = str.LastIndexOf('.');
            if (index > 0)
            {
                string tmp = str.Substring(index);
                tmp = tmp.Replace("/", "");
                return tmp;
            }
            return str;
        }
    }
}
