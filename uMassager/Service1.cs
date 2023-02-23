using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace uMassager
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] // one servise for all user-connection
    public class Service1 : IService1
    {
        public int Connect()
        {
            throw new NotImplementedException();
        }

        public void Disconnect(int id)
        {
            throw new NotImplementedException();
        }

        public void SendMassage(string _massage)
        {
            throw new NotImplementedException();
        }
    }
}
