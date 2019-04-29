using System;

namespace NewYearChaos
{
    internal class Program
    {
        // Complete the minimumBribes function below.
        private static void minimumBribes(int[] q)
        {
            int bribe = 0;
            bool chaotic = false;
            int n = q.Length;
            for (int i = 0; i < n; i++)
            {
                if (q[i] - (i + 1) > 2)
                {
                    chaotic = true;
                    break;
                }
                for (int j = Math.Max(0, q[i] - 1 - 1); j < i; j++)
                {
                    if (q[j] > q[i])
                    {
                        bribe++;
                    }
                }
            }
            if (chaotic)
            {
                Console.WriteLine("Too chaotic");
            }
            else
            {
                Console.WriteLine(bribe);
            }
        }

        private static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine());

                int[] q = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp))
                ;
                minimumBribes(q);
            }
        }
    }
}