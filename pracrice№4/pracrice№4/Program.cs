using System;

namespace pracrice_4
{
    class Program
    {
        // Возвращает значение функции.
        static double MyFunction(double x)
        {
            double func = Math.Pow(x,3)-(0.2*Math.Pow(x,2))-(0.2*x)-1.2;
            return func;
        }

        static void Main(string[] args)
        {
            double x0;      // Временная переменная.
            double a = 1;   // Левая граница отрезка.
            double b = 1.5; // Правая граница отрезка.
            double eps;     // Значение эпсилон.

            Console.Write("Введите Эпсилон: ");
            eps = double.Parse(Console.ReadLine());

            if (a > b)
            {
                x0 = a;
                a = b;
                b = x0;
            }

            // Если f(a)*f(b)>0 корней нет.
            if (MyFunction(a) * MyFunction(b) > 0)
            {
                Console.WriteLine("Корней нет");
            }
            else
            {
                // находим середину отрезка.
                x0 = (a + b) / 2;

                // Проверяем на какой части отрезка находится корень.
                if (MyFunction(a) * MyFunction(x0) < 0)
                {
                    b = x0;
                }
                if (MyFunction(x0) * MyFunction(b) < 0)
                {
                    a = x0;
                }

                // Повторяем пока |b-a|>eps.
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
