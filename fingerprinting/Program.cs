using System;
using System.Collections.Generic;

namespace fingerprinting
{
    class Program
    {
        static void Main(string[] args)
        {
            Winnowing test = new Winnowing(31, 100);
            //string a = "aisdoiasdoiajIOSJDIAJSDOJSAODIJ  ;  ; ; ; ; asijdiasjdjaisdl a;sdasd;adasldp[aklksd;fihwaidfj92347827348 asjdajisd";
            //string b = "aisdapofsdfoijsadigaf726731723UAHASIUDHIUSAHD : :::: '';; asdajsijdaijsdKOJIIJDAS012-----asdkIJIJASDIJASDJJJJJJJJJ";
            string a = "A do run run run, a do run run";
            string b = "";
            List<int> fa = test.GetFingerprint(a, 3, 8);
            List<int> fb = test.GetFingerprint(b, 3, 8);
            foreach (int i in fa)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("");
            foreach (int i in fb)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
