using System;

namespace MathApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int.TryParse(args[0], out int value);

            int fatorial = 1;

            for (int n = 1; n <= value; n++)
            {
                fatorial *= n;

                Console.WriteLine(n + " fatorial= " + fatorial);
            }
        }
    }
}
