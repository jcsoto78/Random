using System;
using System.Collections.Generic;
using System.Linq;

namespace AnnoyingCodingTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{GeometricTripletHashed(new List<long>{ 1,2,2,4 }, 2)}");
        }

        //https://www.thepoorcoder.com/hackerrank-count-triplets-solution/
        public static long GeometricTripletHashed(List<long> arr, int r)
        {
            var aHash= new Dictionary<long, int>();//<arr[i],count>
            var bHash = new Dictionary<long, int>();

            long total = 0;

            //fill  aHash
            for (int i = 0; i < arr.Count; i++)
            {
                if (aHash.ContainsKey(arr[i]))
                {
                    aHash[arr[i]]++;
                }
                else
                {
                    aHash.Add(arr[i], 1);
                }
            }

            //check hash for triplets center

            for (int i = 0; i < arr.Count; i++)
            {
                var jLeftIndex = (arr[i] / r); 
                var kRightIndex = (arr[i] * r);

                //update ahash
                aHash[arr[i]] -= 1;

                if (bHash.ContainsKey(jLeftIndex) && aHash.ContainsKey(kRightIndex) && arr[i]%r ==0)
                {
                    total += bHash[jLeftIndex] * aHash[kRightIndex];
                }

                //update bHash
                if (bHash.ContainsKey(arr[i]))
                {
                    bHash[arr[i]]++;
                }
                else
                {
                    bHash.Add(arr[i], 1);
                }

            }

            return total;
           
        }

        public static int GeometricTripletsOpt(List<long> arr, long r)
        {
            //arr.Sort();

            var sortedDictionary = new Dictionary<int, long>();

            for (int i = 0; i < arr.Count; i++)
            {
                sortedDictionary.Add(i,arr[i]);
            }

            int n = sortedDictionary.Count;

            int pI = 0, qI = pI + 1, rI = qI + 1; // PI is back index of sliding window ''caterpillar, RI is head index
            int tripletsCount = 0;

            while (pI < n - 2) //stops when the window indexes are invalid by +1
            {
                ////since the array is sorted, ri and qi must move forward looking for further cases, else move the sliding window
                if (sortedDictionary[rI] == r * sortedDictionary[qI] && sortedDictionary[qI] == r * sortedDictionary[pI])
                {
                    tripletsCount++;
                }
                //moving the sliding window
                //for each iteration move rI first up the ending position, then qI then pI
                if (rI < n - 1)
                {
                    //move rI
                    rI++;
                }
                else if (qI < n - 2)
                {
                    //move qI
                    qI++;
                    rI = qI + 1;
                }
                else //rI is at [n-1] and qI is at [n-2]
                {
                    //move position indexes window
                    pI++; qI = pI + 1; rI = qI + 1;
                }
            }

            return tripletsCount;
        }


        ////https://www.hackerrank.com/challenges/count-triplets-1/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
        public static int GeometricTriplets(List<long> arr, long r) 
        {
            arr.Sort();

            long[] sortedArray = arr.ToArray();
            int n = sortedArray.Length;

            int pI = 0, qI = pI + 1, rI = qI + 1; // PI is back index of sliding window ''caterpillar, RI is head index
            int tripletsCount = 0;

            while (pI < n - 2) //stops when the window indexes are invalid by +1
            {
                ////since the array is sorted, ri and qi must move forward looking for further cases, else move the sliding window
                if (sortedArray[rI]/r == sortedArray[qI] && sortedArray[qI]/r == sortedArray[pI] )
                {
                    tripletsCount++;
                }
                //moving the sliding window
                //for each iteration move rI first up the ending position, then qI then pI
                if (rI < n - 1) 
                {
                    //move rI
                    rI++;
                }
                else if (qI < n - 2)
                {
                    //move qI
                    qI++;
                    rI = qI + 1;
                }
                else //rI is at [n-1] and qI is at [n-2]
                {
                    //move position indexes window
                    pI++; qI = pI + 1; rI = qI + 1;
                }
            }

            return tripletsCount;
        }
    }
}
