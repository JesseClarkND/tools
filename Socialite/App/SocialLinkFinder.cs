using Clark.Crawler;
using Clark.Crawler.Models;
using Clark.Crawler.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.App
{
    public class SocialLinkFinder
    {
        public static List<KeyValuePair<string, string>> Find(string body, string url, List<string> socialUrls)
        {
            List<KeyValuePair<string, string>> foundUrls = new List<KeyValuePair<string, string>>();
            LinkParser parser = new LinkParser();
            parser.ParseLinksAgility(body, url, true);

            foreach (Request foundUrl in parser.GoodUrls)
            {
                string foundDomain = DomainUtility.GetDomainFromUrl(foundUrl.Url);
                string foundURL = foundUrl.Url.Split('?')[0];

                if (!CheckForSharing(foundDomain, foundUrl.Url))
                    continue;

                if (socialUrls.Contains(foundDomain.ToLower()))
                {
                    if (AppContext.UserNames.Count == 0)
                    {
                        if (!AppContext.FoundSocialURLs.Contains(foundUrl.Url))
                        {
                            AppContext.FoundSocialURLs.Add(foundUrl.Url);

                            Request request = new Request(DomainUtility.EnsureHTTPS(foundUrl.Url));
                            RequestUtility.GetWebText(request);
                            if (request.Response.Code.Equals("404"))
                                AppContext.FoundSocialURLs404.Add(foundUrl.Url + " @ " + url);

                            foundUrls.Add(new KeyValuePair<string, string>(request.Response.Code, foundUrl.Url + " @ " + url));
                        }
                    }
                    else
                    {
                        foreach (string userName in AppContext.UserNames)
                        {
                            if (foundURL.ToLower().Contains(userName.ToLower()))
                            {
                                if (!AppContext.FoundSocialURLs.Contains(foundUrl.Url))
                                {
                                     AppContext.FoundSocialURLs.Add(foundUrl.Url);

                                    Request request = new Request(DomainUtility.EnsureHTTPS(foundUrl.Url));
                                    RequestUtility.GetWebText(request);
                                    if (request.Response.Code.Equals("404"))
                                        AppContext.FoundSocialURLs404.Add(foundUrl.Url + " @ " + url);

                                    foundUrls.Add(new KeyValuePair<string, string>(request.Response.Code, foundUrl.Url + " @ " + url));
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return foundUrls;
        }

        private static bool CheckForSharing(string domain, string url)
        {
            //todo:
            if (url.Contains("iframe"))
                return false;

            switch (domain)
            {
                case "facebook.com":
                    if (url.Contains("share") || url.Contains("pages") || url.Contains("search"))
                        return false;
                    break;
                case "twitter.com":
                    if (url.Contains("intent") || url.Contains("statuses") || url.Contains("status"))
                        return false;
                    break;

                case "pintrist":
                    if (url.Contains("pin/create"))
                        return false;
                    break;


                case "youtube":
                    if (url.Contains("watch"))
                        return false;
                    break;

                case "instagram":
                    ;
                    break;
            }

            return true;
        }
    }
}