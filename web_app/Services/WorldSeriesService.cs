using System.Collections.Generic;
using System.Globalization;
using System.IO;
using web_app.Models;

namespace web_app.Services
{
    //reads Data/WorldSeries.csv once and lets us pull winner/loser for a given year
    public class WorldSeriesService
    {
        //store results by year for quick lookup
        private readonly Dictionary<int, WorldSeriesResult> _byYear =
            new Dictionary<int, WorldSeriesResult>();

        public WorldSeriesService()
        {
            //build absolute path to the csv in the repo
            //(Data/WorldSeries.csv under web_app)
            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Data",
                "WorldSeries.csv"
            );

            if (!File.Exists(path))
            {
                //csv missing, just bail. no throw because we still want the app to run
                return;
            }

            using (var reader = new StreamReader(path))
            {
                //read header first line ("Year,Winner,...")
                var header = reader.ReadLine();

                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    //naive csv split. this is fine because our fields do not contain commas
                    var cols = line.Split(',');

                    if (cols.Length < 4)
                        continue;

                    //Year,Winner,Loser,Games
                    if (!int.TryParse(cols[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out int y))
                        continue;

                    var row = new WorldSeriesResult
                    {
                        Year = y,
                        Winner = cols[1],
                        Loser = cols[2],
                        Games = cols[3]
                    };

                    _byYear[y] = row;
                }
            }
        }

        //simple helper to get one year. returns null if no series that year
        public WorldSeriesResult? GetYear(int year)
        {
            if (_byYear.TryGetValue(year, out var row))
                return row;
            return null;
        }
    }
}
