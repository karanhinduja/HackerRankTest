using System;
using System.IO;

namespace _2DArrayDS
{
    internal class Program
    {
        // Complete the hourglassSum function below.
        private static int hourglassSum(int[][] arr)
        {
            int temp;
            int max = int.MinValue;
            for (int i = 0; i < 4; i++)
            {
                for (int k = 0; k < 4; k++)
                {
                    temp = arr[i][k] + arr[i][k + 1] + arr[i][k + 2] //row 1
                        + arr[i + 1][k + 1]  //row 2
                        + arr[i + 2][k] + arr[i + 2][k + 1] + arr[i + 2][k + 2]; //row 3
                    max = Math.Max(temp, max);
                }
            }
            return max;
        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            int[][] arr = new int[6][];
            for (int i = 0; i < 6; i++)
            {
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }
            int result = hourglassSum(arr);
            textWriter.WriteLine(result);
            textWriter.Flush();
            textWriter.Close();
        }
    }
}