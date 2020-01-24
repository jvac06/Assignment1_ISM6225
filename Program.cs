using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1
{
    class Program
    {
        private static void Main(string[] args)
        {
            int num = 5;
            PrintPattern(num);
            
            /*int n2 = 6;
            PrintSeries(n2);

            string s = "09:15:35PM";
            string t = UsfTime(s);
            Console.WriteLine(t);

            int n3 = 110;
            int k = 11;
            UsfNumbers(n3, k);

            string[] words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
            PalindromePairs(words);*/

        }
        //Problem 1 
        private static void PrintPattern(int n)
        {
            /*n – number of lines for the pattern, integer (int)
            * summary   : This method prints number pattern of integers using recursion
            * For example n = 5 will display the output as: 
            * 54321
            * 4321
            * 321
            * 21
            * 1
            * returns      : N/A
            * return type  : void
            */
            try
            {

                int num = n;
                while (num > 0)
                {
                    int[] mySequence = Enumerable.Range(1, num).ToArray();
                    Array.Reverse(mySequence);
                    string printSequence = string.Join("", mySequence);
                    Console.WriteLine(printSequence);
                    num--;
                }
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printPattern");
            }

        }

        //Problem 2
        /*private static void PrintSeries(int n2)
        {
            n2 – number of terms of the series, integer (int)
             *This method prints the following series till n terms: 1, 3, 6, 10, 15, 21……
             *For example, if n2 = 6, output will be
            * 1,3,6,10,15,21
            * Returns : N / A
            * Return type: void
            * Hint: Series is 1,1 + 2 = 3,1 + 2 + 3 = 6,1 + 2 + 3 + 4 = 10,1 + 2 + 3 + 4 + 5 = 15, 1 + 2 + 3 + 4 + 5 + 6 = 21……
            
            try
            {
                //Write your code here .!!
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printSeries");
            }
        }*/

/*        public static string UsfTime(string s)
        {
            try
            {
                //Write your code here .!!
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing UsfTime");
            }
            return null;
        }


        public static void UsfNumbers(int n3, int k)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing UsfNumbers()");
            }
        }



        public static void PalindromePairs(string[] words)
        {
            try
            {
                // Write your code here
            }
            catch
            {

                Console.WriteLine("Exception occured while computing     PalindromePairs()");
            }
        }

        public static void Stones(int n4)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing Stones()");
            }
        }
*/
    }
}
