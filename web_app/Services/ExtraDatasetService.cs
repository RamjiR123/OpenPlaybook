using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace web_app.Services
{
    //this loads the bigger mlb dataset (awards, games, plays, etc)
    //we are not using it in any query yet. it's just preloaded and ready.
    //
    //we read each csv into memory as raw lines so other code can inspect it later
    //without hitting disk again
    public class ExtraDatasetService
    {
        //this keeps the file contents in memory
        //key = relative path like "awards/Most_Valuable_Player.csv"
        //value = all lines from that csv
        private readonly Dictionary<string, List<string>> _files =
            new Dictionary<string, List<string>>();

        public ExtraDatasetService()
        {
            //base dir inside repo where you dropped the zip
            //expected: web_app/Data/mlb/
            var baseDir = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Data",
                "mlb"
            );

            //list of csv files we know about. if any are missing it's fine.
            var csvs = new[]
            {
                "awards/ALCS_MVP.csv",
                "awards/Comeback_Player_of_the_Year.csv",
                "awards/Cy_Young.csv",
                "awards/Gold_Glove.csv",
                "awards/Hank_Aaron_Award.csv",
                "awards/Manager_of_the_Year.csv",
                "awards/Most_Valuable_Player.csv",
                "awards/NLCS_MVP.csv",
                "awards/Relief_Man_Award.csv",
                "awards/Roberto_Clemente_Award.csv",
                "awards/Rookie_of_the_Year.csv",
                "awards/Silver_Slugger.csv",
                "awards/World_Series_MVP.csv",
                "baserunningNotes.csv",
                "events.csv",
                "fieldingNotes.csv",
                "games.csv",
                "hittersByGame.csv",
                "hittingNotes.csv",
                "inningHighlights.csv",
                "inningScore.csv",
                "letterNotes.csv",
                "pitchersByGame.csv",
                "pitches.csv",
                "pitchingNotes.csv",
                "plays.csv"
            };

            foreach (var relPath in csvs)
            {
                //build absolute path like Data/mlb/awards/ALCS_MVP.csv
                var fullPath = Path.Combine(
                    baseDir,
                    relPath.Replace("/", Path.DirectorySeparatorChar.ToString())
                );

                if (!File.Exists(fullPath))
                    continue;

                //read all lines and stash
                var allLines = File.ReadAllLines(fullPath).ToList();
                _files[relPath] = allLines;
            }
        }

        //returns everything we loaded
        //key is filename relative to Data/mlb
        //value is the raw csv lines
        public IReadOnlyDictionary<string, List<string>> GetAll()
        {
            return _files;
        }

        //quick helper if you only want one file
        //example usage later: GetFile("awards/World_Series_MVP.csv")
        public IReadOnlyList<string> GetFile(string relPath)
        {
            if (_files.TryGetValue(relPath, out var lines))
                return lines;
            return new List<string>();
        }
    }
}
