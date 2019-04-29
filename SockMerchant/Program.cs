using System;
using System.IO;
using System.Linq;

namespace SockMerchant
{
    internal class Program
    {

        // Complete the sockMerchant function below.
        private static int sockMerchant(int n, int[] ar)
        {
            var sortedAr = ar.OrderBy(x => x).ToArray();
            int findGroup = 0;
            while (sortedAr.Count() != 0)
            {
                var foundIdx = Array.LastIndexOf(sortedAr, sortedAr[0]);
                if (foundIdx == 0)
                {
                    sortedAr = sortedAr.Where((val, idx) => idx != 0).ToArray();
                }
                else
                {
                    sortedAr = sortedAr.Where((val, idx) => idx != 0 && idx != foundIdx).ToArray();
                    findGroup++;
                }
            }
            return findGroup;
        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            int[] ar = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), arTemp => Convert.ToInt32(arTemp));
            int result = sockMerchant(n, ar);
            //Console.WriteLine(result);
            //Console.ReadLine();
            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}

