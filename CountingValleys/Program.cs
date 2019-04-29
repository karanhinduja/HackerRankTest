using System;
using System.IO;

namespace CountingValleys
{
    internal class Program
    {

        // Complete the countingValleys function below.
        private static int countingValleys(int n, string s)
        {
            int currentSeaLevel = 0;
            int previousSeaLevel = 0;
            int valleyCount = 0;
            for (int i = 0; i < n; i++)
            {
                switch (s[i].ToString().ToUpper())
                {
                    case "U":
                        currentSeaLevel++;
                        break;
                    case "D":
                        currentSeaLevel--;
                        break;
                }
                if (previousSeaLevel == 0 && currentSeaLevel < 0)
                {
                    valleyCount++;
                }
                previousSeaLevel = currentSeaLevel;
            }
            return valleyCount;

        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            string s = Console.ReadLine();

            int result = countingValleys(n, s);

            Console.WriteLine(result);
            //Console.ReadLine();
            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}