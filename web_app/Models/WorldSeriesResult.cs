namespace web_app.Models
{
    //one world series entry from the csv
    //example: 2016, chicago cubs beat cleveland indians 4-3
    public class WorldSeriesResult
    {
        public int Year { get; set; }
        public string Winner { get; set; } = "";
        public string Loser { get; set; } = "";
        public string Games { get; set; } = "";
    }
}
