using System;
using System.Threading;

class ThreadTest
{
    bool done;

    static void Main()
    {
        ThreadTest tt = new ThreadTest();   // Create a common instance
        new Thread(tt.Go).Start();
        tt.Go();

        Console.ReadKey();
    }

    // Note that Go is now an instance method
    void Go()
    {
        if (!done) { done = true; Console.WriteLine("Done"); }
    }
}

