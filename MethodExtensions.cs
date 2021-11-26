namespace LinkedListHW
{
    internal static class MethodExtensions
    {
        /// <summary>
        /// Returns length of the given linkedlist
        /// </summary>
        // טענת כניסה
        /// <param name="list">linked list to get his length</param>
        // טענת יציאה
        /// <returns>length of the given linkedlist</returns>
        public static int Length<T>(this Node<T> list)
        {
            Node<T> temp = list;
            int length = 0;

            while (temp != null)
            {
                length++;

                temp = temp.GetNext();
            }
            return length;
        }
        /// <summary>
        /// Inserts the given value at the end of the given list
        /// </summary>
        // טענת כניסה
        /// <typeparam name="T">Type of linkedlist/value</typeparam>
        /// <param name="list">linkedlist to insert the given value in</param>
        /// <param name="value">value to insert at the end of the given linkedlist</param>
        // טענת יציאה 
        // אין
        public static void InsertEnd<T>(this Node<T> list, T value)
        {
            Node<T> temp = list;

            while (temp.GetNext() != null)
            {
                temp = temp.GetNext();
            }

            Node<T> next = new Node<T>(value); // create new node with value of the given value
            temp.SetNext(next); // set next to the new created node
        }
    }
}
