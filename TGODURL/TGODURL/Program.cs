using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLService;
using HtmlAgilityPack;

namespace TGODURL
{
    class Program
    {
        static void Main(string[] args)
        {
            InitTGOD();
        }

        public static void InitTGOD()
        {
            try
            {
                var bolService = new BOLService.BOLService();
                List<ImgLink> lst = new List<ImgLink>();
                var web = new HtmlWeb();
                int start = 0;
                int end = 6; //1

                for (int i = end; i >= start; i--)
                {
                    string strURL = string.Format("http://www.tgod.cn/travelpic.aspx?page={0}", i);
                    var doc = web.Load(strURL);
                    //TODO: Check valid 
                    var divContainer = doc.DocumentNode.SelectSingleNode("//ul[@id = 'ulnvshen']");
                    if (divContainer == null)
                    {
                        return;
                    }

                    foreach (var node in divContainer.ChildNodes)
                    {
                        if (node.Name.Equals("li") && node.HasChildNodes)
                        {
                            try
                            {
                                foreach (HtmlNode nodeLink in node.ChildNodes)
                                {
                                    if (nodeLink.Name.Equals("a"))
                                    {
                                        string strPage = string.Format("http://www.tgod.cn{0}", nodeLink.Attributes["href"].Value);
                                        ProcessDetailPage(strPage);

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
                    Console.WriteLine("Finish page ^_^: " + strURL);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void ProcessDetailPage(string strPage)
        {
            try
            {
                var bolService = new BOLService.BOLService();
                var lst = new List<BOLService.ImgLink>();
                var web = new HtmlWeb();
                var doc = web.Load(strPage);
                //TODO: Check valid 
                var divContainer = doc.DocumentNode.SelectSingleNode("//ul[@class = 'pic clearfix']");
                if (divContainer == null)
                {
                    return;
                }
                 
                foreach (HtmlNode childNode in divContainer.ChildNodes)
                {
                    if (childNode.HasChildNodes && childNode.Name.Equals("li"))
                    {
                        foreach (var node in childNode.ChildNodes)
                        {
                            if (node.Name.Equals("img") && node.Attributes["src"] != null)
                            {
                                try
                                {
                                    string strLink = node.Attributes["src"].Value;
                                    strLink = strLink.Replace("/upload_x/", "/upload_big/");
                                    var item = new BOLService.ImgLink()
                                    {
                                        Category = "Girl",
                                        Counter = strLink,
                                        CreateDate = DateTime.Now,
                                        Domain = "tgod.cn",
                                        GroupName = "TGOD",
                                        linkimg = strLink
                                    };
                                    if (!bolService.CheckExistLinkByDomain(strLink, "tgod.cn"))
                                    {
                                        lst.Add(item);
                                        Console.WriteLine(strLink);
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


        //public static void TestImageOnePage(string strPage, string strCounter, string category, string strTitle)
        //{
        //    try
        //    {
        //        var bolService = new BOLService.BOLService();
        //        if (bolService.CheckExistLinkByDomain(strCounter, "tgod.me"))
        //        {
        //            Console.WriteLine("Exist :" + strCounter);
        //            return;
        //        }

        //        var lst = new List<BOLService.ImgLink>();
        //        var web = new HtmlWeb();
        //        var doc = web.Load(strPage);
        //        //TODO: Check valid 
        //        var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'main']");
        //        if (divContainer == null)
        //        {
        //            return;
        //        }
        //        HtmlNodeCollection nodeImagesCollection = divContainer.SelectNodes("//span[@class = 'photoThum']");
        //        foreach (HtmlNode childNode in nodeImagesCollection)
        //        {
        //            if (childNode.HasChildNodes)
        //            {
        //                foreach (var node in childNode.ChildNodes)
        //                {
        //                    if (node.Name.Equals("a") && node.Attributes["title"] != null)
        //                    {
        //                        try
        //                        {
        //                            string strLink = node.Attributes["href"].Value;
        //                            var item = new BOLService.ImgLink()
        //                            {
        //                                Category = category,
        //                                Counter = strCounter,
        //                                CreateDate = DateTime.Now,
        //                                Domain = "tgod.me",
        //                                GroupName = strTitle,
        //                                linkimg = strLink
        //                            };
        //                            lst.Add(item);
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            //TODO: show error;
        //                            Console.WriteLine(ex.ToString());
        //                        }
        //                    }
        //                }

        //            }
        //        }
        //        if (lst.Count > 0)
        //        {
        //            bolService.SaveImgDepVD(lst);
        //            Console.WriteLine(strPage);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //}
    }
}
