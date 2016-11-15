using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLService;
using HtmlAgilityPack;

namespace XemLaSuongGetURL
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Deal rùi.
            SexyGirl();
        }

        public static void SexyGirl()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start = 1;
            int end = 3; //TODO: current max value 36

            //track counter: id="post-5740"
            for (int i = start; i < end; i++)
            {
                try
                {
                    var doc = web.Load("http://xemlasuong.org/anh/page/" + i);
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@class = 'items-container items-container-blog']");
                    if (divContainer == null) continue;

                    foreach (HtmlNode htmlNode in divContainer.ChildNodes)
                    {
                        if (htmlNode.Name.Equals("div") && htmlNode.Attributes["class"] != null )
                        {
                            string strClass = htmlNode.Attributes["class"].Value;
                            if (strClass.Equals("items-container-responsive"))
                            {
                                foreach (HtmlNode node in htmlNode.ChildNodes)
                                {
                                    if (node.Name.Equals("div"))
                                    {
                                        string strID = node.Attributes["id"].Value;
                                        foreach (HtmlNode childNode in node.ChildNodes)
                                        {
                                            if (childNode.Name.Equals("a"))
                                            {
                                                string strPage = childNode.Attributes["href"].Value;
                                                string strCounter = strID;
                                                string strTitle = BuildCounter(strPage);
                                                bool bDownloaded = bolService.CheckLinkDownloaded("xemlasuong.org", strCounter);
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
                                break;
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
            Console.WriteLine("Finish sexy-girl ^_^");
        }

        public static void TestImageOnePage(string strPage, string strCounter, string category, string strTitle)
        {
            try
            {
                var bolService = new BOLService.BOLService();
                if (bolService.CheckExistLinkByDomain(strCounter, "xemlasuong.org")) return;

                var lst = new List<ImgLink>();
                var web = new HtmlWeb();
                var doc = web.Load(strPage);
                //TODO: Check valid 
                var divContainer = doc.DocumentNode.SelectSingleNode("//div[@class = 'blog-single-para']");
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
                        string strClass = node.Attributes["class"] != null
                            ? node.Attributes["class"].Value
                            : string.Empty;
                        if (strClass.Contains("size-full"))
                        {
                            var item = new ImgLink()
                            {
                                Category = category,
                                Counter = strCounter,
                                CreateDate = DateTime.Now,
                                Domain = "xemlasuong.org",
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

        public static string BuildCounter(string str)
        {
            string tmp = str.Replace("http://xemlasuong.org/","");
            return tmp.Replace("/", "").Replace('-', ' ');
        }
    }
}
