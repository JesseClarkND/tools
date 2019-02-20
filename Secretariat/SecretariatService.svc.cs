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
        private static string _url = "N/A";
        private static DateTime _started = DateTime.MaxValue;
        private static string _status = "Idle";


        public string CheckConnection()
        {
            return "Ack";
        }

        public string CheckLastURL()
        {
            return _url;
        }

        public string CheckStatus()
        {
            return _status;
        }

        public string CheckStartTime()
        {
            return _started.ToString();
        }

        public string TestURL(string url)
        {
            _started = DateTime.Now;
            _status = "Working";

            var urlsToTest = new List<string>(){url.Trim(new char[]{'*','.'})};

            Log("========================");
            Log("Starting " + url + " at " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            Log("========================");

            if (url.StartsWith("*"))
            {
                urlsToTest.AddRange(LoadSubdomains(url));
            }

            //threads
            foreach (var earl in urlsToTest)
            {
                _url = earl;

                Test(earl);
            }

            _started = DateTime.MaxValue;
            _status = "Idle";

            return "";
        }

        private void Test(string url)
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

                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    sb.Append(DateTime.Now.ToString());
                    sb.Append(" Checking: " + url + Environment.NewLine);
                    sb.Append("------------------");
                    List<IAttack> attacks = new List<IAttack>();

                    //Future: Auto detect dlls
                    attacks.Add(new Clark.Attack.ContentScanner.Processor());
                    attacks.Add(new Clark.Attack.SocialMedia.Processor());
                    attacks.Add(new Clark.Attack.InformationLeak.Processor());
                    attacks.Add(new Clark.Attack.CRLF.Processor());
                    attacks.Add(new Clark.Attack.VulnerableFiles.Processor());
                    attacks.Add(new Clark.Attack.HTTPHeader.Processor());
                    attacks.Add(new Clark.Attack.CSP.Processor());
                    attacks.Add(new Clark.Attack.HTTPResponse.Processor());
                    attacks.Add(new Clark.Attack.FileUpload.Processor());
                    attacks.Add(new Clark.Attack.Redirect.Processor());

                    WebPageRequest request = new WebPageRequest();
                    request.Address = url;
                    WebPageLoader.Load(request);

                    var sRequest = new AttackRequest();
                    sRequest.Body = request.Response.Body;
                    sRequest.URL = url;
                    sRequest.Domain = DomainUtility.GetDomainFromUrl(url);
                    sRequest.LogDir = Settings.LogDir;

                    _countdown = new CountdownEvent(attacks.Count);
                    List<Thread> lstThreads = new List<Thread>();
                    foreach (var attack in attacks)
                    {
                        Thread th = new Thread(() => { sb.Append(Environment.NewLine + ExecuteAttack(attack, sRequest)); });
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
                LogError("!!!!!Exception: " + ex.Message + " Inner: " + inner + " Stack: " + ex.StackTrace);
            }

            Log(sb.ToString());


        }

        private string ExecuteAttack(IAttack attack, AttackRequest sRequest)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                var sResult = attack.Check(sRequest);

                if (sResult.Success)
                {
                    string msg = sRequest.URL + Environment.NewLine;
                    msg += "Vulnerability Found: " + String.Join(Environment.NewLine, sResult.Results.ToArray());
                    sb.Append(msg);
                    SendEmail(attack.Name, msg);
                }
                else
                {
                    sb.Append(attack.Name);
                    sb.Append(" failed to find a vulnerability.");
                }
            }
            catch (Exception ex)
            {
                sb.Append("Exception: ");
                sb.Append(ex.Message);
                if (ex.InnerException != null)
                    sb.Append(" " + ex.InnerException.Message);
                sb.Append("ST: " + ex.StackTrace);
            }
            finally
            {
                _countdown.Signal();
            }
            return sb.ToString();
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

        private void LogError(string log)
        {
            TextFileLogger.Log(Settings.LogDir, DateTime.Now.ToString("yyyy-MM-dd") + "-Error.txt", DateTime.Now + "-" + log);
        }

        private List<string> LoadSubdomains(string url)
        {
            string testUrl = url.Trim(new char[]{'*','.'});
            var subDomains = new List<string>();

            //This will have to get moved to a central db
            List<string> knownSubdomains = new List<string>();
            string existingFile = Path.Combine(Settings.ExistingDir, testUrl.Replace(".", "") + ".txt");
            if (File.Exists(existingFile))
                knownSubdomains = File.ReadAllLines(existingFile).ToList();

            HunterRequest request = new HunterRequest();
            request.Domain = testUrl;
            request.KnownSubdomains = knownSubdomains;
            request.SecurityTrailsAPIKey = Settings.SecurityTrailsAPI;
            request.VirusTotalAPIKey = Settings.VirusTotalAPI;

            subDomains = Hunter.GatherAll(request);

            Log("Subdomains found: " + subDomains.Count);
            TextFileLogger.WriteOverwriteFile(Settings.ExistingDir, testUrl.Replace(".", "") + ".txt", subDomains);

            return subDomains;
        }
    }
}