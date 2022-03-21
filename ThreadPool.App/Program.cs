using System;
using System.Threading;

namespace ThreadPool.App;

class Program
{
    
    static void PrintTheNumbers(object state)
    {
        Printer task = (Printer)state;
        task.PrintNumbers();
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("\n***** Fun with CLR Thread Pool *****\n");
        Console.WriteLine("Main thread started. ThreadID = {0}", Thread.CurrentThread.ManagedThreadId);
        
        Printer p = new Printer();

        WaitCallback workItem = new WaitCallback(PrintTheNumbers);

        for(int i = 0; i < 10; i++)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(workItem, p);
        } 

        Console.WriteLine("All tasks queued");
        Console.ReadLine();
    }
}