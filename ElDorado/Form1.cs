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
            _radBrute.Checked = true;
            CrawlerContext.Initialize();
            _txtURL.Text = "blackdoorsec.net";
        }

        private void _btnStart_Click(object sender, EventArgs e)
        {
            if (_radBrute.Checked)
                AppContext.Mode = GenerationMode.Brute;
            else
            {
                AppContext.Mode = GenerationMode.File;
                AppContext.FileLocation = openFileDialog.FileName;
            }

            AppContext.SearchFindings = _chkRescan.Checked;
            AppContext.Found.Add(_txtURL.Text);
            _btnStart.Enabled = false;
            _bgWorker.DoWork += new DoWorkEventHandler(_bgWorker_DoWork);
            _bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgWorker_RunWorkerCompleted);

            _bgWorker.RunWorkerAsync();
        }

        private void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string baseURL = _txtURL.Text;
                _resultAction = new Action<IRequest>(Write);
                _pageCounterAction = new Action(UpdateSiteCount);

                if (AppContext.SearchFindings)
                {
                    int count = 0;
                    while (AppContext.Found.Count != AppContext.Scanned.Count)
                    {
                        Pizarro.Explore(AppContext.Found[count], _resultAction, _pageCounterAction);
                        AppContext.Scanned.Add(AppContext.Found[count]);
                    }
                }
                else
                {
                    Pizarro.Explore(AppContext.Found[0], _resultAction, _pageCounterAction);
                    AppContext.Scanned.Add(AppContext.Found[0]);
                }
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

            _lstFound.Items.Add(request.Url);
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
