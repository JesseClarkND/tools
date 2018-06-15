using Clark.Crawler;
using Clark.Crawler.Interfaces;
using Clark.Crawler.Models;
using Clark.Crawler.Utilities;
using ElDorado.App;
using ElDorado.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElDorado
{
    public partial class Form1 : Form
    {
        private static Action<IRequest> _resultAction;
        private static Action _pageCounterAction;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CrawlerContext.Initialize();
            _txtURL.Text = "blackdoorsec.net";
        }

        private void _btnStart_Click(object sender, EventArgs e)
        {
            _btnStart.Enabled = false;
            _bgWorker.DoWork += new DoWorkEventHandler(_bgWorker_DoWork);
            _bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgWorker_RunWorkerCompleted);
            //backgroundWorker1.CancellationPending

            _bgWorker.RunWorkerAsync();
        }

        private void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //  CrawlerContext.SessionFileName = "Scraper";
                //   Core.SQLite.Accessor.Settings.ConnectionString = "data source=" + CrawlerContext.SessionFileName;
                //CrawlerContext.SetURL(_txtURL.Text);

                string baseURL = _txtURL.Text;
                _resultAction = new Action<IRequest>(Write);
                _pageCounterAction = new Action(UpdateSiteCount);

                SubDomainGenerator gen = new SubDomainGenerator();
                while (true)
                {
                    Request request = new Request(gen.GenerateString() + "."+baseURL);

                    RequestUtility.GetWebText(request);
                    if (!request.Response.Code.Equals("404"))
                    {
                        //AppContext.FoundSocialURLs404.Add(foundUrl.Url + " @ " + url);
                        //_lstFound.Items.Add(request.Url);
                    }
                }

               // Crawler.CrawlSite(_resultAction, _pageCounterAction);
                //LinearCrawler.CrawlSite(DataGridWrite, SiteCounter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Scanner Error: " + ex.Message);
            }
        }

        public void UpdateSiteCount()
        {
            if (_lblCount.InvokeRequired)
            {
                this.BeginInvoke(_pageCounterAction);
                return;
            }

            string counter = _lblCount.Text;
            int count = int.Parse(counter);
            _lblCount.Text = (++count).ToString();
            _lblCount.Refresh();
        }

        public void Write(IRequest request)
        {      
            if (_lstFound.InvokeRequired)
            {
                this.BeginInvoke(_resultAction, request);
                return;
            }
        }

        private void _bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //_lblComplete.Text = "Complete";
            //_btnLaunch.Enabled = true;
            //_pbLoading.Visible = false;
        }

        private void _btnSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _lblFile.Text = openFileDialog.FileName;
            }
        }
    }
}
