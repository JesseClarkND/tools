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

        public static void Explore(int threadCount, string domain, object responseHandler, object actCounter)
        {
            _responseHandler = (Action<IRequest>)responseHandler;
            _pageCounter = (Action)actCounter;

            Search(threadCount, domain);
        }

        private static void Search(int threadCount, string domain)
        {
            //playing with best idea of multi-threading vs tasks vs thread pool etc
            SubDomainGenerator gen = null;

            if (AppContext.Mode == GenerationMode.Brute)
                gen = new SubDomainGenerator();
            else
                gen = new SubDomainGenerator(AppContext.FileLocation);


            Task[] tasks = new Task[threadCount];

            for (int count = 0; count < threadCount; count++)
            {
                tasks[count] = Task.Factory.StartNew(() => SearchRequest(gen, domain, count));
            }

            Task.WaitAll(tasks);

            //229 requests/min
            //string subDomain = gen.Next();
            //while (!String.IsNullOrEmpty(subDomain))
            //{
            //    _pageCounter.Invoke();
            //    CheckRequest(new Request("http://" + subDomain + "." + domain));
            //    CheckRequest(new Request("https://" + subDomain + "." + domain));
            //    subDomain = gen.Next();
            //}
        }

        private static void SearchRequest(SubDomainGenerator gen, string domain, int meh)
        {
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