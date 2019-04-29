using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTablesRansomNote
{
    internal class Program
    {
        // Complete the checkMagazine function below.
        private static void checkMagazine(string[] magazine, string[] note)
        {
            Array.Sort(magazine);
            Array.Sort(note);

            List<string> ranList = note.ToList();
            List<string> magList = magazine.ToList();

            if (note.Length > magazine.Length)
            {
                Console.WriteLine("No");
                return;
            }
            int i = 0;
            foreach (var s in ranList)
            //for (int i = 0; i < ranList.Count; i++)
            {
                int idx = magList.BinarySearch(s);
                if (idx >= 0)
                {
                    magList.RemoveAt(idx);
                }
                else
                {
                    Console.WriteLine("No");
                    break;
                }
                if (i == ranList.Count - 1)
                {
                    Console.WriteLine("Yes");
                }

                i++;
            }
        }

        private static void Main(string[] args)
        {
            string[] mn = Console.ReadLine().Split(' ');
            int m = Convert.ToInt32(mn[0]);
            int n = Convert.ToInt32(mn[1]);
            string[] magazine = Console.ReadLine().Split(' ');
            string[] note = Console.ReadLine().Split(' ');
            checkMagazine(magazine, note);
        }
    }
}
