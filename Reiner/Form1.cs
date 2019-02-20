using Reiner.SecretariatService;
using Reiner.Subforms;
using Reiner.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reiner
{
    public partial class Reiner : Form
    {
        private const string IP_LABEL_ID = "_lblIP";
        private const string URL_LABEL_ID = "_lblURL";
        private const string STARTED_LABEL_ID = "_lblStarted";
        private const string STATUS_LABEL_ID = "_lblStatus";
        // private const string STATUS_LIGHT_ID = "_oval";
        private const string SERVICE_NAME = "SecretariatService.svc";

        public Reiner()
        {
            InitializeComponent();
        }

        private void _btnStart_Click(object sender, EventArgs e)
        {

        }

        private void manageBatchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmURLBatches form = new frmURLBatches();
                var result = form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Reiner_Load(object sender, EventArgs e)
        {
            _txtTestURL1.Text = "*.extrahop.com";

            InitializeGUI();

            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            _backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            _backgroundWorker.WorkerReportsProgress = true;
            _backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                System.Threading.Thread.Sleep(1 * 30 * 1000);

                _backgroundWorker.ReportProgress(1);

            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateAllPanelStatus();
        }

        private void InitializeGUI()
        {
            List<string> batchNames = URLBatchUtility.LoadBatchNames().ToList();
            _ddlTestURLBatch1.DataSource = batchNames;
            //_ddlTestURLBatch2.DataSource = batches; ...


            UpdateAllPanelStatus();
        }

        private void UpdateAllPanelStatus()
        {
            //     SecretariatClient client = new SecretariatClient(WCFClientHelper.HttpBinder, WCFClientHelper.GetEndpointAddress(Settings.WCFServiceAddress, "WCFService.svc"))
            using (SecretariatServiceClient client1 = new SecretariatServiceClient(WCFClientHelper.HttpBinder, WCFClientHelper.GetEndpointAddress(Settings.ServerIP1, SERVICE_NAME)))
            {
                UpdateIPLabel(1, WCFClientHelper.GetEndpointAddress(Settings.ServerIP1, SERVICE_NAME).ToString());

                UpdatePanelStatus(1, client1);
            }

            using (SecretariatServiceClient client2 = new SecretariatServiceClient(WCFClientHelper.HttpBinder, WCFClientHelper.GetEndpointAddress(Settings.ServerIP2, SERVICE_NAME)))
            {
                UpdateIPLabel(2, WCFClientHelper.GetEndpointAddress(Settings.ServerIP2, SERVICE_NAME).ToString());

                UpdatePanelStatus(2, client2);
            }
        }




        //Move these to a control
        #region Panel 1
        private void _btnStartBatch1_Click(object sender, EventArgs e)
        {
            _ddlTestURLBatch1.Enabled = false;
            UpdateStatusLabel(1, "Started.. Awaiting update");

            var thread = new Thread(() =>
            {
                using (SecretariatServiceClient client1 = new SecretariatServiceClient(WCFClientHelper.HttpBinder, WCFClientHelper.GetEndpointAddress(Settings.ServerIP1, SERVICE_NAME)))
                {
                    if (String.IsNullOrEmpty(_txtTestURL1.Text))
                    {
                        MessageBox.Show("Enter a URL to test.");
                        return;
                    }
                    foreach (var item in URLBatchUtility.LoadURLsFromBatch(_ddlTestURLBatch1.SelectedItem.ToString()))
                    {
                        client1.TestURL(item);
                    }
                }
            });


            thread.Start();
            //thread.Join();

            _ddlTestURLBatch1.Enabled = true; ;
        }

        private void _btnStartTestURL1_Click(object sender, EventArgs e)
        {
            UpdateStatusLabel(1, "Started.. Awaiting update");

            Task.Factory.StartNew(() => 
           // var thread = new Thread(() =>
            {
                using (SecretariatServiceClient client1 = new SecretariatServiceClient(WCFClientHelper.HttpBinder, WCFClientHelper.GetEndpointAddress(Settings.ServerIP1, SERVICE_NAME)))
                {
                    if (String.IsNullOrEmpty(_txtTestURL1.Text))
                    {
                        MessageBox.Show("Enter a URL to test.");
                        return;
                    }

                    client1.TestURL(_txtTestURL1.Text);
                }

            });


           // thread.Start();
        }

        #endregion

        #region Controls

        private Microsoft.VisualBasic.PowerPacks.OvalShape FindOval(int panelId)
        {
            switch (panelId)
            {
                case 1:
                    return _oval1;
                    break;
                case 2:
                    return _oval2;
                    break;
            }
            return null;
        }

        private void UpdatePanelStatus(int panelId, SecretariatServiceClient client)
        {
            if (CheckIfAwake(client, FindOval(panelId)))
            {
                UpdateURLLabel(panelId, client.CheckLastURL());
                UpdateStartedLabel(panelId, client.CheckStartTime());
                UpdateStatusLabel(panelId, client.CheckStatus());
            }
        }

        private Control FindFormControl(string id)
        {
            return Controls.Find(id, true).FirstOrDefault();
        }

        private void UpdateIPLabel(int panelNumber, string ip)
        {
            var label = FindFormControl(IP_LABEL_ID + panelNumber);
            if (label != null)
                label.Text = ip;
            label.Refresh();
        }

        private void UpdateURLLabel(int panelNumber, string url)
        {
            var label = FindFormControl(URL_LABEL_ID + panelNumber);
            if (label != null)
                label.Text = url;
            label.Refresh();
        }

        private void UpdateStartedLabel(int panelNumber, string started)
        {
            var label = FindFormControl(STARTED_LABEL_ID + panelNumber);
            if (label != null)
                label.Text = started;
            label.Refresh();
        }

        private void UpdateStatusLabel(int panelNumber, string status)
        {
            var label = FindFormControl(STATUS_LABEL_ID + panelNumber);
            if (label != null)
                label.Text = status;
            label.Refresh();
        }


        private bool CheckIfAwake(SecretariatServiceClient client, Microsoft.VisualBasic.PowerPacks.OvalShape oval)
        {
            oval.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;

            if (client.CheckConnection() == "Ack")
            {
                oval.FillColor = Color.Green;
                return true;
            }
            else
            {
                oval.FillColor = Color.Red;
                return false;
            }
        }
        #endregion


        #region Panel 2
        private void _btnStartTestURL2_Click(object sender, EventArgs e)
        {
            UpdateStatusLabel(2, "Started.. Awaiting update");

             Task.Factory.StartNew(() => 
            //var thread = new Thread(() =>
                {
                    using (SecretariatServiceClient client2 = new SecretariatServiceClient(WCFClientHelper.HttpBinder, WCFClientHelper.GetEndpointAddress(Settings.ServerIP2, SERVICE_NAME)))
                    {
                        if (String.IsNullOrEmpty(_txtTestURL2.Text))
                        {
                            MessageBox.Show("Enter a URL to test.");
                            return;
                        }

                        client2.TestURL(_txtTestURL2.Text);
                    }
                });

           // thread.Start();
            // thread.Join();
        }

        #endregion
    }
}
