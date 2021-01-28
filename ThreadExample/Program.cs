using System;
using System.Threading;

namespace ThreadExample
{
    class Program
    {
        private static int Counter = 0;

        private static object locker = new object();

        private static void ThreadFunction()
        {
            Monitor.Enter(locker);
            try
            {
                for (int i = 0; i < 1000000; i++)
                    Counter += 1;
            }
            finally
            {
                Monitor.Exit(locker);
            }
            
        }

        static void Main(string[] args)
        {
            Thread[] threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(ThreadFunction);
                threads[i].Start();
            }

            for (int i = 0; i < 10; i++)
                threads[i].Join();

            Console.WriteLine("Counter is {0}", Counter);
            Console.ReadKey();
        }
    }
}
