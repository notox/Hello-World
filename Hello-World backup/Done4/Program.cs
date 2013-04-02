using System;
using System.Threading;

class ThreadTest
{
    static bool done;    // Static fields are shared between all threads

    static void Main()
    {
        ThreadTest tt = new ThreadTest();   // Create a common instance
        new Thread(tt.Go).Start();
        tt.Go();

        Console.ReadKey();
    }

    void Go()
    {
        if (!done) { Console.WriteLine("Done"); done = true; }
    }
}
