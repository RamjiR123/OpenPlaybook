using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace web_app.Services
{
    //this is my commit from last week but as a service for the api + frontend

    public class KeywordService : IKeywordService
    {
        //keywords
        private readonly List<string> _keywords = new List<string>
        {
            "WON", "LOST", "ALCS", "NLCS", "ALDS", "NLDS", "WILD CARD", "CHAMPIONSHIP", "WORLD SERIES"
        };

        // regex for multiple word keywords (such as "world series")
        private readonly List<Regex> _keywordPatterns = new List<Regex>();

        // ctor sets up year keywords + compiles regex once
        public KeywordService()
        {
            InitializeKeywords();
        }

        //adds years 2010-2025 to _keywords
        //then builds Regex list that matches full words / word boundaries
        private void InitializeKeywords()
        {
            for (int y = 2010; y <= 2025; y++)
                _keywords.Add(y.ToString());

            //regex for multiple word keywords (such as "world series")
            foreach (var kw in _keywords)
            {
                _keywordPatterns.Add(
                    new Regex(BuildWordBoundaryPattern(kw), RegexOptions.Compiled)
                );
            }
        }

        //makes input all caps (to not be case-sensitive)
        //returns ordered keyword matches
        public List<string> ExtractKeywords(string rawInput)
        {
            if (rawInput == null)
                rawInput = string.Empty;

            //uppercase it
            string input = rawInput.ToUpperInvariant();

            //track where each match happened so we can sort by index later
            var found = new List<(int idx, string kw)>();

            for (int i = 0; i < _keywords.Count; i++)
            {
                string kw = _keywords[i];
                Regex rx = _keywordPatterns[i];

                foreach (Match m in rx.Matches(input))
                {
                    if (m.Success)
                    {
                        found.Add((m.Index, kw));
                    }
                }
            }

            //sorts based on what came first in the user text
            //this keeps some basic grammar-ish ordering of what the user asked
            found.Sort((a, b) => a.idx.CompareTo(b.idx));

            //copy to vector
            var result = new List<string>(found.Count);
            foreach (var f in found)
                result.Add(f.kw);

            return result;
        }

        //this is for keywords with spaces (such as "world series")
        //split on spaces, escape each piece, and allow any whitespace between
        //so "world        series" still hits
        private static string BuildWordBoundaryPattern(string keywordAllCaps)
        {
            var parts = keywordAllCaps.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parts.Length; i++)
                parts[i] = Regex.Escape(parts[i]);

            //"\s+" between parts lets multiword phrases still match
            string middle = string.Join(@"\s+", parts);

            //\b ... \b so we don't match partial words
            return $@"\b{middle}\b";
        }
    }
}
