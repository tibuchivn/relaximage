using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLService
{
    public class BOLService
    {
        private readonly DBContextDataContext _context;

        public BOLService()
        {
            _context = new DBContextDataContext();
        }

        public List<ImgLink> GetCoolRandomImgLinks(int amount)
        {
            var listImgLink = (from link in _context.ImgLinks
                where !link.IsBadURL.HasValue || !link.IsBadURL.Value
                orderby _context.Random()
                select link).Take(amount);
            if (listImgLink.Any())
            {
                return listImgLink.ToList();
            }
            return new List<ImgLink>
                   {
                       new ImgLink
                       {
                           linkimg =
                               "http://upload.wikimedia.org/wikipedia/commons/a/aa/Empty_set.svg"
                       }
                   };
        }

        public List<ImgLink> GetImgLinks(int index, int amount)
        {
            var vReturnValue = new List<ImgLink>();
            if (amount > 0)
            {
                vReturnValue = _context.ImgLinks.Where(o=>!o.IsBadURL.HasValue || !o.IsBadURL.Value )
                    .OrderByDescending(o => o.ID)
                    .Skip(index * amount).Take(amount).ToList();
                if(vReturnValue.Count == 0)
                    vReturnValue = _context.ImgLinks.Where(o => !o.IsBadURL.HasValue || !o.IsBadURL.Value)
                        .OrderBy(o => o.ID)
                        .Take(amount).ToList();
            }
            else
            {
                vReturnValue = _context.ImgLinks
                    .Where(o => !o.IsBadURL.HasValue || !o.IsBadURL.Value)
                    .OrderByDescending(o => o.ID)
                    .Take(1000).ToList(); 
            }

            if (vReturnValue.Count == 0)
            {
                vReturnValue.Add(new ImgLink()
                {
                    linkimg = "http://upload.wikimedia.org/wikipedia/commons/a/aa/Empty_set.svg"
                });
            }
            return vReturnValue;
        }

        public int TotalImages()
        {
            return _context.ImgLinks.Count();
        }

        public List<GetRandomImageResult> GetRandomImage(int amount)
        {
            if (amount > 0)
            {
                return _context.GetRandomImage(500, amount).ToList();
            }
            return null;
        }

        public ImgLink GetImgLinkById(int id)
        {
            return _context.ImgLinks.FirstOrDefault(o => o.ID == id);
        }

        public List<ImgLink> GetImgToDownLoad(int amount)
        {
            return _context.ImgLinks
                .Where(o => !o.IsBadURL.HasValue || !o.IsBadURL.Value)
                .Where(o => !o.IsDownLoaded.HasValue || !o.IsDownLoaded.Value)
                .Take(amount).ToList();
        }

        public void UpdateDownloaded(List<ImgLink> lst)
        {
            foreach (var link in lst)
            {
                var obj = _context.ImgLinks.FirstOrDefault(o => o.ID == link.ID);
                if(obj != null)
                    obj.IsDownLoaded = true;
            }
            _context.SubmitChanges();
        }

        public void SaveImg(ImgLink img)
        {
            _context.ImgLinks.InsertOnSubmit(img);
            _context.SubmitChanges();
        }

        public void SaveImg(List<ImgLink> lstLinks)
        {
            foreach (var link in lstLinks)
            {
                var v = _context.ImgLinks.FirstOrDefault(o => o.linkimg == link.linkimg);
                if(v == null)
                    _context.ImgLinks.InsertOnSubmit(link);
            }
            _context.SubmitChanges();
        }

        public void SaveImgDepVD(List<ImgLink> lstLinks)
        {
            foreach (var link in lstLinks)
            {
                var v = _context.ImgLinks.FirstOrDefault(o => o.linkimg == link.linkimg);
                if (v == null)
                    _context.ImgLinks.InsertOnSubmit(link);
                else
                {
                    v.Category = link.Category;
                    v.Counter = link.Counter;
                    v.Domain = link.Domain;
                    v.GroupName = link.GroupName;
                    v.IsBadURL = false;
                }
                _context.SubmitChanges();
            }
        }

        public ImgLink GetLastestChanDaiImage()
        {
            var result = _context.ImgLinks.Where(o => o.Domain == "chandai.tv").OrderByDescending(o => o.ID).FirstOrDefault();
            return result;
        }

        public bool CheckLinkDownloaded(string strDomain, string strCounter)
        {
            return _context.ImgLinks.Any(o => o.Domain == strDomain && o.Counter == strCounter);
        }

        public List<ImgLink> GetImgLinksByDomain(int index, int amount, string stringDomain)
        {
            var vReturnValue = new List<ImgLink>();
            if (amount > 0)
            {
                vReturnValue = _context.ImgLinks
                    .Where(o => !o.IsBadURL.HasValue || !o.IsBadURL.Value)
                    .Where(o=>o.Domain == stringDomain)
                    .OrderByDescending(o => o.ID)
                    .Skip(index * amount).Take(amount).ToList();
            }
            else
            {
                vReturnValue = _context.ImgLinks
                    .Where(o => !o.IsBadURL.HasValue || !o.IsBadURL.Value)
                    .Where(o => o.Domain == stringDomain)
                    .OrderByDescending(o => o.ID)
                    .ToList();    
            }

            if (vReturnValue.Count == 0)
            {
                vReturnValue.Add(new ImgLink()
                {
                    linkimg = "http://upload.wikimedia.org/wikipedia/commons/a/aa/Empty_set.svg"
                });
            }
            return vReturnValue;
        }

        public  bool CheckExistLinkByDomain(string counter, string domain)
        {
            return _context.ImgLinks.Any(o => o.Counter.Equals(counter) && o.Domain.Equals(domain));
        }

        public void UpdateBadURL(int id)
        {
            var obj = _context.ImgLinks.FirstOrDefault(o => o.ID == id);
            if (obj != null)
            {
                //TODO: update bad url
                obj.IsBadURL = true;
                obj.IsCheckLive = true;
                _context.SubmitChanges();
            }
        }

        public void ReverURL(int id)
        {
            var obj = _context.ImgLinks.FirstOrDefault(o => o.ID == id);
            if (obj != null)
            {
                //TODO: update bad url
                obj.IsBadURL = false;
                _context.SubmitChanges();
            }
        }

        public List<ImgLink> GetBadURL(string strDomain)
        {
            if (!string.IsNullOrEmpty(strDomain))
            {
                return _context.ImgLinks.Where(o => o.IsBadURL.Value && o.Domain.Equals(strDomain))
                .OrderBy(o => o.ID).ToList();
            }
            return _context.ImgLinks.Where(o => o.IsBadURL.Value)
                .OrderBy(o=>o.ID)
                .ToList();
        }

        public List<ImgLink> GetListImgForCheck(int amount)
        {
            var lst = _context.ImgLinks.Where(o => (o.IsBadURL == null || o.IsBadURL == false) &&  (o.IsCheckLive == null || o.IsCheckLive == false));
            return lst.OrderBy(o => o.ID).Take(amount).ToList();
        }

        public void UpdateStatus(int imglinkId)
        {
            var obj = _context.ImgLinks.FirstOrDefault(o => o.ID == imglinkId);
            if (obj != null)
            {
                obj.IsCheckLive = true;
                _context.SubmitChanges();
            }
        }
    }
}
