using Clark.Crawler;
using Socialite.App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Socialite.Settings
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CrawlerContext.UserAgent = _txtUserAgent.Text;
            CrawlerContext.IncludeSubdomains = _chkSubdomains.Checked;
            if(!String.IsNullOrEmpty(_txtUsername.Text))
                AppContext.UserNames.Add(_txtUsername.Text);
            if (!String.IsNullOrEmpty(_txtUsername2.Text))
                AppContext.UserNames.Add(_txtUsername2.Text);
            if (!String.IsNullOrEmpty(_txtUsername3.Text))
                AppContext.UserNames.Add(_txtUsername3.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            _txtUserAgent.Text = CrawlerContext.UserAgent;
            _chkSubdomains.Checked = CrawlerContext.IncludeSubdomains;
            foreach (string dir in CrawlerContext.IgnoreDirectory)
            {
                _lstIgnoreDir.Items.Add(dir);
            }
        }
    }
}
