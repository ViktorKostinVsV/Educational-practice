using System;
using System.Text;

namespace pracrice_11
{
    class Program
    {
        // Кодируем заданный текст.
        static StringBuilder Encrypt(StringBuilder builder, int n)
        {
            // Цикл для сдвига кодирования.
            for (int j = 0; j < n; j++)
            {
                // Цикл для замены букв.
                for (int i = 0; i < builder.Length; i++)
                {
                    // Проверяем буквы русского алфавита.
                    if (builder[i] >= (char)1040 && builder[i] < (char)1045 || (builder[i] >= (char)1046 && builder[i] < (char)1071)
                        || (builder[i] >= (char)1072 && builder[i] < (char)1077 || (builder[i] >= (char)1078 && builder[i] < (char)1103)))
                    {
                        builder[i]++;
                    }

                    // Замена граничных букв.
                    else if (builder[i] == (char)1071)  
                    {
                        builder[i] = 'А';
                    }
                    else if (builder[i] == (char)1103)
                    {
                        builder[i] = 'а';
                    }
                    else if (builder[i] == (char)1045)
                    {
                        builder[i] = 'Ё';
                    }
                    else if (builder[i] == (char)1077)
                    {
                        builder[i] = 'ё';
                    }
                    else if (builder[i] == (char)1025)
                    {
                        builder[i] = 'Ж';
                    }
                    else if (builder[i] == (char)1105)
                    {
                        builder[i] = 'ж';
                    }
                }
            }

            return builder;
        }

        // Декодируем заданный текст.
        static StringBuilder Decrypt(StringBuilder builder, int n)
        {
            // Цикл для сдвига декодирования.
            for (int j = 0; j < n; j++)
            {
                // Цикл для замены букв.
                for (int i = 0; i < builder.Length; i++)
                {
                    // Проверяем буквы русского алфавита.
                    if (builder[i] > (char)1040 && builder[i] <= (char)1045 || (builder[i] > (char)1046 && builder[i] <= (char)1071)
                        || (builder[i] > (char)1072 && builder[i] <= (char)1077 || (builder[i] > (char)1078 && builder[i] <= (char)1103)))
                    {
                        builder[i]--;
                    }

                    // Замена граничных букв.
                    else if (builder[i] == (char)1040)
                    {
                        builder[i] = 'Я';
                    }
                    else if (builder[i] == (char)1072)
                    {
                        builder[i] = 'я';
                    }
                    else if (builder[i] == (char)1046)
                    {
                        builder[i] = 'Ё';
                    }
                    else if (builder[i] == (char)1078)
                    {
                        builder[i] = 'ё';
                    }
                    else if (builder[i] == (char)1025)
                    {
                        builder[i] = 'Е';
                    }
                    else if (builder[i] == (char)1105)
                    {
                        builder[i] = 'е';
                    }
                }
            }

            return builder;
        }

        static void Main(string[] args)
        {

            Console.Write("Введите текст: ");
            StringBuilder builder = new StringBuilder(Console.ReadLine());

            builder = Encrypt(builder, 1);

            Console.WriteLine(builder);

            builder = Decrypt(builder, 1);

            Console.WriteLine(builder);
        }      
    }
}
