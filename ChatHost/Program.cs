using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ChatHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(uMassager.Service1)))
            {
                host.Open();
                Console.WriteLine("Host has started!!!");
                Console.ReadLine();
            }
        }
    }
}
