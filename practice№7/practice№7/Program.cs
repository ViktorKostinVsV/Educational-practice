using System;

namespace practice_7
{
    class Program
    {
        static int num = 1;

        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int K = int.Parse(Console.ReadLine());

            int[] array = new int[N];

            for (int i = 0; i< N; i++)
            {
                array[i] = i + 1;
            }

            Print(array, K);

            if (N >= K)
            {
                while (Next(array, N, K))
                {
                    Print(array, K);
                }
            }
        }

        static void Print(int[] array, int K)
        {
            Console.Write(num++ + "= ");

            for(int i = 0; i<K; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine(); 
        }

        static bool Next(int[] array, int N, int K)
        {
            int M = K;

            for (int i = M - 1; i >= 0; --i)
            {
                if (array[i] < N - M + i + 1)
                {
                    ++array[i];
                    for(int j = i + 1; j < M; ++j)
                    {
                        array[j] = array[j - 1] + 1;
                    }
                    return true;
                }
            }

            return false;
        }
    }
}
