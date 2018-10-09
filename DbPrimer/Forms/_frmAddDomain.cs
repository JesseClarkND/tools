using Clark.Domain.Component;
using Clark.Domain.Data.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbPrimer.Forms
{
    public partial class _frmAddDomain : Form
    {
        public _frmAddDomain()
        {
            InitializeComponent();
        }

        private void _frmAddDomain_Load(object sender, EventArgs e)
        {
        }

        private void _btnSave_Click(object sender, EventArgs e)
        {
            _btnSave.Enabled = false;

            Clark.Domain.Data.Domain domain = new Clark.Domain.Data.Domain();
            domain.DomainName = _txtDomain.Text;
            domain.BountyURL = _txtPolicy.Text;
            domain.BountyEndDate = _endBountyChecks.Value;

            if (_radHackerone.Checked)
                domain.Platform = "hackerone";
            else if (_radBugBountyJP.Checked)
                domain.Platform = "bugbountyjp";
            else if (_radBugcrowd.Checked)
                domain.Platform = "bugcrowd";
            else if (_radSelf.Checked)
                domain.Platform = "self";
            else if (_radSynack.Checked)
                domain.Platform = "synack";

            domain.Private = _chkPrivate.Checked;

            var domainController = new DomainController();
            UpdateResult res = domainController.Insert(domain);
            if (res.Error)
            {
                MessageBox.Show(res.Message);
            }
            else
            {
                _txtDomain.Text = "";
                _txtPolicy.Text = "";
                _endBountyChecks.Value = new DateTime(2999, 12, 21);
                _chkPrivate.Checked = false;
            }

            _btnSave.Enabled = true;
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
