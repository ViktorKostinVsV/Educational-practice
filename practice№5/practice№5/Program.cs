using System;

namespace practice_5
{
    class Program
    {

        static Random rnd = new Random();

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
                        if (equal < arr[i, j])
                        {
                            arr[i, j] = 1;
                        }
                        else
                        {
                            arr[i, j] = 0;
                        }
                        Console.Write(arr[i, j] + " ");
                    }
                    else
                    {
                        Console.Write(arr[i, j] + " ");
                    }
                }

                Console.WriteLine();
            }

            return arr;
        }

        static void Main(string[] args)
        {
            int[,] arr = MakeArray();
            Console.WriteLine();
            arr = NewArray(arr);
        }
    }
}
