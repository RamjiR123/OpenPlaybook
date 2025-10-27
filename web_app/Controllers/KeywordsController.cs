using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using web_app.Models;
using web_app.Services;

namespace web_app.Controllers
{
    // controller for keyword stuff
    // route base: /api/keywords
    [ApiController]
    [Route("api/[controller]")]
    public class KeywordsController : ControllerBase
    {
        private readonly IKeywordService _keywordService;
        private readonly WorldSeriesService _worldSeriesService;

        public KeywordsController(IKeywordService keywordService, WorldSeriesService worldSeriesService)
        {
            _keywordService = keywordService;
            _worldSeriesService = worldSeriesService;
        }

        // POST /api/keywords/extract
        // takes { "query": "<user text>", "filter": <int> }
        // returns { "vector": [...], "worldSeriesResults": [...] }
        [HttpPost("extract")]
        public ActionResult<KeywordExtractionResult> Extract([FromBody] KeywordExtractionRequest req)
        {
            // fail-safe if body not sent
            var userText = req?.Query ?? string.Empty;

            // filter mode int
            // -1 default, 0 team, 1 player, 2 game, 3 quarter/period
            var filterMode = req?.Filter ?? -1;

            // get semantic keyword vector (ex: ["WON","WORLD SERIES","2016"])
            var vector = _keywordService.ExtractKeywords(userText, filterMode);

            // we'll build this up only if user is actually talking world series
            var wsResults = new List<WorldSeriesResult>();

            // check if "WORLD SERIES" is even in the request
            bool mentionsWorldSeries = vector.Contains("WORLD SERIES");

            if (mentionsWorldSeries)
            {
                // grab any 4-digit numbers that look like years
                // we trust the keyword service to already have things like "2016", "2017"
                // but we also backstop with a regex just in case
                var yearCandidates = new List<int>();

                // 1) pull years that were already added as tokens
                foreach (var token in vector)
                {
                    if (int.TryParse(token, out var y) && y >= 1800 && y <= 3000)
                    {
                        yearCandidates.Add(y);
                    }
                }

                // 2) pull years that might still only live in free text (paranoid)
                var yearRegex = new Regex(@"\b(18|19|20)\d{2}\b");
                foreach (Match m in yearRegex.Matches(userText))
                {
                    if (int.TryParse(m.Value, out var y))
                    {
                        yearCandidates.Add(y);
                    }
                }

                // remove dup years like [2016,2016]
                yearCandidates = yearCandidates.Distinct().ToList();

                // look up each year in our kaggle snapshot
                foreach (var y in yearCandidates)
                {
                    var ws = _worldSeriesService.GetYear(y);
                    if (ws != null)
                    {
                        wsResults.Add(ws);
                    }
                }
            }

            // final response payload back to frontend
            return Ok(new KeywordExtractionResult
            {
                Vector = vector,
                WorldSeriesResults = wsResults
            });
        }
    }
}
