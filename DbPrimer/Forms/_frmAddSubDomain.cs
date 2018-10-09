using Clark.Domain.Component;
using Clark.Domain.Data;
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
    public partial class _frmAddSubDomain : Form
    {
        public _frmAddSubDomain()
        {
            InitializeComponent();
        }

        private void _frmAddSubDomain_Load(object sender, EventArgs e)
        {
            _dateFound.Value = DateTime.Now;

            var controller = new DomainController();
            var result = controller.FindAll();
            _cmbDomain.Items.Add("Select");
            foreach (var item in result.Items)
            {
                _cmbDomain.Items.Add(item.DomainName + "~" + item.DomainId);
            }
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _btnSave_Click(object sender, EventArgs e)
        {
            _btnSave.Enabled = false;

            Subdomain subdomain = new Subdomain();
            subdomain.SubdomainName = _txtSubName.Text;
            subdomain.DateFound = _dateFound.Value;
            subdomain.DomainId = int.Parse(_cmbDomain.SelectedItem.ToString().Split('~')[1].ToString());
            subdomain.FoundType = _txtFoundType.Text;

            SubdomainController subController = new SubdomainController();
            var res = subController.Insert(subdomain);
            if (res.Error)
            {
                MessageBox.Show(res.Message);
            }
            else
            {
                _txtSubName.Text = "";
                _dateFound.Value = DateTime.Now;
                _cmbDomain.SelectedItem = "Select";
                _txtFoundType.Text = "";
            }


            _btnSave.Enabled = true;
        }
    }
}
