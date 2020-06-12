/*Граф задан матрицей смежности. 
Выяснить, является ли он двудольным.*/

using System;

namespace practice_8
{
    class Program
    {
        static bool cheak = true;   // Проверка на двудольность.
        static char[] colors;       // Массив для окраски вершин.
        static int[][] array;       // Матрица смежности.

        // Метод для создания массива.
        static int[,] MakeArray(int n)
        {
            Console.WriteLine("Пишите связь сдругими вершинами  через пробел, если связь  есть пишите 1, иначе 0.");

            bool check = false; ;
            int[,] array = new int[n, n];
            int num;

            for (int i = 0; i < n; i++)
            {
                do
                {
                    check = false;

                    Console.Write($"\n({i + 1}) вершина --> ");
                    string txt = Console.ReadLine();
                    string[] arrayTxt = txt.Split(' ');
                    if (arrayTxt.Length != n)
                    {
                        Console.WriteLine("Неверное кол-во вершин.\nПовторите попытку.");
                        check = true;
                    }
                    else
                    {
                        for (int j = 0; j < arrayTxt.Length; j++)
                        {
                            if (int.TryParse(arrayTxt[j], out num))
                            {
                                if (num == 0 || num == 1)
                                {
                                    array[i, j] = num;
                                }
                                else
                                {
                                    Console.WriteLine("Неверно введены данные.\nПовторите попытку.");
                                    check = true;
                                    break;
                                }
                            }
                        }
                    }

                } while (check);
            }

            return array;
        }

        // Метод для создания равнного массива [вершина][с какими вершинами связаны]
        static int[][] MainArray(int[,] array)
        {
            int nums = 0;
            int[][] mainArray = new int[array.GetLength(0)][];

            for(int i = 0; i < array.GetLength(0); i++)
            {
                nums = 0;
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == 1)
                    {
                        nums++;
                    }
                    
                }

                mainArray[i] = new int[nums];

                for (int j = 0, k=0; j < nums;k++)
                {
                    if (array[i, k] == 1)
                    {
                        mainArray[i][j] = k;
                        j++;
                    }
                    
                }
            }

            return mainArray;
        }

        // Рекурсивный метод для окраски вершин.
        static void Method(int point, char color)
        {
            // Проверяем не окрашена ли вершина.
            if (colors[point] == 'o')
            {
                // Окрашиваем вершину.
                colors[point] = color;

                // Меняем цвет на противоположный.
                char newColor = color == '1' ? '2' : '1';

                // Цикл перебирающий соседей.
                foreach (int i in array[point])
                {
                    // Если цвета совпадают, то граф не двудольный.
                    if (colors[point] == colors[i])
                    {
                        cheak = false;
                    }

                    // Если следующий элемент не окрашен.
                    if (colors[i] == 'o')
                    {
                        Method(i, newColor);
                    }
                }
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите кол-во вершин в графе: ");
            int n = int.Parse(Console.ReadLine());
            colors = new char[n];
            for(int i = 0; i < n; i++)
            {
                colors[i] = 'o';
            }
            array = MainArray(MakeArray(n));

            for (int i = 0; i < array.Length; i++)
            {
                Method(i, '1');
            }

            Console.WriteLine(cheak);
        }
    }
}
