using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLService;
using HtmlAgilityPack;
using log4net;

namespace ChanDaiURL
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            GetChanDaiPhoto();
        }

        private static void GetChanDaiPhoto()
        {
            var bolService = new BOLService.BOLService();
            List<ImgLink> lst = new List<ImgLink>();
            var web = new HtmlWeb();
            int counter = 0;
            int error = 0;
            int start = 1;
            int end = 100;

            var vStartObj = bolService.GetLastestChanDaiImage();
            if (vStartObj != null)
            {
                if (!int.TryParse(vStartObj.Counter, out start))
                {
                    Console.WriteLine("Not Start ^_^");
                    return;
                }
            }

            end = start * 1000;

            for (int i = start; i < end; i++)
            {
                try
                {
                    var doc = web.Load("http://chandai.tv/photo/" + i);
                    var vImg = doc.DocumentNode.SelectSingleNode("//img[@class = 'img-responsive']");
                    if (vImg != null && vImg.Attributes.Count > 1)
                    {
                        counter = i;
                        var vResult = vImg.Attributes[1];
                        if (vResult.Value.Equals("/Content/images/notfound.jpg"))
                        {
                            error += 1;
                            if (error == 300)
                                break;
                        }
                        else
                        {
                            error = 0; //Only end when 10 sequence times no image
                            string strResult = string.Format("http://chandai.tv{0}", vResult.Value);
                            var img = new ImgLink()
                            {
                                linkimg = strResult,
                                Counter = i.ToString(),
                                CreateDate = DateTime.Now,
                                UpdateDate = DateTime.Now,
                                Domain = "chandai.tv"

                            };

                            lst.Add(img);
                            if (lst.Count == 10)
                            {
                                bolService.SaveImg(lst);
                                lst.Clear();
                                Console.WriteLine("Save link " + i);
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    log4net.Config.XmlConfigurator.Configure();
                    log.Info("Error: " + exception);
                    Console.WriteLine(exception.ToString());
                }
            }
            if (lst.Count > 0)
            {
                bolService.SaveImg(lst);
                lst.Clear();
            }
            Console.WriteLine("Finish ^_^");
        }
    }
}
