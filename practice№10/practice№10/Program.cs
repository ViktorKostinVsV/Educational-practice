/*Выполнить задание, реализовав динамические структуры данных «вручную»,
без использования коллекций языка C#.
Написать метод уничтожения дерева.*/

using System;

namespace practice_10
{
    class Program
    {
        class Tree
        {
            static Random rnd = new Random();
            public int data;
            public Tree left;
            public Tree right;
            static public int count = 0;

            // Пустой конструктор.
            public Tree()
            {
                data = default;
                left = null;
                right = null;
            }

            // Конструктор с аргументом типа int.
            public Tree(int d)
            {
                data = d;
                left = null;
                right = null;
            }

            // Создаем дерево.
            static public Tree IdealTree(int size, Tree p)
            {


                if (size <= 0)
                {
                    return null;
                }

                Tree r;
                int nl, nr;
                if (size == 0) { p = null; return p; }
                nl = size / 2;
                nr = size - nl - 1;
                r = new Tree(rnd.Next(1,100));
                for (int i = 0; i < size; i++)
                {
                    r.left = IdealTree(nl, r.left);
                    r.right = IdealTree(nr, r.right);
                }
                return r;
            }

            // Уничтожаем дерево.
            static public Tree Destroy(Tree p)
            {
                if (p != null)
                {
                     Destroy(p.left);

                     Destroy(p.right);

                    p = null;
                }

                return p;
            }

            // Вывод дерева.
            static public void ShowTree(Tree p, int l)
            {
                if (p != null)
                {
                    ShowTree(p.left, l + 3);

                    if (p.data != default)
                    {
                        for (int i = 0; i < l; i++) Console.Write("      ");

                        Console.WriteLine(p.data.ToString());
                    }
                    ShowTree(p.right, l + 3);
                }
            }

            public override string ToString()
            {
                return data.ToString(); ;
            }
        }


        static void Main(string[] args)
        {
            Tree tree = new Tree();
            Console.WriteLine("Создание дерева...");
            tree = Tree.IdealTree(10, tree);

            Tree.ShowTree(tree,2);

            tree = Tree.Destroy(tree);
            Console.WriteLine("Дерево уничтожено");

            Tree.ShowTree(tree, 2);
        }
    }
}
