using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horses
{
    public class Model
    {
        public String DayOfTheWeek { get; set; }

        public String MeetingCode { get; set; }

        public String VenueName { get; set; }

        public Int32 RaceNo { get; set; }

        public String RaceTime { get; set; }

        public Int64 RaceTimeAsEpoch
        {
            get
            {
                try
                {
                    DateTime d = new DateTime(1970,0,1);
                    DateTime.TryParse(this.RaceTime, out d);

                    DateTime epoc = new DateTime(1970, 0, 1);
                    TimeSpan delta = epoc - d;

                    return Convert.ToInt64(delta.TotalSeconds);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public Int32 Distance { get; set; }

        public Int16 WeatherCond { get; set; }

        public Int16 TrackCond { get; set; }

        public Int32 TrackRating { get; set; }

        public Int16 Barrier { get; set; }

        public Double Weight { get; set; }

        public String RunnerName { get; set; }

        public String Rider { get; set; }

        public Int16 RunnerNo { get; set; }

        public Boolean Won { get; set; }

        public Int32 WonAsInt
        {
            get
            {
                return Convert.ToInt32(this.Won);
            }
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}", DayOfTheWeek, MeetingCode, VenueName, RaceNo, RaceTimeAsEpoch,
                Distance, WeatherCond, TrackCond, TrackRating, Barrier, Weight, RunnerName, Rider, RunnerNo, WonAsInt);
        }
    }
}
