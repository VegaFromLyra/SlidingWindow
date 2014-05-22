using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a sequence of integers and a size k, 
// print the minimum number for every sliding window of size k
namespace SlidingWindow
{
    class Program
    {
        static void Main(string[] args)
        {
            // 4 7 2 3 5 9 6 2 4 5

            LinkedList<int> input = new LinkedList<int>();
            input.AddLast(4);
            input.AddLast(7);
            input.AddLast(2);
            input.AddLast(3);
            input.AddLast(5);
            input.AddLast(9);
            input.AddLast(6);
            input.AddLast(2);
            input.AddLast(4);
            input.AddLast(5);

            PrintMinimum(input, 3);
        }

        // Time complexity: O(n) => Its actually O(n / k) * k for worst case
        // Worst case is for sequence like 1 2 3 1 2 3
        // Space complexity: O(n)
        static void PrintMinimum(LinkedList<int> input, int k)
        {
            LinkedListNode<int> currentNode = input.First;

            LinkedList<int> candidateMinimums = new LinkedList<int>();

            int count = 0;

            while (currentNode != null)
            {
                if (candidateMinimums.Count == k)
                {
                    candidateMinimums.RemoveFirst();
                }

                while ((candidateMinimums.Last != null) && (currentNode.Value < candidateMinimums.Last.Value))
                {
                    candidateMinimums.RemoveLast();
                }

                candidateMinimums.AddLast(currentNode.Value);


                if (count >= k - 1)
                {
                    Console.WriteLine(candidateMinimums.First.Value);
                }

                count++;
                currentNode = currentNode.Next;
            }
        }
    }
}
