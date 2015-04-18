using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BOLService;
using HtmlAgilityPack;

namespace UgirlsComURL
{
    public class Program
    {
        static void Main(string[] args)
        {
            UgirlsSexyGirl();
        }

        public static void UgirlsSexyGirl()
        {
            try
            {
                var bolService = new BOLService.BOLService();
                List<ImgLink> lst = new List<ImgLink>();
                var web = new HtmlWeb();
                int start = 75;
                int end = 100; //TODO: current max value 75

                for (int i = start; i <= end; i++)
                {
                    string strURL = string.Format("http://www.ugirls.com/Content/List/Magazine-{0}.html", i);
                    try
                    {
                        string strTitle = string.Format("Magazine-" + i);
                        string strPage = strURL;
                        string strCategory = "Sexy Girl";
                        string strCounter = i.ToString();
                        TestImageOnePage(strPage, strCounter, strCategory, strTitle);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    
                    Console.WriteLine("Finish page ^_^: " + strURL);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void TestImageOnePage(string strPage, string strCounter, string category, string strTitle)
        {
            try
            {
                var bolService = new BOLService.BOLService();
                if (bolService.CheckExistLinkByDomain(strCounter, "ugirls.com"))
                {
                    Console.WriteLine("Exist :" + strCounter);
                    return;
                }

                var lst = new List<BOLService.ImgLink>();
                var web = new HtmlWeb();
                var doc = web.Load(strPage);
                //TODO: Check valid 
                var divContainer = doc.DocumentNode.SelectSingleNode("//div[@class = 'main auto']");
                if (divContainer == null)
                {
                    return;
                }
                HtmlNodeCollection nodeImagesCollection = divContainer.SelectNodes("//div[@class = 'img']");
                if (nodeImagesCollection.Count > 0)
                {
                    foreach (HtmlNode node in nodeImagesCollection.First().ChildNodes)
                    {
                        if (node.Name.Equals("ul") && node.Attributes["id"] != null &&
                            node.Attributes["id"].Value.Equals("myGallery"))
                        {
                           
                            foreach (HtmlNode childNode in node.ChildNodes)
                            {
                                if (childNode.HasChildNodes && childNode.Name.Equals("li"))
                                {
                                    foreach (var nodeThumb in childNode.ChildNodes)
                                    {
                                        if (nodeThumb.Name.Equals("img") && nodeThumb.Attributes["src"] != null)
                                        {
                                            try
                                            {
                                                string strLink = nodeThumb.Attributes["src"].Value;
                                                strLink = strLink.Replace("_magazine_web_m", "");
                                                var item = new BOLService.ImgLink()
                                                {
                                                    Category = category,
                                                    Counter = strCounter,
                                                    CreateDate = DateTime.Now,
                                                    Domain = "ugirls.com",
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
                                    }
                                    
                                }
                            }
                            if (lst.Count > 0)
                            {
                                bolService.SaveImgDepVD(lst);
                                Console.WriteLine(strPage);
                            }
                            break;
                        }
                    }
                }
                 
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        ///////////////////////////////////////////////////
    }
}
