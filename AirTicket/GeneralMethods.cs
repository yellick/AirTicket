using System;

namespace AirTicket
{
    class GeneralMethods
    {
        public string calcTravelTime(int dcx, int dcy, int acx, int acy)
        {
            decimal minutes,
                    hours = 0,
                    distanse = Convert.ToDecimal(Math.Sqrt(Math.Pow(acx - dcx, 2) + Math.Pow(acy - dcy, 2)) * 10);

            hours = distanse / 700;
            minutes = 60 * (hours % 1);

            string tt = Math.Truncate(hours) + " час, " + Math.Truncate(minutes) + " минут";
            return tt;
        }

        // access
        public string getTime(string time)
        {
            time = time.Substring(11);
            return time;
        }

        public string getDate(string date)
        {
            date = date.Substring(0, date.Length - 8);
            return date;
        }

    }
    public class CBData
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public override string ToString() => $"{Id} - {Name}";
    }
}
