using System;
using System.Net;

namespace tes_CSharpe_ResourceText
{
    class ClassTestDNS
    {
        public ClassTestDNS()
        {
            DoGetHostAddresses();
        }

        public void DoGetHostAddresses()
        {
            IPAddress[] ips;
            ips = Dns.GetHostAddresses("192.168.2.126");

            Console.WriteLine("GetHostAddresses({0}) returns:", "192.168.2.126");

            foreach (IPAddress ip in ips)
            {
                Console.WriteLine("    {0}", ip);
            }

        }
        
    }
}
