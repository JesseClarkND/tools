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

namespace AlternateTerritory
{
    public partial class Form1 : Form
    {
        private static int _threadCount=20;
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
            TextFileLogger.Log(Settings.LogDir, DateTime.Now.ToString("yyyy-MM-dd") + ".txt", log); 
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

                Log("========================");
                Log("Starting " + domain + " at "+DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                Log("========================");

                List<string> knownSubdomains = new List<string>();
                string existingFile = Path.Combine(Settings.ExistingDir, domain.Replace(".","")+".txt");
                if(File.Exists(existingFile))
                    knownSubdomains = File.ReadAllLines(existingFile).ToList();

                List<string> subDomains = new List<string>();

                if (System.IO.File.GetLastWriteTime(existingFile) > DateTime.Now.AddDays(-7) && knownSubdomains.Count != 0)
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
                sb.Append("Checking: " + address + Environment.NewLine);
                WebPageRequest request = new WebPageRequest();
                request.Address = address;

                WebPageLoader.Load(request);

                if (request.Response.Body.Equals(String.Empty) && request.Response.TimeOut == false)
                {
                    sb.Append("\tNo body found." + Environment.NewLine);
                }
                else
                {
                    if (request.Response.TimeOut == false)
                    {
                        CheckEngine(request, sb, linkBuilder);
                        CheckBuckets(request, sb, linkBuilder);
                        CheckSocialMedia(request, sb, linkBuilder);
                        CheckServices(request, sb, linkBuilder);
                        CheckDefaultpages(request, sb, linkBuilder);
                        CheckIndexOf(request, sb, linkBuilder);
                    }
                    else
                    {
                        // CheckBigIPService(request, sb);
                    }
                }

                //CheckForFileType(request.Address, sb, "swf", linkBuilder);
                CheckForFileType(request.Address, sb, "php", linkBuilder);
                CheckForFileType(request.Address, sb, "xml", linkBuilder);
                CheckForFileType(request.Address, sb, "conf", linkBuilder);
                CheckForFileType(request.Address, sb, "env", linkBuilder);
                CheckPHPInfo(request.Address, sb, linkBuilder);
                CheckKnownAttackFiles(request.Address, sb, linkBuilder);
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
        private void CheckEngine(WebPageRequest request, StringBuilder sb, StringBuilder linkBuilder = null)
        {
            string engine = SubdomainTakeover.Check(request.Response.Body);

            if (!String.IsNullOrEmpty(engine))
            {
                sb.Append("\tEngine Found! " + engine + "! Email sent." + Environment.NewLine);
                SendEmail("Subdomain takeover", request.Address + " appears to have an open instance of " + engine);
                if (linkBuilder != null)
                    linkBuilder.Append(request.Address + Environment.NewLine);
            }
            else
            {
                sb.Append("\tNo engine found." + Environment.NewLine);
            }
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

        private void CheckBuckets(WebPageRequest request, StringBuilder sb, StringBuilder linkBuilder = null)
        {
            List<string> buckets = S3Bucket.BucketCheck(request.Response.Body);

            if (buckets.Count != 0)
            {
                sb.Append("\tUnclaimed S3 Buckets Found! " + String.Join(", ", buckets.ToArray()) + "! Email sent." + Environment.NewLine);
                SendEmail("Unclaimed  S3 Buckets Used", request.Address + " appears to use buckets " + String.Join(", " + Environment.NewLine, buckets.ToArray()));
                if (linkBuilder != null)
                    linkBuilder.Append(request.Address + Environment.NewLine);
            }
            else
            {
                sb.Append("\tNo Unclaimed S3 buckets found." + Environment.NewLine);
            }

            foreach (KeyValuePair<string, string> kvp in request.Response.Scripts)
            {
                buckets = S3Bucket.BucketCheck(kvp.Value);

                if (buckets.Count != 0)
                {
                    sb.Append("\tS3 Buckets Found! " + String.Join(", ", buckets.ToArray()) + "! Email sent." + Environment.NewLine);
                    SendEmail("S3 Buckets Used", kvp.Key + " appears to use buckets " + String.Join(Environment.NewLine, buckets.ToArray()));
                    if (linkBuilder != null)
                        linkBuilder.Append(String.Join(Environment.NewLine, buckets.ToArray()) + Environment.NewLine);
                }
                else
                {
                    sb.Append("\tNo S3 buckets found." + Environment.NewLine);
                }

            }
        }

        private void CheckSocialMedia(WebPageRequest request, StringBuilder sb, StringBuilder linkBuilder = null)
        {
            List<string> socialMedia = SocialMedia.Check(request.Response.Body);

            if (socialMedia.Count != 0)
            {
                sb.Append("\tDormant social media accounts found! " + String.Join(", " + Environment.NewLine, socialMedia.ToArray()) + "! Email sent." + Environment.NewLine);
                SendEmail("Dormant Social Media Used", request.Address + " appears to use dormant social media accounts " + String.Join(Environment.NewLine, socialMedia.ToArray()));
                if (linkBuilder != null)
                {
                    linkBuilder.Append(String.Join(Environment.NewLine, socialMedia.ToArray()) + Environment.NewLine);
                }
            }
            else
            {
                sb.Append("\tNo dormant social media accounts found." + Environment.NewLine);
            }
        }

        private void CheckServices(WebPageRequest request, StringBuilder sb, StringBuilder linkBuilder = null)
        {
            string service = Services.Check(request.Response.Body);

            if (!String.IsNullOrEmpty(service))
            {
                sb.Append("\tService Exposure Found! " + service + "! Email sent." + Environment.NewLine);
                SendEmail("Exposed Service", request.Address + " appears to have an exposed service of " + service);
                if (linkBuilder != null)
                    linkBuilder.Append(request.Address + Environment.NewLine);
            }
            else
            {
                sb.Append("\tNo exposed services found." + Environment.NewLine);
            }
        }

        private void CheckDefaultpages(WebPageRequest request, StringBuilder sb, StringBuilder linkBuilder = null)
        {
            string defaultPage = DefaultPage.Check(request.Response.Body);

            if (!String.IsNullOrEmpty(defaultPage))
            {
                sb.Append("\tDefault Page Found! " + defaultPage + "! Email sent." + Environment.NewLine);
                SendEmail("\tDefault Page", request.Address + " appears to have a default page for " + defaultPage);
                if (linkBuilder != null)
                    linkBuilder.Append(request.Address + Environment.NewLine);
            }
            else
            {
                sb.Append("\tNo default pages found."+Environment.NewLine);
            }
        }

        private void CheckPHPInfo(string url, StringBuilder sb, StringBuilder linkBuilder = null)
        {
            string phpInfo = PHPInfo.Check(url);

            if (!String.IsNullOrEmpty(phpInfo))
            {
                sb.Append("\tPHP Info Found! " + phpInfo + "! Email sent." + Environment.NewLine);
                SendEmail("\tPHP Info Found ", phpInfo + " appears to have an exposed phpinfo()");
                if (linkBuilder != null)
                    linkBuilder.Append(phpInfo + Environment.NewLine);
            }
            else
            {
                sb.Append("\tNo phpinfo pages found." + Environment.NewLine);
            }
        }

        private void CheckForFileType(string url, StringBuilder sb, string fileExtension, StringBuilder linkBuilder = null)
        {
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
                    sb.Append("\t"+fileExtension+" Files Found! " + info + "! Email sent." + Environment.NewLine);
                    SendEmail("\t" + fileExtension + " Files Found ", url + " appears to have " + fileExtension + " files: " + Environment.NewLine + String.Join(Environment.NewLine, info.ToArray()));
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
        }

        private void CheckIndexOf(WebPageRequest request, StringBuilder sb, StringBuilder linkBuilder = null)
        {
            bool indexOf = IndexOf.Check(request.Response.Body);

            if (indexOf)
            {
                sb.Append("\tDirectory Traversal Found! " + request.Address + "! Email sent." + Environment.NewLine);
                SendEmail("\tDirectory Traversal Found", request.Address + " appears to have directory traversal enabled.");
                if (linkBuilder != null)
                {
                    linkBuilder.Append(request.Address + Environment.NewLine);
                }
            }
            else
            {
                sb.Append("\tNo directory traversal found." + Environment.NewLine);
            }
        }

        private void CheckKnownAttackFiles(string url, StringBuilder sb, StringBuilder linkBuilder = null)
        {
            List<string> attackFiles = KnownAttackFiles.Check(url);

            if (attackFiles.Count!=0)
            {
                sb.Append("\tKnown Attack Files Found! " + url + "! Email sent." + Environment.NewLine + Environment.NewLine + (String.Join(Environment.NewLine, attackFiles.ToArray())));
                SendEmail("\tKnown Attack Files Found ", url + " appears to have known attack files: "+Environment.NewLine +(String.Join(Environment.NewLine, attackFiles.ToArray())));
                if (linkBuilder != null)
                {
                    linkBuilder.Append(String.Join(Environment.NewLine, attackFiles.ToArray()) + Environment.NewLine);
                }
            }
            else
            {
                sb.Append("\tNo known attack files found." + Environment.NewLine);
            }
        }

        #endregion

        #region Testing Buttons
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
                    sb.Append("\tBody found." + Environment.NewLine);
                    if (request.Response.TimeOut == false)
                    {
                    //    CheckEngine(request, sb);
                        CheckBuckets(request, sb);
                    //    CheckSocialMedia(request, sb);
                    //    CheckServices(request, sb);
                    //    CheckDefaultpages(request, sb);
                    }
                    else
                    {
                        sb.Append("\tTimed out"+Environment.NewLine);
                    //    CheckBigIPService(request, sb);
                    }

                    //CheckPHPInfo(request.Address, sb);
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
                        //    CheckEngine(request, sb);
                        // CheckBuckets(request, sb);
                        CheckSocialMedia(request, sb);
                        //    CheckServices(request, sb);
                        //    CheckDefaultpages(request, sb);
                    }
                    else
                    {
                        sb.Append("\tTimed out" + Environment.NewLine);
                        //    CheckBigIPService(request, sb);
                    }

                    //CheckPHPInfo(request.Address, sb);
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
                    sb.Append("\tBody found." + Environment.NewLine);
                    if (request.Response.TimeOut == false)
                    {
                        CheckEngine(request, sb);
                        //CheckBuckets(request, sb);
                        //CheckSocialMedia(request, sb);
                        //    CheckServices(request, sb);
                        //    CheckDefaultpages(request, sb);
                    }
                    else
                    {
                        sb.Append("\tTimed out" + Environment.NewLine);
                        //    CheckBigIPService(request, sb);
                    }

                    //CheckPHPInfo(request.Address, sb);
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
                else
                {
                    sb.Append("\tBody found." + Environment.NewLine);
                    if (request.Response.TimeOut == false)
                    {
                        //CheckEngine(request, sb);
                        //CheckBuckets(request, sb);
                        //CheckSocialMedia(request, sb);
                        //    CheckServices(request, sb);
                        //    CheckDefaultpages(request, sb);
                    }
                    else
                    {
                        sb.Append("\tTimed out" + Environment.NewLine);
                        //    CheckBigIPService(request, sb);
                    }
                }

                CheckPHPInfo(request.Address, sb);

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
                    sb.Append("\tBody found." + Environment.NewLine);
                    if (request.Response.TimeOut == false)
                    {
                        //CheckEngine(request, sb);
                        //CheckBuckets(request, sb);
                        //CheckSocialMedia(request, sb);
                        //    CheckServices(request, sb);
                        CheckDefaultpages(request, sb);
                    }
                    else
                    {
                        sb.Append("\tTimed out" + Environment.NewLine);
                        //    CheckBigIPService(request, sb);
                    }

                    //CheckPHPInfo(request.Address, sb);
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
                    sb.Append("\tBody found." + Environment.NewLine);
                    if (request.Response.TimeOut == false)
                    {
                        //CheckEngine(request, sb);
                        //CheckBuckets(request, sb);
                        //CheckSocialMedia(request, sb);
                        CheckServices(request, sb);
                        //CheckDefaultpages(request, sb);
                    }
                    else
                    {
                        sb.Append("\tTimed out" + Environment.NewLine);
                        //    CheckBigIPService(request, sb);
                    }

                    //CheckPHPInfo(request.Address, sb);
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

                    CheckIndexOf(request, sb);
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

                CheckKnownAttackFiles(request.Address, sb);

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
