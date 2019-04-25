using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace tes_CSharpe_ResourceText.网络
{
    class TestTCP_Client
    {
        private TcpListener server;
        private TcpClient client;
        private TcpClient client_temp;
        private NetworkStream ClientStream;

        public TestTCP_Client()
        {
            Test_IPAddress();
        }

        /// <summary>
        /// 测试ipAddress类、TcpListener类
        /// </summary>
        public void Test_IPAddress()
        {
            Console.WriteLine(IPAddress.Any);
            Console.WriteLine(IPAddress.Broadcast);

            server = new TcpListener(IPAddress.Any, 8080);
            server.Start();
            Console.WriteLine("server start ....");

            Thread tread = new Thread(() =>
            {
                while (true)
                {
                    Console.WriteLine(101);
                    client_temp = server.AcceptTcpClient();
                    //Console.WriteLine(server.Pending());
                    Console.WriteLine(123);
                    //Console.WriteLine(client_temp);
                    if (client_temp.Connected)
                        Console.WriteLine(222);
                }
            });

            tread.IsBackground = false;
            tread.Start();

            TestIPClient();
            //server.Stop();
            Console.WriteLine("server end....");
        }

        /// <summary>
        /// 测试Client类
        /// </summary>
        public void TestIPClient()
        {
            client = new TcpClient("127.0.0.1", 8080);
            //Console.WriteLine(client.Available);
            ClientStream = client.GetStream();
            Console.WriteLine(ClientStream);
            //Thread threadSend = new Thread(() =>
            //{
            //    while (true)
            //    {
            //        if (client.Connected)
            //        {
            //            Test_SendMessg();
            //        }

            //    }
            //});
            //Thread threadWrite = new Thread(() =>
            //{
            //    while (true)
            //    {
            //        if (client.Connected)
            //        {
            //            Test_SendMessg();
            //        }

            //    }
            //});

            if (client.Connected)
            {
                while (true)
                {
                    Test_SendMessg();
                }
            }
        }

        /// <summary>
        /// 测试传送数据给服务端
        /// </summary>
        public void Test_SendMessg()
        {
            string readLine = Console.ReadLine();
            //string readLine = DateTime.Today.ToString();
            byte[] WriteBuffer = Encoding.ASCII.GetBytes(readLine);
            ClientStream.Write(WriteBuffer, 0, WriteBuffer.Length);

            Console.WriteLine(DateTime.Now + " send Word: " + readLine);

        }
    }
}
