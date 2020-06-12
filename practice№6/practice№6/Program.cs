/*Ввести a_1,a_2,a_3,N.
Построить последовательность чисел a_k  = 13* a_k–1 – 10* a_k-2 + a_k–3.
Построить N элементов последовательности проверить, образуют ли элементы,
стоящие на четных местах, возрастающую подпоследовательность.*/

using System;

namespace practice_6
{
    class Program
    {
        static int a1;
        static int a2;
        static int a3;

        static void Main(string[] args)
        {
            Console.Write("Введите а1: ");
            a1 = int.Parse(Console.ReadLine());
            Console.Write("Введите а2: ");
            a2 = int.Parse(Console.ReadLine());
            Console.Write("Введите а3: ");
            a3 = int.Parse(Console.ReadLine());
            Console.Write("Введите N: ");
            int N = int.Parse(Console.ReadLine());

            int[] result = new int[N];

            Console.Write("Итоговая последовательность: ");
            for(int i = 1; i <= N; i++)
            {
                Console.Write(Function(i) + " ");
            }

            if (Function(2) > Function(4))
            {
                Console.WriteLine("Последовательность убывающая");
            }
            else if(Function(2) < Function(4))
            {
                Console.WriteLine("Последовательность возрастающая");
            }
            else
            {
                Console.WriteLine("Последовательность остается не изменной");
            }

            Console.WriteLine();
        }

        // Рекурсивная функция, нахождения элемента последовательности.
        static int Function(int a)
        {
            int result;

            if (a == 1)
            {
                return a1;
            }
            else if (a == 2)
            {
                return a2;
            }
            else if (a == 3)
            {
                return a3;
            }
            else
            {
                result = 13 * Function(a - 1) - 10 * Function(a - 2) + Function(a - 3);
                return result;
            }
        }
    }
}
