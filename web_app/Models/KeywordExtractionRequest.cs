namespace web_app.Models
{
    //body we get from the frontend
    //example: { "query": "who won the alcs in 2018 and the world series" }
    public class KeywordExtractionRequest
    {
        public string? Query { get; set; }
    }
}
