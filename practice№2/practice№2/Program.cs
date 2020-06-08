using System;

namespace practice_2
{
    class Program
    {
        public static int Main()
        {
            string[] masNumbers = Console.ReadLine().Split(' ');

            int counter;
            int sum;
            string result = "";

            for (int k = 0; k < masNumbers.Length; k++)
            {
                sum = 0;
                counter = 0;

                int num = int.Parse(masNumbers[k]);

                for (; num % 2 == 0; num /= 2)
                {
                    sum += 2;
                    counter++;
                }

                for (int i = 3; i <= num;)
                {
                    if (num % i == 0)
                    {
                        if (i > 9)
                        {
                            sum += Summ(i);
                            counter++;
                        }
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
