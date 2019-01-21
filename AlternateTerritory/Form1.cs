using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clark.Subdomain;
using Clark.ContentScanner;
using System.Net.Mail;
using System.Net;
using System.IO;
using Clark.Logger;
using System.Threading;
using AlternateTerritory.Extensions;
using Clark.Common.Models;
using Clark.Common.Utility;
using Clark.WebArchiveCrawler;
using Clark.WebArchiveCrawler.Model;
using Core.MySQL.Accessor;
using MySql.Data.MySqlClient;
using Clark.Domain.Component;
using Clark.Domain.Data.Results;
using Clark.Domain.Data;
using Clark.ContentScanner.Models;
using AlternateTerritory.Models;

namespace AlternateTerritory
{
    public partial class Form1 : Form
    {
        private static int _threadCount=50;
        private static CountdownEvent _countdown;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _txtDomain.Text = "yahoo.com";
        }

        private void Log(string log)
        {
            TextFileLogger.Log(Settings.LogDir, DateTime.Now.ToString("yyyy-MM-dd") + ".txt", DateTime.Now + "-" + log); 
        }

        private void LogLinks(string log)
        {
            if (String.IsNullOrEmpty(log))
                return;
            TextFileLogger.Log(Settings.InterstingURLs, DateTime.Now.ToString("yyyy-MM-dd") + ".txt", log);
        }

        private void LogTest(string log)
        {
            _rtbLog.Text = log+Environment.NewLine;
        }

