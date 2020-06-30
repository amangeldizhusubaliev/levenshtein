using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace levenshtein
{
    class levenshtein
    {
        public static int Compare(string a, string b)
        {
            int alen = a.Length;
            int blen = b.Length;
            int[,] d = new int[2,blen + 1];
            for (int j = 0; j <= blen; j++)
            {
                d[0, j] = j;
            }
            for (int i = 1; i <= alen; i++)
            {
                d[i & 1, 0] = i;
                for (int j = 1; j <= blen; j++)
                {
                    d[i & 1, j] = Math.Min(Math.Min(d[i & 1, j - 1], d[(i & 1) ^ 1, j]) + 1, d[(i & 1) ^ 1,j - 1] + (a[i - 1] != b[j - 1] ? 1 : 0));
                }
            }
            return d[alen & 1, blen];
        }
    }
}
