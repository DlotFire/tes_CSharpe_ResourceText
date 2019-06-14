using System;

namespace tes_CSharpe_ResourceText
{
    class Program
    {
        static void Main(string[] args)
        {
            GetProjectPath();

            //TestConvertDotResource ts = new TestConvertDotResource();

            //new 网络.TestIPAdress();
            //new 网络.TestTCP_Client();

            //TestZip tesZip = new TestZip("o");
            //ClassTestDNS tesDns = new ClassTestDNS();

            //线程.TesThreading tsThreading = new 线程.TesThreading();

            //new 序列化与反序列化.TestXPathQueryGenerator();

            //new 反射.TestReflection_Assembly();
            //new 反射.TestReflection_module();
            //new 反射.TestReflection_Type();

            //new LINQ.TestIntroToLINQ();
            new 代码生成.Tes_MD5();
        }

        private static void GetProjectPath()
        {
            //1.获取模块的完整路径。 
            Console.WriteLine($"System.Diagnostics.Process.GetCurrentProcess():" +
                $" \n{System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName}\n");

            //2.获取和设置当前目录(该进程从中启动的目录)的完全限定目录 
            Console.WriteLine($"Environment.CurrentDirectory: " +
                $"\n{Environment.CurrentDirectory}\n");

            //3.获取应用程序的当前工作目录 
            Console.WriteLine($"System.IO.Directory.GetCurrentDirectory():" +
                $" \n{System.IO.Directory.GetCurrentDirectory()}\n");

            //4.获取程序的基目录 
            Console.WriteLine($"AppDomain.CurrentDomain.BaseDirectory:" +
                $" \n{AppDomain.CurrentDomain.BaseDirectory}\n");

            //5.获取和设置包括该应用程序的目录的名称 
            Console.WriteLine($"AppDomain.CurrentDomain.SetupInformation.ApplicationBase:" +
                $" \n{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\n");

            //6.获取启动了应用程序的可执行文件的路径 
            // System.Windows.Forms.Application.StartupPath;

            //7.获取启动了应用程序的可执行文件的路径及文件名 
            // System.Windows.Forms.Application.ExecutablePath;

            Console.WriteLine("====================================================");
        }
    }
}
