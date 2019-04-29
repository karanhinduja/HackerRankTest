using System;
using System.IO;
using System.Linq;

namespace RepeatedString
{
    internal class Program
    {
        // Complete the repeatedString function below.
        private static long repeatedString(string s, long n)
        {
            long A_Occurance = s.Count(x => x == 'a');
            int strLen = s.Length;
            var possibleStringRepeatitions = n / strLen;
            A_Occurance *= possibleStringRepeatitions;
            var offsetStringLength = n % s.Length;
            for (int i = 0; i < offsetStringLength; i++)
            {
                if (s[i] == 'a')
                {
                    A_Occurance++;
                }
            }
            return A_Occurance;
        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            string s = Console.ReadLine().ToLower().Trim();
            long n = Convert.ToInt64(Console.ReadLine().Trim());
            long result = repeatedString(s, n);
            //Console.WriteLine(result);
            //Console.Read();
            textWriter.WriteLine(result);
            textWriter.Flush();
            textWriter.Close();
        }
    }
}