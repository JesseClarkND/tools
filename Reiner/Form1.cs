using Reiner.Subforms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reiner
{
    public partial class Reiner : Form
    {
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
            
            //WCFServiceClient client = new WCFServiceClient(WCFClientHelper.HttpBinder, WCFClientHelper.GetEndpointAddress(Settings.WCFServiceAddress, "WCFService.svc"))
            //AttackServiceRefernce client = new AttackServiceRefernce
        }
    }
}
