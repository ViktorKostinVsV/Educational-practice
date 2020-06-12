/*Дана действительная квадратная матрица порядка 9.
Получить целочисленную квадратную матрицу того же порядка,
в которой элементы равны единице, если соответствующий ему элемент исходной матрицы больше элемента,
расположенного в его строке на главной диагонали, и равен нулю в противном случае */

using System;

namespace practice_5
{
    class Program
    {

        static Random rnd = new Random();

        // Создаем массив.
        static int[,] MakeArray()
        {
            int[,] arr = new int[9, 9];

            for(int i = 0; i < arr.GetLength(0); i++)
            {

                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rnd.Next(1, 10);
                    Console.Write(arr[i, j] + " ");
                }

                Console.WriteLine();
            }

            return arr;
        }

        // Изменяем массив в соответствии с заданием.
        static int[,] NewArray(int[,] arr)
        {
            int equal;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                equal = arr[i, i];

                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i != j)
                    {
                        // Если элемент больше элемента главной дигонали, заменяется на 1, иначе - на 0.
                        if (equal < arr[i, j])
                        {
                            arr[i, j] = 1;
                        }
                        else
                        {
                            arr[i, j] = 0;
                        }
                    }
                    else
                    {
                    }
                }

            }

            return arr;
        }

        // Вывод массива.
        static void Show(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                        Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Генерация массива...");
            int[,] arr = MakeArray();
            Console.WriteLine("Измененный массив:");
            arr = NewArray(arr);
            Show(arr);
        }
    }
}
