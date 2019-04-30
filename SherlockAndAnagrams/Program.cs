using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SherlockAndAnagrams
{
    internal class Program
    {
        //private static void Main(String[] args)
        //{
        //    ProcessInput();
        //    //RunSampleTestcase(); 
        //}

        //public static void RunSampleTestcase()
        //{
        //    var hashedAnagramsDictionary = sherlockAndAnagrams("abba");

        //    var pairs = CalculatePairs(hashedAnagramsDictionary);

        //    Debug.Assert(pairs == 4);
        //}

        //public static void ProcessInput()
        //{
        //    var queries = int.Parse(Console.ReadLine());

        //    while (queries-- > 0)
        //    {
        //        var input = Console.ReadLine();

        //        var hashedAnagramsDictionary = sherlockAndAnagrams(input);

        //        Console.WriteLine(CalculatePairs(hashedAnagramsDictionary));
        //    }
        //}

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                int result = CalculatePairs(sherlockAndAnagrams(s));

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
        /*
     * Make sure that two anagram strings will have some hashed code
     * 
     * @frequencyTable - Dictionary<char, int>
     * The frequency table has to be sorted first and then construct 
     * a string with each char in alphabetic numbers concatenated by 
     * its occurrences. 
     * 
     */
        public static int GetHashedAnagram(Dictionary<char, int> frequencyTable)
        {
            // build frequency table dynamically, how many time? O(n*n), n 
            // is the string's length
            StringBuilder key = new StringBuilder();

            foreach (var item in frequencyTable.OrderBy(s => s.Key))
            {
                key.Append(item.Key + item.Value.ToString());
            }

            return key.ToString().GetHashCode();
        }

        /*
         * What should be taken cared of in the design? 
         * Time complexity: 
         * 3 for loops 
         * first loop, loop on the substring's length
         * second loop, loop on the substring's start position
         * third loop, go over each char in the substring to build a 
         * frequency table first; and then
         * update hashed anagram counting dictionary - a statistics, basically 
         * tell the fact like this:
         * For example, test case string abba, 
         * substring ab -> hashed key a1b1, value is 2, because there are 
         * two substrings: "ab","ba" having hashed key: "a1b1"
         * Here are all possible hashed keys: 
         * a1   - a, a, 
         * b1   - b, b
         * a1b1 - ab, ba
         * b2   - bb
         * a1b2 - abb, bba
         * a2b2 - abba
         * 
         */
        public static Dictionary<int, int> sherlockAndAnagrams(string input)
        {
            var hashedAnagramsDictionary = new Dictionary<int, int>();

            var length = input.Length;

            for (var substringLength = 1; substringLength < length; substringLength++)
            {
                for (var index = 0; index <= length - substringLength; index++)
                {
                    var frequencyTable = new Dictionary<char, int>();

                    // build frequency table dynamically, how many time? O(n*n), 
                    // n is the string's length
                    for (var start = index; start < index + substringLength; start++)
                    {
                        char c = input[start];
                        if (frequencyTable.ContainsKey(c))
                        {
                            frequencyTable[c]++;
                        }
                        else
                        {
                            frequencyTable.Add(c, 1);
                        }
                    }

                    var key = GetHashedAnagram(frequencyTable);

                    if (hashedAnagramsDictionary.ContainsKey(key))
                    {
                        hashedAnagramsDictionary[key]++;
                    }
                    else
                    {
                        hashedAnagramsDictionary.Add(key, 1);
                    }
                }
            }

            return hashedAnagramsDictionary;
        }

        /*
         * The formula to calculate pairs
         * For example, test case string abba, 
         * substring ab -> hashed key a1b1, value is 2, because there are 
         * two substrings: "ab","ba" having hashed key: "a1b1"
         * Here are all possible hashed keys: 
         * a1   - a, a, 
         * b1   - b, b
         * a1b1 - ab, ba
         * b2   - bb
         * a1b2 - abb, bba
         * a2b2 - abba
         * So, how many pairs? 
         * should be 4, from 4 hashed keys: a1, b1, a1b1 and a2b2
         */
        public static int CalculatePairs(Dictionary<int, int> hashedAnagrams)
        {
            // get pairs
            int anagrammaticPairs = 0;

            foreach (var count in hashedAnagrams)
            {
                anagrammaticPairs += count.Value * (count.Value - 1) / 2;
            }

            return anagrammaticPairs;
        }
    }
}
