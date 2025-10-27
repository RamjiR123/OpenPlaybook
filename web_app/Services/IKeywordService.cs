using System.Collections.Generic;

namespace web_app.Services
{
    //interface so controller isn't hard-coded to one impl
    //lets us swap baseball -> football -> nba later without touching controller
    public interface IKeywordService
    {
        //takes raw user text ("who won the alcs in 2018") and returns
        //the ordered vector of matched keywords
        List<string> ExtractKeywords(string rawInput);
    }
}
