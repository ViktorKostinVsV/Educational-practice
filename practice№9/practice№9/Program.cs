﻿using System;

namespace practice_9
{
    class Program
    {
        static collection MyCollection = new collection();

        public class Item
        {
            public Item(int data)
            {
                Data = data;
            }
            public int Data { get; set; }
            public Item Next { get; set; }
        }

        public class collection
        {
            public Item head; // головной/первый элемент
            public Item tail; // последний/хвостовой элемент
            int count;  // количество элементов в списке

            // добавление элемента
            public void Add(int data)
            {
                Item node = new Item(data);
                // если список пуст
                if (head == null)
                {
                    head = node;
                    tail = node;
                    tail.Next = head;
                }
                else
                {
                    node.Next = head;
                    tail.Next = node;
                    tail = node;
                }
                count++;
            }
            public bool Remove(int data)
            {
                Item current = head;
                Item previous = null;

                if (IsEmpty) return false;

                do
                {
                    if (current.Data.Equals(data))
                    {
                        // Если узел в середине или в конце
                        if (previous != null)
                        {
                            // убираем узел current, теперь previous ссылается не на current, а на current.Next
                            previous.Next = current.Next;

                            // Если узел последний,
                            // изменяем переменную tail
                            if (current == tail)
                                tail = previous;
                        }
                        else // если удаляется первый элемент
                        {

                            // если в списке всего один элемент
                            if (count == 1)
                            {
                                head = tail = null;
                            }
                            else
                            {
                                head = current.Next;
                                tail.Next = current.Next;
                            }
                        }
                        count--;
                        return true;
                    }

                    previous = current;
                    current = current.Next;
                } while (current != head);

                return false;
            }

            public bool IsEmpty { get { return count == 0; } }
        }
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());

            Add(MyCollection,5);

            Console.WriteLine(MyCollection.tail.Data);
            Console.WriteLine(MyCollection.head.Data);

            Console.WriteLine(Contains(MyCollection.head, 15));
            Console.WriteLine(Contains(MyCollection.head, 5));

            Delete(MyCollection,6);

            Console.WriteLine(MyCollection.tail.Data);
            Console.WriteLine(MyCollection.head.Data);

        }

        static void Add(collection collection ,int n)
        {
            if (n > 0)
            {
                if (n > 1)
                {
                    Add(collection, n - 1);
                }

                collection.Add(n);
            }
        }

        static void Delete(collection collection,int n)
        {
            if (n > 1)
            {
                Delete(collection,n - 1);
            }

            collection.Remove(n);
        }

        static public bool Contains(Item current, int data)
        {
            if (current.Equals(MyCollection.tail))
            {
                return current.Data.Equals(data);
            }
            else if (current.Data.Equals(data))
            {
                return true;
            }
            else if (Contains(current.Next, data) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
