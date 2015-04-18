using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BOLService;
using log4net;

namespace ServiceDownImg
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            var bolService = new BOLService.BOLService();
            var lstUpdate = new List<ImgLink>();
            for (int i = 0; i < 2000; i++)
            {
                var lstImg = bolService.GetImgToDownLoad(100);
                 
                if(lstImg.Count == 0)
                    break;
                
                foreach (var link in lstImg)
                {
                    try
                    {
                        string str = link.linkimg;
                        int index = str.LastIndexOf('.');
                        string strExtension = str.Substring(index + 1);
                        var webClient = new WebClient();
                        webClient.DownloadFile(str, "D:\\Public\\Project_Tools_\\DemoDepVDWeb\\Demo1\\Download_\\" + link.ID + "." + strExtension);
                        Console.WriteLine(link.ID);
                        lstUpdate.Add(link);
                    }
                    catch (Exception exception)
                    {
                        log4net.Config.XmlConfigurator.Configure();
                        log.Info("Error: " + exception);
                        Console.WriteLine(exception.ToString());
                    }
                }
                bolService.UpdateDownloaded(lstUpdate);
                lstUpdate.Clear();
                Console.WriteLine("Group : " + i);
            }
            Console.WriteLine("Finish! ^_^");
            
            
        }
    }
}
