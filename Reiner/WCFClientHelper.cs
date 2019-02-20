using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Reiner
{
    public static class WCFClientHelper
    {
        public static Binding HttpBinder
        {
            get
            {
                XmlDictionaryReaderQuotas quotas = new XmlDictionaryReaderQuotas();
                quotas.MaxNameTableCharCount = int.MaxValue;
                quotas.MaxStringContentLength = int.MaxValue;
                quotas.MaxArrayLength = int.MaxValue;
                quotas.MaxDepth = int.MaxValue;
                quotas.MaxBytesPerRead = int.MaxValue;

                var binder = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
                binder.MaxReceivedMessageSize = int.MaxValue;
                binder.MaxBufferPoolSize = long.MaxValue;
                binder.MaxBufferSize = int.MaxValue;
                binder.ReaderQuotas = quotas;
                binder.ReceiveTimeout = TimeSpan.FromDays(2);
                binder.SendTimeout = TimeSpan.FromDays(2);

                return binder;
            }
        }

        public static EndpointAddress GetEndpointAddress(string serviceAddress, string suffix)
        {
            if (serviceAddress.EndsWith("/") == false)
                serviceAddress += "/";

            return new EndpointAddress(serviceAddress + suffix);
        }
    }
}