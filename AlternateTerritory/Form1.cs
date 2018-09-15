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

namespace AlternateTerritory
{
    public partial class Form1 : Form
    {
        private static int _threadCount=12;
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

        private void _btnStart_Click(object sender, EventArgs e)
        {
            //string domain = _txtDomain.Text;
            _btnStart.Text = "Service Started...";
            _btnStart.Enabled = false;
            List<string> domains = File.ReadAllLines(Settings.SourceFile).ToList();

            foreach (string domain in domains)
            {
                Log("========================");
                Log("Starting " + domain);
                Log("========================");

                List<string> knownSubdomains = new List<string>();
                string existingFile = Path.Combine(Settings.ExistingDir, domain.Replace(".","")+".txt");
                if(File.Exists(existingFile))
                    knownSubdomains = File.ReadAllLines(existingFile).ToList();

                List<string> subDomains = new List<string>();

                if (System.IO.File.GetLastWriteTime(existingFile) > DateTime.Now.AddHours(-48) && knownSubdomains.Count != 0)
                {
                    subDomains = knownSubdomains;
                    Log("Subdomains loaded from file: " + subDomains.Count);
                }
                else
                {
                    subDomains = Hunter.Gather(domain, knownSubdomains);
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
                        Thread th = new Thread(() => { TestDomain(chunck, true); });
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
                        CheckEngine(request, sb);
                        CheckBuckets(request, sb);
                        CheckSocialMedia(request, sb);
                        CheckServices(request, sb);
                        CheckDefaultpages(request, sb);
                    }
                    else
                    {
                        CheckBigIPService(request, sb);
                    }

                    CheckPHPInfo(request.Address, sb);
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                sb.Append("!!!!!Exception: " + ex.Message + " Inner: "+inner);
            }
            Log(sb.ToString());

            if(signalEnd)
                _countdown.Signal();
        }

        private void CheckEngine(WebPageRequest request, StringBuilder sb)
        {
            string engine = SubdomainTakeover.Check(request.Response.Body);

            if (!String.IsNullOrEmpty(engine))
            {
                sb.Append("\tEngine Found! " + engine + "! Email sent." + Environment.NewLine);
                SendEmail("Subdomain takeover", request.Address + " appears to have an open instance of " + engine);
            }
            else
            {
                sb.Append("\tNo engine found." + Environment.NewLine);
            }
        }

        private void CheckBigIPService(WebPageRequest request, StringBuilder sb)
        {
            //to be checked only if it base directroy / times out
            //https://twitter.com/_ayoubfathi_/status/1039070515690844160

            bool bigIP = BigIP.Check(request.Address);

            if (bigIP)
            {
                sb.Append("\tBig IP Service Found! " + request.Address+"/my.service" + " Email sent." + Environment.NewLine);
                SendEmail("Big IP Service Found", request.Address + " appears to have a Big IP service running at " + request.Address+"/my.service");
            }
            else
            {
                sb.Append("\tNo engine found." + Environment.NewLine);
            }

        }

        private void CheckBuckets(WebPageRequest request, StringBuilder sb)
        {
            List<string> buckets = S3Bucket.BucketCheck(request.Response.Body);

            if (buckets.Count != 0)
            {
                sb.Append("\tUnclaimed S3 Buckets Found! " + String.Join(", ", buckets.ToArray()) + "! Email sent." + Environment.NewLine);
                SendEmail("Unclaimed  S3 Buckets Used", request.Address + " appears to use buckets " + String.Join(", " + Environment.NewLine, buckets.ToArray()));
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
                    SendEmail("S3 Buckets Used", kvp.Key + " appears to use buckets " + String.Join(", " + Environment.NewLine, buckets.ToArray()));
                }
                else
                {
                    sb.Append("\tNo S3 buckets found." + Environment.NewLine);
                }

            }
        }

        private void CheckSocialMedia(WebPageRequest request, StringBuilder sb)
        {
            List<string> socialMedia = SocialMedia.Check(request.Response.Body);

            if (socialMedia.Count != 0)
            {
                sb.Append("\tDormant social media accounts found! " + String.Join(", " + Environment.NewLine, socialMedia.ToArray()) + "! Email sent." + Environment.NewLine);
                SendEmail("Dormant Social Media Used", request.Address + " appears to use dormant social media accounts " + String.Join(", " + Environment.NewLine, socialMedia.ToArray()));
            }
            else
            {
                sb.Append("\tNo dormant social media accounts found." + Environment.NewLine);
            }
        }

        private void CheckServices(WebPageRequest request, StringBuilder sb)
        {
            string service = Services.Check(request.Response.Body);

            if (!String.IsNullOrEmpty(service))
            {
                sb.Append("\tService Exposure Found! " + service + "! Email sent." + Environment.NewLine);
                SendEmail("Exposed Service", request.Address + " appears to have an exposed service of " + service);
            }
            else
            {
                sb.Append("\tNo exposed services found." + Environment.NewLine);
            }
        }

        private void CheckDefaultpages(WebPageRequest request, StringBuilder sb)
        {
            string defaultPage = Services.Check(request.Response.Body);

            if (!String.IsNullOrEmpty(defaultPage))
            {
                sb.Append("\tDefault Page Found! " + defaultPage + "! Email sent." + Environment.NewLine);
                SendEmail("\tDefault Page", request.Address + " appears to have a default page for " + defaultPage);
            }
            else
            {
                sb.Append("\tNo default pages found."+Environment.NewLine);
            }
        }

        private void CheckPHPInfo(string url, StringBuilder sb)
        {
            string phpInfo = PHPInfo.Check(url);

            if (!String.IsNullOrEmpty(phpInfo))
            {
                sb.Append("\tPHP Info Found! " + phpInfo + "! Email sent." + Environment.NewLine);
                SendEmail("\tPHP Info Found ", phpInfo + " appears to have an exposed phpinfo()");
            }
            else
            {
                sb.Append("\tNo default pages found." + Environment.NewLine);
            }
        }


        private static void SendEmail(string subject, string body) {
            var fromAddress = new MailAddress("hogarth45scanners@gmail.com", Settings.ServerName);
            var toAddress = new MailAddress("hogarth45@gmail.com", "To Name");
            string fromPassword = "hogarth45scanners@1";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }     
        }

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
            Log(sb.ToString());
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
            Log(sb.ToString());
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
            Log(sb.ToString());
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

                    CheckPHPInfo(request.Address, sb);
                }
            }
            catch (Exception ex)
            {
                string inner = "";
                if (ex.InnerException != null)
                    inner = ex.InnerException.Message;
                sb.Append("!!!!!Exception: " + ex.Message + " Inner: " + inner);
            }
            Log(sb.ToString());
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
            Log(sb.ToString());
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
            Log(sb.ToString());
        }

        #endregion
    }
}
