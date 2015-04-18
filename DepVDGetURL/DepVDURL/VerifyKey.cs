using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepVDURL
{
    public class VerifyKey
    {
        public string code { get; set; }
        public string content { get; set; }
        public string message { get; set; }

        public VerifyKey()
        {
            code = string.Empty;
            content = string.Empty;
            message = string.Empty;
        }
    }
}
