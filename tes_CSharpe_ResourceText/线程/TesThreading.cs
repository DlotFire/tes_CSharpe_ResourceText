using System;
using System.Threading;

namespace tes_CSharpe_ResourceText.线程
{
    class TesThreading
    {
        public TesThreading()
        {
            Console.WriteLine("Come IN TesThread Class!!!");

            //EnqueueThreadPool();//有线程存在才会执行，且线程执行完毕才会执行它。
            //Thread.Sleep(1000);//如不挂起，ThreadPool不会执行。

            //TesThreadStart();

            TesWaitHandle();
        }

        /// <summary>
        /// 创建有参数线程回调函数
        /// </summary>
        private void TesThreadStart()
        {
            //无参委托，ThreadStart
            //ThreadStart doworkDeleg = DoWork;
            //Thread newThread = new Thread(doworkDeleg);
            //Console.WriteLine(10);
            //newThread.Start();
            //Console.WriteLine(11);

            //有参委托，
            ParameterizedThreadStart paramThread = DoWork;
            Thread newThread = new Thread(paramThread);
            Console.WriteLine(12);
            newThread.Start("parame");
            Console.WriteLine(13);

        }

        /// <summary>
        /// 无参线程执行函数
        /// </summary>
        private void DoWork()
        {
            Console.WriteLine("function DoWork excute!! it is no parameter.");

        }

        /// <summary>
        /// 有参线程执行函数
        /// </summary>
        /// <param name="na"></param>
        private void DoWork(object na)
        {
            Console.WriteLine("function DoWork excute!! it is have an parameter");
            Console.WriteLine(na);
        }

        /// <summary>
        /// 测试线程池
        /// </summary>
        private void EnqueueThreadPool()
        {
            ThreadPool.QueueUserWorkItem(DoWork);
            ThreadPool.QueueUserWorkItem(DoWork,"pool");             
        }

        /// <summary>
        /// 测试waitHandle API
        /// </summary>
        private void TesWaitHandle()
        {
            Console.WriteLine("Main starting.");
            AutoResetEvent autoEvent = new AutoResetEvent(false);

            ThreadPool.QueueUserWorkItem(
                new WaitCallback(WorkMethod), autoEvent);

            // Wait for work method to signal.
            autoEvent.WaitOne();//挂起AutoRestEvent进程，直到接到信息
            Console.WriteLine("Work method signaled.\nMain ending.");
        }

        /// <summary>
        /// 测试waitHandle API
        /// </summary>
        private void WorkMethod(object stateInfo)
        {
            Console.WriteLine("Work starting.");

            // Simulate time spent working.
            Thread.Sleep(new Random().Next(100, 2000));

            // Signal that work is finished.
            Console.WriteLine("Work ending.");
            ((AutoResetEvent)stateInfo).Set();//通知waitOne进程可以继续了
        }

    }
}
