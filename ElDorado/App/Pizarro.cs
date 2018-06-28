using Clark.Crawler.Interfaces;
using Clark.Crawler.Models;
using Clark.Crawler.Utilities;
using ElDorado.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElDorado.App
{
    public static class Pizarro
    {
        private static Action<IRequest> _responseHandler;
        private static Action _pageCounter;
        private static CountdownEvent _countdown;

        public static void Explore(int threadCount, string domain, object responseHandler, object actCounter)
        {
            _responseHandler = (Action<IRequest>)responseHandler;
            _pageCounter = (Action)actCounter;


            if(!CheckForWildCard(domain))
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

             _countdown = new CountdownEvent(threadCount);

             //10 threads 812/min vs TaskFactory 10 tasks 638/min
            List<Thread> lstThreads = new List<Thread>();
            for (int count = 0; count < threadCount; count++)
            {
                Thread th = new Thread(() => { SearchRequest(gen, domain); });
                lstThreads.Add(th);
            }

            foreach (Thread th in lstThreads)
                th.Start();

            _countdown.Wait();
        }

        private static bool CheckForWildCard(string domain)
        {
            if (CheckRequest(new Request("https://aa89abbbck398s0a." + domain)))
                return true;

            if (CheckRequest(new Request("http://aa89abbbck398s0a." + domain)))
                return true;

            return false;
        }

        private static void SearchRequest(SubDomainGenerator gen, string domain)
        {
            string subDomain = gen.Next();
            while (!String.IsNullOrEmpty(subDomain))
            {
                _pageCounter.Invoke();
                if(!CheckRequest(new Request("https://" + subDomain + "." + domain)))
                    CheckRequest(new Request("http://" + subDomain + "." + domain));
                subDomain = gen.Next();
            }
            _countdown.Signal();
        }

        private static bool CheckRequest(Request request)
        {
            RequestUtility.GetWebText(request);

            // if (request.Response.Error == true)
            if (!String.IsNullOrEmpty(request.Response.ErrorMessage))
            {
                return false;
                //MessageBox.Show(request.Response.ErrorMessage);
            }

            if (request.Response.Code.Equals("200"))
            {
                AppContext.Found.Add(request.Url);
                if (!AppContext.PortsFound.ContainsKey(request.Url))
                    AppContext.PortsFound.Add(request.Url, new List<int>());//threw an object not set 6/24
                _responseHandler.Invoke(request);

                return true;
                //AppContext.FoundSocialURLs404.Add(foundUrl.Url + " @ " + url);
                //_lstFound.Items.Add(request.Url);
            }

            return false;
        }
    }
}