using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NFLKeywordExtractor
{
    class Program
    {
        //keywords
        private static readonly List<string> Keywords = new List<string>
        {
            "WON", "LOST", "TIED",
            "OT", "OVERTIME",
            "REGULAR SEASON", "PLAYOFFS", "WILD CARD", "DIVISIONAL",
            "CONFERENCE CHAMPIONSHIP", "SUPER BOWL",
            "SCORE", "POINTS"
        };

        // regex for multiple word keywords (such as "super bowl" or "conference championship")
        private static readonly List<Regex> KeywordPatterns = new List<Regex>();

        static void Main()
        {
            InitializeKeywords();

            string input = GetUserInput();
            List<string> vector = ExtractKeywords(input);

            Console.WriteLine("\nMatched keyword vector:");
            Console.WriteLine($"[ {string.Join(", ", vector)} ]");
        }

        ///adds years, weeks, and teams to Keywords; compiles regex
        private static void InitializeKeywords()
        {
            //years commonly present in nfl datasets (adjust as needed)
            for (int y = 2000; y <= 2025; y++)
                Keywords.Add(y.ToString());

            //weeks up to 22 to be safe (regular season + odd cases)
            for (int w = 1; w <= 22; w++)
                Keywords.Add($"WEEK {w}");

            //32 nfl team abbreviations (all caps)
            string[] teams =
            {
                "ARI","ATL","BAL","BUF","CAR","CHI","CIN","CLE",
                "DAL","DEN","DET","GB","HOU","IND","JAX","KC",
                "LAC","LAR","LV","MIA","MIN","NE","NO","NYG",
                "NYJ","PHI","PIT","SEA","SF","TB","TEN","WAS"
            };
            Keywords.AddRange(teams);

            //regex for multiple word keywords (flexible spaces) and word boundaries for all tokens
            foreach (var kw in Keywords)
                KeywordPatterns.Add(new Regex(BuildWordBoundaryPattern(kw), RegexOptions.Compiled));
        }

        ///asks user question and returns one line of input.
        private static string GetUserInput()
        {
            Console.WriteLine("Enter nfl games search (e.g., \"did KC win in OT in WEEK 12 of 2023 super   bowl score?\"):");
            Console.Write("> ");
            return Console.ReadLine() ?? string.Empty;
        }

        ///makes input all caps (to not be case-sensitive)
        ///returns keyword matches in order of first appearance (duplicates allowed if mentioned multiple times)
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

        //this is for keywords with spaces (such as "super bowl" or "conference championship")
        private static string BuildWordBoundaryPattern(string keywordAllCaps)
        {
            var parts = keywordAllCaps.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++) parts[i] = Regex.Escape(parts[i]);
            string middle = string.Join(@"\s+", parts);

            return $@"\b{middle}\b";
        }
    }
}
