using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLService;
using HtmlAgilityPack;

namespace XinhHayLaURL
{
    class Program
    {
        static void Main(string[] args)
        {
            //TheFirstRun();
            DailyRun();
        }
        public static void TestImageOnePage(string strPage, string strCounter, string category, string strTitle)
        {
            try
            {
                var bolService = new BOLService.BOLService();
                var lst = new List<ImgLink>();
                var web = new HtmlWeb();
                var doc = web.Load(strPage);
                //TODO: Check valid 
                var divContainer = doc.DocumentNode.SelectSingleNode("//div[@class = 'photo-container']");
                if (divContainer != null)
                {
                    //var imgNodes = divContainer.SelectNodes("//img[@onerror = 'imgerror(this)']");
                    foreach (HtmlNode node in divContainer.ChildNodes)
                    {
                        try
                        {
                            if (node.Name.Equals("a"))
                            {
                                foreach (HtmlNode imgNode in node.ChildNodes)
                                {
                                    if (imgNode.Name.Equals("img"))
                                    {
                                        string strLink = imgNode.Attributes["src"].Value;
                                        if (!strLink.Contains("Content/themes/noimg_big.jpg")
                                            && !strLink.Contains("http://api.xinhvl.tekreds.com"))
                                        {
                                            ImgLink obj = new ImgLink()
                                            {
                                                CreateDate = DateTime.UtcNow,
                                                Domain = "xinh.hay.la",
                                                Counter = strCounter,
                                                linkimg = strLink,
                                                Category = category,
                                                GroupName = strTitle
                                            };
                                            lst.Add(obj);
                                            break;
                                        }
                                    }
                                }
                            }
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

        public static void XinhHayLaDaily(string catagory, string strURL)
        {
            try
            {
                var bolService = new BOLService.BOLService();
                var lst = new List<ImgLink>();
                var web = new HtmlWeb();
                var doc = web.Load(strURL);
                //TODO: Check valid  URL

                var divContainer = doc.DocumentNode.SelectSingleNode("//div[@class = 'items post']");
                if (divContainer == null) return;

                foreach (HtmlNode node in divContainer.ChildNodes)
                {
                    if (node != null && node.Name == "div")
                    {
                        try
                        {
                            foreach (HtmlNode childNode in node.ChildNodes)
                            {
                                if (childNode.Name.Equals("a"))
                                {
                                    HtmlNode nodeDivImage = childNode.SelectSingleNode("//div[@class = 'contest-item-image']");
                                    HtmlNode nodeImage = nodeDivImage.SelectSingleNode("//img");
                                    string strImg = nodeImage.Attributes["src"].Value;
                                    if (strImg.Contains("Content/themes/noimg_big.jpg"))
                                        break;

                                    string strPage = string.Format("http://xinh.hay.la{0}", childNode.Attributes["href"].Value);
                                    string strCounter = strPage.Substring(strPage.LastIndexOf('/') + 1);

                                    HtmlNode nodeTitle = childNode.SelectSingleNode("//div[@class = 'ext-info title']");
                                    string strTitle = nodeTitle != null ? nodeTitle.InnerText : string.Empty;

                                    //TODO: Check exist Link
                                    if (!bolService.CheckExistLinkByDomain(strCounter, "xinh.hay.la"))
                                    {
                                        TestImageOnePage(strPage, strCounter, catagory, strTitle);
                                    }

                                    break;
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

            Console.WriteLine("Finish " + catagory + " ^_^");
        }

        public static void XinhHayLaLoop(string category, string strPage)
        {
            try
            {
                var bolService = new BOLService.BOLService();
                var lst = new List<ImgLink>();
                var web = new HtmlWeb();
                var doc = web.Load(strPage);
                //TODO: Check valid  URL

                string strCounter = strPage.Substring(strPage.LastIndexOf('/') + 1);
                HtmlNode nodeTitle = doc.DocumentNode.SelectSingleNode("//h1[@class = 'title']");
                string strTitle = nodeTitle != null ? nodeTitle.InnerText : string.Empty;
                //TODO: Check exist Link
                bool existCouter = bolService.CheckExistLinkByDomain(strCounter, "xinh.hay.la");
                if (!existCouter)
                {
                    TestImageOnePage(strPage, strCounter, category, strTitle);
                }

                var divContainer = doc.DocumentNode.SelectSingleNode("//div[@class = 'navButtons']");
                if (divContainer == null) return;

                foreach (HtmlNode node in divContainer.ChildNodes)
                {
                    try
                    {
                        if (node.Name == "a" && node.Attributes["class"].Value == "prev")
                        {
                            string strLoopPage = string.Format("http://xinh.hay.la{0}", node.Attributes["href"].Value);
                            XinhHayLaLoop(category, strLoopPage);
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
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


        public static void TheFirstRun()
        {
            XinhHayLaLoop("Cosplay", "http://xinh.hay.la/hot-girl/beautiful-girl-photos/3015");

            XinhHayLaLoop("diu-dang", "http://xinh.hay.la/hot-girl/hot-girl-xinh-nhu-hoa-voi-vay-do-tai-xinh-hay-la/3030");

            XinhHayLaLoop("18", "http://xinh.hay.la/hot-girl/hai-hotgirl-duoc-dan-mang-bau-chon-co-vong-nguc-dep-nhat/2917");

            XinhHayLaLoop("sexy", "http://xinh.hay.la/hot-girl/hinh-gai-xinh-hinh-gai-xinh-hinh-gai-xinh/3044");

            XinhHayLaLoop("xitin", "http://xinh.hay.la/hot-girl/hinh-hot-girl-magnae-pika-hot-girl-thu-ha/3038");

            XinhHayLaLoop("Nghe-Thuat", "http://xinh.hay.la/hot-girl/tuyet-dep-bo-anh-nude-cua-duong-quoc-dinh/3055");

            XinhHayLaLoop("bikini", "http://xinh.hay.la/hot-girl/beautiful-girl-photos/3015");

            XinhHayLaLoop("nguoi-mau", "http://xinh.hay.la/hot-girl/hot-girl-tam-tit-cute-girl-gai-cute-xinh/3033");

            XinhHayLaLoop("us-uk", "http://xinh.hay.la/hot-girl/xinh-nhu-bella-thorne/3263");

            XinhHayLaLoop("asia", "http://xinh.hay.la/hot-girl/duyen-dang-x/3262");

            XinhHayLaLoop("Hot-girl", "http://xinh.hay.la/hot-girl/sexy-voi-vay-da-hoi/3206");
        }

        public static void DailyRun()
        {
            XinhHayLaDaily("Cosplay", "http://xinh.hay.la/girl-xinh/cosplay/90");

            XinhHayLaDaily("diu-dang", "http://xinh.hay.la/girl-xinh/diu-dang/71");

            XinhHayLaDaily("18", "http://xinh.hay.la/girl-xinh/18/81");

            XinhHayLaDaily("sexy", "http://xinh.hay.la/girl-xinh/sexy/73");

            XinhHayLaDaily("xitin", "http://xinh.hay.la/girl-xinh/xi-tin/69");

            XinhHayLaDaily("Nghe-Thuat", "http://xinh.hay.la/girl-xinh/nghe-thuat/76");

            XinhHayLaDaily("bikini", "http://xinh.hay.la/girl-xinh/bikini/75");

            XinhHayLaDaily("Nguoi-mau", "http://xinh.hay.la/girl-xinh/nguoi-mau/66");

            XinhHayLaDaily("us-uk", "http://xinh.hay.la/girl-xinh/us-uk/84");

            XinhHayLaDaily("asia", "http://xinh.hay.la/girl-xinh/asia/83");

            XinhHayLaDaily("Hot-girl", "http://xinh.hay.la/girl-xinh/hot-girl/82");
        }
    }
}
