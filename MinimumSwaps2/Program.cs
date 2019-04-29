using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MinimumSwaps2
{
    internal class Program
    {
        // Complete the minimumSwaps function below.
        private static int minimumSwaps(int[] arr)
        {
            int n = arr.Length;
            int ans = 0;
            var p = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                p[arr[i]] = i;
            }
            var list = p.Keys.ToList();
            list.Sort();
            var visited = new bool[n];
            for (int i = 0; i < n; i++)
            {
                if (visited[i] || p[list[i]] == i)
                {
                    continue;
                }
                int cycle = 0;
                int j = i;
                while (!visited[j])
                {
                    visited[j] = true;
                    j = p[list[j]];
                    cycle++;
                }
                ans += (cycle - 1);
            }
            return ans;
        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int res = minimumSwaps(arr);
            textWriter.WriteLine(res);
            textWriter.Flush();
            textWriter.Close();
        }
    }
}
