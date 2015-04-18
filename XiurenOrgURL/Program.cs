using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLService;
using HtmlAgilityPack;

namespace XiurenOrgURL
{
    public class Program
    {
        static void Main(string[] args)
        {
            XuiRenSexyGirl();

            //int[] monthsNotRun = { 7, 8, 9, 10 };
            //int currentMonth = DateTime.UtcNow.Month;
            //if (monthsNotRun.Contains(currentMonth))
            //{
            //    System.Console.WriteLine("Service not run on list months [7,8,9,10]");
            //    return;
            //}
            //System.Console.WriteLine("running ...");
        }

        public static void XuiRenSexyGirl()
        {
            try
            {
                var bolService = new BOLService.BOLService();
                List<ImgLink> lst = new List<ImgLink>();
                var web = new HtmlWeb();
                int start = 1;
                int end = 5; //TODO: current max value 27

                for (int i = start; i <= end; i++)
                {
                    string strURL = string.Format("http://www.xiuren.org/page-{0}.html", i);
                    var doc = web.Load(strURL);
                    //TODO: Check valid 
                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'main']");
                    if (divContainer == null)
                    {
                        return;
                    }

                    foreach (HtmlNode childNode in divContainer.ChildNodes)
                    {
                        if (childNode.Name.Equals("div") && childNode.Attributes["class"] != null &&
                            childNode.Attributes["class"].Value.Equals("loop"))
                        {
                            //TODO: have 4 column
                            //HtmlNodeCollection nodeImagesCollection = childNode.SelectNodes("//div[@class = 'content']");

                            foreach (var node in childNode.ChildNodes)
                            {
                                if (node.Name.Equals("div") && node.HasChildNodes)
                                {
                                    try
                                    {
                                        foreach (HtmlNode nodeLink in node.ChildNodes)
                                        {
                                            if (nodeLink.Name.Equals("a"))
                                            {
                                                string strTitle = nodeLink.Attributes["title"].Value;
                                                string strPage = nodeLink.Attributes["href"].Value;
                                                string strCategory = "Sexy Girl";
                                                string strCounter = strPage;
                                                TestImageOnePage(strPage, strCounter, strCategory, strTitle);
                                                break;
                                            }
                                        }
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
                if (bolService.CheckExistLinkByDomain(strCounter, "xiuren.org"))
                {
                    Console.WriteLine("Exist :" + strCounter);
                    return;
                }

                var lst = new List<BOLService.ImgLink>();
                var web = new HtmlWeb();
                var doc = web.Load(strPage);
                //TODO: Check valid 
                var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'main']");
                if (divContainer == null)
                {
                    return;
                }
                HtmlNodeCollection nodeImagesCollection = divContainer.SelectNodes("//span[@class = 'photoThum']");
                foreach (HtmlNode childNode in nodeImagesCollection)
                {
                    if (childNode.HasChildNodes)
                    {
                        foreach (var node in childNode.ChildNodes)
                        {
                            if (node.Name.Equals("a") && node.Attributes["title"] != null)
                            {
                                try
                                {
                                    string strLink = node.Attributes["href"].Value;
                                    var item = new BOLService.ImgLink()
                                    {
                                        Category = category,
                                        Counter = strCounter,
                                        CreateDate = DateTime.Now,
                                        Domain = "xiuren.org",
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        ///////////////////////////////////////////////////
    }
}
