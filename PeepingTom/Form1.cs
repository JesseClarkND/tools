using Clark.Common.Models;
using Clark.Common.Utility;
using Clark.Subdomain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeepingTom.Extensions;
using System.Text.RegularExpressions;
using System.Net;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace PeepingTom
{
    public partial class Form1 : Form
    {
        private static int _threadCount = 10;
        private static CountdownEvent _countdown;
        private static readonly object _syncObject = new object();
        private static readonly object _colorObject = new object();
        private static readonly object _browserObject = new object();
        private static readonly object _subMessageObject = new object();
        Dictionary<string, Color> _colors = new Dictionary<string, Color>();
        private static Action<DataGridRow> _dataGridWrite;
        private static Action<String> _statusWrite;
        private static Action<String> _subStatusWrite;
        private static Action<String, String> _batchAction;

        private Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void _btnStart_Click(object sender, EventArgs e)
        {
            string firstUrl = _txtURL.Text;

            if (String.IsNullOrEmpty(firstUrl))
            {
                MessageBox.Show("Enter a url.");
                return;
            }

            List<string> urls = new List<string>();
        
            List<string> urlsToTest = new List<string>();

            if (firstUrl.StartsWith("*"))
            {
                //Load subdomains
                HunterRequest hr = new HunterRequest();
                hr.Domain = firstUrl.TrimStart('*').TrimStart('.');
                urlsToTest = Hunter.GatherAll(hr);

                //urlsToTest = new List<string>() { "www.neopets.com" };
            }
            else
            {
                urlsToTest.Add(firstUrl);
            }

            _bgwScanner.DoWork += new DoWorkEventHandler(_bgwScanner_DoWork);
            _bgwScanner.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgwScanner_RunWorkerCompleted);

            _bgwScanner.RunWorkerAsync(urlsToTest);

        }

        private void _bgwScanner_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                TestURLS((List<String>)e.Argument);
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

        private void TestURLS(List<string> urlsToTest)
        {
            _statusWrite = new Action<string>(Status);
            _dataGridWrite = new Action<DataGridRow>(AddRow);
            _subStatusWrite = new Action<string>(SubStatus);
            _batchAction = new Action<string, string>(SetBatch);

             List<string> schemas = new List<string>();
            schemas.Add("https");
            schemas.Add("http");

            foreach (var schema in schemas)
            {
                _statusWrite.Invoke("Starting schema: " + schema);
                int chunckCount = 1;
                foreach (List<string> subDomainChunk in urlsToTest.ChunkBy(_threadCount))
                {
                    _statusWrite.Invoke("Starting chunck count: " + chunckCount);

                    foreach (var sub in subDomainChunk)
                        _batchAction.Invoke(schema+"://"+sub, "W");

                    int count = Math.Min(_threadCount, subDomainChunk.Count);
                    _countdown = new CountdownEvent(count);

                    List<Thread> lstThreads = new List<Thread>();

                    //DataGridRow[] results = new DataGridRow[count];
                   // List<DataGridRow> results = new List<DataGridRow>();

                    _statusWrite.Invoke("Creating threads for chunck count" + chunckCount);
                    int index = 0;
                    foreach (string chunck in subDomainChunk)
                    {
                        string address = "";

                        if (schema.Equals("http"))
                            address = DomainUtility.EnsureHTTP(chunck.ToString());
                        else
                            address = DomainUtility.EnsureHTTPS(chunck.ToString());

                        Thread th = new Thread(() =>
                        {
                            try
                            {
                                WorkThread(address);
                                //DataGridRow row = WorkThread(address);
                                //lock (_syncObject)
                                //{
                                //    results.Add(row);
                                //}
                            }
                            catch (Exception ex)
                            {
                                int x = 0;
                            }
                        });
                        lstThreads.Add(th);
                        index++;
                    }
                    index = 0;

                    _statusWrite.Invoke("Starting threads for chunck count: " + chunckCount);


                    foreach (Thread th in lstThreads)
                    {
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                    }
                    _statusWrite.Invoke("Waiting on chunck count: " + chunckCount);
                    _countdown.Wait();
                    _statusWrite.Invoke("Finished chunck count: " + chunckCount);
                    chunckCount++;
 
                }
            }
        }

        private Color GetColor(string key)
        {          
             lock (_colorObject)
             {
                 if (!_colors.ContainsKey(key))
                 {
                     _colors.Add(key, Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
                 }

                 return _colors[key];
             }
        }

        private void SetBatch(string url, string command)
        {
            if (_lstBatch.InvokeRequired)
            {
                this.BeginInvoke(_batchAction, url, command);
                return;
            }

            if (command == "W")
            {
                //Write
                _lstBatch.Items.Add(url);
            }
            else if (command == "R")
            {
                //Remove
                _lstBatch.Items.Remove(url);

                lock (_subMessageObject)
                {
                    for (int n = _lstSubMessage.Items.Count - 1; n >= 0; --n)
                    {
                        string removelistitem = url;
                        if (_lstSubMessage.Items[n].ToString().Contains(removelistitem))
                        {
                            _lstSubMessage.Items.RemoveAt(n);
                        }
                    }
                }
            }
        }

        private void Status(string mesage)
        {
            if (_lblStatus.InvokeRequired)
            {
                this.BeginInvoke(_statusWrite, mesage);
                return;
            }

            _lblStatus.Text = mesage;
        }

        private void SubStatus(string mesage)
        {
            if (_lblSubStatus.InvokeRequired)
            {
                this.BeginInvoke(_subStatusWrite, mesage);
                return;
            }

            _lblSubStatus.Text = mesage;

            lock (_subMessageObject)
            {
                _lstSubMessage.Items.Insert(0, mesage);
            }
        }

        private void AddRow(DataGridRow row)
        {
            if (_dataGrid.InvokeRequired)
            {
                this.BeginInvoke(_dataGridWrite, row);
                return;
            }

            DataGridViewRow viewRow = (DataGridViewRow)_dataGrid.Rows[0].Clone();
            viewRow.DefaultCellStyle.BackColor = row.Color;
            viewRow.Cells[0].Value = row.URL;
            viewRow.Cells[1].Value = row.ResponseCode;
            viewRow.Cells[2].Value = row.Image;
            viewRow.Cells[3].Value = row.MD5;
            _dataGrid.Rows.Add(viewRow);

            _dataGrid.Refresh();
        }

        private void WorkThread(string testUrl)
        {
            try
            {
               // WebPageRequest request = new WebPageRequest();
              //  request.Address = testUrl;

                _subStatusWrite.Invoke("Loading: " + testUrl);
              //  WebPageLoader.Load(request);

                _subStatusWrite.Invoke("Loaded: " + testUrl);

                DataGridRow row = new DataGridRow();
                row.URL = testUrl;
              //  row.ResponseCode = request.Response.Code;

               // if (!String.IsNullOrEmpty(request.Response.Body))
               // {
                    _subStatusWrite.Invoke("Creating Image: " + testUrl);
                    Image image = Capture(testUrl);// (request.Response.Body);
                    _subStatusWrite.Invoke("Image Created: " + testUrl);
                    try
                    {
                        //Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                        string str = testUrl.Replace("://", "").Replace(".", "~");//rgx.Replace(testUrl, "");

                        try
                        {
                            _subStatusWrite.Invoke("Saving Image: " + testUrl);
                            image.Save(@"C:\Temp\PeepingTom\" + str + ".jpg", ImageFormat.Jpeg);
                        }
                        catch { }

                        _subStatusWrite.Invoke("Creating Thumbnail: " + testUrl);
                        row.Image = image.GetThumbnailImage(100, 100, () => false, IntPtr.Zero);
                    }
                    catch
                    {
                        row.Image = null;
                    }


                    row.MD5 = HashImage(image);
                //}
                //else
                //{
                //    row.MD5 = "";
                //}

                _subStatusWrite.Invoke("Creating Color: " + testUrl);
                row.Color = GetColor(row.MD5);

                //AddRow(row);
                _subStatusWrite.Invoke("Inserting Row " + testUrl);
                _dataGridWrite.Invoke(row);
                _subStatusWrite.Invoke("Finished: " + testUrl);
                _batchAction.Invoke(testUrl, "R");
            }
            catch(Exception ex)
            {
                int x = 0;
            }
            finally
            {
                _countdown.Signal();
            }
        }

        private static string HashImage(Image image)
        {
            byte[] bytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                bytes = ms.ToArray();
            }

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(bytes);

            // make a hex string of the hash for display or whatever
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2").ToLower());
            }

            return sb.ToString();
        }

        private Image Capture(string url)//string html)
        {
            Image result = new Bitmap(1024, 768);

            var thread = new Thread(() =>
            {
                try
                {
                    _subStatusWrite.Invoke("Generating browser: " + url);
                    using (var browser = new WebBrowser())
                    {
                        browser.ScrollBarsEnabled = false;
                        browser.AllowNavigation = true;
                       // browser.DocumentText = html;
                        browser.Url = new Uri(url);
                        browser.Width = 1024;
                        browser.Height = 768;
                        browser.ScriptErrorsSuppressed = true;
                        browser.DocumentCompleted += (sender, args) => DocumentCompleted(sender, args, url, ref result);

                        lock (_browserObject)
                        {
                            Stopwatch sp = new Stopwatch();
                            sp.Start();
                            while (browser.ReadyState != WebBrowserReadyState.Complete)
                            {
                                if (sp.ElapsedMilliseconds > 30000)
                                    break;
                                Application.DoEvents();
                            }
                            sp.Stop();
                            _subStatusWrite.Invoke("Browser Complete: " + url);
                        }

                    }
                }
                catch { }
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            return result;
        }

        private void DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e, string url, ref Image image)
        {
            var browser = sender as WebBrowser;
            if (e.Url.AbsolutePath != browser.Url.AbsolutePath)
            {
                _subStatusWrite.Invoke("DocumentCompleted: " + url);
                return; //Stops document completed from firing multiple times //https://stackoverflow.com/questions/18321872/documentcompleted-firing-multiple-times-accepted-stackoverflow-answer-not-work
            }

            if (browser == null) return;
            if (browser.Document == null) return;
            if (browser.Document.Body == null) return;

           // lock (_browserObject)
           // {
            _subStatusWrite.Invoke("Going to native generator. " + url);
                NativeMethods.GetImage(browser.ActiveXInstance, image, Color.White);
            //GetImage(browser.ActiveXInstance, image, Color.White);
           // }
           // Regex rgx = new Regex("[^a-zA-Z0-9 -]");
           // string str = rgx.Replace(DateTime.Now.ToString(), "");

           // screenshot.Save(@"C:\Temp\PeepingTom\" + str + ".png", ImageFormat.Png);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _txtURL.Text = "*.yahoo.com";
        }

        private void _btnImport_Click(object sender, EventArgs e)
        {
            DialogResult result = _fileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string file = _fileDialog.FileName;
                try
                {
                    string[] urls = File.ReadAllLines(file);

                    foreach (var url in urls)
                    {
                        _lstImport.Items.Add(url);
                    }

                }
                catch (IOException)
                {
                }
            }
        }

        private void _btnStartList_Click(object sender, EventArgs e)
        {

            if (_lstImport.Items.Count==0)
            {
                MessageBox.Show("Enter a urls in list.");
                return;
            }

           // TestURLS(_lstImport.Items.Cast<String>().ToList());
            _bgwScanner.DoWork += new DoWorkEventHandler(_bgwScanner_DoWork);
            _bgwScanner.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgwScanner_RunWorkerCompleted);

            _bgwScanner.RunWorkerAsync(_lstImport.Items.Cast<String>().ToList());
        }

        private void _btnClear_Click(object sender, EventArgs e)
        {
            _dataGrid.Rows.Clear();
            _dataGrid.Refresh();
            _lstBatch.Items.Clear();
            _lstSubMessage.Items.Clear();
        }

        private void _btnFolderSelect_Click(object sender, EventArgs e)
        {
            DialogResult result = _folderDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                _lblDir.Text = _folderDialog.SelectedPath;// +"\\*.jpg";
            }
        }

        private void _btnImageScan_Click(object sender, EventArgs e)
        {
            if (_lblDir.Text == "-")
            {
                MessageBox.Show("Select a directory.");
                return;
            }

            string[] filePaths = System.IO.Directory.GetFiles(_lblDir.Text, "*.jpg");

            foreach (var filePath in filePaths)
            {
                Image image = Image.FromFile(filePath);

                DataGridRow row = new DataGridRow();

                string url = Path.GetFileNameWithoutExtension(filePath);
                url = url.Replace("https", "https://");
                if(!url.Contains('/'))
                    url = url.Replace("http", "http://");
                url = url.Replace("~", ".");

                row.URL = url;
                row.ResponseCode = "";
                row.Image = image.GetThumbnailImage(100, 100, () => false, IntPtr.Zero);
                row.MD5 = HashImage(image);
                row.Color = GetColor(row.MD5);

                AddRow(row);
            }
        }
    }

}