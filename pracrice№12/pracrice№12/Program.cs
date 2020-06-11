using System;

namespace pracrice_12
{
    class Program
    {
        static int count = 0;   // Счетчик перемещений.
        static int count2 = 0;  // Счетчик сравниваний.

        // Добавление элементов в Пирамиду.
        static int AddInPyramid(int[] array, int i, int N)
        {
            int imax;
            int buf;
            if ((2 * i + 2) < N)
            {
                count2++;
                if (array[2 * i + 1] < array[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
            }
            else imax = 2 * i + 1;
            if (imax >= N)
            {
                count2++;
                return i;
            }
            if (array[i] < array[imax])
            {
                count2++;
                count++;
                buf = array[i];
                array[i] = array[imax];
                array[imax] = buf;
                if (imax < N / 2) i = imax;
            }
            return i;
        }

        // Сортируем пирамидой.
        static void Pyramid(int[] array, int n)
        {
            for (int i = n / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = AddInPyramid(array, i, n);
                if (prev_i != i)
                {
                    count2++;
                    ++i;
                }
            }

            int buf;
            for (int k = n - 1; k > 0; --k)
            {
                count++;
                buf = array[0];
                array[0] = array[k];
                array[k] = buf;
                int i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    count2++;
                    prev_i = i;
                    i = AddInPyramid(array, i, k);
                }
            }
        }

        // Сортируем методом подсчета.
        static void CountingSort(int[] array)
        {
            var min = array[0];
            var max = array[0];

            foreach (int element in array)
            {
                
                if (element > max)
                {
                    count2++;
                    max = element;
                }
                else if (element < min)
                {
                    count2++;
                    min = element;
                }
            }

            count2++;
            var correctionFactor = min != 0 ? -min : 0;
            max += correctionFactor;

            int[] count = new int[max + 1];
            for (var i = 0; i < array.Length; i++)
            {
                count[array[i] + correctionFactor]++;
            }

            var index = 0;
            for (var i = 0; i < count.Length; i++)
            {
                for (var j = 0; j < count[i]; j++)
                {
                    Program.count++;
                    array[index] = i - correctionFactor;
                    index++;
                }
            }
        }

        // Создаем массив.
        static int[] MakeArray(int c)
        {
            Random rnd = new Random();
            int[] mas = new int[c];

            for(int i = 0; i < c; i++)
            {
                mas[i] = rnd.Next(1, 100);
            }

            return mas;
        }

        // Создаем отсортированный массив.
        static int[] MakeSortedArray(int c)
        { 
            int[] mas = new int[c];

            for (int i = 0; i < c; i++)
            {
                mas[i] = i;
            }

            return mas;
        }

        // Создаем массив отсортированный в обратном порядке.
        static int[] MakeUnsortedArray(int c)
        {
            int[] mas = new int[c];

            for (int i = 0; i < c; i++)
            {
                mas[i] = c-i-1;
            }

            return mas;
        }

        // Выводим массив на экран.
        static void ShowArray(int[] array)
        {
            foreach(int i in array)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] array = MakeArray(20);
            ShowArray(array);
            Pyramid(array, array.Length);
            Console.WriteLine();
            Console.WriteLine("Кол-во перемещений: "+ count);
            Console.WriteLine("Кол-во сравнений: "+count2);
            count = 0;
            count2 = 0;
            Console.WriteLine();
            ShowArray(array);

            array = MakeArray(20);
            ShowArray(array);
            CountingSort(array);
            Console.WriteLine();
            Console.WriteLine("Кол-во перемещений: " + count);
            Console.WriteLine("Кол-во сравнений: " + count2);
            count = 0;
            count2 = 0;
            Console.WriteLine();
            ShowArray(array);

            array = MakeSortedArray(20);
            ShowArray(array);
            Pyramid(array, array.Length);
            Console.WriteLine();
            Console.WriteLine("Кол-во перемещений: " + count);
            Console.WriteLine("Кол-во сравнений: " + count2);
            count = 0;
            count2 = 0;
            Console.WriteLine();
            ShowArray(array);

            ShowArray(array);
            CountingSort(array);
            Console.WriteLine();
            Console.WriteLine("Кол-во перемещений: " + count);
            Console.WriteLine("Кол-во сравнений: " + count2);
            count = 0;
            count2 = 0;
            Console.WriteLine();
            ShowArray(array);

            array = MakeUnsortedArray(20);
            ShowArray(array);
            Pyramid(array, array.Length);
            Console.WriteLine();
            Console.WriteLine("Кол-во перемещений: " + count);
            Console.WriteLine("Кол-во сравнений: " + count2);
            count = 0;
            count2 = 0;
            Console.WriteLine();
            ShowArray(array);

            array = MakeUnsortedArray(20);
            ShowArray(array);
            CountingSort(array);
            Console.WriteLine();
            Console.WriteLine("Кол-во перемещений: " + count);
            Console.WriteLine("Кол-во сравнений: " + count2);
            count = 0;
            count2 = 0;
            Console.WriteLine();
            ShowArray(array);

        }
    }
}
