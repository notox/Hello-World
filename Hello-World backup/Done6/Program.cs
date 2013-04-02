using System;
using System.Threading;

class ThreadTest
{
    static bool done;    // Static fields are shared between all threads
    static readonly object locker = new object();

    static void Main()
    {
        ThreadTest tt = new ThreadTest();   // Create a common instance
        new Thread(tt.Go).Start();
        tt.Go();

        Console.ReadKey();
    }

    void Go()
    {
        Monitor.Enter(locker);
        try
        {
            if (!done) { Console.WriteLine("Done"); done = true; }
        }
        finally
        {
            Monitor.Exit(locker);
        }
    }
}
