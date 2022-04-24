namespace StringProblems
{
    public class UndergroundSystem
    {
        Dictionary<int, Customer> dctCheckIn;
        List<Station> stations;
        public UndergroundSystem()
        {
            dctCheckIn = new Dictionary<int, Customer>();
            stations = new List<Station>();
        }

        public void CheckIn(int id, string stationName, int t)
        {
            Customer customer = new Customer()
            {
                Id = id,
                Station = stationName,
                TravelType = TravelType.CheckIn,
                Time = t
            };

            if(!stations.Exists(x=>x.StationName == stationName))
            {
                stations.Add(new Station(stationName));
            }
            
            dctCheckIn.Add(id, customer);

        }

        public void CheckOut(int id, string stationName, int t)
        {
            if (dctCheckIn.ContainsKey(id))
            {
                Customer customer = dctCheckIn[id];

                var st = stations.FirstOrDefault(x => x.StationName == customer.Station);



                st?.AddDestinationStationTime(stationName,  t - customer.Time);
            }

            dctCheckIn.Remove(id);
        }

        public double GetAverageTime(string startStation, string endStation)
        {
            var st = stations.FirstOrDefault(x => x.StationName == startStation);
            if (st != null)
            {
               return st.GetAverageTimeOfDestinationStation(endStation);
            }
            return 0;
        }
    }
}
