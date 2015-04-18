using System;
using System.Collections.Generic;
using System.Linq;
using BOLService;
using HtmlAgilityPack;

namespace HoanVuURL
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: run daily
            GetHome();

            //GetBikiniGirl();
            //GetChanDaiVaXe();
            //GetCosplays();
            //GetHotGirlSexy();
            //GetGirlXinh();
            //GetGirlXinhVietNam();
            //GetJapanKorea();
            
            //TestImageOnePage("http://photo.hoanvu.net/chan-dai-va-xe/nguoi-dep-quan-chip-ben-sieu-xe-5358.html");
        }

        public static void GetHome()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start = 1;
            int end = 100;

            //track counter: id="post-5740"
            for (int i = start; i < end; i++)
            {
                try
                {
                    var doc = web.Load("http://photo.hoanvu.net");
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'container']");
                    if (divContainer == null) continue;

                    foreach (HtmlNode node in divContainer.ChildNodes)
                    {
                        if (node != null && node.Name == "div")
                        {
                            try
                            {
                                string strCounter = node.Attributes["id"].Value;
                                if (strCounter != "post-tags")
                                {
                                    bool bDownloaded = bolService.CheckLinkDownloaded("photo.hoanvu.net", strCounter);
                                    if (!bDownloaded && node.HasChildNodes)
                                    {
                                        HtmlNode nodeDiv = node.SelectSingleNode("//div[@class = 'post-thumbnail']");
                                        HtmlNode nodea = nodeDiv.SelectSingleNode("//a[@class = 'img']");
                                        string strTitle = nodea.Attributes["title"].Value;
                                        string strPage = nodea.Attributes["href"].Value;

                                        //TODO: call function Get Images
                                        SaveImageOnePage(strPage, strCounter, "bikini-girl", strTitle);
                                    }
                                }
                                
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.ToString());
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
            Console.WriteLine("Finish GetBikiniGirl ^_^");
        }

        public static void GetBikiniGirl()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start = 1;
            int end = 17;

            //track counter: id="post-5740"
            for (int i = start; i < end; i++)
            {
                try
                {
                    var doc = web.Load("http://photo.hoanvu.net/bikini-girl/page/" + i);
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'container']");
                    if(divContainer == null) continue;
                    
                    foreach (HtmlNode node in divContainer.ChildNodes)
                    {
                        if (node != null && node.Name == "div")
                        {
                            try
                            {
                                string strCounter = node.Attributes["id"].Value;
                                bool bDownloaded = bolService.CheckLinkDownloaded("photo.hoanvu.net", strCounter);
                                if (!bDownloaded && node.HasChildNodes)
                                {
                                    HtmlNode nodeDiv = node.SelectSingleNode("//div[@class = 'post-thumbnail']");
                                    HtmlNode nodea = nodeDiv.SelectSingleNode("//a[@class = 'img']");
                                    string strTitle = nodea.Attributes["title"].Value;
                                    string strPage = nodea.Attributes["href"].Value;

                                    //TODO: call function Get Images
                                    SaveImageOnePage(strPage, strCounter, "bikini-girl", strTitle);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.ToString());
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
            Console.WriteLine("Finish GetBikiniGirl ^_^");
        }

        public static void GetChanDaiVaXe()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start = 1;
            int end = 4;

            //track counter: id="post-5740"
            for (int i = start; i < end; i++)
            {
                try
                {
                    var doc = web.Load("http://photo.hoanvu.net/chan-dai-va-xe/page/" + i);
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'container']");
                    if (divContainer == null) continue;

                    foreach (HtmlNode node in divContainer.ChildNodes)
                    {
                        if (node != null && node.Name == "div")
                        {
                            try
                            {
                                string strCounter = node.Attributes["id"].Value;
                                bool bDownloaded = bolService.CheckLinkDownloaded("photo.hoanvu.net", strCounter);
                                if (!bDownloaded && node.HasChildNodes)
                                {
                                    HtmlNode nodeDiv = node.SelectSingleNode("//div[@class = 'post-thumbnail']");
                                    HtmlNode nodea = nodeDiv.SelectSingleNode("//a[@class = 'img']");
                                    string strTitle = nodea.Attributes["title"].Value;
                                    string strPage = nodea.Attributes["href"].Value;

                                    //TODO: call function Get Images
                                    SaveImageOnePage(strPage, strCounter, "bikini-girl", strTitle);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.ToString());
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
            Console.WriteLine("Finish GetBikiniGirl ^_^");
        }

        public static void GetCosplays()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start = 1;
            int end = 3;

            //track counter: id="post-5740"
            for (int i = start; i < end; i++)
            {
                try
                {
                    var doc = web.Load("http://photo.hoanvu.net/cosplays/page/" + i);
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'container']");
                    if (divContainer == null) continue;

                    foreach (HtmlNode node in divContainer.ChildNodes)
                    {
                        if (node != null && node.Name == "div")
                        {
                            try
                            {
                                string strCounter = node.Attributes["id"].Value;
                                bool bDownloaded = bolService.CheckLinkDownloaded("photo.hoanvu.net", strCounter);
                                if (!bDownloaded && node.HasChildNodes)
                                {
                                    HtmlNode nodeDiv = node.SelectSingleNode("//div[@class = 'post-thumbnail']");
                                    HtmlNode nodea = nodeDiv.SelectSingleNode("//a[@class = 'img']");
                                    string strTitle = nodea.Attributes["title"].Value;
                                    string strPage = nodea.Attributes["href"].Value;

                                    //TODO: call function Get Images
                                    SaveImageOnePage(strPage, strCounter, "bikini-girl", strTitle);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.ToString());
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
            Console.WriteLine("Finish GetBikiniGirl ^_^");
        }

        public static void GetHotGirlSexy()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start = 1;
            int end = 3;

            //track counter: id="post-5740"
            for (int i = start; i < end; i++)
            {
                try
                {
                    var doc = web.Load("http://photo.hoanvu.net/hot-girl-sexy/page/" + i);
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'container']");
                    if (divContainer == null) continue;

                    foreach (HtmlNode node in divContainer.ChildNodes)
                    {
                        if (node != null && node.Name == "div")
                        {
                            try
                            {
                                string strCounter = node.Attributes["id"].Value;
                                bool bDownloaded = bolService.CheckLinkDownloaded("photo.hoanvu.net", strCounter);
                                if (!bDownloaded && node.HasChildNodes)
                                {
                                    HtmlNode nodeDiv = node.SelectSingleNode("//div[@class = 'post-thumbnail']");
                                    HtmlNode nodea = nodeDiv.SelectSingleNode("//a[@class = 'img']");
                                    string strTitle = nodea.Attributes["title"].Value;
                                    string strPage = nodea.Attributes["href"].Value;

                                    //TODO: call function Get Images
                                    SaveImageOnePage(strPage, strCounter, "bikini-girl", strTitle);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.ToString());
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
            Console.WriteLine("Finish GetBikiniGirl ^_^");
        }

        public static void GetGirlXinh()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start = 1;
            int end = 19;

            //track counter: id="post-5740"
            for (int i = start; i < end; i++)
            {
                try
                {
                    var doc = web.Load("http://photo.hoanvu.net/girl-xinh/page/" + i);
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'container']");
                    if (divContainer == null) continue;

                    foreach (HtmlNode node in divContainer.ChildNodes)
                    {
                        if (node != null && node.Name == "div")
                        {
                            try
                            {
                                string strCounter = node.Attributes["id"].Value;
                                bool bDownloaded = bolService.CheckLinkDownloaded("photo.hoanvu.net", strCounter);
                                if (!bDownloaded && node.HasChildNodes)
                                {
                                    HtmlNode nodeDiv = node.SelectSingleNode("//div[@class = 'post-thumbnail']");
                                    HtmlNode nodea = nodeDiv.SelectSingleNode("//a[@class = 'img']");
                                    string strTitle = nodea.Attributes["title"].Value;
                                    string strPage = nodea.Attributes["href"].Value;

                                    //TODO: call function Get Images
                                    SaveImageOnePage(strPage, strCounter, "bikini-girl", strTitle);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.ToString());
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
            Console.WriteLine("Finish GetBikiniGirl ^_^");
        }

        public static void GetGirlXinhVietNam()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start = 1;
            int end = 3;

            //track counter: id="post-5740"
            for (int i = start; i < end; i++)
            {
                try
                {
                    var doc = web.Load("http://photo.hoanvu.net/girl-xinh-viet-nam/page/" + i);
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'container']");
                    if (divContainer == null) continue;

                    foreach (HtmlNode node in divContainer.ChildNodes)
                    {
                        if (node != null && node.Name == "div")
                        {
                            try
                            {
                                string strCounter = node.Attributes["id"].Value;
                                bool bDownloaded = bolService.CheckLinkDownloaded("photo.hoanvu.net", strCounter);
                                if (!bDownloaded && node.HasChildNodes)
                                {
                                    HtmlNode nodeDiv = node.SelectSingleNode("//div[@class = 'post-thumbnail']");
                                    HtmlNode nodea = nodeDiv.SelectSingleNode("//a[@class = 'img']");
                                    string strTitle = nodea.Attributes["title"].Value;
                                    string strPage = nodea.Attributes["href"].Value;

                                    //TODO: call function Get Images
                                    SaveImageOnePage(strPage, strCounter, "bikini-girl", strTitle);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.ToString());
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
            Console.WriteLine("Finish GetBikiniGirl ^_^");
        }

        public static void GetJapanKorea()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start = 1;
            int end = 3;

            //track counter: id="post-5740"
            for (int i = start; i < end; i++)
            {
                try
                {
                    var doc = web.Load("http://photo.hoanvu.net/japan-korea/page/" + i);
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'container']");
                    if (divContainer == null) continue;

                    foreach (HtmlNode node in divContainer.ChildNodes)
                    {
                        if (node != null && node.Name == "div")
                        {
                            try
                            {
                                string strCounter = node.Attributes["id"].Value;
                                bool bDownloaded = bolService.CheckLinkDownloaded("photo.hoanvu.net", strCounter);
                                if (!bDownloaded && node.HasChildNodes)
                                {
                                    HtmlNode nodeDiv = node.SelectSingleNode("//div[@class = 'post-thumbnail']");
                                    HtmlNode nodea = nodeDiv.SelectSingleNode("//a[@class = 'img']");
                                    string strTitle = nodea.Attributes["title"].Value;
                                    string strPage = nodea.Attributes["href"].Value;

                                    //TODO: call function Get Images
                                    SaveImageOnePage(strPage, strCounter, "bikini-girl", strTitle);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.ToString());
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
            Console.WriteLine("Finish GetBikiniGirl ^_^");
        }

        public static void SaveImageOnePage(string strPage, string strCounter, string strCategory, string strTitle)
        {
            try
            {
                var bolService = new BOLService.BOLService();
                var lst = new List<ImgLink>();
                var web = new HtmlWeb();
                var doc = web.Load(strPage);
                //TODO: Check valid 
                var divContainer = doc.DocumentNode.SelectNodes("//a[@imageanchor = '1']");
                if (divContainer == null)
                {
                    var v = doc.DocumentNode.SelectSingleNode("//div[@class = 'post-content']");
                    if (v != null && v.HasChildNodes)
                    {
                        foreach (HtmlNode htmlNode in v.ChildNodes)
                        {
                            if (htmlNode.Name.Equals("div") && htmlNode.Attributes["style"].Value == "padding:10px")
                            {
                                var vTagP = htmlNode.SelectSingleNode("//p");
                                if (!vTagP.HasAttributes)
                                {
                                    divContainer = vTagP.SelectNodes("//img");
                                    foreach (HtmlNode node in divContainer)
                                    {
                                        try
                                        {
                                            string str = node.Attributes["src"].Value;
                                            if (str.Contains("photo.hoanvu.net/wp-content/uploads/thumbnail/")
                                                || str.Contains("photo.hoanvu.net/wp-content/themes/iphoto/images/logo.png"))
                                            {
                                                continue;
                                            }
                                            if (str.Contains("blogspot.com") || str.Contains("photo.hoanvu.net/wp-content/")
                                                || str.Contains("data.hoanvu.net/images"))
                                            {
                                                ImgLink obj = new ImgLink()
                                                {
                                                    CreateDate = DateTime.UtcNow,
                                                    Domain = "photo.hoanvu.net",
                                                    Counter = strCounter,
                                                    linkimg = str,
                                                    Category = strCategory,
                                                    GroupName = strTitle
                                                };
                                                if (!lst.Any(o => o.linkimg.Equals(obj.linkimg)))
                                                {
                                                    lst.Add(obj);
                                                    Console.WriteLine(str);
                                                }
                                            }
                                        }
                                        catch (Exception exception)
                                        {
                                            Console.WriteLine(exception.ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (HtmlNode node in divContainer)
                    {
                        try
                        {
                            ImgLink obj = new ImgLink()
                            {
                                CreateDate = DateTime.UtcNow,
                                Domain = "photo.hoanvu.net",
                                Counter = strCounter,
                                linkimg = node.Attributes["href"].Value,
                                Category = strCategory,
                                GroupName = strTitle
                            };
                            lst.Add(obj);
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.ToString());
                        }
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

        public static void TestImageOnePage(string strPage)
        {
            try
            {
                var bolService = new BOLService.BOLService();
                var lst = new List<ImgLink>();
                var web = new HtmlWeb();
                var doc = web.Load(strPage);
                //TODO: Check valid 
                var divContainer = doc.DocumentNode.SelectNodes("//a[@imageanchor = '1']");
                if (divContainer == null)
                {
                    var v = doc.DocumentNode.SelectSingleNode("//div[@class = 'post-content']");
                    if (v != null && v.HasChildNodes)
                    {
                        foreach (HtmlNode htmlNode in v.ChildNodes)
                        {
                            if (htmlNode.Name.Equals("div") && htmlNode.Attributes["style"].Value == "padding:10px" )
                            {
                                var vTagP = htmlNode.SelectSingleNode("//p");
                                if (!vTagP.HasAttributes)
                                {
                                    divContainer = vTagP.SelectNodes("//img");
                                    foreach (HtmlNode node in divContainer)
                                    {
                                        try
                                        {
                                            string str = node.Attributes["src"].Value;
                                            if (str.Contains("photo.hoanvu.net/wp-content/uploads/thumbnail/")
                                                || str.Contains("photo.hoanvu.net/wp-content/themes/iphoto/images/logo.png"))
                                            {
                                                continue;
                                            }
                                            if (str.Contains("blogspot.com") || str.Contains("photo.hoanvu.net/wp-content/")
                                                || str.Contains("data.hoanvu.net/images"))
                                            {
                                                ImgLink obj = new ImgLink()
                                                {
                                                    CreateDate = DateTime.UtcNow,
                                                    Domain = "photo.hoanvu.net",
                                                    //Counter = strCounter,
                                                    linkimg = str,
                                                    //Category = strCategory,
                                                    //GroupName = strTitle
                                                };
                                                lst.Add(obj);
                                                Console.WriteLine(str);
                                            }
                                        }
                                        catch (Exception exception)
                                        {
                                            Console.WriteLine(exception.ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (HtmlNode node in divContainer)
                    {
                        try
                        {
                            ImgLink obj = new ImgLink()
                            {
                                CreateDate = DateTime.UtcNow,
                                Domain = "photo.hoanvu.net",
                                //Counter = strCounter,
                                linkimg = node.Attributes["href"].Value,
                                //Category = strCategory,
                                //GroupName = strTitle
                            };
                            lst.Add(obj);
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.ToString());
                        }
                    }
                }

                bolService.SaveImg(lst);
                Console.WriteLine(strPage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
