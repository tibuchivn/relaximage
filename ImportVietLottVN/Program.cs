using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLService;
using HtmlAgilityPack;

namespace ImportVietLottVN
{
    class Program
    {
        static void Main(string[] args)
        {
            LookupVietlotVN();
            //TODO: per day
            //ImportOnePageVietlottVN(1);
        }

        public static void LookupVietlotVN()
        {
            for (int i = 3; i > 0; i--)
            {
                ImportOnePageVietlottVN(i);
            }
        }

        public static void ImportOnePageVietlottVN(int pageId)
        {
            try
            {
                var bolService = new BOLService.BOLService();
                List<VietlottVNDto> lst = new List<VietlottVNDto>();

                var web = new HtmlWeb();
                string strURL = string.Format("http://www.vietlott.vn/vi/trung-thuong/ket-qua-trung-thuong/mega-6-45/winning-numbers/?p={0}", pageId);
                var doc = web.Load(strURL);
                //TODO: Check valid 
                var divContainer = doc.DocumentNode.SelectSingleNode("//table[@class = 'table table-striped']");
                if (divContainer == null)
                {
                    Console.WriteLine("Nothing to import ^_^");
                    return;
                }
                 
                foreach (HtmlNode childNode in divContainer.ChildNodes)
                {
                    if (childNode.Name.Equals("tbody"))
                    {
                        if (childNode.HasChildNodes)
                        {
                            foreach (HtmlNode mychildNode in childNode.ChildNodes)
                            {
                                if (mychildNode.Name.Equals("tr"))
                                {
                                    var obj = new VietlottVNDto();
                                    foreach (var tdChildNodes in mychildNode.ChildNodes)
                                    {
                                        if (tdChildNodes.Name.Equals("td"))
                                        {
                                            if (tdChildNodes.Attributes["style"] != null)
                                            {
                                                obj.StrNumber = tdChildNodes.InnerText;
                                                if (tdChildNodes.HasChildNodes)
                                                {
                                                    foreach (HtmlNode spanChildNode in tdChildNodes.ChildNodes)
                                                    {
                                                        if (spanChildNode.Name.Equals("span"))
                                                        {
                                                            string strNumber = spanChildNode.InnerText;
                                                            obj.ListNumbers.Add(strNumber);
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                obj.DatePize = tdChildNodes.InnerText;
                                            }
                                        }
                                    }
                                    lst.Add(obj);
                                }
                            }
                        }
                    }
                }
                bolService.ImportVietLottPage(lst);
                Console.WriteLine("Finish page ^_^: " + strURL);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /////////////////////////////////////////////////////////
    }
}
