using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BOLService;

namespace CheckLiveURLImage
{
    public class Program
    {
        static void Main(string[] args)
        {

            int i = 1000;
            for (int j = 0; j < i; j++)
            {
                //ClearInvalidURLImage();
                ValidURLProcess obj = new ValidURLProcess();
                Console.WriteLine("Begin Round" + j);
                obj.ProcessCheckURL();
                Console.WriteLine("Finish Round: " + j);
                Console.WriteLine("");
            }

            Console.ReadKey();
        }

        private static void ClearInvalidURLImage()
        {
            var _bolService = new BOLService.BOLService();
            var lstImgs = _bolService.GetListImgForCheck(50);
            if (lstImgs.Count > 0)
            {
                foreach (ImgLink img in lstImgs)
                {
                    try
                    {
                        var req = (HttpWebRequest)HttpWebRequest.Create(img.linkimg);
                        req.Method = "HEAD";
                        using (var resp = req.GetResponse())
                        {
                            if (!resp.ContentType.ToLower(CultureInfo.InvariantCulture).StartsWith("image/"))
                            {
                                Console.WriteLine("Invalid: " + img.linkimg);
                            }
                            _bolService.UpdateStatus(img.ID);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        _bolService.UpdateBadURL(img.ID);
                    }
                }
            }
            
        }


    }
}
