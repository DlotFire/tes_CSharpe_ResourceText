using System;
using System.Collections.Generic;
using System.Resources;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace tes_CSharpe_ResourceText
{
    class TestConvertDotResource
    {
        //private List<tcpLis>
        private TcpListener server;
        private TcpClient client;
        private TcpClient client_temp;
        private NetworkStream ClientStream;
        
        /// <summary>
        /// 测试加载配制表resx
        /// </summary>
        public void resPrint()
        {
            ResourceManager res = new ResourceManager("tes_CSharpe_ResourceText.o", typeof(TestConvertDotResource).Assembly);
            if (res != null) Console.WriteLine("res not null");
            Console.WriteLine(res.BaseName);
            //Console.WriteLine(res.GetString("sf"));

            Console.WriteLine(Environment.CommandLine);
            Console.WriteLine(Environment.CurrentDirectory);

            foreach (System.Collections.DictionaryEntry item in Environment.GetEnvironmentVariables())
            {
                Console.WriteLine(string.Format("items:{0} , {1} ",item.Key,item.Value));
            }     
        }

        /// <summary>
        /// 测试ipAddress类、TcpListener类
        /// </summary>
        public void testIPAddress()
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

            testIPClient();
            //server.Stop();
            Console.WriteLine("server end....");
        }

        /// <summary>
        /// 测试Client类
        /// </summary>
        public void testIPClient()
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
            //            testSendMessg();
            //        }

            //    }
            //});
            //Thread threadWrite = new Thread(() =>
            //{
            //    while (true)
            //    {
            //        if (client.Connected)
            //        {
            //            testSendMessg();
            //        }

            //    }
            //});

            if (client.Connected)
            {
                while (true)
                {
                    testSendMessg();
                }
            }
        }

        /// <summary>
        /// 测试传送数据给服务端
        /// </summary>
        public void testSendMessg()
        {
            string readLine = Console.ReadLine();
            //string readLine = DateTime.Today.ToString();
            byte[] WriteBuffer = Encoding.ASCII.GetBytes(readLine);
            ClientStream.Write(WriteBuffer, 0, WriteBuffer.Length);

            Console.WriteLine(DateTime.Now + " send Word: " + readLine);

        }


        /// <summary>
        /// 打印信息
        /// </summary>
        public void testPrintMessg()
        {

        }
    }
}
