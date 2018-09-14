using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AlternateTerritory
{
    public static class Settings
    {
        private static string _logDir = "";
        private static string _sourceFile = "";
        private static string _existingDir = "";
        private static string _serverName = "";

        public static string LogDir
        {
            get
            {
                if (String.IsNullOrEmpty(_logDir))
                {
                    Initilize();
                }
                return _logDir;
            }
        }
        public static string SourceFile
        {
            get
            {
                if (String.IsNullOrEmpty(_sourceFile))
                {
                    Initilize();
                }
                return _sourceFile;
            }
        }
        public static string ExistingDir
        {
            get
            {
                if (String.IsNullOrEmpty(_existingDir))
                {
                    Initilize();
                }
                return _existingDir;
            }
        }
        public static string ServerName
        {
            get
            {
                if (String.IsNullOrEmpty(_serverName))
                {
                    Initilize();
                }
                return _serverName;
            }
        }

        private static void Initilize()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Alternative\Settings.xml");

            XmlNode node = doc.DocumentElement.SelectSingleNode("/root/Server");
            _serverName = node.InnerText;

            node = doc.DocumentElement.SelectSingleNode("/root/Logs");
            _logDir = node.InnerText;

            node = doc.DocumentElement.SelectSingleNode("/root/Existing");
            _existingDir = node.InnerText;

            node = doc.DocumentElement.SelectSingleNode("/root/Source");
            _sourceFile = node.InnerText;
        }
    }


}