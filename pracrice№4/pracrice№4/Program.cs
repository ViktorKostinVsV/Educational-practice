using System;

namespace pracrice_4
{
    class Program
    {
        static double MyFunction(double x)
        {
            double func = Math.Pow(x,3)-(0.2*Math.Pow(x,2))-(0.2*x)-1.2;
            return func;
        }

        static double Dif(double x)
        {
            double dif = (3 * Math.Pow(x, 2)) - (0.4 * x) - 1.4;
            return dif;
        }

        static double Dif2(double x)
        {
            double dif2 = (6 * x) - 1.8;
            return dif2;
        }

        static void Main(string[] args)
        {
            double x0, xn;
            double a = 1; 
            double b = 1.5;
            double eps;

            Console.Write("Введите Эпсилон: ");
            eps = double.Parse(Console.ReadLine());

            if (a > b)
            {
                x0 = a;
                a = b;
                b = x0;
            }

            if (MyFunction(a) * MyFunction(b) > 0)
            {
                Console.WriteLine("Корней нет");
            }
            else
            {
                x0 = (a + b) / 2;

                if (MyFunction(a) * MyFunction(x0) < 0)
                {
                    b = x0;
                }
                if (MyFunction(x0) * MyFunction(b) < 0)
                {
                    a = x0;
                }

                while (Math.Abs(b - a) > eps)
                {
                    x0 = (a + b) / 2;

                    if (MyFunction(a) * MyFunction(x0) < 0)
                    {
                        b = x0;
                    }
                    if (MyFunction(x0) * MyFunction(b) < 0)
                    {
                        a = x0;
                    }
                }

                Console.WriteLine("Корень: " + x0);
            }        
        }
    }
}
