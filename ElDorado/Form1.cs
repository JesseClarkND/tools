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
using System.IO;
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
        private static Action _portCounterAction;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _radBrute.Checked = true;
            CrawlerContext.Initialize();
            _pnlPortsSelect.Visible = false;
            _txtURL.Text = "blackdoorsec.net";
            _chkScreenshot.Enabled = false;
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

            AppContext.DoPortScan = _chkPortScan.Checked;
            AppContext.SaveToFile = _chkSave.Checked;
            AppContext.SearchFindings = _chkRescan.Checked;
            AppContext.Found.Add(_txtURL.Text);
            //AppContext.PortsFound.Add(_txtURL.Text, new List<int>());
            //_lstFound.Items.Add(_txtURL.Text);
            AppContext.ThreadCount = _trkBarTasks.Value;

            if (AppContext.DoPortScan)
            {
                if (_radCommonPorts.Checked)
                    AppContext.MaxPort = 1023;
                else if (_radAllPorts.Checked)
                    AppContext.MaxPort = 65535;
            }

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
                _portCounterAction = new Action(UpdatePortCount);

                if (AppContext.SearchFindings)
                {
                    int count = 0;
                    while (AppContext.Found.Count != AppContext.Scanned.Count)
                    {
                        Pizarro.Explore(AppContext.ThreadCount, AppContext.Found[count], _resultAction, _pageCounterAction);
                        AppContext.Scanned.Add(AppContext.Found[count]);
                        count++;
                    }
                }
                else
                {
                    Pizarro.Explore(AppContext.ThreadCount, AppContext.Found[0], _resultAction, _pageCounterAction);
                    AppContext.Scanned.Add(AppContext.Found[0]);
                }

                if (AppContext.DoPortScan)
                {
                    foreach (string host in AppContext.PortsFound.Keys)
                    {
                        if(AppContext.MaxPort != 0)
                            PortScanner.Start(AppContext.ThreadCount, host, 0, AppContext.MaxPort, AppContext.TimeOut, _portCounterAction);
                        else
                            PortScanner.Start(AppContext.ThreadCount, host, AppContext.TimeOut, _portCounterAction);
                        WritePortFindings(host);
                    }
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

        public void UpdatePortCount()
        {
            if (_lblPortCount.InvokeRequired)
            {
                this.BeginInvoke(_portCounterAction);
                return;
            }

            string counter = _lblPortCount.Text;
            int count = int.Parse(counter);
            _lblPortCount.Text = (++count).ToString();
            _lblPortCount.Refresh();
        }

        public void WritePortFindings(string domain)
        {
            string findings = @"C:\results\EldoradoFindings.txt";

            string[] fileContents = File.ReadAllLines(findings);

            for (int i = 0; i < fileContents.Length; ++i)
            {
                if (fileContents[i] == domain)
                {
                    fileContents[i] += " - " + String.Join(", ", AppContext.PortsFound[domain].ToArray());
                    break;
                }
            }

            // And writing it all back out:

            File.WriteAllLines(findings, fileContents);
        }

        public void Write(IRequest request)
        {      
            if (_lstFound.InvokeRequired)
            {
                this.BeginInvoke(_resultAction, request);
                return;
            }

            _lstFound.Items.Add(request.Url);

            if (AppContext.SaveToFile)
            {
                string path = @"C:\results\EldoradoFindings.txt";
                // This text is added only once to the file.
                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(request.Url);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(request.Url);
                    }
                }
            }
        }

        private void _bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //_lblComplete.Text = "Complete";
            //_btnLaunch.Enabled = true;
            //_pbLoading.Visible = false;
            MessageBox.Show("Done");
        }

        private void _btnSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _lblFile.Text = openFileDialog.FileName;
            }
        }

        private void _chkPortScan_CheckedChanged(object sender, EventArgs e)
        {
            if (_chkPortScan.Checked)
            {
                _pnlPortsSelect.Visible = _chkPortScan.Visible = true;
                _radPopularPorts.Checked = true;
            }
        }

        private void _lstFound_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lstPorts.Items.Clear();

            string domain = _lstFound.GetItemText(_lstFound.SelectedItem);

            if (AppContext.PortsFound.ContainsKey(domain))
            {
                foreach (int port in AppContext.PortsFound[domain])
                {
                    _lstPorts.Items.Add(port);
                }
            }
        }

        private void _btnStartPort_Click(object sender, EventArgs e)
        {
            _portCounterAction = new Action(UpdatePortCount);
            PortScanner.Start(AppContext.ThreadCount, _txtURL.Text, AppContext.TimeOut, _portCounterAction);
        }
    }
}