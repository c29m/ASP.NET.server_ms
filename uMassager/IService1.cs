using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace uMassager
{
    [ServiceContract(CallbackContract =typeof(IServerChatCallback))]
    public interface IService1
    {
        [OperationContract]
        int Connect();
        
        [OperationContract]
        void Disconnect(int id);

        [OperationContract(IsOneWay = true)]
        void SendMassage(string _massage);
    }

    public interface IServerChatCallback
    {
        [OperationContract]
        void MassageCallback(string _massage);

    }

}
