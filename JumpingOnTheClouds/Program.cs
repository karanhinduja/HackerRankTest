using System;
using System.IO;

namespace JumpingOnTheClouds
{
    internal class Program
    {
        // Complete the jumpingOnClouds function below.
        private static int jumpingOnClouds(int[] c)
        {
            int jumpCount = 0;
            int i = 0;
            while (i < c.Length - 1)
            {
                if (i + 2 < c.Length && c[i + 2] == 0)
                {
                    i = i + 2;
                    jumpCount++;
                }
                else
                {
                    i++;
                    jumpCount++;
                }
            }
            return jumpCount;
        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            int n = Convert.ToInt32(Console.ReadLine());
            int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp));
            int result = jumpingOnClouds(c);
            //Console.WriteLine(result);
            //Console.Read();
            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