        private void _btnStart_Click(object sender, EventArgs e)
        {
            //string domain = _txtDomain.Text;
            _btnStart.Text = "Service Started...";
            _btnStart.Enabled = false;
            List<string> domains = File.ReadAllLines(Settings.SourceFile).ToList();

            //DomainController domainController = new DomainController();
            //SubdomainController subdomainController = new SubdomainController();
            //DomainFindResult findResult = domainController.FindAll();
           // foreach (Clark.Domain.Data.Domain domainItem in findResult.Items)
            foreach (string domain in domains)
            {
                //string domain = domainItem.DomainName;
                //_chkCrawlSites
                Log("========================");
                Log("Starting " + domain + " at "+DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                Log("========================");

                List<string> knownSubdomains = new List<string>();
                string existingFile = Path.Combine(Settings.ExistingDir, domain.Replace(".","")+".txt");
                if(File.Exists(existingFile))
                    knownSubdomains = File.ReadAllLines(existingFile).ToList();

                List<string> subDomains = new List<string>();

                if (System.IO.File.GetLastWriteTime(existingFile) > DateTime.Now.AddDays(-60) && knownSubdomains.Count != 0)
                {
                    subDomains = knownSubdomains;
                    Log("Subdomains loaded from file: " + subDomains.Count);
                }
                else
                {
                    HunterRequest request = new HunterRequest();
                    request.Domain = domain;
                    request.KnownSubdomains = knownSubdomains;
                    request.SecurityTrailsAPIKey = Settings.SecurityTrailsAPI;
                    request.VirusTotalAPIKey = Settings.VirusTotalAPI;

                    subDomains = Hunter.GatherAll(request);

                    Log("Subdomains found: " + subDomains.Count);
                    TextFileLogger.WriteOverwriteFile(Settings.ExistingDir, domain.Replace(".", "") + ".txt", subDomains);
                }

                subDomains.Insert(0, domain);
                List<string> chunked = new List<string>();
                foreach (List<string> subDomainChunk in subDomains.ChunkBy(_threadCount))
                {
                    _countdown = new CountdownEvent(Math.Min(_threadCount,subDomainChunk.Count));

                    List<Thread> lstThreads = new List<Thread>();

                    foreach (string chunck in subDomainChunk)
                    {
                        //Subdomain sub = new Subdomain();
                        //sub.DateFound = DateTime.Now;
                        //sub.DomainId = domainItem.DomainId;
                        //sub.SubdomainName = chunck.ToString().Replace(domain, "").Trim('.');

                        //subdomainController.Insert(sub);

                        Thread th = new Thread(() => { TestDomain(chunck.ToString(), true); });
                        lstThreads.Add(th);
                    }

                    foreach (Thread th in lstThreads)
                        th.Start();

                    _countdown.Wait();
                }
            }
        }

        private void TestDomain(string address, bool signalEnd)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder linkBuilder = new StringBuilder();
            try
            {
                List<string> schemas = new List<string>();
                schemas.Add("http");
                schemas.Add("https");

                foreach(var schema in schemas)
                {
                    if (schema.Equals("http"))
                        address = DomainUtility.EnsureHTTP(address);
                    else
                        address = DomainUtility.EnsureHTTPS(address);

                    sb.Append("Checking: " + address + Environment.NewLine);
                    WebPageRequest request = new WebPageRequest();
                    request.Address = address;

                    WebPageLoader.Load(request);

                    ScannerRequest sRequest = new ScannerRequest();
                    sRequest.Body = request.Response.Body;
                    sRequest.URL = address;
                    sRequest.Domain = DomainUtility.GetDomainFromUrl(address);

                    ScannerResult result = new ScannerResult();
                    ScannerContext scannerContext = new ScannerContext();


                    if (request.Response.Body.Equals(String.Empty) && request.Response.TimeOut == false)
                    {
                        sb.Append("\tNo body found." + Environment.NewLine);
                    }
                    else
                    {
                        if (request.Response.TimeOut == false)
                        {
                            result = CheckEngine(sRequest, sb, linkBuilder);
                            if (result.Success) { scannerContext.FoundVulnerabilities.Add(new Vulnerability() { URL = "", Results = result.Results }); }

                            result = CheckBuckets(sRequest, sb, linkBuilder);
                            if (result.Success) { scannerContext.FoundVulnerabilities.Add(new Vulnerability() { URL = "", Results = result.Results }); }

                            result = CheckSocialMedia(sRequest, sb, linkBuilder);
                            if (result.Success) { scannerContext.FoundVulnerabilities.Add(new Vulnerability() { URL = "", Results = result.Results }); }

                            result = CheckServices(sRequest, sb, linkBuilder);
                            if (result.Success) { scannerContext.FoundVulnerabilities.Add(new Vulnerability() { URL = "", Results = result.Results }); }

                            result = CheckDefaultpages(sRequest, sb, linkBuilder);
                            if (result.Success) { scannerContext.FoundVulnerabilities.Add(new Vulnerability() { URL = "", Results = result.Results }); }

                            result = CheckIndexOf(sRequest, sb, linkBuilder);
                            if (result.Success) { scannerContext.FoundVulnerabilities.Add(new Vulnerability() { URL = "", Results = result.Results }); }

                            foreach (var script in request.Response.Scripts)
                            {
                                ScannerRequest scriptRequest = new ScannerRequest();
                                scriptRequest.Body = script.Value;
                                scriptRequest.URL = script.Key;

                                result = CheckBuckets(scriptRequest, sb, linkBuilder);
                                if (result.Success) { scannerContext.FoundVulnerabilities.Add(new Vulnerability() { URL = "", Results = result.Results }); }
                            }
                        }
                        else
                        {
                            // CheckBigIPService(request, sb);
                        }
                    }

                    //CheckForFileType(request.Address, sb, "swf", linkBuilder);
                    //result = CheckForFileType(request.Address, sb, "php", linkBuilder);
                    //if (result.Success) { scannerContext.FoundVulnerabilities.Add(new Vulnerability() { URL = "", Results = result.Results }); }

                    //result = CheckForFileType(request.Address, sb, "xml", linkBuilder);
                    //if (result.Success) { scannerContext.FoundVulnerabilities.Add(new Vulnerability() { URL = "", Results = result.Results }); }

                    //result = CheckForFileType(request.Address, sb, "conf", linkBuilder);
                    //if (result.Success) { scannerContext.FoundVulnerabilities.Add(new Vulnerability() { URL = "", Results = result.Results }); }

                    //result = CheckForFileType(request.Address, sb, "env", linkBuilder);
                    //if (result.Success) { scannerContext.FoundVulnerabilities.Add(new Vulnerability() { URL = "", Results = result.Results }); }

                    result = CheckPHPInfo(sRequest, sb, linkBuilder);
                    if (result.Success) { scannerContext.FoundVulnerabilities.Add(new Vulnerability() { URL = "", Results = result.Results }); }

                    result = CheckKnownAttackFiles(sRequest, sb, linkBuilder);
                    if (result.Success) { scannerContext.FoundVulnerabilities.Add(new Vulnerability() { URL = "", Results = result.Results }); }

                    result = CheckCRLF(sRequest, sb, linkBuilder);
                    if (result.Success) { scannerContext.FoundVulnerabilities.Add(new Vulnerability() { URL = "", Results = result.Results }); }

                    result = CheckCSP(sRequest, sb, linkBuilder);
                    if (result.Success) { scannerContext.FoundVulnerabilities.Add(new Vulnerability() { URL = "", Results = result.Results }); }

                    result = CheckHeaders(sRequest, sb);
                    if (result.Success) { scannerContext.FoundVulnerabilities.Add(new Vulnerability() { URL = "", Results = result.Results }); }
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                sb.Append("!!!!!Exception: " + ex.Message + " Inner: "+inner + " Stack: " +ex.StackTrace);
            }
            Log(sb.ToString());
            LogLinks(linkBuilder.ToString());
            
            if(signalEnd)
                _countdown.Signal();

        }


        private static void SendEmail(string subject, string body)
        {
            var fromAddress = new MailAddress("hogarth45scanners@gmail.com", Settings.ServerName);
            var toAddress = new MailAddress("hogarth45@gmail.com", "To Name");
     
            MailGun.Blast(subject, body, fromAddress, toAddress, Settings.EmailPassword);
        }

        #region
        private ScannerResult CheckEngine(ScannerRequest request, StringBuilder sb, StringBuilder linkBuilder = null)
        {
            ScannerResult result = SubdomainTakeover.Check(request);

            if (result.Success)
            {
                sb.Append("\tEngine Found! " + result.Results.First() + "! Email sent." + Environment.NewLine);
                SendEmail("Subdomain takeover", request.URL + " appears to have an open instance of " + result.Results.First());
                if (linkBuilder != null)
                    linkBuilder.Append(request.URL + Environment.NewLine);
            }
            else
            {
                sb.Append("\tNo engine found." + Environment.NewLine);
            }

            return result;
        }

        private void CheckBigIPService(WebPageRequest request, StringBuilder sb, StringBuilder linkBuilder = null)
        {
            //to be checked only if it base directroy / times out
            //https://twitter.com/_ayoubfathi_/status/1039070515690844160

            bool bigIP = BigIP.Check(request.Address);

            if (bigIP)
            {
                sb.Append("\tBig IP Service Found! " + request.Address+"/my.service" + " Email sent." + Environment.NewLine);
                SendEmail("Big IP Service Found", request.Address + " appears to have a Big IP service running at " + request.Address+"/my.service");
                if (linkBuilder != null)
                    linkBuilder.Append(request.Address + Environment.NewLine);
            }
            else
            {
                sb.Append("\tNo engine found." + Environment.NewLine);
            }

        }

        private ScannerResult CheckBuckets(ScannerRequest request, StringBuilder sb, StringBuilder linkBuilder = null)
        {
            ScannerResult result = S3Bucket.BucketCheck(request);

            if (result.Success)
            {
                sb.Append("\tUnclaimed S3 Buckets Found! " + String.Join(", ", result.Results.ToArray()) + "! Email sent." + Environment.NewLine);
                SendEmail("Unclaimed  S3 Buckets Used", request.URL + " appears to use buckets " + String.Join(", " + Environment.NewLine, result.Results.ToArray()));
                if (linkBuilder != null)
                    linkBuilder.Append(request.URL + Environment.NewLine);
            }
            else
            {
                sb.Append("\tNo Unclaimed S3 buckets found." + Environment.NewLine);
            }

            return result;
        }

        private ScannerResult CheckHeaders(ScannerRequest request, StringBuilder sb, StringBuilder linkBuilder = null)
        {
            request.LogDir = Settings.LogDir;
            ScannerResult result = Headers.Check(request);

            if (result.Success)
            {
                sb.Append("\tHeader attacks found! " + String.Join(", " + Environment.NewLine, result.Results.ToArray()) + "! Email sent." + Environment.NewLine);
                SendEmail("Header attacks found", request.URL + " appears to be vulnerable to header attacks " + String.Join(Environment.NewLine, result.Results.ToArray()));
                if (linkBuilder != null)
                {
                    linkBuilder.Append(String.Join(Environment.NewLine, result.Results.ToArray()) + Environment.NewLine);
                }
            }
            else
            {
                sb.Append("\tNo header attacks found." + Environment.NewLine);
            }

            return result;
        }

        private ScannerResult CheckSocialMedia(ScannerRequest request, StringBuilder sb, StringBuilder linkBuilder = null)
        {
            ScannerResult result = SocialMedia.Check(request);

            if (result.Success)
            {
                sb.Append("\tDormant social media accounts found! " + String.Join(", " + Environment.NewLine, result.Results.ToArray()) + "! Email sent." + Environment.NewLine);
                SendEmail("Dormant Social Media Used", request.URL + " appears to use dormant social media accounts " + String.Join(Environment.NewLine, result.Results.ToArray()));
                if (linkBuilder != null)
                {
                    linkBuilder.Append(String.Join(Environment.NewLine, result.Results.ToArray()) + Environment.NewLine);
                }
            }
            else
            {
                sb.Append("\tNo dormant social media accounts found." + Environment.NewLine);
            }

            return result;
        }

        private ScannerResult CheckServices(ScannerRequest request, StringBuilder sb, StringBuilder linkBuilder = null)
        {
            ScannerResult result = Services.Check(request);

            if (result.Success)
            {
                sb.Append("\tService Exposure Found! " + result.Results.First() + "! Email sent." + Environment.NewLine);
                SendEmail("Exposed Service", request.URL + " appears to have an exposed service of " + result.Results.First());
                if (linkBuilder != null)
                    linkBuilder.Append(request.URL + Environment.NewLine);
            }
            else
            {
                sb.Append("\tNo exposed services found." + Environment.NewLine);
            }

            return result;
        }

        private ScannerResult CheckDefaultpages(ScannerRequest request, StringBuilder sb, StringBuilder linkBuilder = null)
        {

            ScannerResult result = DefaultPage.Check(request);

            if (result.Success)
            {
                sb.Append("\tDefault Page Found! " + result.Results.First() + "! Email sent." + Environment.NewLine);
                SendEmail("\tDefault Page", request.URL + " appears to have a default page for " + result.Results.First());
                if (linkBuilder != null)
                    linkBuilder.Append(request.URL + Environment.NewLine);
            }
            else
            {
                sb.Append("\tNo default pages found."+Environment.NewLine);
            }

            return result;
        }

        private ScannerResult CheckPHPInfo(ScannerRequest request, StringBuilder sb, StringBuilder linkBuilder = null)
        {
            ScannerResult result = PHPInfo.Check(request);

            if (result.Success)
            {
                sb.Append("\tPHP Info Found! " + result.Results.First() + "! Email sent." + Environment.NewLine);
                SendEmail("\tPHP Info Found ", result.Results.First() + " appears to have an exposed phpinfo()");
                if (linkBuilder != null)
                    linkBuilder.Append(result.Results.First() + Environment.NewLine);
            }
            else
            {
                sb.Append("\tNo phpinfo pages found." + Environment.NewLine);
            }

            return result;
        }

        private ScannerResult CheckForFileType(string url, StringBuilder sb, string fileExtension, StringBuilder linkBuilder = null)
        {
            ScannerResult result = new ScannerResult();
            try
            {
                CrawlRequest request = new CrawlRequest();
                request.FileType = fileExtension;
                request.Address = url.Trim('/').Replace("https://", "").Replace("http://", "");
                request.Limit = 50;
                request.FindAll = true;
                List<string> info = Crawler.SearchFileType(request, true);

                if (info.Count != 0)
                {
                    result.Success = true;
                    sb.Append("\t"+fileExtension+" Files Found! " + info + "! Email sent." + Environment.NewLine);
                    SendEmail("\t" + fileExtension + " Files Found ", url + " appears to have " + fileExtension + " files: " + Environment.NewLine + String.Join(Environment.NewLine, info.ToArray()));
                    result.Results.AddRange(info);
                    if (linkBuilder != null)
                    {
                        linkBuilder.Append(String.Join(Environment.NewLine, info.ToArray()) + Environment.NewLine);
                    }
                }
                else
                {
                    sb.Append("\tNo " + fileExtension + " files found." + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File finder exception: " + ex.Message);
            }

            return result;
        }

        private ScannerResult CheckIndexOf(ScannerRequest request, StringBuilder sb, StringBuilder linkBuilder = null)
        {
            ScannerResult result = IndexOf.Check(request);

            if (result.Success)
            {
                sb.Append("\tDirectory Traversal Found! " + request.URL + "! Email sent." + Environment.NewLine);
                SendEmail("\tDirectory Traversal Found", request.URL + " appears to have directory traversal enabled.");
                if (linkBuilder != null)
                {
                    linkBuilder.Append(request.URL + Environment.NewLine);
                }
            }
            else
            {
                sb.Append("\tNo directory traversal found." + Environment.NewLine);
            }

            return result;
        }

        private ScannerResult CheckKnownAttackFiles(ScannerRequest request, StringBuilder sb, StringBuilder linkBuilder = null)
        {
            ScannerResult result = KnownAttackFiles.Check(request);

            if (result.Success)
            {
                sb.Append("\tKnown Attack Files Found! " + request.URL + "! Email sent." + Environment.NewLine + Environment.NewLine + (String.Join(Environment.NewLine, result.Results.ToArray())));
                SendEmail("\tKnown Attack Files Found ", request.URL + " appears to have known attack files: " + Environment.NewLine + (String.Join(Environment.NewLine, result.Results.ToArray())));
                if (linkBuilder != null)
                {
                    linkBuilder.Append(String.Join(Environment.NewLine, result.Results.ToArray()) + Environment.NewLine);
                }
            }
            else
            {
                sb.Append("\tNo known attack files found." + Environment.NewLine);
            }

            return result;
        }

        private ScannerResult CheckCRLF(ScannerRequest request, StringBuilder sb, StringBuilder linkBuilder = null)
        {
            ScannerResult result = CRLF.Check(request);

            if (result.Success)
            {
                sb.Append("\tCRLF Attack Found! " + request.URL + "! Email sent." + result.Results.First());
                SendEmail("\tCRLF Attack Found ", request.URL + " appears to have known attack files: " + Environment.NewLine + result.Results.First());
                if (linkBuilder != null)
                {
                    linkBuilder.Append(String.Join(Environment.NewLine, result.Results.ToArray()) + Environment.NewLine);
                }
            }
            else
            {
                sb.Append("\tNo CRLF found." + Environment.NewLine);
            }

            return result;
        }

        private ScannerResult CheckCSP(ScannerRequest request, StringBuilder sb, StringBuilder linkBuilder = null)
        {
            ScannerResult result = ContentSecurityPolicy.Check(request);

            if (result.Success)
            {
                sb.Append("\tCSP Vulnerability Found! " + request.URL + "! Email sent." + result.Results.First());
                SendEmail("\tCSP Vulnerability Found ", request.URL + " appears to have unclaimed CSP URLS: " + Environment.NewLine + result.Results.First());
                if (linkBuilder != null)
                {
                    linkBuilder.Append(String.Join(Environment.NewLine, result.Results.ToArray()) + Environment.NewLine);
                }
            }
            else
            {
                sb.Append("\tNo CSP found." + Environment.NewLine);
            }

            return result;
        }
        #endregion

        #region Testing Buttons
        private void _btnHeadersTest_Click(object sender, EventArgs e)
        {
            string address = _txtDomain.Text;
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append("Starting Headers Test : " + address + Environment.NewLine);
                ScannerRequest sRequest = new ScannerRequest();
                sRequest.URL = address;
                sRequest.Domain = DomainUtility.GetDomainFromUrl(address);
                sRequest.LogDir = Settings.LogDir;

                CheckHeaders(sRequest, sb);
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                sb.Append("!!!!!Exception: " + ex.Message + " Inner: " + inner);
            }
            LogTest(sb.ToString());
        }

        private void _btnS3Test_Click(object sender, EventArgs e)
        {
            //http://blackdoorsec.net/s3.html
            string address = _txtDomain.Text;
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append("Starting S3 Test : " + address + Environment.NewLine);
                WebPageRequest request = new WebPageRequest();
                request.Address = address;

                WebPageLoader.Load(request);

                if (request.Response.Body.Equals(String.Empty) && request.Response.TimeOut == false)
                {
                    sb.Append("\tNo body found." + Environment.NewLine);
                }
                else
                {
                    ScannerRequest sRequest = new ScannerRequest();
                    sRequest.Body = request.Response.Body;
                    sRequest.URL = address;
                    sRequest.Domain = DomainUtility.GetDomainFromUrl(address);

                    sb.Append("\tBody found." + Environment.NewLine);
                    if (request.Response.TimeOut == false)
                    {
                        CheckBuckets(sRequest, sb);
       
                    }
                    else
                    {
                        sb.Append("\tTimed out"+Environment.NewLine);
                    }

                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                sb.Append("!!!!!Exception: " + ex.Message + " Inner: " + inner);
            }
            LogTest(sb.ToString());
        }

        private void _btnSocialMediaTest_Click(object sender, EventArgs e)
        {
            string address = _txtDomain.Text;
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append("Starting Social Media Test : " + address + Environment.NewLine);
                WebPageRequest request = new WebPageRequest();
                request.Address = address;

                WebPageLoader.Load(request);

                if (request.Response.Body.Equals(String.Empty) && request.Response.TimeOut == false)
                {
                    sb.Append("\tNo body found." + Environment.NewLine);
                }
                else
                {
                    sb.Append("\tBody found." + Environment.NewLine);
                    if (request.Response.TimeOut == false)
                    {
                        ScannerRequest sRequest = new ScannerRequest();
                        sRequest.Body = request.Response.Body;
                        sRequest.URL = address;
                        sRequest.Domain = DomainUtility.GetDomainFromUrl(address);
              
                        CheckSocialMedia(sRequest, sb);
    
                    }
                    else
                    {
                        sb.Append("\tTimed out" + Environment.NewLine);
      
                    }

                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                sb.Append("!!!!!Exception: " + ex.Message + " Inner: " + inner);
            }
            LogTest(sb.ToString());
        }

        private void _btnSubdomainTakeoverTest_Click(object sender, EventArgs e)
        {
            string address = _txtDomain.Text;
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append("Starting Subdomain Takeover Test : " + address + Environment.NewLine);
                WebPageRequest request = new WebPageRequest();
                request.Address = address;

                WebPageLoader.Load(request);

                if (request.Response.Body.Equals(String.Empty) && request.Response.TimeOut == false)
                {
                    sb.Append("\tNo body found." + Environment.NewLine);
                }
                else
                {
                    ScannerRequest sRequest = new ScannerRequest();
                    sRequest.Body = request.Response.Body;
                    sRequest.URL = address;
                    sRequest.Domain = DomainUtility.GetDomainFromUrl(address);

                    sb.Append("\tBody found." + Environment.NewLine);
                    if (request.Response.TimeOut == false)
                    {
                        CheckEngine(sRequest, sb);

                    }
                    else
                    {
                        sb.Append("\tTimed out" + Environment.NewLine);
                        //    CheckBigIPService(request, sb);
                    }

   
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                sb.Append("!!!!!Exception: " + ex.Message + " Inner: " + inner);
            }
            LogTest(sb.ToString());
        }

        private void _btnPHPInfoTest_Click(object sender, EventArgs e)
        {
            string address = _txtDomain.Text;
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append("Starting PHP Info Test : " + address + Environment.NewLine);
                WebPageRequest request = new WebPageRequest();
                request.Address = address;

                WebPageLoader.Load(request);

                if (request.Response.Body.Equals(String.Empty) && request.Response.TimeOut == false)
                {
                    sb.Append("\tNo body found." + Environment.NewLine);
                }

                ScannerRequest sRequest = new ScannerRequest();
                sRequest.Body = request.Response.Body;
                sRequest.URL = address;
                sRequest.Domain = DomainUtility.GetDomainFromUrl(address);

                CheckPHPInfo(sRequest, sb);

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                sb.Append("!!!!!Exception: " + ex.Message + " Inner: " + inner);
            }
            LogTest(sb.ToString());
        }

        private void _btnDefaultTest_Click(object sender, EventArgs e)
        {
            string address = _txtDomain.Text;
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append("Starting PHP Info Test : " + address + Environment.NewLine);
                WebPageRequest request = new WebPageRequest();
                request.Address = address;

                WebPageLoader.Load(request);

                if (request.Response.Body.Equals(String.Empty) && request.Response.TimeOut == false)
                {
                    sb.Append("\tNo body found." + Environment.NewLine);
                }
                else
                {
                    ScannerRequest sRequest = new ScannerRequest();
                    sRequest.Body = request.Response.Body;
                    sRequest.URL = address;
                    sRequest.Domain = DomainUtility.GetDomainFromUrl(address);

                    sb.Append("\tBody found." + Environment.NewLine);
                    if (request.Response.TimeOut == false)
                    {
                        CheckDefaultpages(sRequest, sb);
                    }
                    else
                    {
                        sb.Append("\tTimed out" + Environment.NewLine);
                    }

                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                sb.Append("!!!!!Exception: " + ex.Message + " Inner: " + inner);
            }
            LogTest(sb.ToString());
        }

        private void _btnServicesTest_Click(object sender, EventArgs e)
        {
            string address = _txtDomain.Text;
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append("Starting PHP Info Test : " + address + Environment.NewLine);
                WebPageRequest request = new WebPageRequest();
                request.Address = address;

                WebPageLoader.Load(request);

                if (request.Response.Body.Equals(String.Empty) && request.Response.TimeOut == false)
                {
                    sb.Append("\tNo body found." + Environment.NewLine);
                }
                else
                {
                    ScannerRequest sRequest = new ScannerRequest();
                    sRequest.Body = request.Response.Body;
                    sRequest.URL = address;
                    sRequest.Domain = DomainUtility.GetDomainFromUrl(address);

                    sb.Append("\tBody found." + Environment.NewLine);
                    if (request.Response.TimeOut == false)
                    {
                        CheckServices(sRequest, sb);

                    }
                    else
                    {
                        sb.Append("\tTimed out" + Environment.NewLine);
                    }

                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                sb.Append("!!!!!Exception: " + ex.Message + " Inner: " + inner);
            }
            LogTest(sb.ToString());
        }

        private void _btnWebArchiveTest_Click(object sender, EventArgs e)
        {
            string address = _txtDomain.Text;
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append("Starting WebArchive Test: " + address + Environment.NewLine);
                WebPageRequest request = new WebPageRequest();
                request.Address = address;

              //  WebPageLoader.Load(request);

                CheckForFileType(request.Address, sb, "html");
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                sb.Append("!!!!!Exception: " + ex.Message + " Inner: " + inner);
            }
            LogTest(sb.ToString());
        }

