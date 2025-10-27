namespace web_app.Models
{
    // body we accept from the frontend
    // example:
    // {
    //   "query": "who won the alcs in 2018 and the world series",
    //   "filter": 0
    // }
    public class KeywordExtractionRequest
    {
        public string? Query { get; set; }

        // filter mode
        // -1 for default, 0 for "team", 1 for "player", 2 for "game", and 3 for "quarter/period"
        public int Filter { get; set; } = -1;
    }
}