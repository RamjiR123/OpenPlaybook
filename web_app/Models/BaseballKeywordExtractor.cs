using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace BaseballKeywordExtractor{
    class Program
    {
        //keywords
        private static readonly List<string> Keywords = new List<string>
        {"WON", "LOST", "ALCS", "NLCS", "ALDS", "NLDS", "WILD CARD", "CHAMPIONSHIP", "WORLD SERIES"};

        // regex for multiple word keywords (such as "world series")
        private static readonly List<Regex> KeywordPatterns = new List<Regex>();

        static void Main()
        {
            InitializeKeywords();

            string input = GetUserInput();
            List<string> vector = ExtractKeywords(input);

            Console.WriteLine("\nMatched keyword vector:");
            Console.WriteLine($"[ {string.Join(", ", vector)} ]");
        }

        ///adds years 2010-2025 to Keywords
        private static void InitializeKeywords()
        {
            for (int y = 2010; y <= 2025; y++)
                Keywords.Add(y.ToString());

            //regex for multiple word keywords (such as "world series")
            foreach (var kw in Keywords)
                KeywordPatterns.Add(new Regex(BuildWordBoundaryPattern(kw), RegexOptions.Compiled));
        }

        /// asks user question and returns one line of input.
        private static string GetUserInput()
        {
            Console.WriteLine("Enter postseason search (e.g., \"who won the ALCS in 2018 and the World Series?\"):");
            Console.Write("> ");
            return Console.ReadLine() ?? string.Empty;
        }

        ///makes input all caps (to not be case-sensitive)
        ///returns unique keyword matches
        private static List<string> ExtractKeywords(string rawInput)
        {
            //uppercase it
            string input = rawInput.ToUpperInvariant();

            var found = new List<(int idx, string kw)>();

            for (int i = 0; i < Keywords.Count; i++)
            {
                var kw = Keywords[i];
                var rx = KeywordPatterns[i];

                foreach (Match m in rx.Matches(input))
                {
                    if (m.Success)
                    {
                        found.Add((m.Index, kw));
                    }
                }
            }

            //sorts based on what came first (for future to add better computational grammar understanding)
            found.Sort((a, b) => a.idx.CompareTo(b.idx));

            //copy to vector
            var result = new List<string>(found.Count);
            foreach (var f in found) result.Add(f.kw);
            return result;
        }

        //this is for keywords with spaces (such as "world series")
        private static string BuildWordBoundaryPattern(string keywordAllCaps)
        {
            
            var parts = keywordAllCaps.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++) parts[i] = Regex.Escape(parts[i]);
            string middle = string.Join(@"\s+", parts);

            return $@"\b{middle}\b";
        }
    }
}