        private void _btnDirectoryTraversal_Click(object sender, EventArgs e)
        {
            string address = _txtDomain.Text;
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append("Starting PHP Info Test : " + address + Environment.NewLine);
                WebPageRequest request = new WebPageRequest();
                request.Address = address;

                WebPageLoader.Load(request);

                if (request.Response.Body.Equals(String.Empty) && request.Response.TimeOut == false)
                {
                    sb.Append("\tNo body found." + Environment.NewLine);
                }
                else
                {
                    sb.Append("\tBody found." + Environment.NewLine);

                    ScannerRequest sRequest = new ScannerRequest();
                    sRequest.Body = request.Response.Body;
                    sRequest.URL = address;

                    sRequest.Domain = DomainUtility.GetDomainFromUrl(address);
                    CheckIndexOf(sRequest, sb);
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                sb.Append("!!!!!Exception: " + ex.Message + " Inner: " + inner);
            }
            LogTest(sb.ToString());
        }

        private void _btnCRLFTest_Click(object sender, EventArgs e)
        {
            string address = _txtDomain.Text;
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append("Starting CRLF Attacks: " + address + Environment.NewLine);
                WebPageRequest request = new WebPageRequest();
                request.Address = address;

                WebPageLoader.Load(request);

                if (request.Response.Body.Equals(String.Empty) && request.Response.TimeOut == false)
                {
                    sb.Append("\tNo body found." + Environment.NewLine);
                }
                else
                {
                    sb.Append("\tBody found." + Environment.NewLine);

                }

                ScannerRequest sRequest = new ScannerRequest();
                sRequest.Body = request.Response.Body;
                sRequest.URL = address;
                sRequest.Domain = DomainUtility.GetDomainFromUrl(address);

                CheckCRLF(sRequest, sb);

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                sb.Append("!!!!!Exception: " + ex.Message + " Inner: " + inner);
            }
            LogTest(sb.ToString());
        }

        private void _btnKnownAttackTest_Click(object sender, EventArgs e)
        {
            string address = _txtDomain.Text;
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append("Starting Known Attack Files: " + address + Environment.NewLine);
                WebPageRequest request = new WebPageRequest();
                request.Address = address;

                WebPageLoader.Load(request);

                if (request.Response.Body.Equals(String.Empty) && request.Response.TimeOut == false)
                {
                    sb.Append("\tNo body found." + Environment.NewLine);
                }
                else
                {
                    sb.Append("\tBody found." + Environment.NewLine);

                }

                ScannerRequest sRequest = new ScannerRequest();
                sRequest.Body = request.Response.Body;
                sRequest.URL = address;
                sRequest.Domain = DomainUtility.GetDomainFromUrl(address);

                CheckKnownAttackFiles(sRequest, sb);

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                sb.Append("!!!!!Exception: " + ex.Message + " Inner: " + inner);
            }
            LogTest(sb.ToString());
        }

        private void _buttonCSPTest_Click(object sender, EventArgs e)
        {
            string address = _txtDomain.Text;
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append("Starting CSP Check: " + address + Environment.NewLine);

                ScannerRequest sRequest = new ScannerRequest();
                sRequest.URL = address;
                sRequest.Domain = DomainUtility.GetDomainFromUrl(address);

                CheckCSP(sRequest, sb);

            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                sb.Append("!!!!!Exception: " + ex.Message + " Inner: " + inner);
            }
            LogTest(sb.ToString());
        }
        #endregion

        #region Test Subdomain
        private void _btnFindSubomainsTest_Click(object sender, EventArgs e)
        {
            string domain = _txtDomain.Text;

            StringBuilder sb = new StringBuilder();
            sb.Append("Testing findsubdomains.com...");
            List<string> subDomains = Hunter.Gather_FindSubdomains(domain);
            sb.Append("Subdomains found: " + subDomains.Count);
            foreach (string sub in subDomains.Take(5))
            {
                sb.Append(sub+Environment.NewLine);
            }

            LogTest(sb.ToString());
        }


        private void _btnNetcraftTest_Click(object sender, EventArgs e)
        {
            string domain = _txtDomain.Text;

            StringBuilder sb = new StringBuilder();
            sb.Append("Testing netcraft.com...");
            List<string> subDomains = Hunter.Gather_NetCraft(domain);
            sb.Append("Subdomains found: " + subDomains.Count);
            foreach (string sub in subDomains.Take(5))
            {
                sb.Append(sub + Environment.NewLine);
            }

            LogTest(sb.ToString());
        }

        private void _btnSecTrailsTest_Click(object sender, EventArgs e)
        {
            string domain = _txtDomain.Text;

            StringBuilder sb = new StringBuilder();
            sb.Append("Testing Security Trails API...");
            List<string> subDomains = Hunter.Gather_SecurityTrails(domain, Settings.SecurityTrailsAPI);
            sb.Append("Subdomains found: " + subDomains.Count);
            foreach (string sub in subDomains.Take(5))
            {
                sb.Append(sub + Environment.NewLine);
            }

            LogTest(sb.ToString());
        }

        #endregion

        #region Database Tests
        private void _btnDatabaseConnectivityTest_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            MySqlConnection conn = null;
            try
            {
                conn = DatabaseManager.GetConnection();
                sb.Append("Testing..." + Environment.NewLine);
                sb.Append(conn.ConnectionString + Environment.NewLine);
                conn.Open();
                sb.Append("Looks Good!");
            }
            catch (ArgumentException a_ex)
            {
                sb.Append("Check the Connection String." + Environment.NewLine);
                sb.Append(a_ex.Message);
            }
            catch (MySqlException ex)
            {
                /*string sqlErrorMessage = "Message: " + ex.Message + "\n" +
                "Source: " + ex.Source + "\n" +
                "Number: " + ex.Number;
                Console.WriteLine(sqlErrorMessage);
                */
                switch (ex.Number)
                {
                    //http://dev.mysql.com/doc/refman/5.0/en/error-messages-server.html
                    case 1042:
                        sb.Append("Unable to connect to any of the specified MySQL hosts (Check Server,Port)" + Environment.NewLine);
                        break;
                    case 0:
                        sb.Append("Access denied (Check DB name,username,password)" + Environment.NewLine);
                        break;
                    default:
                        sb.Append(ex.Message);
                        break;
                }
            }
            catch (Exception ex)
            {
                sb.Append("Some unknown error occurred."+Environment.NewLine);
                sb.Append(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            LogTest(sb.ToString());
        }

        #endregion

        private void _btnTestEmail_Click(object sender, EventArgs e)
        {
            SendEmail("test email", "test body");
        }
    }
}
