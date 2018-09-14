﻿using Clark.Crawler;
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
                            if (!request.Response.Code.Equals("200"))
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
                                    Request request = new Request(DomainUtility.EnsureHTTPS(foundURL));
                                    RequestUtility.GetWebText(request);
                                    if (!request.Response.Code.Equals("200"))
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