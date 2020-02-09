using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Assignment1
{
    class Program
    {
        private static void Main(string[] args)
        {
            int n = 5;
            PrintPattern(n);

            int n2 = 6;
            PrintSeries(n2);

            string s = "09:15:35PM";
            string t = UsfTime(s);
            Console.WriteLine(t);

            int n3 = 110;
            int k = 11;
            UsfNumbers(n3, k);

            string[] words = new string[] { "abcd" , "dcba", "lls", "s", "sssll" };
            PalindromePairs(words);

            int n4 = 9;
            Stones(n4);

        }
        //Problem 1 
        /// <summary>
        /// This method creates a countdown line that decreases in size each iteration. Given a positive interger(n), it creates a reversed enumerable range. Using a while loop 
        /// it iterates a decreasing countdown of the range until the counter, "n", has reached 0. 
        /// Each line range also decreases in size by one in each line iteration iteration by using the counter as guide.
        /// </summary>
        /// <param name="n"> number of lines for the pattern entered </param>
        private static void PrintPattern(int n)
        {
            try
            {
                if (n <= 0)
                {
                    Console.WriteLine("printPattern Error: Number of lines entered (n) must be greater than 0");
                }
                while (n > 0)
                {
                    int[] mySequence = Enumerable.Range(1, n).ToArray();
                    Array.Reverse(mySequence);
                    string printSequence = string.Join("", mySequence);  //formats output so the range is printed without spaces in between
                    Console.WriteLine(printSequence);
                    n--;
                }
                Console.WriteLine("");
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printPattern");
            }

        }

        //Problem 2
        /// <summary>
        /// This method allows one to easily add the numbers in sequence and view the sum of these numbers in a list printout. 
        /// Given a positive interger(n2), it creates an enumerable range containing intergers, these intergers are summed
        /// and logged into a list by using a while loop. The list is finally formatted to print the sum of each previous number
        /// with a comma in between
        /// </summary>
        /// <param name="n2"> number of terms entered </param>
        private static void PrintSeries(int n2)
        {
            try
            {
                if (n2 <= 0)
                {
                    Console.WriteLine("PrintSeries Error: Number of terms in a series (n2) must be an interger greater than 0");
                }
                int ans = 0; 
                int index = 0;
                List<int> mySeries = new List<int>();
                int[] myRange = Enumerable.Range(1, n2).ToArray();
                while (n2 > 0)
                {
                    ans += myRange[index];
                    mySeries.Add(ans);
                    index++;
                    n2--;
                }
                string printSeries = string.Join(",", mySeries);
                Console.WriteLine(printSeries);
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printSeries");
            }

        }

        //Problem 3 
        /// <summary>
        /// Method converts Earth Time to Planet USF Time using DateTime class format checks to ensure that the input
        /// string (s) is entered in hh:mm:sstt format. Once input has been verified Earth Time units are converted to seconds
        /// and converted back to USF units using the 36 U, 60 S and 45 F conversions specified. The return provides
        /// the result in UU:SS:FF format.
        /// </summary>
        /// <param name="s">String passed to be checked if entered earth time is in correct format </param>
        /// <returns> formatError= message showing error|| result = USF Time </returns>     
        public static string UsfTime(string s)
        {
            try
            {
                CultureInfo american = new CultureInfo("en-US");
                DateTime earthTime;
                if (!DateTime.TryParseExact(s, "hh:mm:sstt", american, DateTimeStyles.None, out earthTime))
                {
                    string formatError = "UsfTime Error: Enter time in hh:mm:ssAM or hh:mm:ssPM format";
                    return formatError + Environment.NewLine;
                }
                else
                {
                    double hourToSec = (earthTime.Hour * 60) * 60;
                    double minToSec = (earthTime.Minute * 60);
                    double seconds = (earthTime.Second);
                    double inputTotalSec = hourToSec + minToSec + seconds;
                    double hourUSF = inputTotalSec / (45 * 60);
                    double minUSF = (hourUSF - Math.Truncate(hourUSF)) * 60;
                    double secUSF = (minUSF - Math.Truncate(minUSF)) * 45;
                    string result = $"{Math.Truncate(hourUSF).ToString("00.##", american)}:{Math.Truncate(minUSF).ToString("00.##", american)}:{Math.Round(secUSF).ToString("00.##", american)}";
                    return result + Environment.NewLine;
                }
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing UsfTime");
                return null;
            }
        }
        
        //Problem 4
        /// <summary>
        /// Given two positive intergers defining range size and number per line. This method prints the range in the defined format replacing 
        /// number divisible by 3, 5, or 7 for characters U,S, or F respectively. If a number is divisible by two or more of these specified intergers
        /// the method prints all the applicable characters. This is checked by using nested conditionals that replace the variable output.
        /// <param name="n3"> total number of intergers</param>
        /// <param name="k"> number of numbers per line</param>
        public static void UsfNumbers(int n3, int k)
        {
            if (n3<=0 || k <= 0)
            {
                Console.WriteLine("UsfNumbers Error: Please enter numbers greater than 0 for the total number of intergers(n3) and number of lines(k)"
                    +Environment.NewLine);
            }
            else
            {
                try
                {
                    // Write your code here
                    int[] totalInt = Enumerable.Range(0, n3).ToArray();
                    for (int i = 1; i <= totalInt.Length; i++)
                    {
                        string output; // variable that will be printed
                        if (i % 3 == 0)   //nested conditionals
                        {
                            if (i % 5 == 0 && i % 7 == 0)
                            {
                                output = "USF";
                            }
                            else if (i % 5 == 0)
                            {
                                output = "US";
                            }
                            else if (i % 7 == 0)
                            {
                                output = "UF";
                            }
                            else
                            {
                                output = "U";
                            }
                        }
                        else if (i % 5 == 0)
                        {
                            if (i % 7 == 0)
                            {
                                output = "SF";
                            }
                            else
                            {
                                output = "S";
                            }
                        }
                        else if (i % 7 == 0)
                        {
                            output = "F";
                        }
                        else
                        {
                            output = i.ToString();
                        }
                        Console.Write(output + " ");
                        if (i % k == 0)
                        {
                            Console.Write(Environment.NewLine);
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Exception occured while computing UsfNumbers()");
                }
                Console.WriteLine();

            }
        }

        //Problem 5
        /// <summary>
        /// Given an array of strings with two items or more the method checks if the concatenation of each one of the items
        /// creates a palindrome, a word that is a mirror of itself if split in half. If the new merged word is a palindrome the method will
        /// output the index location of these two words in a list in the order that it is paired. The method does this creating a dictiorany of
        /// index value pairs for each word and concatenated word value. Then using a loop it checks each characted in the string (i.e. first vs last) to
        /// make sure they match. If they do throughout the string, then it's a palindrome and it gets added to a new dictionary which is
        /// then printed. The method disregards uppercases characters.
        /// by converting them in lower cases.
        /// </summary>
        /// <param name="words"></param>
        public static void PalindromePairs(string[] words)
        {
            if (words.Length < 2)
            {
                Console.WriteLine("PalindromePairs Error: Array of words must have at least two string items");
            }
            else
            {
                try
                {
                    // Write your code here
                    Dictionary<Tuple<int, int>, string> pairs = new Dictionary<Tuple<int, int>, string>();
                    for (int a = 0; a < words.Length; a++)
                    {
                        for (int b = 0; b < words.Length; b++)
                        {
                            string merged = string.Concat(words[a], words[b]);
                            if (merged.Length % 2 != 0)
                            {
                                continue;
                            }
                            pairs.Add(new Tuple<int, int>(a, b), merged);
                        }
                    }
                    Dictionary<Tuple<int, int>, string> palindromes = new Dictionary<Tuple<int, int>, string>();
                    foreach (KeyValuePair<Tuple<int, int>, string> word in pairs)
                    {
                        int min = 0;
                        int max = word.Value.Length - 1;
                        int check = 1; // ON/OFF variable = 1 is on, 0 is off
                        while (check == 1)
                        {
                            if (min > max)
                            {
                                palindromes.Add(word.Key, word.Value);
                                break;
                            }
                            char left = word.Value[min];
                            char right = word.Value[max];
                            if (char.ToLower(left) != char.ToLower(right))
                            {
                                check = 0;
                            }
                            min++;
                            max--;
                        }
                    }
                    string output = String.Join(",", palindromes.Keys).Replace("(", "[");
                    string finalOutput = output.Replace(")", "]");
                    Console.WriteLine("[" + finalOutput + "]");
                }
                catch
                {
                    Console.WriteLine("Exception occured while computing PalindromePairs()");
                }
            }
            Console.WriteLine();
        }

        //Problem 6
        /// <summary>
        /// This method simulates scenarios of a two-player game where each player is allowed to draw between one to three stones per turn
        /// from a bag filled with rocks. The person who draws the last rock from the bag is the person that wins the game. The scenarios simulated
        /// will inform player one, if depending on the number of stones, whether he/she will loose(fail) or a set of draws they should make in order
        /// to win. This method prints the List of draws that each player will make in order for player one to win. The list contains the number of 
        /// stones each player draws with each odd turn (index in the list) being turns for player one. The method determines the number of stones that 
        /// the player should draw by checking what is the remainder when the number of stones left is divided by four. If the remainder is zero the player 
        /// whose turn is next is bound to loose. We use a uint data type to ensure that the number of stones in the bag is not less than 0.
        /// </summary>
        /// <param name="n4"> the number of stones in the bag </param>
        public static void Stones(int n4)
        {
            if (n4 < 4)
            {
                Console.WriteLine("Stones Error: Bag must have at least four stones for both players to play");
            }
            else
            {
                try
                {
                    // Write your code here
                    uint remains = Convert.ToUInt32(n4);
                    List<uint> takenOut = new List<uint>();
                    uint take = 0;
                    int index = 0;
                    Random rnd = new Random();
                    while (remains > 0)
                    {
                        switch (remains % 4)
                        {
                            case 0:
                                if (index % 2 == 0)
                                {
                                    Console.WriteLine("false");
                                    return;
                                }
                                else
                                {
                                    take = Convert.ToUInt32(rnd.Next(1, 4));
                                    takenOut.Insert(index, take);
                                    break;
                                }
                            case 1:
                                take = 1;
                                takenOut.Insert(index, take);
                                break;
                            case 2:
                                take = 2;
                                takenOut.Insert(index, take);
                                break;
                            case 3:
                                take = 3;
                                takenOut.Insert(index, take);
                                break;
                        }
                        remains -= take;
                        index++;
                    }
                    Console.WriteLine("[" + String.Join(",", takenOut) + "]");
                }
                catch
                {
                    Console.WriteLine("Exception occured while computing Stones()");
                }

            }

        }
    }
}
