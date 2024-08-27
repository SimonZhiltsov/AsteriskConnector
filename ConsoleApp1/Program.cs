using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //var testThread = new Thread(() => { for (var i = 0; i < 10000000;) { var j = i * 223333; Console.WriteLine("1st finished!"); }
            //    Console.WriteLine("1st finished!");
            //});

            ////testThread.IsBackground = true;
            ////testThread.Start();
            //Console.WriteLine(testThread.IsAlive);
            //Console.WriteLine(testThread.IsBackground);
            List<string> tst = new List<string>();
            for (int i = 0; i < 1000; i++)
            {
                tst.Add(i.ToString() + new Random().Next(10000));
            }

            //while (true)
            //{
            //    TestMemory.Test(tst);
            //    Thread.Sleep(500);
            //}

            var threads = new List<Thread>();

            for (var i = 0; i < 100; i++)
            {
                threads.Add(CreateThread(i, ThreadPriority.Normal));
                threads[i].Name = "test" + i;
            }
            threads[1].Start();
            //Console.WriteLine(threads[1].ExecutionContext);

            //var resThreads = new List<Thread>();
            //Console.WriteLine(Thread.CurrentThread.Name);
            //resThreads.AddRange(CreateFewThreads(5, ThreadPriority.Highest));
            //resThreads.AddRange(CreateFewThreads(6, ThreadPriority.Lowest));
            //resThreads.AddRange(CreateFewThreads(7, ThreadPriority.Normal));

            //Task.WaitAll(resThreads.Select(x => Task.Factory.StartNew(x.Suspend)));

            //resThreads.ForEach(x => x.Start());

            var ddd = new string[10000];
        }

        public static class  TestMemory 
        {
            public static void Test(List<string> tst)
            {
                for (int i = 0; i < 1000; i++)
                {
                    tst.Add(i.ToString() + new Random().Next(10000));
                }
                Thread.Sleep(2000);
            }
        }

        static Thread CreateThread(long index, ThreadPriority threadPr)
        {
            var res = new Thread(() =>
            {
                for (var i = 0; i < 10000000;)
                {
                    var j = i * 223333;
                    Console.WriteLine($"{index} execute with priority {threadPr.ToString()}!");
                }
                Console.WriteLine($"{index} finished!");
            });
            return res;
        }



        //TEST
        static Thread[] CreateFewThreads(int n, ThreadPriority threadPriority)
        {
            var threads = new List<Thread>();
            for (var i = 0; i < 100; i++)
            {
                threads.Add(CreateThread(i, threadPriority));
            }

            return threads.ToArray();
        }
    }
}
