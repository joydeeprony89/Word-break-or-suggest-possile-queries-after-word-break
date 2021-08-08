using System;
using System.Collections.Generic;

namespace Word_break_or_suggest_possile_queries_after_word_break
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            string word = "pineapplepenapple";
            var dictionary = new List<string>() { "apple", "pen", "applepen", "pine", "pineapple" };
            Console.WriteLine(string.Join("\n", p.WordBreak(word, dictionary)));
        }

        List<string> WordBreak(string word, List<string> dictionary)
        {
            return DFS(word, dictionary, new Dictionary<string, List<string>>());
        }

        List<string> DFS(string word, List<string> dictionary, Dictionary<string, List<string>> hash)
        {
            if (hash.ContainsKey(word))
                return hash[word];
            List<string> result = new List<string>();
            if (string.IsNullOrWhiteSpace(word))
            {
                result.Add("");
                return result;
            }

            foreach (string w in dictionary)
            {
                if (word.StartsWith(w))
                {
                    string right = word.Substring(w.Length);
                    var results = DFS(right, dictionary, hash);
                    foreach (string s in results)
                    {
                        string ss = string.IsNullOrWhiteSpace(s) ? "" : " " + s;
                        result.Add(w + ss);
                    }
                }
            }
            hash.Add(word, result);
            return result;
        }
    }
}
