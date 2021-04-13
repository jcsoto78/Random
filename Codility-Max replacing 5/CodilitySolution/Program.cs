using System;
using System.Text;

namespace CodilitySolution
{
    class Program
    {
        static void Main(string[] args)
        {
            
       
            Console.WriteLine($"{new Solution(5)}");
        }
    }


    public class Solution
    {
        public int Solution(int N)
        {
    
            int input = 0;

            string inputString = "$" + input.ToString().Trim('-');

            int n = inputString.Length;

            int max = -8000;

            var sb = new StringBuilder(inputString);

            for (int i = 0; i < n + 1; i++)
            {
                sb.Replace('$', Convert.ToChar(N.ToString()));

                int parsedValue = int.Parse(sb.ToString());
                int possibleMax = input >= 0 ? parsedValue : parsedValue * -1;

                max = possibleMax > max ? possibleMax : max;

                if (i < n - 1)
                {
                    var rightValue = sb[i + 1]; //save right value
                    sb[i + 1] = '$';
                    sb[i] = rightValue;
                }
            }

            return max;
        }
    }
}
