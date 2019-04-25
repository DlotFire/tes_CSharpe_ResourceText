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
        public TestConvertDotResource()
        {
            //ResPrint();
            PrintEnvironmentVariables();
        }

        /// <summary>
        /// 测试加载配制表resx
        /// </summary>
        public void ResPrint()
        {
            ResourceManager res = new ResourceManager("tes_CSharpe_ResourceText.o", typeof(TestConvertDotResource).Assembly);
            if (res != null) Console.WriteLine("res not null");
            Console.WriteLine(res.BaseName);
            Console.WriteLine(res.GetString("sf"));
        }

        /// <summary>
        ///  打印系统环境变量
        /// </summary>
        public void PrintEnvironmentVariables()
        {
            Console.WriteLine(Environment.CommandLine);
            Console.WriteLine(Environment.CurrentDirectory);

            foreach (System.Collections.DictionaryEntry item in Environment.GetEnvironmentVariables())
            {
                Console.WriteLine(string.Format("items:{0} , {1} ", item.Key, item.Value));
            }
        }

        /// <summary>
        /// 打印信息
        /// </summary>
        public void Test_PrintMessg()
        {

        }
    }
}
