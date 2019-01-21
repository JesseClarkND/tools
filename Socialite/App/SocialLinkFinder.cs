using Clark.Crawler;
using Clark.Crawler.Models;
using Clark.Crawler.Utilities;
using Clark.Socialite.Data;
using Clark.Socialite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.App
{
    public class SocialLinkFinder
    {
        public static List<string> Ignore = new List<string>(){ "www.facebook.com/buzzfeedobsessed", 
                                                                "www.facebook.com/buzzfeedsports",
                                                                "www.facebook.com/buzzfeedella",
                                                                "www.facebook.com/buzzfeedkeith",
                                                                "www.facebook.com/buzzfeedzach",
                                                                "www.facebook.com/buzzfeedeugene",
                                                                "www.facebook.com/buzzfeedweddings",
                                                                "facebook.com/buzzfeedandrew",
                                                                "www.instagram.com/buzzfeedstyle"};

        public static Dictionary<string, string> Find(string body, string url, List<string> userNames, List<DomainData> socialDomains, bool returnOnlyNone200=true)
        {
            Dictionary<string, string> foundUrls = new Dictionary<string, string>();
            LinkParser parser = new LinkParser();
            parser.ParseLinksAgility(body, url, true);

            foreach (Request foundUrl in parser.GoodUrls)
            {
                string foundURL = DomainUtility.StripProtocol(foundUrl.Url.Split('?')[0]);

                if (SocialDomainUtility.CheckIfSocialMediaSite(foundURL, socialDomains))
                {
                    if (userNames.Count == 0)
                    {
                        if (!foundUrls.ContainsKey(foundURL))
                        {
                            Request request = new Request(DomainUtility.EnsureHTTPS(foundURL));
                            RequestUtility.GetWebText(request);
                            if (!request.Response.Code.Equals("200") || request.Url.Contains("buymethat"))
                                foundUrls.Add(foundURL, url);
                            else if(!returnOnlyNone200)
                                foundUrls.Add(foundURL, url);
                        }
                    }
                    else
                    {
                        foreach (string userName in userNames)
                        {
                            if (foundURL.ToLower().Contains(userName.ToLower()))
                            {
                                if (!foundUrls.ContainsKey(foundURL))
                                {
                                    if (Ignore.Contains(foundURL.ToLower()))
                                        continue;

                                    Request request = new Request(DomainUtility.EnsureHTTPS(foundURL));
                                    RequestUtility.GetWebText(request);
                                    if (!request.Response.Code.Equals("200") || request.Url.Contains("buymethat"))
                                        foundUrls.Add(foundURL, url);
                                    else if (!returnOnlyNone200)
                                        foundUrls.Add(foundURL, url);
                                }
                            }
                        }
                    }
                }
            }
            return foundUrls;
        }


    }
}