using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Horses.Provider
{
    public class Tatts
    {
        public ICollection<String> GetMeetTracks(DateTime start)
        {
            XDocument raceDay = XDocument.Load(String.Format("https://tatts.com/pagedata/racing/{0}/{1}/{2}/RaceDay.xml", start.Year, start.Month, start.Day));

            IEnumerable<XElement> meetings = from el in raceDay.Descendants("Meeting")
                                             select el;

            ICollection<String> venues = new List<String>();
            foreach (XElement meet in meetings)
            {
                String venueName = meet.Attribute("VenueName").Value;
            }
        }
    }
}
