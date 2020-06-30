using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace fingerprinting
{
    class Winnowing
    {
        public int prime;
        public int mod;

        public Winnowing()
        {
            prime = 31;
            mod = 1000000007;
        }

        public Winnowing(int prime, int mod)
        {
            this.prime = prime;
            this.mod = mod;
        }

        string RemoveIrrevelantSymbols(string s)
        {
            s = s.ToLower();
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                if (c >= 'a' && c <= 'z')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        int GetHash(string s)
        {
            int h = 0;
            foreach (char c in s)
            {
                h = Convert.ToInt32((Convert.ToInt64(h) * prime + c) % mod);
            }
            return h;
        }

        public List<int> GetFingerprint(string text, int noiseTreshold, int guaranteeTreshold)
        {
            text = RemoveIrrevelantSymbols(text);

            List<int> h = new List<int>();

            for (int i = 0; i < text.Length - noiseTreshold; i++)
            {
                h.Add(GetHash(text.Substring(i, noiseTreshold)));
            }

            int w = guaranteeTreshold - noiseTreshold + 1;

            List<int> ans = new List<int>();
            List<int> ids = new List<int>();

            for (int i = 0; i < h.Count; i++)
            {
                int l = Math.Max(0, i - w + 1);
                int r = i;
                int mi = l;
                for (int j = l; j <= r; j++)
                {
                    if (h[j] <= h[mi])
                    {
                        mi = j;
                    }
                }
                if (ids.Count == 0 || ids[ids.Count - 1] != mi)
                {
                    ids.Add(mi);
                    ans.Add(h[mi]);
                }
            }

            return ans;
        } 
    }
}
