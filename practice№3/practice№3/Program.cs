using System;

namespace practice_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double userX = double.Parse(Console.ReadLine());
            double userY = double.Parse(Console.ReadLine());

            if (userY >= 0 &&
                Math.Abs(Math.Pow(userX, 2) + Math.Pow(userY, 2)) <= 1 &&
                (Math.Abs(Math.Pow(userX, 2) + Math.Pow(userY, 2)) >= Math.Pow(0.3, 2) || (userX <= 0)))
            {
                Console.WriteLine(Math.Pow(userX, 2) - 1);
            }
            else
            {
                Console.WriteLine(Math.Sqrt(Math.Abs(userX - 1)));
            }
        }
    }
}
