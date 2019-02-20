using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Secretariat
{
    [ServiceContract]
    public interface ISecretariatService
    {

        [OperationContract]
        string CheckConnection();

        [OperationContract]
        string CheckLastURL();

        [OperationContract]
        string CheckStatus();

        [OperationContract]
        string CheckStartTime();

        [OperationContract]
        string TestURL(string url);
    }
}
