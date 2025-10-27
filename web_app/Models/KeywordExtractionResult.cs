using System.Collections.Generic;

namespace web_app.Models
{
    // what we send back
    // vector looks like ["WON","WORLD SERIES","2016"]
    // worldseriesresults is info pulled from the kaggle snapshot
    public class KeywordExtractionResult
    {
        public List<string> Vector { get; set; } = new List<string>();

        // results we found in world series data for any mentioned years
        public List<WorldSeriesResult> WorldSeriesResults { get; set; } =
            new List<WorldSeriesResult>();
    }
}
