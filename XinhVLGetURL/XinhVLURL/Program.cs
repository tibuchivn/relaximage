using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLService;
using HtmlAgilityPack;

namespace XinhVLURL
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: run daily
            Bikini();
            Nude();
            SexyGirl();
            TeenGirl();
            AuMy();
            ChauA();
            VietNam();
        }

        public static void TestImageOnePage(string strPage, string strCounter, string category, string strTitle)
        {
            try
            {
                var bolService = new BOLService.BOLService();
                if (bolService.CheckExistLinkByDomain(strCounter, "xinhvl.com")) return;

                var lst = new List<ImgLink>();
                var web = new HtmlWeb();
                var doc = web.Load(strPage);
                //TODO: Check valid 
                var divContainer = doc.DocumentNode.SelectSingleNode("//div[@class = 'img-wrap']");
                if (divContainer == null)
                {
                     return;
                }

                HtmlNodeCollection nodeImagesCollection = divContainer.SelectNodes("//img");
                foreach (var node in nodeImagesCollection)
                {
                    try
                    {
                        string strLink = node.Attributes["src"].Value;
                        if (strLink.Contains(string.Format("-{0}-",strCounter)))
                        {
                            var item = new ImgLink()
                            {
                                Category = category,
                                Counter = strCounter,
                                CreateDate = DateTime.Now,
                                Domain = "xinhvl.com",
                                GroupName = strTitle,
                                linkimg = strLink
                            };
                            lst.Add(item);
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

        public static void Bikini()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start = 1;
            int end = 3; //TODO: Current max 9;

            //track counter: id="post-5740"
            for (int i = start; i < end; i++)
            {
                try
                {
                    var doc = web.Load("http://xinhvl.com/channels/bikini-xinh/?page=" + i);
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'xinhVLListBit']");
                    if (divContainer == null) continue;

                    foreach (HtmlNode htmlNode in divContainer.ChildNodes)
                    {
                        if (htmlNode.Name.Equals("div"))
                        {
                            foreach (HtmlNode childNode in htmlNode.ChildNodes)
                            {
                                if (childNode.Name.Equals("a"))
                                {
                                    string strPage = childNode.Attributes["href"].Value;
                                    string strCounter = BuildCounter(strPage);
                                    string strTitle = childNode.NextSibling.NextSibling.InnerText;
                                    bool bDownloaded = bolService.CheckLinkDownloaded("xinhvl.com", strCounter);
                                    if (!bDownloaded)
                                    {
                                        //TODO: call function Get Images
                                        TestImageOnePage(strPage, strCounter, "bikini", strTitle);
                                    } 
                                    break;
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
            Console.WriteLine("Finish Bikini ^_^");
        }

        public static void Nude()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start = 1;
            int end = 3; //TODO max value 10;

            //track counter: id="post-5740"
            for (int i = start; i < end; i++)
            {
                try
                {
                    var doc = web.Load("http://xinhvl.com/channels/anh-nude?page=" + i);
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'xinhVLListBit']");
                    if (divContainer == null) continue;

                    foreach (HtmlNode htmlNode in divContainer.ChildNodes)
                    {
                        if (htmlNode.Name.Equals("div"))
                        {
                            foreach (HtmlNode childNode in htmlNode.ChildNodes)
                            {
                                if (childNode.Name.Equals("a"))
                                {
                                    string strPage = childNode.Attributes["href"].Value;
                                    string strCounter = BuildCounter(strPage);
                                    string strTitle = childNode.NextSibling.NextSibling.InnerText;
                                    bool bDownloaded = bolService.CheckLinkDownloaded("xinhvl.com", strCounter);
                                    if (!bDownloaded)
                                    {
                                        //TODO: call function Get Images
                                        TestImageOnePage(strPage, strCounter, "Nude", strTitle);
                                    }
                                    break;
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
            Console.WriteLine("Finish Bikini ^_^");
        }

        public static void SexyGirl()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start = 1;
            int end = 3; //TODO: max value 18; 

            //track counter: id="post-5740"
            for (int i = start; i < end; i++)
            {
                try
                {
                    var doc = web.Load("http://xinhvl.com/channels/sexy-girl/?page=" + i);
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'xinhVLListBit']");
                    if (divContainer == null) continue;

                    foreach (HtmlNode htmlNode in divContainer.ChildNodes)
                    {
                        if (htmlNode.Name.Equals("div"))
                        {
                            foreach (HtmlNode childNode in htmlNode.ChildNodes)
                            {
                                if (childNode.Name.Equals("a"))
                                {
                                    string strPage = childNode.Attributes["href"].Value;
                                    string strCounter = BuildCounter(strPage);
                                    string strTitle = childNode.NextSibling.NextSibling.InnerText;
                                    bool bDownloaded = bolService.CheckLinkDownloaded("xinhvl.com", strCounter);
                                    if (!bDownloaded)
                                    {
                                        //TODO: call function Get Images
                                        TestImageOnePage(strPage, strCounter, "sexy-girl", strTitle);
                                    }
                                    break;
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
            Console.WriteLine("Finish Bikini ^_^");
        }

        public static void TeenGirl()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start = 1;
            int end = 3; // TODO Max value 8

            //track counter: id="post-5740"
            for (int i = start; i < end; i++)
            {
                try
                {
                    var doc = web.Load("http://xinhvl.com/channels/teen-girl/?page=" + i);
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'xinhVLListBit']");
                    if (divContainer == null) continue;

                    foreach (HtmlNode htmlNode in divContainer.ChildNodes)
                    {
                        if (htmlNode.Name.Equals("div"))
                        {
                            foreach (HtmlNode childNode in htmlNode.ChildNodes)
                            {
                                if (childNode.Name.Equals("a"))
                                {
                                    string strPage = childNode.Attributes["href"].Value;
                                    string strCounter = BuildCounter(strPage);
                                    string strTitle = childNode.NextSibling.NextSibling.InnerText;
                                    bool bDownloaded = bolService.CheckLinkDownloaded("xinhvl.com", strCounter);
                                    if (!bDownloaded)
                                    {
                                        //TODO: call function Get Images
                                        TestImageOnePage(strPage, strCounter, "teen-girl", strTitle);
                                    }
                                    break;
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
            Console.WriteLine("Finish Bikini ^_^");
        }

        public static void AuMy()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start = 1;
            int end = 3; //TODO: max value 21

            //track counter: id="post-5740"
            for (int i = start; i < end; i++)
            {
                try
                {
                    var doc = web.Load("http://xinhvl.com/channels/au-my/?page=" + i);
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'xinhVLListBit']");
                    if (divContainer == null) continue;

                    foreach (HtmlNode htmlNode in divContainer.ChildNodes)
                    {
                        if (htmlNode.Name.Equals("div"))
                        {
                            foreach (HtmlNode childNode in htmlNode.ChildNodes)
                            {
                                if (childNode.Name.Equals("a"))
                                {
                                    string strPage = childNode.Attributes["href"].Value;
                                    string strCounter = BuildCounter(strPage);
                                    string strTitle = childNode.NextSibling.NextSibling.InnerText;
                                    bool bDownloaded = bolService.CheckLinkDownloaded("xinhvl.com", strCounter);
                                    if (!bDownloaded)
                                    {
                                        //TODO: call function Get Images
                                        TestImageOnePage(strPage, strCounter, "au-my", strTitle);
                                    }
                                    break;
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
            Console.WriteLine("Finish Bikini ^_^");
        }

        public static void ChauA()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start = 1;
            int end = 3; //TODO: max value 45

            //track counter: id="post-5740"
            for (int i = start; i < end; i++)
            {
                try
                {
                    var doc = web.Load("http://xinhvl.com/channels/chau-a/?page=" + i);
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'xinhVLListBit']");
                    if (divContainer == null) continue;

                    foreach (HtmlNode htmlNode in divContainer.ChildNodes)
                    {
                        if (htmlNode.Name.Equals("div"))
                        {
                            foreach (HtmlNode childNode in htmlNode.ChildNodes)
                            {
                                if (childNode.Name.Equals("a"))
                                {
                                    string strPage = childNode.Attributes["href"].Value;
                                    string strCounter = BuildCounter(strPage);
                                    string strTitle = childNode.NextSibling.NextSibling.InnerText;
                                    bool bDownloaded = bolService.CheckLinkDownloaded("xinhvl.com", strCounter);
                                    if (!bDownloaded)
                                    {
                                        //TODO: call function Get Images
                                        TestImageOnePage(strPage, strCounter, "chau-a", strTitle);
                                    }
                                    break;
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
            Console.WriteLine("Finish Bikini ^_^");
        }

        public static void VietNam()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start = 1;
            int end = 3; //TODO: max value 52

            //track counter: id="post-5740"
            for (int i = start; i < end; i++)
            {
                try
                {
                    var doc = web.Load("http://xinhvl.com/channels/viet-nam/?page=" + i);
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'xinhVLListBit']");
                    if (divContainer == null) continue;

                    foreach (HtmlNode htmlNode in divContainer.ChildNodes)
                    {
                        if (htmlNode.Name.Equals("div"))
                        {
                            foreach (HtmlNode childNode in htmlNode.ChildNodes)
                            {
                                if (childNode.Name.Equals("a"))
                                {
                                    string strPage = childNode.Attributes["href"].Value;
                                    string strCounter = BuildCounter(strPage);
                                    string strTitle = childNode.NextSibling.NextSibling.InnerText;
                                    bool bDownloaded = bolService.CheckLinkDownloaded("xinhvl.com", strCounter);
                                    if (!bDownloaded)
                                    {
                                        //TODO: call function Get Images
                                        TestImageOnePage(strPage, strCounter, "viet-nam", strTitle);
                                    }
                                    break;
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
            Console.WriteLine("Finish Bikini ^_^");
        }

        public static string BuildCounter(string str)
        {
            string tmp = str.Substring(0, str.LastIndexOf("/", System.StringComparison.Ordinal));
            return tmp.Substring(tmp.LastIndexOf("/", System.StringComparison.Ordinal) + 1);
        }
    }
}
