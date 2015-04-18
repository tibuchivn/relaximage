using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLService;
using HtmlAgilityPack;

namespace XemAnhGetURL
{
    class Program
    {
        static void Main(string[] args)
        {
            Daily_AnhGirlXinh();

            //FirstRun_AnhGirlXinh();

            //TestImageOnePage("http://www.xemanh.net/anh-girl-xinh-de-thuong-phan6,","","","");
        }

        public static void TestImageOnePage(string strPage, string strCounter, string category, string strTitle)
        {
            try
            {
                var bolService = new BOLService.BOLService();
                if (bolService.CheckExistLinkByDomain(strCounter, "xemanh.net")) return;

                var lst = new List<ImgLink>();
                var web = new HtmlWeb();
                var doc = web.Load(strPage);
                //TODO: Check valid 
                var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'main']");
                if (divContainer == null)
                {
                    return;
                }

                HtmlNode articleNode = divContainer.SelectSingleNode("//article");
                HtmlNode sectionNode = articleNode.SelectSingleNode("//section");
                foreach (var node in sectionNode.ChildNodes)
                {
                    try
                    {
                        if (node.Name.Equals("p") && node.HasAttributes && node.HasChildNodes)
                        {
                            HtmlNode nodeA = node.FirstChild;
                            if (node.ChildNodes.Count > 1)
                            {
                                foreach (HtmlNode f1Node in node.ChildNodes)
                                {
                                    if (f1Node.Name.Equals("a") || f1Node.Name.Equals("img"))
                                    {
                                        nodeA = f1Node;
                                        break;
                                    }
                                }
                            }

                            HtmlNode nodeImg = nodeA;
                            if (nodeA.Name.Equals("a") && nodeA.HasChildNodes)
                            {
                                foreach (HtmlNode fNode in nodeA.ChildNodes)
                                {
                                    if (fNode.Name.Equals("img"))
                                    {
                                        nodeImg = fNode;
                                        break;
                                    }
                                }
                            }
                            if (nodeImg != null && nodeImg.Name.Equals("img") && nodeImg.Attributes["src"] != null)
                            {
                                string strLink = nodeImg.Attributes["src"].Value;
                                var item = new ImgLink()
                                {
                                    Category = category,
                                    Counter = strCounter,
                                    CreateDate = DateTime.Now,
                                    Domain = "xemanh.net",
                                    GroupName = strTitle,
                                    linkimg = strLink
                                };
                                lst.Add(item);
                            }
                        }
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

        public static void FirstRun_AnhGirlXinh()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start =22;
            int end = 0; //TODO: Current max 9;

            //track counter: id="post-5740"
            for (int i = start; i > end; i--)
            {
                try
                {
                    string strURL = "http://www.xemanh.net/category/anh-girl-xinh/page/" + i;
                    Console.WriteLine(i + " : " + strURL);

                    var doc = web.Load(strURL);
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'main']");
                    if (divContainer == null) continue;

                    foreach (HtmlNode htmlNode in divContainer.ChildNodes)
                    {
                        try
                        {
                            if (htmlNode.Name.Equals("article"))
                            {
                                foreach (HtmlNode childNode in htmlNode.ChildNodes)
                                {
                                     
                                    if (childNode.Name.Equals("a") && childNode.Attributes["class"] != null && childNode.Attributes["class"].Value == "home-thumb")
                                    {
                                        string strPage = childNode.Attributes["href"].Value;
                                        string strCounter = htmlNode.Id;
                                        string strTitle = childNode.Attributes["title"].Value;
                                        bool bDownloaded = bolService.CheckLinkDownloaded("xemanh.net", strCounter);
                                        if (!bDownloaded)
                                        {
                                            //TODO: call function Get Images
                                            TestImageOnePage(strPage, strCounter, "anh-girl-xinh", strTitle);
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                        catch (Exception exceptionArticle)
                        {
                            Console.WriteLine(exceptionArticle.ToString());
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
            Console.WriteLine("Finish AnhGirlXinh ^_^");
        }

        public static void Daily_AnhGirlXinh()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start = 1;
            int end = 5; //TODO: Current max 9;

            //track counter: id="post-5740"
            for (int i = start; i < end; i++)
            {
                try
                {
                    string strURL = "http://www.xemanh.net/category/anh-girl-xinh/page/" + i;
                    Console.WriteLine(i + " : " + strURL);

                    var doc = web.Load(strURL);
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'main']");
                    if (divContainer == null) continue;

                    foreach (HtmlNode htmlNode in divContainer.ChildNodes)
                    {
                        try
                        {
                            if (htmlNode.Name.Equals("article"))
                            {
                                foreach (HtmlNode childNode in htmlNode.ChildNodes)
                                {

                                    if (childNode.Name.Equals("a") && childNode.Attributes["class"] != null && childNode.Attributes["class"].Value == "home-thumb")
                                    {
                                        string strPage = childNode.Attributes["href"].Value;
                                        string strCounter = htmlNode.Id;
                                        string strTitle = childNode.Attributes["title"].Value;
                                        bool bDownloaded = bolService.CheckLinkDownloaded("xemanh.net", strCounter);
                                        if (!bDownloaded)
                                        {
                                            //TODO: call function Get Images
                                            TestImageOnePage(strPage, strCounter, "anh-girl-xinh", strTitle);
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                        catch (Exception exceptionArticle)
                        {
                            Console.WriteLine(exceptionArticle.ToString());
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
            Console.WriteLine("Finish AnhGirlXinh ^_^");
        }
    }
}
