using System;
using System.IO;

namespace ArrayManipulation
{
    internal class Program
    {
        // Complete the arrayManipulation function below.
        private static long arrayManipulation(int n, int[][] queries)
        {
            long[] outputArray = new long[n + 2];
            for (int i = 0; i < queries.Length; i++)
            {
                int a = queries[i][0];
                int b = queries[i][1];
                int k = queries[i][2];
                outputArray[a] += k;
                outputArray[b + 1] -= k;
            }
            long max = getMax(outputArray);
            return max;
        }
        private static long getMax(long[] inputArray)
        {
            long max = long.MinValue;
            long sum = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                sum += inputArray[i];
                max = Math.Max(max, sum);
            }
            return max;
        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            string[] nm = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(nm[0]);
            int m = Convert.ToInt32(nm[1]);
            int[][] queries = new int[m][];
            for (int i = 0; i < m; i++)
            {
                queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
            }
            long result = arrayManipulation(n, queries);
            textWriter.WriteLine(result);
            textWriter.Flush();
            textWriter.Close();
        }
    }
}