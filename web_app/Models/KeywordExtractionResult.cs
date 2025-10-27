using System.Collections.Generic;

namespace web_app.Models
{
    //whats sent back
    //vector looks like ["WON","ALCS","2018","WORLD SERIES"]
    public class KeywordExtractionResult
    {
        public List<string> Vector { get; set; } = new List<string>();
    }
}
