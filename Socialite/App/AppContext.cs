using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.App
{
    public static class AppContext
    {
        public static List<string> UserNames = new List<string>();
        public static List<string> FoundSocialURLs = new List<string>();
        public static List<string> FoundSocialURLs404 = new List<string>();
    }
}