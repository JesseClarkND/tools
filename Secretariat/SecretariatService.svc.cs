using Clark.Attack.Common.Interfaces;
using Clark.Attack.Common.Models;
using Clark.Common.Models;
using Clark.Common.Utility;
using Clark.Logger;
using Clark.Subdomain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace Secretariat
{
    public class SecretariatService : ISecretariatService
    {
        private static CountdownEvent _countdown;

        public string CheckConnection()
        {
            return "Ack";
        }

        public string TestURL(string url)
        {
            var urlsToTest = new List<string>(){url};

            Log("========================");
            Log("Starting " + url + " at " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            Log("========================");

            if (url.StartsWith("*"))
            {
                urlsToTest.AddRange(LoadSubdomains(url));
            }

            //threads

            return "";
        }

        private void TestURL(string url)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                List<string> schemas = new List<string>();
                schemas.Add("http");
                schemas.Add("https");

                foreach (var schema in schemas)
                {
                    if (schema.Equals("http"))
                        url = DomainUtility.EnsureHTTP(url);
                    else
                        url = DomainUtility.EnsureHTTPS(url);

                    sb.Append("Checking: " + url + Environment.NewLine);

                    List<IAttack> attacks = new List<IAttack>();

                    //Future: Auto detect dlls
                    attacks.Add(new Clark.Attack.ContentScanner.Processor());
                    attacks.Add(new Clark.Attack.SocialMedia.Processor());
                    attacks.Add(new Clark.Attack.InformationLeak.Processor());
                    attacks.Add(new Clark.Attack.CRLF.Processor());

                    WebPageRequest request = new WebPageRequest();
                    request.Address = url;
                    WebPageLoader.Load(request);

                    var sRequest = new AttackRequest();
                    sRequest.Body = request.Response.Body;
                    sRequest.URL = url;
                    sRequest.Domain = DomainUtility.GetDomainFromUrl(url);

                    _countdown = new CountdownEvent(attacks.Count);
                    List<Thread> lstThreads = new List<Thread>();
                    foreach (var attack in attacks)
                    {
                        Thread th = new Thread(() => { ExecuteAttack(attack, sRequest, sb) });
                        lstThreads.Add(th);
                    }

                    foreach (Thread th in lstThreads)
                        th.Start();

                    _countdown.Wait();
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                sb.Append("!!!!!Exception: " + ex.Message + " Inner: " + inner + " Stack: " + ex.StackTrace);
            }

            Log(sb.ToString());

            _countdown.Signal();
        }

        private void ExecuteAttack(IAttack attack, AttackRequest sRequest, StringBuilder sb)
        {
            var sResult = attack.Check(sRequest);

            if (sResult.Success)
            {
                string msg = "Vulnerability Found: " + String.Join(Environment.NewLine, sResult.Results.ToArray());
                sb.Append(msg);
                SendEmail(attack.Name, msg);
            }
            else
            {
                sb.Append(attack.Name);
                sb.Append(" failed to find a vulnerability.");
            }
        }

        private static void SendEmail(string subject, string body)
        {
            var fromAddress = new MailAddress("hogarth45scanners@gmail.com", Settings.ServerName);
            var toAddress = new MailAddress("hogarth45@gmail.com", "To Name");

            MailGun.Blast(subject, body, fromAddress, toAddress, Settings.EmailPassword);
        }

        private void Log(string log)
        {
            TextFileLogger.Log(Settings.LogDir, DateTime.Now.ToString("yyyy-MM-dd") + ".txt", DateTime.Now + "-" + log);
        }

        private List<string> LoadSubdomains(string url)
        {
            var subDomains = new List<string>();

            //This will have to get moved to a central db
            List<string> knownSubdomains = new List<string>();
            string existingFile = Path.Combine(Settings.ExistingDir, url.Replace(".", "") + ".txt");
            if (File.Exists(existingFile))
                knownSubdomains = File.ReadAllLines(existingFile).ToList();

            HunterRequest request = new HunterRequest();
            request.Domain = url;
            request.KnownSubdomains = knownSubdomains;
            request.SecurityTrailsAPIKey = Settings.SecurityTrailsAPI;
            request.VirusTotalAPIKey = Settings.VirusTotalAPI;

            subDomains = Hunter.GatherAll(request);

            Log("Subdomains found: " + subDomains.Count);
            TextFileLogger.WriteOverwriteFile(Settings.ExistingDir, url.Replace(".", "") + ".txt", subDomains);

            return subDomains;
        }
    }
}