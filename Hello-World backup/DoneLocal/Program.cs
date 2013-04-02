using System;
using System.Threading;

class ThreadTest
{
    static void Main()
    {
		string t = "";
		
		ThreadTest tt = new ThreadTest();   // Create a common instance
        new Thread(tt.Go).Start();
        tt.Go();

        Console.ReadKey();
    }

    // Note that Go is now an instance method
    void Go()
    {
        bool done = false;
        if (!done) { done = true; Console.WriteLine("Done"); }
    }
}

