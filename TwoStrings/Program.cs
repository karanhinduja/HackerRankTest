using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TwoStrings
{
    internal class Program
    {
        // Complete the twoStrings function below.
        private static string twoStrings(string s1, string s2)
        {
            List<Char> s1List = s1.ToCharArray().OrderBy(x => x).ToList();
            List<Char> s2List = s2.ToCharArray().OrderBy(x => x).ToList();

            string hasValue = "NO";
            foreach (var item in s1List)
            {
                int idx = s2List.BinarySearch(item);
                if (idx >= 0)
                {
                    hasValue = "YES";
                    break;
                }
            }
            return hasValue;
        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s1 = Console.ReadLine();

                string s2 = Console.ReadLine();

                string result = twoStrings(s1, s2);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}

