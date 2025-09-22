using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'happyLadybugs' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING b as parameter.
     */

    public static string happyLadybugs(string b)
    {
         int n = b.Length;
         
         Dictionary<char, int> freq = new Dictionary<char, int>();
         foreach (char ch in b)
    {
        if (freq.ContainsKey(ch))
            freq[ch]++;
        else
            freq[ch] = 1;
    }
    bool hasEmpty = b.Contains('_');

    foreach (var kvp in freq)
    {
        char ch = kvp.Key;
        int count = kvp.Value;

        if (ch != '_' && count == 1)
            return "NO";
    }
    if (!hasEmpty)
    {
        for (int i = 0; i < n; i++)
        {
            if ((i == 0 || b[i] != b[i - 1]) &&
                (i == n - 1 || b[i] != b[i + 1]))
                return "NO";
        }
    }
    return "YES";
    }
}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int g = Convert.ToInt32(Console.ReadLine().Trim());

        for (int gItr = 0; gItr < g; gItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            string b = Console.ReadLine();

            string result = Result.happyLadybugs(b);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
