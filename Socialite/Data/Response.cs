using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Data
{
    public class Response
    {
        public bool Error = false;
        public string ErrorMessage = "";
        public string Code = "";//HTTP code 403, 404, 200, etc
        public string Body = "";
    }
}
