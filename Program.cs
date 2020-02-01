﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Diagnostics;

namespace Assignment1
{
    class Program
    {
        private static void Main(string[] args)
        {
            /*int num = 5;
            PrintPattern(num);*/

            /*int n2 = 6;
            PrintSeries(n2);*/

            /*string s = "12:30";
            string t = UsfTime(s);
            Console.WriteLine(t);*/

            /*int n3 = 110;
            int k = 11;
            UsfNumbers(n3, k);*/

            string[] words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
            PalindromePairs(words);

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
        private static void PrintSeries(int n2)
        {
            /*n2 – number of terms of the series, integer (int)
             *This method prints the following series till n terms: 1, 3, 6, 10, 15, 21……
             *For example, if n2 = 6, output will be
            * 1,3,6,10,15,21
            * Returns : N / A
            * Return type: void
            * Hint: Series is 1,1 + 2 = 3,1 + 2 + 3 = 6,1 + 2 + 3 + 4 = 10,1 + 2 + 3 + 4 + 5 = 15, 1 + 2 + 3 + 4 + 5 + 6 = 21……
            */
            try
            {
                int num2 = n2;
                int ans = 0;
                int counter = 0;
                List<int> mySeries = new List<int>();
                while (num2 > 0)
                {
                    int[] myRange = Enumerable.Range(1, n2).ToArray();
                    ans += myRange[counter];
                    mySeries.Add(ans);
                    counter++;
                    num2--;
                }
                string printSeries = string.Join(",", mySeries);
                Console.WriteLine(printSeries);
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printSeries");
            }

        }


        //Problem 3 
        public static string UsfTime(string s)
        {
            /* On planet “USF” which is similar to that of Earth follows different clock
             * where instead of hours they have U , instead of minutes they have S , instead
             * of seconds they have F. Similar to earth where each day has 24 hours, each hour
             * has 60 minutes and each minute has 60 seconds , USF planet’s day has 36 U , each
             * U has 60 S and each S has 45 F. 
             * Your task is to write a method usfTime which takes 12HR  format and return string 
             * representing input time in USF time format.
             * Input format: A string s with time in 12 hour clock format (i.e. hh:mm:ssAM or            * hh:mm:ssPM) where 01<= hh<=12, 00<=mm,ss,<=60
             * Output format: a string with converted time in USF clock format (i.e. UU:SS:FF ) 
             * where 01<= UU<=36, 00<=SS<=59,00<=FF<=45
             * 
             * Sample Input : 09:15:35PM
             * Sample Output: 28:20:35 
             * 
             * returns      : String
             * return type  : string
             * 
             * Hint: One way of doing this is by calculating total number of seconds in Input time
             * and dividing those seconds according to USF time.
             */
            try
            {
                CultureInfo american = new CultureInfo("en-US");
                DateTime earthTime = Convert.ToDateTime(s, american);
                double hourToSec = (earthTime.Hour * 60) * 60;
                double minToSec = (earthTime.Minute * 60);
                double seconds = (earthTime.Second);
                double inputTotalSec = hourToSec + minToSec + seconds;
                double hourUSF = inputTotalSec / (45 * 60);
                double minUSF = (hourUSF - Math.Truncate(hourUSF)) * 60;
                double secUSF = (minUSF - Math.Truncate(minUSF)) * 45;
                string result = $"{Math.Truncate(hourUSF).ToString("00.##", american)}:{Math.Truncate(minUSF).ToString("00.##", american)}:{Math.Round(secUSF).ToString("00.##", american)}";
                return result;
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing UsfTime");
            }
            return null;
        }

        //Problem 4
        public static void UsfNumbers(int n3, int k)
        {
            /*n- total number of integers( 110 )
             * k-number of numbers per line ( 11)
             * USF Numbers : This method prints the numbers 1 to 110, 11 numbers per line.
             * The method shall print 'U' in place of numbers which are multiple of 3,"S" for 
             * multiples of 5,"F" for multiples of 7, 'US' in place of numbers which are multiple 
             * of 3 and 5,'SF' in place of numbers which are multiple of 5 and 7 and so on. 
             * The output shall look like 
             * 1 2 U 4 S U F 8 U S 11 
             * U 13 F US 16 17 U 19 S UF 22
             * 23 U S 26 U F 29 US 31 32 U....
             * 
             * returns      : N/A
             * return type  : void
             */

            try
            {
                // Write your code here
                int[] totalInt = Enumerable.Range(0, n3).ToArray();
                for (int i = 1; i <= totalInt.Length; i++)
                {
                    string output;
                    if (i%3 == 0 && i%5 ==0 && i%7 == 0)  //try to use nesting instead
                    {
                        output = "USF";
                    }
                    else if (i%5==0 && i % 7 == 0)
                    {
                        output = "SF";
                    }
                    else if (i%3 == 0 && i%7 ==0) 
                    {
                        output = "UF";
                    }
                    else if (i % 3 == 0 && i % 5 == 0)
                    {
                        output = "US";
                    }
                    else if (i % 5 == 0)
                    {
                        output = "S";
                    }
                    else if (i % 7 == 0)
                    {
                        output = "F";
                    }
                    else if (i % 3 == 0)
                    {
                        output = "U";
                    }
                    else
                    {
                        output = i.ToString();
                    }
                    Console.Write(output + " ");
                    if (i % 11 == 0)
                    {
                        Console.Write(Environment.NewLine);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing UsfNumbers()");
            }
        }


        //Problem 5
        public static void PalindromePairs(string[] words)
        {
            /*You are given a list of unique words, the task is to find all the pairs of 
             * distinct indices (i,j) in the given list such that, the concatenation of two
             * words i.e. words[i]+words[j] is a palindrome.
             * Example:
             * Input: ["abcd","dcba","lls","s","sssll"]
             * Output: [[0,1],[1,0],[3,2],[2,4]] 
             * Explanation: The palindromes are ["dcbaabcd","abcddcba","slls","llssssll"]
             * Example:
             * Input: ["bat","tab","cat"]
             * Output: [[0,1],[1,0]] 
             * Explanation: The palindromes are ["battab","tabbat"]
             * 
             * returns      : N/A
             * return type  : void
             */
            //try
            //{
                // Write your code here
                string[,] palindromes;
                for (int a = 0; a < words.Length; a++)
                {
                    for (int b = 0; b < words.Length; b++) 
                    {
                        string merged = string.Concat(words[a], words[b]);
                        Debug.WriteLine(merged);
                        if (merged.Length%2 == 0)
                        {
                            int mid = merged.Length / 2;
                            Debug.WriteLine("mid: " + mid);
                            int max = merged.Length - 1;
                            //Debug.WriteLine(merged.Substring(merged.Length+max));
                            for (int min = 0; min < mid; min++)
                            {
                                char left = merged[min];
                                char right = merged[max]; 
                                //Debug.WriteLine(merged[i]); 
                                if (char.ToLower(left) == char.ToLower(right))
                                {
                                    Console.Write("Pali Match: " + merged);
                                    Console.WriteLine("");
                                }
                                else { Debug.WriteLine("Not a pali: " + merged); }
                                max--;
                            }
                        }
                    }
                    
                }
                
            //}
            //catch
            //{

            //    Console.WriteLine("Exception occured while computing PalindromePairs()");
            //}
        }

        /*        public static void Stones(int n4)
                {
                    try
                    {
                        // Write your code here
                    }
                    catch
                    {
                        Console.WriteLine("Exception occured while computing Stones()");
                    }*/


    }
}
