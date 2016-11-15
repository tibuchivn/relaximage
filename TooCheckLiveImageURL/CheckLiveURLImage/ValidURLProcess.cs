using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BOLService;

namespace CheckLiveURLImage
{
    public class ValidURLProcess
    {
        public void ProcessCheckURL()
        {
            var _bolService = new BOLService.BOLService();
            var lstImgs = _bolService.GetListImgForCheck(150);

            var parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = 100;
            Parallel.ForEach(lstImgs, ThreadProcessData);
        }

        private void ThreadProcessData(ImgLink img)
        {
            Console.WriteLine("Start Check: " + img.linkimg);
            var _bolService = new BOLService.BOLService();
            try
            {
                var req = (HttpWebRequest)HttpWebRequest.Create(img.linkimg);
                req.Method = "HEAD";
                using (var resp = req.GetResponse())
                {
                    if (!resp.ContentType.ToLower(CultureInfo.InvariantCulture).StartsWith("image/"))
                    {
                        Console.WriteLine("Invalid: " + img.linkimg);
                        _bolService.UpdateBadURL(img.ID, true);
                    }
                    else
                    {
                        _bolService.UpdateBadURL(img.ID, false);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                _bolService.UpdateBadURL(img.ID);
            }
            Console.WriteLine("End Check: " + img.linkimg);
        }
    }
}
