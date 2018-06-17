using Clark.Crawler.Interfaces;
using Clark.Crawler.Models;
using Clark.Crawler.Utilities;
using ElDorado.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElDorado.App
{
    public static class Pizarro
    {
        private static Action<IRequest> _responseHandler;
        private static Action _pageCounter;

        public static void Explore(string domain, object responseHandler, object actCounter)
        {
            _responseHandler = (Action<IRequest>)responseHandler;
            _pageCounter = (Action)actCounter;

            Search(domain);
        }

        private static void Search(string domain)
        {
            SubDomainGenerator gen = null;

            if (AppContext.Mode == GenerationMode.Brute)
                gen = new SubDomainGenerator();
            else
                gen = new SubDomainGenerator(AppContext.FileLocation);

            string subDomain = gen.Next();
            while (!String.IsNullOrEmpty(subDomain))
            {
                _pageCounter.Invoke();
                CheckRequest(new Request("http://" + subDomain + "." + domain));
                CheckRequest(new Request("https://" + subDomain + "." + domain));
                subDomain = gen.Next();
            }
        }

        private static void CheckRequest(Request request)
        {
            RequestUtility.GetWebText(request);

            // if (request.Response.Error == true)
            if (!String.IsNullOrEmpty(request.Response.ErrorMessage))
            {
                return;
                //MessageBox.Show(request.Response.ErrorMessage);
            }

            if (request.Response.Code.Equals("200"))
            {
                AppContext.Found.Add(request.Url);
                _responseHandler.Invoke(request);

                //AppContext.FoundSocialURLs404.Add(foundUrl.Url + " @ " + url);
                //_lstFound.Items.Add(request.Url);
            }
        }
    }
}