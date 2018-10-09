using Clark.Common.Models;
using Clark.Common.Utility;
using Clark.Domain.Component;
using Clark.Domain.Data;
using Clark.Domain.Data.Results;
using Core.MySQL.Accessor;
using DbPrimer.Forms;
using DbPrimer.Utility;
using HtmlAgilityPack;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbPrimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LogTest(string log)
        {
            _rtbLog.Text += log + Environment.NewLine;
        }

        private void _btnTestConnection_Click(object sender, EventArgs e)
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
                        break;
                }
            }
            catch (Exception ex)
            {
                sb.Append("Some unknown error occurred." + Environment.NewLine);
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

        private void _btnAddDomain_Click(object sender, EventArgs e)
        {
            _frmAddDomain form = new _frmAddDomain();
            form.Show();
        }

        private void _btnDumpDomains_Click(object sender, EventArgs e)
        {
            var controller = new DomainController();
            var result = controller.FindAll();
            foreach (var item in result.Items)
                LogTest(item.DomainName);
            LogTest("Domains dumped!");
        }

        private void _btnInitialize_Click(object sender, EventArgs e)
        {
            var controller = new DomainController();
            var result = controller.CreateTable();
            if (result.Error)
                LogTest(result.Message);

            var subdomaincontroller = new SubdomainController();
            var subdomainresult = subdomaincontroller.CreateTable();
            if (subdomainresult.Error)
                LogTest(result.Message);

            var ignorecontroller = new DomainIgnoreController();
            var ignoreresult = ignorecontroller.CreateTable();
            if (subdomainresult.Error)
                LogTest(result.Message);

            LogTest("Tables Created!");
        }

        private void _btnAddSubdomain_Click(object sender, EventArgs e)
        {
            _frmAddSubDomain form = new _frmAddSubDomain();
            form.Show();
        }

        private void _btnProgramLoad_Click(object sender, EventArgs e)
        {
            List<HackingTarget> items = JsonLoader.Load(@"C:\Alternative\Source\doc.json");
            DomainController domainController = new DomainController();
            DomainIgnoreController ignoreController = new DomainIgnoreController();
            foreach (HackingTarget item in items)
            {
                foreach (Target target in item.Targets.in_scope)
                {
                    string platform = "";
                    if (item.URL.Contains("hackerone"))
                    {
                        if (!target.asset_type.Equals("URL"))
                            continue;
                        platform = "hackerone";
                    }

                    if (item.URL.Contains("bugcrowd"))
                    {
                        //if (!target.type.Equals("website"))
                        if(!target.target.Contains("http"))
                            continue;
                        platform = "bugcrowd";
                    }

                    string domaintext = target.asset_identifier;
                    if (String.IsNullOrEmpty(domaintext))
                        domaintext = target.target;

                    domaintext = domaintext.Replace("*.", "").Replace("https://", "").Replace("http://", "").Replace("(","").Replace(")","").Split('?')[0].Split('/')[0];

                    string regex = "(\\[.*\\])|(\".*\")|('.*')|(\\(.*\\))|(<.*>)";
                    domaintext = Regex.Replace(domaintext, regex, "");

                    string[] parts = domaintext.Split('.');

                    if (parts.Length>=2)
                    {
                        int count = parts.Length - 1;
                        domaintext = parts[count - 1] + "." + parts[count];
                    }

                    Clark.Domain.Data.Domain domain = domainController.FindByDomain(domaintext);
                    if (domain == null)
                    {
                        domain = new Domain();

                        domain.Platform = platform;
                        domain.BountyURL = item.URL;
                        domain.BountyEndDate = new DateTime(2999, 12, 31);
                        domain.Private = false;
                        domain.DomainName = domaintext;
   
                        UpdateResult res = domainController.Insert(domain);
                        if (res.Error)
                            MessageBox.Show(target.asset_identifier + " error");
                    }
                }

                foreach (Target target in item.Targets.out_of_scope)
                {
                    if(!target.asset_type.Equals("URL"))
                        continue;

                    DomainIgnore ignore = ignoreController.FindByIgnoreDomain(target.asset_identifier.Replace("*.", ""));
                    if(ignore==null)
                    {
                        ignore = new DomainIgnore();

                        string domain2Ignore = target.asset_identifier;
                        domain2Ignore = domain2Ignore.Replace("*.", "").Replace("https://", "").Replace("http://", "").Replace("(", "").Replace(")", "").Split('?')[0].Split('/')[0];

                        string regex = "(\\[.*\\])|(\".*\")|('.*')|(\\(.*\\))|(<.*>)";
                        domain2Ignore = Regex.Replace(domain2Ignore, regex, "");

                        ignore.DomainToIgnore = domain2Ignore;



                        UpdateResult res = ignoreController.Insert(ignore);
                        if (res.Error)
                            MessageBox.Show(target.asset_identifier + " error");
                    }
                }
            }
        }

        private void _btnLoadText_Click(object sender, EventArgs e)
        {
            List<string> domains = File.ReadAllLines(@"C:\Alternative\Source\list.txt").ToList();

            DomainController domainController = new DomainController();

            foreach (string domaintxt in domains)
            {
                Clark.Domain.Data.Domain domain = domainController.FindByDomain(domaintxt);
                if (domain == null)
                {
                    domain = new Domain();

                    domain.Platform = "";
                    domain.BountyURL = "";
                    domain.BountyEndDate = new DateTime(2999, 12, 31);
                    domain.Private = false;
                    domain.DomainName = domaintxt;

                    domainController.Insert(domain);
                }
            }

        }

        private void _btnInitSubdomain_Click(object sender, EventArgs e)
        {
            DomainController domainController = new DomainController();
            SubdomainController subdomainController = new SubdomainController();
            DomainFindResult findResult = domainController.FindAll();

            List<string> knownSubdomains = new List<string>();
            List<string> knowndbSubdomains = new List<string>();
            foreach (Domain domainItem in findResult.Items)
            {
                string domain = domainItem.DomainName;
                string existingFile = Path.Combine(@"C:\Alternative\Existing", domain.Replace(".", "") + ".txt");
                if (File.Exists(existingFile))
                    knownSubdomains = File.ReadAllLines(existingFile).ToList();

                knownSubdomains = knownSubdomains.Select(x=>x.Replace("."+domainItem.DomainName, "")).ToList();

                SubdomainFindResult subDomainFindResult = subdomainController.FindByDomain(domainItem.DomainId);
                if(subDomainFindResult.Error)
                    MessageBox.Show(subDomainFindResult.Message);

                knowndbSubdomains = subDomainFindResult.Items.Select(x => x.SubdomainName).ToList();

                List<string> inList1ButNotList2 = (from o in knownSubdomains
                                                   join p in knowndbSubdomains on o equals p into t
                                                   from od in t.DefaultIfEmpty()
                                                   where od == null
                                                   select o).ToList<string>();

                foreach (string newItem in inList1ButNotList2)
                {
                    Subdomain sub = new Subdomain();

                    sub.DomainId = domainItem.DomainId;
                    sub.DateFound = DateTime.Now;
                    sub.FoundType = "scanner";
                    sub.SubdomainName = newItem;

                    subdomainController.Insert(sub);
                }
            }
        }

        private void _btnFindSubdomains_Click(object sender, EventArgs e)
        {
            //This site also offers an API 4 request/min and there is also limited info on a page
            //try the api then try the page

            List<string> subdomains = new List<string>();

            WebPageRequest request = new WebPageRequest();
            request.Address = "https://www.virustotal.com/vtapi/v2/domain/report?apikey=aff8183060bfe0fcfa977c9f5273b2d76eecdd2cec2b83a7c22d3fc105866894&domain=yahoo.com";
            WebPageLoader.Load(request);

            dynamic d = JObject.Parse(request.Response.Body);

            if (d.subdomains != null)
            {
                foreach (string subdomain in d.subdomains)
                {
                    subdomains.Add(subdomain);
                }
            }

            if (subdomains.Count == 0)
            {
                request = new WebPageRequest();
                request.Address = "https://www.virustotal.com/en/domain/yahoo.com/information";
                request.CookieJar.Add(new System.Net.Cookie()
                {
                    Domain="www.virustotal.com",
                    HttpOnly=false,
                    Path="/",
                    Name = "VT_PREFERRED_LANGUAGE",
                    Value="en"
                });

                WebPageLoader.Load(request);

                HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(request.Response.Body);

                var divNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='observed-subdomains']");
                if (divNode != null)
                {
                    var aNodes = divNode.Descendants("a");
                    foreach (HtmlNode a in aNodes)
                    {
                        string found = Regex.Replace(a.InnerText, @"\n|\s+", "");
                        if(found.Contains("yahoo.com"))
                            subdomains.Add(found);
                    }
                }

                int x = 0;

            }

        }
    }
}
