using Microsoft.AspNetCore.Mvc;
using web_app.Models;
using web_app.Services;

namespace web_app.Controllers
{
    //controller for keyword stuff
    //route base: /api/keywords
    [ApiController]
    [Route("api/[controller]")]
    public class KeywordsController : ControllerBase
    {
        private readonly IKeywordService _keywordService;

        public KeywordsController(IKeywordService keywordService)
        {
            _keywordService = keywordService;
        }

        //POST /api/keywords/extract
        //takes { "query": "<user text>" }
        //returns { "vector": [ ... ] }
        [HttpPost("extract")]
        public ActionResult<KeywordExtractionResult> Extract([FromBody] KeywordExtractionRequest req)
        {
            // fail-safe if body not sent
            var userText = req?.Query ?? string.Empty;

            var vector = _keywordService.ExtractKeywords(userText);

            return Ok(new KeywordExtractionResult
            {
                Vector = vector
            });
        }
    }
}
