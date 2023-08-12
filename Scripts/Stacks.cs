using System;
using System.Collections.Generic;

namespace VHon
{
    public static class Stacks
    {
        //===============================================================================================================================
        // stack.Shuffle();
        //===============================================================================================================================
        public static void Shuffle<T>(this Stack<T> stack)
        {
            List<T> temp = new(stack);
            Random random = new();

            for (int i = temp.Count - 1; i > 1; i--)
            {
                int k = random.Next(i + 1);
                (temp[i], temp[k]) = (temp[k], temp[i]);
            }

            stack.Clear();
            foreach (T item in temp) stack.Push(item);
        }
        // ------------------------------------------------------------------------------------------------------------------------------        
    }
}