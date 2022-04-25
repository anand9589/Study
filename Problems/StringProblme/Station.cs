namespace StringProblems
{
    internal class Station
    {
        public string StationName { get; set; }

        private Dictionary<string, List<int>> DestinationStations;

        public Station(string stationName)
        {
            this.StationName = stationName;
            DestinationStations = new Dictionary<string, List<int>>();
        }

        public void AddDestinationStationTime(string stationName, int t)
        {
            if (DestinationStations.ContainsKey(stationName))
            {
                DestinationStations[stationName].Add(t);
            }
            else
            {
                DestinationStations.Add(stationName, new List<int>() { t });
            }
        }

        public double GetAverageTimeOfDestinationStation(string stationName)
        {
            if (DestinationStations.ContainsKey(stationName))
            {
                double averageTime = DestinationStations[stationName].Average();

                return averageTime;
                //return Math.Round((double)(DestinationStations[stationName].Sum() / DestinationStations[stationName].Count()), 5);
            }
            return 0;
        }
    }
}
