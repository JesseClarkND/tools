using Clark.Crawler.Interfaces;
using Clark.Crawler.Utilities;
using ElDorado.App;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ElDorado.Utility
{
    public static class PortScanner
    {
        //https://github.com/PhilipMur/C-Sharp-Multi-Threaded-Port-Scanner/blob/master/MultiPortScan/PortScanner.cs
        private static string _host;
        private static PortList _portList;
        private static int _count = 0;
        private static CountdownEvent _countdown;
        private static Action _portCounter;
        private static Dictionary<string, IPAddress> _hostToIP = new Dictionary<string, IPAddress>();

        public static int TcpTimeout;

        private class isTcpPortOpen
        {
            public TcpClient MainClient { get; set; }
            public bool tcpOpen { get; set; }
        }

        public static void Prep(List<string> hosts)
        {
            //https://docs.microsoft.com/en-us/dotnet/framework/network-programming/asynchronous-client-socket-example
            foreach (string host in hosts)
            {
                AddHost(host);
            }
        }

        private static void AddHost(string host)
        {
            if (!_hostToIP.ContainsKey(host))
            {
                IPHostEntry ipHostInfo = Dns.GetHostEntry(DomainUtility.StripProtocol(host));
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                _hostToIP.Add(host, ipAddress);
            }
        }

        public static void Start(int threadCounter, string host, int portStart, int portStop, int timeout, object actCounter)
        {
            _host = host;
            AddHost(_host);
     
            _portList = new PortList(portStart, portStop);
            TcpTimeout = timeout;
            _portCounter = (Action)actCounter;

            _countdown = new CountdownEvent(threadCounter);
            for (int i = 0; i < threadCounter; i++)
            {
                Thread thread = new Thread(new ThreadStart(RunScanTcp));
                thread.Start();
            }
            _countdown.Wait();
        }

        public static void Start(int threadCounter, string host, int timeout, object actCounter)
        {
            _host = host;
            AddHost(_host);
    
            _portList = new PortList();
            TcpTimeout = timeout;
            _portCounter = (Action)actCounter;

            _countdown = new CountdownEvent(threadCounter);
            for (int i = 0; i < threadCounter; i++)
            {
                Thread thread = new Thread(new ThreadStart(RunScanTcp));
                thread.Start();
            }
            _countdown.Wait();
        }

        public static void RunScanTcp()
        {
            int port = 0;

            while ((port = _portList.NextPort()) != -1)
            {
                _count = port;

                Thread.Sleep(1); //lets be a good citizen to the cpu
                _portCounter.Invoke();
                try
                {
                    Connect(_host, port, TcpTimeout);
                }
                catch
                {
                    continue;
                }

                if (AppContext.PortsFound.ContainsKey(_host))
                    AppContext.PortsFound[_host].Add(port);

                //try
                //{
                //    //grabs the banner / header info etc..
                //    Console.WriteLine(BannerGrab(host, port, tcpTimeout));


                //}
                //catch (Exception ex)
                //{
              
                //    Console.WriteLine("Could not retrieve the Banner ::Original Error = " + ex.Message);
        
                //}
   
                //string webpageTitle = GetPageTitle("http://" + host + ":" + port.ToString());

                //if (!string.IsNullOrWhiteSpace(webpageTitle))
                //{
      
                //    Console.WriteLine("Webpage Title = " + webpageTitle + "Found @ :: " + "http://" + host + ":" + port.ToString());

                //}
                //else
                //{
                //    Console.WriteLine("Maybe A Login popup or a Service Login Found @ :: " + host + ":" + port.ToString());
                //}

            }
            _countdown.Signal();
        }

        //method for returning tcp client connected or not connected
        public static TcpClient Connect(string hostName, int port, int timeout)
        {
            var newClient = new TcpClient();

            var state = new isTcpPortOpen
            {
                MainClient = newClient,
                tcpOpen = true
            };

            IAsyncResult ar = newClient.BeginConnect(_hostToIP[hostName], port, AsyncCallback, state);
            state.tcpOpen = ar.AsyncWaitHandle.WaitOne(timeout, false);

            if (state.tcpOpen == false || newClient.Connected == false)
                throw new Exception();
            return newClient;
        }

        //method for Grabbing a webpage banner / header information
        public static string BannerGrab(string hostName, int port, int timeout)
        {
            var newClient = new TcpClient(hostName, port);

            newClient.SendTimeout = timeout;
            newClient.ReceiveTimeout = timeout;
            NetworkStream ns = newClient.GetStream();
            StreamWriter sw = new StreamWriter(ns);

            sw.Write("HEAD / HTTP/1.1\r\n\r\n"
                + "Connection: Closernrn");

            sw.Flush();

            byte[] bytes = new byte[2048];
            int bytesRead = ns.Read(bytes, 0, bytes.Length);
            string response = Encoding.ASCII.GetString(bytes, 0, bytesRead);

            return response;
        }

        //async callback for tcp clients
        static void AsyncCallback(IAsyncResult asyncResult)
        {
            var state = (isTcpPortOpen)asyncResult.AsyncState;
            TcpClient client = state.MainClient;

            try
            {
                client.EndConnect(asyncResult);
            }
            catch
            {
                return;
            }

            if (client.Connected && state.tcpOpen)
                return;

            client.Close();
        }

        static string GetPageTitle(string link)
        {
            try
            {
                WebClient x = new WebClient();
                string sourcedata = x.DownloadString(link);
                string getValueTitle = Regex.Match(sourcedata, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;

                return getValueTitle;

            }
            catch (Exception ex)
            {
                //todo
                return "";
            }
        }
    }
}