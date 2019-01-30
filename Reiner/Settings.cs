using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Reiner
{
    public static class Settings
    {
        private static string _urlBatchDir = "";
        private static string _serverIP1 = "";

        public static string URLBatch
        {
            get
            {
                if (String.IsNullOrEmpty(_urlBatchDir))
                {
                    Initilize();
                }
                return _urlBatchDir;
            }
        }

        public static string ServerIP1
        {
            get
            {
                if (String.IsNullOrEmpty(_serverIP1))
                {
                    Initilize();
                }
                return _serverIP1;
            }
        }

        private static void Initilize()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Reiner\Settings.xml");

            XmlNode node = doc.DocumentElement.SelectSingleNode("/root/URLBatch");
            _urlBatchDir = node.InnerText;

            node = doc.DocumentElement.SelectSingleNode("/root/ServerIP1");
            _serverIP1 = node.InnerText;
        }
    }
}