public class Functions
{
    public static long Factorial(int n)
    {
        if (n < 0) { return -1; }    //error result - undefined
        if (n > 256) { return -2; }  //error result - input is too big

        if (n == 0) { return 1; }

        // Calculate the factorial iteratively rather than recursively:
        long result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
}