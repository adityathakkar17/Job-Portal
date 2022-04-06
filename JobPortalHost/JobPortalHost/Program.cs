using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfJobPortal;

namespace JobPortalHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type t1 = typeof(ManageUserService);
            Type t2 = typeof(JobService);
            Type t3 = typeof(JobApplicationService);
            Uri http1 = new Uri("http://localhost:8000/ManageUserService");
            Uri http2 = new Uri("http://localhost:8000/JobService");
            Uri http3 = new Uri("http://localhost:8000/JobApplicationService");
            ServiceHost host1 = new ServiceHost(t1,http1);
            ServiceHost host2 = new ServiceHost(t2, http2);
            ServiceHost host3 = new ServiceHost(t3, http3);

            host1.Open();
            host2.Open();
            host3.Open();

            Console.WriteLine("publish");
            Console.ReadLine();
            host1.Close();
            host2.Close();
            host3.Close();


        }
    }
}
