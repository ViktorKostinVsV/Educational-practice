/*Пусть D – заштрихованная часть плоскости (рис. 1.3.1) и пусть u определяется по x и y следующим
 образом (запись (x,y)ϵD означает, что точка с координатами x,y принадлежит D): 
г)u= {(x^2-1 если (x,y)∈D, √(|x-1| ) в противном случае;
Даны действительные числа x,y. Определить u.
*/


using System;

namespace practice_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите x: ");
            double userX = double.Parse(Console.ReadLine());
            Console.Write("Введите y: ");
            double userY = double.Parse(Console.ReadLine());

            Console.Write("u = ");

            // Проверка на совпадение с фигурой.
            if (userY >= 0 &&
                Math.Abs(Math.Pow(userX, 2) + Math.Pow(userY, 2)) <= 1 &&
                (Math.Abs(Math.Pow(userX, 2) + Math.Pow(userY, 2)) >= Math.Pow(0.3, 2) || (userX <= 0)))
            {
                Console.WriteLine(Math.Pow(userX, 2) - 1);
            }
            else
            {
                Console.WriteLine(Math.Sqrt(Math.Abs(userX - 1)));
            }
        }
    }
}
