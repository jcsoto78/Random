using System;
using System.Collections.Generic;
using System.Text;

namespace CodilyTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine($"{Solution(1041)}");
        }


        // Complete the rotLeft function below.
        static int[] rotateArrayToLeft(int[] a, int d)
        {
            var rotatedArray = new int[a.Length];

            //the amount of rotations to the right equaling d rotations to the left
            int rotateToRight = ((2 * a.Length) - d) % a.Length;

            for (int i = 0; i < a.Length; i++)
            {
                var rotatedIndex = (i + rotateToRight) % (a.Length); //right rotation
                rotatedArray[rotatedIndex] = a[i];
            }

            return rotatedArray;
        }

        public static List<int> oddNumbers(int l, int r)
        {
            var oddNumbers = new List<int>();

            for (int i = l; i <= r; i++)
            {
                if (i % 2 != 0)
                {
                    oddNumbers.Add(i);
                }
            }

            return oddNumbers;
        }

        public static string findNumber(List<int> arr, int k)
        {
            string response = "NO";

            if (arr.Contains(k))
            {
                response = "YES";
            }

            return response;
        }

        static int Solution(int n) 
        {
            string binary = Convert.ToString(n, 2);

            var sb = new StringBuilder(binary);
            
            int gap = 0;
            int maxGap = 0;
            int index0 = 0;
            int index1 = 0;

            for (int i = 0; i < sb.Length-1; i++) //iterate through sb char array, -1 to avoid index out of range on belows comparison
            {
                index1 = sb[i].Equals('1')? i : index1;
                index0 = sb[i].Equals('0') ? i : index0;

                if (index0 > index1 && sb[i+1].Equals('1')) // this happens when i is at end of gap -1
                {
                    gap = index0 - index1; 
                }

                maxGap = gap > maxGap ? gap: maxGap; //there can be several gaps
            }

            return maxGap;
        }
    }
}
