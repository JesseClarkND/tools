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
        private static string _urlsOfInterest = "";
        private static string _serverName = "";
        private static string _email = "";
        private static string _emailPassword = "";
        private static string _securityTrailsAPI = "";
        private static string _virsutTotalAPI = "";

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

        public static string SenderEmail
        {
            get
            {
                if (String.IsNullOrEmpty(_email))
                {
                    Initilize();
                }
                return _email;
            }
        }

        public static string EmailPassword
        {
            get
            {
                if (String.IsNullOrEmpty(_emailPassword))
                {
                    Initilize();
                }
                return _emailPassword;
            }
        }

        public static string SecurityTrailsAPI
        {
            get
            {
                if (String.IsNullOrEmpty(_securityTrailsAPI))
                {
                    Initilize();
                }
                return _securityTrailsAPI;
            }
        }

        public static string VirusTotalAPI
        {
            get
            {
                if (String.IsNullOrEmpty(_virsutTotalAPI))
                {
                    Initilize();
                }
                return _virsutTotalAPI;
            }
        }

        public static string InterstingURLs
        {
            get
            {
                if (String.IsNullOrEmpty(_urlsOfInterest))
                {
                    Initilize();
                }
                return _urlsOfInterest;
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

            node = doc.DocumentElement.SelectSingleNode("/root/Email");
            _email = node.InnerText;

            node = doc.DocumentElement.SelectSingleNode("/root/EmailPassword");
            _emailPassword = node.InnerText;

            node = doc.DocumentElement.SelectSingleNode("/root/SecurityTrailsAPI");
            _securityTrailsAPI = node.InnerText;

            node = doc.DocumentElement.SelectSingleNode("/root/VirusTotalAPI");
            _virsutTotalAPI = node.InnerText;

            node = doc.DocumentElement.SelectSingleNode("/root/InterestingURL");
            _urlsOfInterest = node.InnerText;

        }
    }


}