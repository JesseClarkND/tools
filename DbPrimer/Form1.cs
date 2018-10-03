using Clark.Domain.Component;
using Core.MySQL.Accessor;
using DbPrimer.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbPrimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LogTest(string log)
        {
            _rtbLog.Text += log + Environment.NewLine;
        }

        private void _btnTestConnection_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            MySqlConnection conn = null;
            try
            {
                conn = DatabaseManager.GetConnection();
                sb.Append("Testing..." + Environment.NewLine);
                sb.Append(conn.ConnectionString + Environment.NewLine);
                conn.Open();
                sb.Append("Looks Good!");
            }
            catch (ArgumentException a_ex)
            {
                sb.Append("Check the Connection String." + Environment.NewLine);
                sb.Append(a_ex.Message);
            }
            catch (MySqlException ex)
            {
                /*string sqlErrorMessage = "Message: " + ex.Message + "\n" +
                "Source: " + ex.Source + "\n" +
                "Number: " + ex.Number;
                Console.WriteLine(sqlErrorMessage);
                */
                switch (ex.Number)
                {
                    //http://dev.mysql.com/doc/refman/5.0/en/error-messages-server.html
                    case 1042:
                        sb.Append("Unable to connect to any of the specified MySQL hosts (Check Server,Port)" + Environment.NewLine);
                        break;
                    case 0:
                        sb.Append("Access denied (Check DB name,username,password)" + Environment.NewLine);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                sb.Append("Some unknown error occurred." + Environment.NewLine);
                sb.Append(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            LogTest(sb.ToString());
        }

        private void _btnAddDomain_Click(object sender, EventArgs e)
        {
            _frmAddDomain form = new _frmAddDomain();
            form.Show();
        }

        private void _btnDumpDomains_Click(object sender, EventArgs e)
        {
            var controller = new DomainController();
            var result = controller.FindAll();
            foreach (var item in result.Items)
                LogTest(item.DomainName + Environment.NewLine);
            LogTest("Domains dumped!");
        }

        private void _btnInitialize_Click(object sender, EventArgs e)
        {
            var controller = new DomainController();
            var result = controller.CreateTable();
            if (result.Error)
                LogTest(result.Message);

            LogTest("Tables Created!");
        }
    }
}
