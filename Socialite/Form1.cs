﻿using Clark.Crawler;
using Clark.Crawler.Interfaces;
using Clark.Crawler.Models;
using Socialite.App;
using Socialite.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Socialite
{
    public partial class Form1 : Form
    {
        private static Action<IRequest> _resultAction;
        private static Action _pageCounterAction;

        public Form1()
        {
            InitializeComponent();
        }

        private void _btnStart_Click(object sender, EventArgs e)
        {
            _btnStart.Enabled = false;
            _bgwScanner.DoWork += new DoWorkEventHandler(_bgwScanner_DoWork);
            _bgwScanner.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgwScanner_RunWorkerCompleted);
            //backgroundWorker1.CancellationPending

            _bgwScanner.RunWorkerAsync();
        }

        private void _bgwScanner_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
              //  CrawlerContext.SessionFileName = "Scraper";
             //   Core.SQLite.Accessor.Settings.ConnectionString = "data source=" + CrawlerContext.SessionFileName;
                CrawlerContext.SetURL(_txtURL.Text);

                _resultAction = new Action<IRequest>(Write);
                _pageCounterAction = new Action(UpdateSiteCount);

                Crawler.CrawlSite(_resultAction, _pageCounterAction);
                //LinearCrawler.CrawlSite(DataGridWrite, SiteCounter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Scanner Error: " + ex.Message);
            }
        }

        private void _bgwScanner_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //_lblComplete.Text = "Complete";
            //_btnLaunch.Enabled = true;
            //_pbLoading.Visible = false;
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
            if (_lstResult.InvokeRequired)
            {
                this.BeginInvoke(_resultAction, request);
                return;
            }

            List<string> socialURLs = _lstTarget.Items.Cast<String>().ToList();
            List<KeyValuePair<string, string>> foundSocialUrls = SocialLinkFinder.Find(request.Response.Body, request.Url, socialURLs);

            foreach (KeyValuePair<string, string> url in foundSocialUrls)
            {
                if (!url.Key.Equals("200"))
                {
                    _lstResult.Items.Add(url);

                    string path = @"C:\results\SocialiteFindings.txt";
                    // This text is added only once to the file.
                    if (!File.Exists(path))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine(url.Key + " " + url.Value);
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.WriteLine(url.Key + " " + url.Value);
                        }
                    }
                }
            }
            _lstResult.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CrawlerContext.Initialize();
            CrawlerContext.LightMode = true;
            _txtURL.Text = "https://www.buzzfeed.com/news?utm_term=.pc7OLEyE8#.oyOAQyByr";
            _lstTarget.Items.Add("facebook.com");
            _lstTarget.Items.Add("twitter.com");
            _lstTarget.Items.Add("instagram.com");
            _lstTarget.Items.Add("pintrist.com");
            _lstTarget.Items.Add("youtube.com");
            _lstTarget.Items.Add("flickr.com");
            _lstTarget.Items.Add("linkedin.com");
        }

        private void _btnAddTarget_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(_txtAddTarget.Text))
                return;//show error?

            _lstTarget.Items.Add(_txtAddTarget.Text);
            _lstTarget.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(_lstTarget.SelectedIndex>=0)
                _lstTarget.Items.RemoveAt(_lstTarget.SelectedIndex);
        }

        private void scannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmSettings form = new frmSettings();
                var result = form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _btnFolderSelect_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                _lblDir.Text = folderBrowser.SelectedPath;
            }
        }

        private void _btnStartFolder_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(folderBrowser.SelectedPath))
            {
                _lblDir.Text = "Select a dir, dork";
                return;
            }

            string[] files = Directory.GetFiles(folderBrowser.SelectedPath, "*.txt", SearchOption.AllDirectories);

            _resultAction = new Action<IRequest>(Write);
            _pageCounterAction = new Action(UpdateSiteCount);

            foreach (string file in files)
            {
                string[] lines = File.ReadAllLines(file);
                foreach (string line in lines)
                {
                    if (String.IsNullOrEmpty(line))
                        continue;
                    CrawlerContext.Initialize();
                    CrawlerContext.LightMode = true;
                    CrawlerContext.Depth = 2;

                    CrawlerContext.SetURL(line);
                    Crawler.CrawlSite(_resultAction, _pageCounterAction);

                }
            }
        }
    }
}
