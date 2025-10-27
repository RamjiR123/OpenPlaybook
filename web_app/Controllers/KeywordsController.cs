using Microsoft.AspNetCore.Mvc;
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

        public KeywordsController(IKeywordService keywordService)
        {
            _keywordService = keywordService;
        }

        // POST /api/keywords/extract
        // takes { "query": "<user text>", "filter": <int> }
        // returns { "vector": [ ... ] }
        [HttpPost("extract")]
        public ActionResult<KeywordExtractionResult> Extract([FromBody] KeywordExtractionRequest req)
        {
            // fail-safe if body not sent
            var userText = req?.Query ?? string.Empty;

            // this is the dropdown selection coming from frontend
            // filter mode int matches:
            // -1 default, 0 team, 1 player, 2 game, 3 quarter/period
            var filterMode = req?.Filter ?? -1;

            // pass everything into service (service now knows filter)
            var vector = _keywordService.ExtractKeywords(userText, filterMode);

            return Ok(new KeywordExtractionResult
            {
                Vector = vector
            });
        }
    }
}