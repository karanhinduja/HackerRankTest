using System;
using System.IO;
using System.Linq;

namespace ArraysLeftRotation
{
    internal class Program
    {
        // Complete the rotLeft function below.
        private static int[] rotLeft(int[] a, int d)
        {
            var firstPart = a.Where((val, idx) => idx < d);
            var secondPart = a.Where((val, idx) => idx >= d);
            return secondPart.Concat(firstPart).ToArray();
        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            string[] nd = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(nd[0]);
            int d = Convert.ToInt32(nd[1]);
            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
            int[] result = rotLeft(a, d);
            textWriter.WriteLine(string.Join(" ", result));
            textWriter.Flush();
            textWriter.Close();
        }
    }
}