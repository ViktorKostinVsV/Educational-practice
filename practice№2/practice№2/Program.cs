/*Число Смита — такое составное число,
сумма цифр которого равняется сумме цифр всех его простых сомножителей.
Так, примером числа Смита может служить 202,
поскольку 2 + 0 + 2 = 4 и 2 + 1 + 0 + 1 = 4 (202 = 2 * 101). 
Напишите программу, которая для заданной последовательности чисел определяет,
какие из них являются числами Смита. 
*/

using System;

namespace practice_2
{
    class Program
    {
        public static int Main()
        {
            // Ввод чисел.
            string[] masNumbers = Console.ReadLine().Split(' ');

            int counter;        // Счетчик множителей.
            int sum;            // Сумма чисел.
            string result = ""; // Переменная для результата.

            // Цикл для разложения чисел на простые множители.
            for (int k = 0; k < masNumbers.Length; k++)
            {
                sum = 0;                            // Счетчик множителей.
                counter = 0;                        // Сумма чисел.
                int num = int.Parse(masNumbers[k]); // Число на разложение.

                // Раскладываем на множитель (2)
                for (; num % 2 == 0; num /= 2)
                {
                    sum += 2;
                    counter++;
                }

                // Раскладываем на све остальные множители.
                for (int i = 3; i <= num;)
                {
                    if (num % i == 0)
                    {
                        // Если число простое и больше 9, считаем сумму чисел.
                        if (i > 9)
                        {
                            sum += Summ(i);
                            counter++;
                        }
                        // Иначе добавляем число к сумме.
                        else if (i > 1)
                        {
                            sum += i;
                            counter++;
                        }
                        num /= i;
                    }
                    else
                    {
                        i += 2;
                    }
                }

                // Если это число Смита, в результат пишется 1, иначе 0.
                if (sum == Summ(int.Parse(masNumbers[k]))&& counter!=1)
                {

                    result += 1;
                }
                else
                {
                    result += 0;
                }
            }

            Console.WriteLine(result);
            return 0;
        }

        // Метод считающий числа.
        static public int Summ(int number)
        {
            int s = 0;
            while (number > 0)
            {

                s = s + number % 10;
                number = number / 10;

            }

            return s;
        }

    }

    
}
