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
        List<ServerUser> users = new List<ServerUser>();
        int NextID = 1;
        public int Connect(string _name)
        {
            ServerUser user = new ServerUser() {
                ID = NextID,
                Name = _name,
                operationContext = OperationContext.Current,
            };
            NextID++;
            SendMassage($"!!![{user.ID}] { user.Name } has conected to server ", 0);
            users.Add(user);

            return user.ID;
        }

        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(x => x.ID == id);
            if (user != null) {
                users.Remove(user);
                SendMassage($"!!! {user.ID} {user.Name} disconect from server ", 0);
            }
        }

        public void SendMassage(string _massage, int ID)
        {
            foreach (var user in users) {
                string answer = DateTime.Now.ToShortTimeString();
                if (user == null)
                {
                    answer += $": {user.Name} : ";
                }
                answer += _massage;
                user.operationContext.GetCallbackChannel<IServerChatCallback>().MassageCallback(answer);
            }

        }
    }
}
