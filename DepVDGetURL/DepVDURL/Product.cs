using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepVDURL
{
    public class Product
    {
        public string code { get; set; }
        public Content content { get; set; }
        public string message { get; set; }

        public Product()
        {
            code = string.Empty;
            content = new Content();
            message = string.Empty;
        }
    }

    public class Content
    {
        public List<topic> topics { get; set; }

        public Content()
        {
            topics = new List<topic>();
        }
    }

    public class topic
    {
        public topic()
        {
            models = new List<Model>();
            Photos = new List<Photo>();
            user = new user();
        }

        public string absViewUrl { get; set; }
        public string absWidgetImage { get; set; }
        public string commentsCount { get; set; }

        public string likeCount { get; set; }

        public List<Model> models { get; set; }

        public List<Photo> Photos { get; set; }

        public string title { get; set; }

        public user user { get; set; }

        public string viewCount { get; set; }
    }


    public class Model
    {
        public string absModelUrl { get; set; }
        public string name { get; set; }
    }

    public class Photo
    {
        public string absNormal { get; set; }
    }

    public class user
    {
        public string absUserUrl { get; set; }
        public string displayName { get; set; }
    }
}
