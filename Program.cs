using System;

namespace LinkedListHW
{
    internal class Program
    {
        private static void Main()
        {
            //  QUESTION 2
            Node<int> a1 = new Node<int>(5);
            Node<int> b1 = new Node<int>(5, a1);
            Node<int> c1 = new Node<int>(8, b1);
            Node<int> d1 = new Node<int>(2, c1);
            Node<int> e1 = new Node<int>(9, d1);
            Node<int> f1 = new Node<int>(1, e1);
            if (List10(f1))
            {
                f1.InsertEnd(6);
                f1.InsertEnd(4);
            }
            Console.WriteLine(f1);

            // QUESTION 3
            Node<int> listTrue = CreateLinkedList(1, 2, 1, 2); // 1 -> 2 -> 1 -> 2 (low, high, low, high) => true
            Node<int> listFalse = CreateLinkedList(2, 1, 2, 1); // 2 -> 1 -> 2 -> 1 (high, low, high, low) => false

            Console.WriteLine(Sod(listTrue));
            Console.WriteLine(Sod(listFalse));

            Console.ReadKey();



        }
        private static Node<T> CreateLinkedList<T>(params T[] numbers)
        {
            Node<T> linkedList = new Node<T>(numbers[numbers.Length - 1]); ;

            for (int i = numbers.Length - 2; i >= 0; i--)
            {
                linkedList = new Node<T>(numbers[i], linkedList);
            }

            return linkedList;
        }

        /// <summary>
        /// Returns true if there is given sequence of num in the given linkedlist
        /// </summary>
        // טענת כניסה
        /// <param name="list">linkedlist to check the sequence in</param>
        /// <param name="num">num which should be in sequence</param>
        /// <param name="count">number of num which should be in the sequence [(count = 3) => num num num]</param>
        // טענת יציאה
        /// <returns>true if the sequence of [num] [count] times in the given [list] linkedlist</returns>
        private static bool CountNumExist(Node<int> list, int num, int count)
        {
            Node<int> temp = list;
            int counter = 0;

            while (temp != null)
            {
                if (temp.GetValue() == num)
                {
                    counter++; // inc counter by 1
                    if (counter == count) // if counter equals to count
                        return true;
                }
                else
                    counter = 0;

                temp = temp.GetNext();
            }
            return false;
        }

        /// <summary>
        /// Checks if the sum of the two following numbers in the given linkedlist is 10 and the length of the linked list is even number
        /// </summary>
        // טענת כניסה
        /// <param name="list">linked list to check</param>
        // טענת יציאה
        /// <returns>true if the sum of the two following number in the given linked list is 10 and the length of the given linked list is even number</returns>
        private static bool List10(Node<int> list)
        {
            int length = 0;
            Node<int> temp = list;

            while (temp != null)
            {
                if ((temp.GetValue() + temp.GetNext().GetValue()) != 10) // sum of two following numbers is NOT 10 (not list10)
                    return false;

                temp = temp.GetNext().GetNext();
                length++;
            }

            if (temp.Length() % 2 != 0) // list length isn't even number (the length is odd number, which is not list10)
                return false;

            return true;

        }
        /// <summary>
        /// checks for each node, if the next node is greater or equals than the previous and next nodes
        /// (low, high, low, high)
        /// for example: 6, 9, 3, 6, 1, 4
        /// </summary>
        // טענת כניסה
        /// <param name="list">linked list to check</param>
        // טענת יציאה
        /// <returns>true if the next node is greater or equals than the previous and next nodes (low, high, low, high) either, false.</returns>
        public static bool Sod(Node<int> list)
        {
            Node<int> p = list;
            while (p != null)
            {
                if (p.HasNext())
                {
                    if (p.GetNext().GetValue() < p.GetValue())
                        return false;
                }
                p = p.GetNext();
                if (p != null)
                {
                    if (p.HasNext())
                    {
                        if (p.GetNext().GetValue() > p.GetValue())
                            return false;
                        p = p.GetNext();
                    }
                }
            }
            return true;
        }
    }
}
