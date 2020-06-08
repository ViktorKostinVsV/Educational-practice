using System;

namespace practice_1
{
    class Program
    {
        static void Main()
        {
            int n;
            int k = 21;
            int index = 0;

            string[] s = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "22", "30", "41", "50",
        "61", "70", "81", "90", "111" };
            string[] s2 = { "200", "311", "400", "511", "600", "711", "800", "911" };

            n = int.Parse(Console.ReadLine());

            if (n < 21)
            {
                Console.WriteLine(s[n - 1]);
                return;
            }
            if(n>=21)
            {             
                for(int i =0; k != n; k++)
                {
                    if (i % 2 == 0)
                    {
                        s2[i] += "0";
                    }
                    else
                    {
                        s2[i] += "1";
                    }                  

                    if (i != 7)
                    {
                        i++;
                    }
                    else
                    {
                        i = 0;
                    }

                    index = i;
                }
            }

            Console.WriteLine(s2[index]);
        }       
    }
}
