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

            public Tree()
            {
                data = default;
                left = null;
                right = null;
            }
            public Tree(int d)
            {
                data = d;
                left = null;
                right = null;
            }

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
            tree = Tree.IdealTree(10, tree);

            Tree.ShowTree(tree,2);

            tree = Tree.Destroy(tree);
            Console.WriteLine("Дерево уничтожено");

            Tree.ShowTree(tree, 2);
        }
    }
}
