using Reiner.Utilities;
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

namespace Reiner.Subforms
{
    public partial class frmURLBatches : Form
    {
        private List<string> _existingFiles = new List<string>();

        public frmURLBatches()
        {
            InitializeComponent();
        }

        private void frmURLBatches_Load(object sender, EventArgs e)
        {
            foreach (string file in URLBatchUtility.LoadBatchNames())
            {
                _existingFiles.Add(file);
            }

            UpdateFileSelect();
        }

        private void _ddlBatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lstURL.Items.Clear();
            foreach (var item in URLBatchUtility.LoadURLsFromBatch(_ddlBatches.SelectedItem.ToString()))
            {
                if(!String.IsNullOrEmpty(item)){
                    _lstURL.Items.Add(item);
                }
            }
        }

        private void _btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_txtName.Text))
                _txtName.Text = "Untitled" + DateTime.Now.ToString("mm_dd_yyyy");

            if (_existingFiles.Contains(_txtName.Text))
            {
                MessageBox.Show("File already exists. Pick a new name.");
                return;
            }

            System.IO.Directory.CreateDirectory(Settings.URLBatch);

            string dir = Path.Combine(Settings.URLBatch, _txtName.Text + ".txt");
            // This text is added only once to the file.
            if (!File.Exists(dir))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(dir))
                {
                   // sw.WriteLine();
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(dir))
                {
                    //sw.WriteLine();
                }
            }

            _ddlBatches.Items.Add(_txtName.Text);
            _ddlBatches.SelectedIndex = _ddlBatches.FindStringExact(_txtName.Text);
            _ddlBatches.Refresh();
            _existingFiles.Add(_txtName.Text);
            _lstURL.Items.Clear();
            _txtName.Text = "";
        }

        private void _btnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this batch?",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string dir = SelectedFilePath();
                File.Delete(dir);
                _existingFiles.Remove(_ddlBatches.Items[_ddlBatches.SelectedIndex].ToString());
                UpdateFileSelect();
                _lstURL.ClearSelected();
                if (_existingFiles.Count != 0)
                {
                    _ddlBatches.SelectedIndex = 0;
                }
            }
        }

        private void _btnAdd_Click(object sender, EventArgs e)
        {
            string addedURL = _txtURL.Text;
            if (String.IsNullOrEmpty(addedURL))
                return;

            _lstURL.Items.Add(addedURL);

            string dir = SelectedFilePath();

            System.IO.Directory.CreateDirectory(Settings.URLBatch);

            if (!File.Exists(dir))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(dir))
                {
                    sw.WriteLine(addedURL);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(dir))
                {
                    sw.WriteLine(addedURL);
                }
            }

            _txtURL.Text = "";
        }

        private string SelectedFilePath()
        {
            return Path.Combine(Settings.URLBatch, _ddlBatches.SelectedItem.ToString() + ".txt");
        }

        private void _btnRemove_Click(object sender, EventArgs e)
        {
            if (_lstURL.SelectedIndex == -1)
                return;

            _lstURL.Items.RemoveAt(_lstURL.SelectedIndex);

            string dir = SelectedFilePath();

            File.WriteAllLines(dir, _lstURL.Items.Cast<String>().ToList());
        }

        private void UpdateFileSelect()
        {
            _ddlBatches.Items.Clear();

            // _ddlBatches.Items.Add("Select");
            foreach (string file in _existingFiles)
            {
                _ddlBatches.Items.Add(file);
            }
        }
    }
}
