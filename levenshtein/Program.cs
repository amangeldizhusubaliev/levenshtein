using System;

namespace levenshtein
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(levenshtein.Compare(args[0], args[1]));
        }
    }
}
