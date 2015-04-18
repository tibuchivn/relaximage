using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BOLService;
using HtmlAgilityPack;

namespace TrucTiepSoURL
{
    class Program
    {
        static void Main(string[] args)
        {
            HotGirl();
        }

        public static void TestImageOnePage(string strPage, string  strCounter, string category, string strTitle)
        {
            try
            {
                var bolService = new BOLService.BOLService();
                if (bolService.CheckExistLinkByDomain(strCounter, "tructiepso.com")) return;

                var lst = new List<ImgLink>();
                var web = new HtmlWeb();
                var doc = web.Load(strPage);
                //TODO: Check valid 
                var divContainer = doc.DocumentNode.SelectSingleNode("//div[@class = 'entry-content rich-content']");
                if (divContainer == null)
                {
                    divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'content_document']");
                    if(divContainer == null) 
                        return;
                }

                HtmlNodeCollection nodeImagesCollection = divContainer.SelectNodes("//img");
                foreach (var node in nodeImagesCollection)
                {
                    try
                    {
                        string strLink = node.Attributes["src"].Value;
                        if (!strLink.Contains("tructiepso.com/wp-content/uploads")
                            && !strLink.Contains("gamer.gif"))
                        {
                            var item = new ImgLink()
                            {
                                Category = category,
                                Counter = strCounter,
                                CreateDate = DateTime.Now,
                                Domain = "tructiepso.com",
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

        public static void HotGirl()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int start = 1;
            int end = 2; //TODO: max value 5;

            //track counter: id="post-5740"
            for (int i = start; i < end; i++)
            {
                try
                {
                    var doc = web.Load("http://tructiepso.com/category/hot-girl/page/" + i);
                    //TODO: Check valid  URL

                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@class = 'nag cf']");
                    if(divContainer == null) continue;

                    HtmlNodeCollection linkPage = divContainer.SelectNodes("//a[@class = 'clip-link']");
                    if(linkPage == null) continue;
                    foreach (HtmlNode node in linkPage)
                    {
                        try
                        {
                            string strCounter = node.Attributes["data-id"].Value;
                            bool bDownloaded = bolService.CheckLinkDownloaded("tructiepso.com", strCounter);
                            if (!bDownloaded )
                            {
                                string strTitle = node.Attributes["title"].Value;
                                string strPage = node.Attributes["href"].Value;

                                //TODO: call function Get Images
                                TestImageOnePage(strPage, strCounter, "Hot-Girl", strTitle);
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
            Console.WriteLine("Finish GetBikiniGirl ^_^");
        }

        public static void CheckValidImageURL()
        {
            var bolService = new BOLService.BOLService();
            int totalRecord = bolService.TotalImages();
            int iCounter = totalRecord/1000;
            for (int i = 0; i <= iCounter; i++)
            {
                Console.WriteLine("Group: " + i);
                var lst = bolService.GetImgLinks(i, 1000);
                foreach (ImgLink link in lst)
                {
                    Console.WriteLine(link.linkimg);
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(link.linkimg);
                    request.Method = "HEAD";
                    try
                    {
                        request.GetResponse();
                        continue;
                    }
                    catch
                    {
                        bolService.UpdateBadURL(link.ID);
                    }
                }
            }
        }
    }
}
