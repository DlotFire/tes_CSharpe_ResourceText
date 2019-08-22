using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace tes_CSharpe_ResourceText.进程
{
    class Tes_Process
    {
        Process proc;
        public Tes_Process()
        {
            proc = new Process();

            CreateCMDProcess();
            //OpenAnFileProcess();
        }

        /// <summary>
        /// 创建一个CMD窗口
        /// </summary>
        public void CreateCMDProcess()
        {
            proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.UseShellExecute = false;
            //proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = false;
            proc.Start();
            proc.StandardInput.WriteLine("dir");//也可以写成dir&exit命令
            //proc.StandardInput.WriteLine("exit");//不退出的话，它会一直等待输入。

            //string str = proc.StandardOutput.ReadToEnd();
            Console.WriteLine("st");
        }

        /// <summary>
        /// 打开F盘的tes01文件
        /// </summary>
        public void OpenAnFileProcess()
        {
            proc.StartInfo.FileName = "f:/tes01.txt";
            proc.Start();
        }
    }
}
