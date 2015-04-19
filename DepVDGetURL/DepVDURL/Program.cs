using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace DepVDURL
{
    public class Program
    {

        static void Main()
        {
            NewSexyGirl();
            HomeSexyGirl();
            US_UK();
            Asia();
            VietNam();

            //RunAsync().Wait(); //TODO: expire
        }

        static async Task RunAsync()
        {
            var _context = new DepVDContextDataContext();
            using (var client = new HttpClient())
            {
                List<string> lstToday = new List<string>();
                // TODO - Send HTTP requests
                // New code:
                client.BaseAddress = new Uri("http://open-api.depvd.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                try
                {
                    HttpResponseMessage response = await client.GetAsync("VerifyKey?key=I264N-Z3EG4-6YOBG-FQV8S-EXUR7");
                    if (response.IsSuccessStatusCode)
                    {
                        VerifyKey key = await response.Content.ReadAsAsync<VerifyKey>();
                        //Console.WriteLine("{0}\t{1}\t{2}", key.code, key.content, key.message);
                        if (key.code.Equals("200"))
                        {
                            #region GetVnTopics
                            //TODO: 3 GetVnTopics
                            for (int j = 1; j <= 20; j++) // should 50 ^_^.
                            {
                                HttpResponseMessage response3 = await client.GetAsync("Topic/GetVnTopics?page=" + j);
                                if (response3.IsSuccessStatusCode)
                                {
                                    Product result = await response3.Content.ReadAsAsync<Product>();
                                    if (result.content.topics.Count > 0)
                                    {
                                        foreach (topic t in result.content.topics)
                                        {
                                            if (t.Photos.Count > 0)
                                            {
                                                foreach (Photo p in t.Photos)
                                                {
                                                    if (!_context.ImgLinks.Any(o => o.linkimg == p.absNormal))
                                                    {
                                                        var obj = new ImgLink()
                                                        {
                                                            linkimg = p.absNormal,
                                                            CreateDate = DateTime.UtcNow,
                                                            Domain = "depvd.com",
                                                            Category = "Viet-Nam-sexy-girl",
                                                            Counter = BuildCounter(t.absViewUrl),
                                                            GroupName = t.title
                                                        };
                                                        _context.ImgLinks.InsertOnSubmit(obj);
                                                        _context.SubmitChanges();
                                                        Console.WriteLine("GetVnTopics " + p.absNormal);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("GetVnTopics End: " + j);
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("GetVnTopics Response content: " + response3.Content);
                                }
                            }
                            #endregion

                            #region GetAsiaTopics
                            //TODO: 4 GetAsiaTopics
                            for (int j = 1; j <= 20; j++) // should 50 ^_^.
                            {
                                HttpResponseMessage response4 = await client.GetAsync("Topic/GetAsiaTopics?page=" + j);

                                if (response4.IsSuccessStatusCode)
                                {
                                    Product result = await response4.Content.ReadAsAsync<Product>();
                                    if (result.content.topics.Count > 0)
                                    {
                                        foreach (topic t in result.content.topics)
                                        {
                                            if (t.Photos.Count > 0)
                                            {
                                                foreach (Photo p in t.Photos)
                                                {
                                                    if (!_context.ImgLinks.Any(o => o.linkimg == p.absNormal))
                                                    {
                                                        var obj = new ImgLink()
                                                        {
                                                            linkimg = p.absNormal,
                                                            CreateDate = DateTime.UtcNow,
                                                            Domain = "depvd.com",
                                                            Category = "asia-sexy-girl",
                                                            Counter = BuildCounter(t.absViewUrl),
                                                            GroupName = t.title
                                                        };
                                                        _context.ImgLinks.InsertOnSubmit(obj);
                                                        _context.SubmitChanges();
                                                        Console.WriteLine("GetAsiaTopics " + p.absNormal);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("GetAsiaTopics End: " + j);
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("GetAsiaTopics Response content: " + response4.Content);
                                }
                            }
                            #endregion

                            #region GetUsUkTopics
                            //TODO: 5 GetUsUkTopics
                            for (int j = 1; j <= 20; j++) // should 50 ^_^.
                            {
                                HttpResponseMessage response5 = await client.GetAsync("Topic/GetUsUkTopics?page=" + j);
                                if (response5.IsSuccessStatusCode)
                                {
                                    Product result = await response5.Content.ReadAsAsync<Product>();
                                    if (result.content.topics.Count > 0)
                                    {
                                        foreach (topic t in result.content.topics)
                                        {
                                            if (t.Photos.Count > 0)
                                            {
                                                foreach (Photo p in t.Photos)
                                                {
                                                    if (!_context.ImgLinks.Any(o => o.linkimg == p.absNormal))
                                                    {
                                                        var obj = new ImgLink()
                                                        {
                                                            linkimg = p.absNormal,
                                                            CreateDate = DateTime.UtcNow,
                                                            Domain = "depvd.com",
                                                            Category = "US-UK-sexy-girl",
                                                            Counter = BuildCounter(t.absViewUrl),
                                                            GroupName = t.title
                                                        };
                                                        _context.ImgLinks.InsertOnSubmit(obj);
                                                        _context.SubmitChanges();
                                                        Console.WriteLine("GetUsUkTopics " + p.absNormal);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("GetUsUkTopics End: " + j);
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("GetUsUkTopics Response content: " + response5.Content);
                                }
                            }
                            #endregion

                            #region GetNewTopics
                            //TODO: 1 GetNewTopics
                            for (int j = 1; j <= 20; j++) // should 50 ^_^.
                            {
                                HttpResponseMessage response1 = await client.GetAsync("Topic/GetNewTopics?page=" + j);
                                if (response1.IsSuccessStatusCode)
                                {
                                    Product result = await response1.Content.ReadAsAsync<Product>();
                                    if (result.content.topics.Count > 0)
                                    {
                                        foreach (topic t in result.content.topics)
                                        {
                                            if (t.Photos.Count > 0)
                                            {
                                                foreach (Photo p in t.Photos)
                                                {
                                                    if (!_context.ImgLinks.Any(o => o.linkimg == p.absNormal))
                                                    {
                                                        var obj = new ImgLink()
                                                        {
                                                            linkimg = p.absNormal,
                                                            CreateDate = DateTime.UtcNow,
                                                            Domain = "depvd.com",
                                                            Category = "sexy-girl",
                                                            Counter = BuildCounter(t.absViewUrl),
                                                            GroupName = t.title
                                                        };
                                                        _context.ImgLinks.InsertOnSubmit(obj);
                                                        _context.SubmitChanges();
                                                        Console.WriteLine("GetNewTopics :" + p.absNormal);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("GetNewTopics End: " + j);
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("GetNewTopics Response content: " + response1.Content);
                                }
                            }
                            #endregion

                            #region GetHomeTopics
                            //TODO: 2 GetNewTopics
                            for (int j = 1; j <= 20; j++) // should 50 ^_^.
                            {
                                HttpResponseMessage response2 = await client.GetAsync("Topic/GetHomeTopics?page=" + j);
                                if (response2.IsSuccessStatusCode)
                                {
                                    Product result = await response2.Content.ReadAsAsync<Product>();
                                    if (result.content.topics.Count > 0)
                                    {
                                        foreach (topic t in result.content.topics)
                                        {
                                            if (t.Photos.Count > 0)
                                            {
                                                foreach (Photo p in t.Photos)
                                                {
                                                    if (!_context.ImgLinks.Any(o => o.linkimg == p.absNormal))
                                                    {
                                                        var obj = new ImgLink()
                                                        {
                                                            linkimg = p.absNormal,
                                                            CreateDate = DateTime.UtcNow,
                                                            Domain = "depvd.com",
                                                            Category = "sexy-girl",
                                                            Counter = BuildCounter(t.absViewUrl),
                                                            GroupName = t.title
                                                        };
                                                        _context.ImgLinks.InsertOnSubmit(obj);
                                                        _context.SubmitChanges();
                                                        Console.WriteLine("GetHomeTopics " + p.absNormal);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("GetHomeTopics End: " + j);
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("GetHomeTopics Response content: " + response2.Content);
                                }
                            }
                            #endregion

                            #region GetTopWeekTopics
                            ////TODO: 1 GetNewTopics
                            //for (int j = 1; j <= 1; j++) // should 50 ^_^.
                            //{
                            //    HttpResponseMessage response6 = await client.GetAsync("Topic/GetTopWeekTopics");
                            //    if (response6.IsSuccessStatusCode)
                            //    {
                            //        Product result = await response6.Content.ReadAsAsync<Product>();
                            //        if (result.content.topics.Count > 0)
                            //        {
                            //            foreach (topic t in result.content.topics)
                            //            {
                            //                if (t.Photos.Count > 0)
                            //                {
                            //                    foreach (Photo p in t.Photos)
                            //                    {
                            //                        if (!_context.ImgLinks.Any(o => o.linkimg == p.absNormal))
                            //                        {
                            //                            var obj = new ImgLink()
                            //                            {
                            //                                linkimg = p.absNormal,
                            //                                CreateDate = DateTime.UtcNow,
                            //                                Domain = "depvd.com",
                            //                                Category = "sexy-girl",
                            //                                Counter = BuildCounter(t.absViewUrl),
                            //                                GroupName = t.title
                            //                            };
                            //                            _context.ImgLinks.InsertOnSubmit(obj);
                            //                            _context.SubmitChanges();
                            //                            Console.WriteLine("GetTopWeekTopics " + p.absNormal);
                            //                        }
                            //                    }
                            //                }
                            //            }
                            //        }
                            //        else
                            //        {
                            //            Console.WriteLine("GetTopWeekTopics End: " + j);
                            //            break;
                            //        }
                            //    }
                            //    else
                            //    {
                            //        Console.WriteLine("GetTopWeekTopics Response content: " + response6.Content);
                            //    }
                            //}
                            #endregion
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.Content);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                    throw exception;
                }
            }
        }

        private static string BuildCounter(string str)
        {
            if( string.IsNullOrEmpty(str))
                return string.Empty;
            return str.Substring(str.LastIndexOf('/') + 1);
        }

        ////////////////////////////////////////////////////////
        //read from page 
 

        public static void US_UK( )
        {
            try
            {
                var bolService = new BOLService.BOLService();
                List<ImgLink> lst = new List<ImgLink>();
                var web = new HtmlWeb();
                int start = 1;
                int end = 37; //TODO: current max value 37

                for (int i = start; i < end; i++)
                {
                    string strURL = "http://www.depvd.com/us-uk/p" + i;
                    var doc = web.Load(strURL);
                    //TODO: Check valid 
                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'vd-topics']");
                    if (divContainer == null)
                    {
                        return;
                    }

                    foreach (HtmlNode childNode in divContainer.ChildNodes)
                    {
                        if (childNode.Name.Equals("div") && childNode.Attributes["class"] != null &&
                            childNode.Attributes["class"].Value.Equals("vd-topic vd-xitin"))
                        {
                            //TODO: have 4 column
                            HtmlNodeCollection nodeImagesCollection = divContainer.SelectNodes("//div[@class = 'vd-topic-title']");

                            foreach (var node in nodeImagesCollection)
                            {
                                try
                                {
                                    foreach (HtmlNode nodeLink in node.ChildNodes)
                                    {
                                        if (nodeLink.Name.Equals("a"))
                                        {
                                            string strTitle = nodeLink.InnerText;
                                            string strPage = nodeLink.Attributes["href"].Value;
                                            string strCategory = "Us-UK-Sexy-Girl";
                                            string strCounter = BuildCounter(strPage);
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
                    Console.WriteLine("Finish page ^_^: " + strURL);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void Asia()
        {
            try
            {
                var bolService = new BOLService.BOLService();
                List<ImgLink> lst = new List<ImgLink>();
                var web = new HtmlWeb();
                int start = 1;
                int end = 20; //TODO: current max value 20

                for (int i = start; i < end; i++)
                {
                    string strURL = "http://www.depvd.com/asia/p" + i;
                    var doc = web.Load(strURL);
                    //TODO: Check valid 
                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'vd-topics']");
                    if (divContainer == null)
                    {
                        return;
                    }

                    foreach (HtmlNode childNode in divContainer.ChildNodes)
                    {
                        if (childNode.Name.Equals("div") && childNode.Attributes["class"] != null &&
                            childNode.Attributes["class"].Value.Equals("vd-topic vd-xitin"))
                        {
                            //TODO: have 4 column
                            HtmlNodeCollection nodeImagesCollection = divContainer.SelectNodes("//div[@class = 'vd-topic-title']");

                            foreach (var node in nodeImagesCollection)
                            {
                                try
                                {
                                    foreach (HtmlNode nodeLink in node.ChildNodes)
                                    {
                                        if (nodeLink.Name.Equals("a"))
                                        {
                                            string strTitle = nodeLink.InnerText;
                                            string strPage = nodeLink.Attributes["href"].Value;
                                            string strCategory = "Asia-Sexy-Girl";
                                            string strCounter = BuildCounter(strPage);
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
                    Console.WriteLine("Finish page ^_^: " + strURL);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void VietNam()
        {
            try
            {
                var bolService = new BOLService.BOLService();
                List<ImgLink> lst = new List<ImgLink>();
                var web = new HtmlWeb();
                int start = 1;
                int end = 5; //TODO: current max value 24

                for (int i = start; i < end; i++)
                {
                    string strURL = "http://www.depvd.com/vn/p" + i;
                    var doc = web.Load(strURL);
                    //TODO: Check valid 
                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'vd-topics']");
                    if (divContainer == null)
                    {
                        return;
                    }

                    foreach (HtmlNode childNode in divContainer.ChildNodes)
                    {
                        if (childNode.Name.Equals("div") && childNode.Attributes["class"] != null &&
                            childNode.Attributes["class"].Value.Equals("vd-topic vd-xitin"))
                        {
                            //TODO: have 4 column
                            HtmlNodeCollection nodeImagesCollection = divContainer.SelectNodes("//div[@class = 'vd-topic-title']");

                            foreach (var node in nodeImagesCollection)
                            {
                                try
                                {
                                    foreach (HtmlNode nodeLink in node.ChildNodes)
                                    {
                                        if (nodeLink.Name.Equals("a"))
                                        {
                                            string strTitle = nodeLink.InnerText;
                                            string strPage = nodeLink.Attributes["href"].Value;
                                            string strCategory = "Viet-Nam-Sexy-Girl";
                                            string strCounter = BuildCounter(strPage);
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
                    Console.WriteLine("Finish page ^_^: " + strURL);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void HomeSexyGirl()
        {
            try
            {
                var bolService = new BOLService.BOLService();
                List<ImgLink> lst = new List<ImgLink>();
                var web = new HtmlWeb();
                int start = 1;
                int end = 5; //TODO: current max value 30

                for (int i = start; i < end; i++)
                {
                    string strURL = "http://www.depvd.com/p" + i;
                    var doc = web.Load(strURL);
                    //TODO: Check valid 
                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'vd-topics']");
                    if (divContainer == null)
                    {
                        return;
                    }

                    foreach (HtmlNode childNode in divContainer.ChildNodes)
                    {
                        if (childNode.Name.Equals("div") && childNode.Attributes["class"] != null &&
                            childNode.Attributes["class"].Value.Equals("vd-topic vd-xitin"))
                        {
                            //TODO: have 4 column
                            HtmlNodeCollection nodeImagesCollection = divContainer.SelectNodes("//div[@class = 'vd-topic-title']");

                            foreach (var node in nodeImagesCollection)
                            {
                                try
                                {
                                    foreach (HtmlNode nodeLink in node.ChildNodes)
                                    {
                                        if (nodeLink.Name.Equals("a"))
                                        {
                                            string strTitle = nodeLink.InnerText;
                                            string strPage = nodeLink.Attributes["href"].Value;
                                            string strCategory = "Sexy-Girl";
                                            string strCounter = BuildCounter(strPage);
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
                    Console.WriteLine("Finish page ^_^: " + strURL);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void NewSexyGirl()
        {
            try
            {
                var bolService = new BOLService.BOLService();
                List<ImgLink> lst = new List<ImgLink>();
                var web = new HtmlWeb();
                int start = 1;
                int end = 5; //TODO: current max value 24

                for (int i = start; i < end; i++)
                {
                    string strURL = "http://www.depvd.com/new/p" + i;
                    var doc = web.Load(strURL);
                    //TODO: Check valid 
                    var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'vd-topics']");
                    if (divContainer == null)
                    {
                        return;
                    }

                    foreach (HtmlNode childNode in divContainer.ChildNodes)
                    {
                        if (childNode.Name.Equals("div") && childNode.Attributes["class"] != null &&
                            childNode.Attributes["class"].Value.Equals("vd-topic vd-xitin"))
                        {
                            //TODO: have 4 column
                            HtmlNodeCollection nodeImagesCollection = divContainer.SelectNodes("//div[@class = 'vd-topic-title']");

                            foreach (var node in nodeImagesCollection)
                            {
                                try
                                {
                                    foreach (HtmlNode nodeLink in node.ChildNodes)
                                    {
                                        if (nodeLink.Name.Equals("a"))
                                        {
                                            string strTitle = nodeLink.InnerText;
                                            string strPage = nodeLink.Attributes["href"].Value;
                                            string strCategory = "Sexy-Girl";
                                            string strCounter = BuildCounter(strPage);
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
                if (bolService.CheckExistLinkByDomain(strCounter, "depvd.com")) return;

                var lst = new List<BOLService.ImgLink>();
                var web = new HtmlWeb();
                var doc = web.Load(strPage);
                //TODO: Check valid 
                var divContainer = doc.DocumentNode.SelectSingleNode("//div[@id = 'vd-view-carousel']");
                if (divContainer == null)
                {
                    return;
                }
                foreach (HtmlNode childNode in divContainer.ChildNodes)
                {
                    if (childNode.Name.Equals("div") && childNode.Attributes["class"] != null &&
                        childNode.Attributes["class"].Value.Equals("carousel-inner"))
                    {
                        foreach (var node in childNode.ChildNodes)
                        {
                            if (node.Name.Equals("div") && node.Attributes["class"] != null &&
                                node.Attributes["class"].Value.Contains("item"))
                            {
                                try
                                {
                                    string strLink = node.FirstChild.Attributes["src"].Value;
                                    if (string.IsNullOrEmpty(strLink))
                                        strLink = node.FirstChild.Attributes["data-original"].Value;
                                    var item = new BOLService.ImgLink()
                                    {
                                        Category = category,
                                        Counter = strCounter,
                                        CreateDate = DateTime.Now,
                                        UpdateDate = DateTime.Now,
                                        Domain = "depvd.com",
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
                        if (lst.Count > 0)
                        {
                            bolService.SaveImgDepVD(lst);
                            Console.WriteLine(strPage);
                        }
                        break;
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
