class MainClass
{
    static int Main(string[] args)
    {
        // Test if input arguments were supplied:
        if (args.Length == 0)
        {
            System.Console.WriteLine("Please enter a numeric argument.");
            System.Console.WriteLine("Usage: Factorial <num>");
            return 1;
        }

        try
        {
            // Convert the input arguments to numbers:
            int num = int.Parse(args[0]);

            System.Console.WriteLine("The Factorial of {0} is {1}.", num, Functions.Factorial(num));
            return 0;
        }
        catch (System.FormatException)
        {
            System.Console.WriteLine("Please enter a numeric argument.");
            System.Console.WriteLine("Usage: Factorial <num>");
            return 1;
        }
    }
}

