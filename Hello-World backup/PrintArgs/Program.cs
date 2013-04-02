namespace PrintArgs
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(string arg in args)
            {
                System.Console.WriteLine(arg);
            }
        }
    }
}
