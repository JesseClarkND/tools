using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Data
{
    public class Request : IEquatable<Request>
    {
        public Request()
        { }

        public Request(string url)
        {
            Url = url;
            Response = new Response();
        }

        public Request(Uri uri)
        {
            Url = uri.ToString();
            Response = new Response();
        }
        public string Url = "";
        public Response Response = null;

        public bool Equals(Request other)
        {
            // Would still want to check for null etc. first.
            return this.Url == other.Url;
        }
    }
}
