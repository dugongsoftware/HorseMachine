﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Horses
{
    class Program
    {
        static void Main(string[] args)
        {
            GetTimes();

            //HorseEntities db = new HorseEntities();
            IRepository db = new EFRepository();

            //Give horses an arbitary number
            Dictionary<String, Int32> horses = new Dictionary<string, int>();

            //counter
            //Int32 horseCounter = 0;

            DateTime startDate = new DateTime(2015, 2, 7);

            while (startDate < System.DateTime.Now)
            {
                try
                {
                    XDocument raceDay = XDocument.Load(String.Format("https://tatts.com/pagedata/racing/{0}/{1}/{2}/RaceDay.xml", startDate.Year, startDate.Month, startDate.Day));

                    IEnumerable<XElement> meetings = from el in raceDay.Descendants("Meeting")
                                                     select el;

                    foreach (XElement meet in meetings)
                    {
                        String venueName = meet.Attribute("VenueName").Value;
                        Int32 trackId = 0; //db.Tracks.FirstOrDefault(t => t.Name == venueName);

                        if (trackId >= 0)
                        {
                            String meetingCode = meet.Attribute("MeetingCode").Value;
                            Int16 numberOfRaces = Convert.ToInt16(meet.Attribute("HiRaceNo").Value);

                            for (Int16 i = 1; i <= numberOfRaces; i++)
                            {
                                Console.WriteLine("{0} R{2} on {1}", venueName, startDate, i);

                                try
                                {
                                    XDocument data = XDocument.Load(String.Format("https://tatts.com/pagedata/racing/{0}/{1}/{2}/{3}{4}.xml", startDate.Year, startDate.Month, startDate.Day, meetingCode, i));
                                    //XElement data = XElement.Load(String.Format("https://tatts.com/pagedata/racing/{0}/{1}/{2}/{3}{4}.xml", startDate.Year, startDate.Month, startDate.Day, meetingCode, i));

                                    //Get races
                                    IEnumerable<XElement> raceElements = from x in data.Descendants("Race")
                                                                         select x;

                                    foreach (XElement raceElement in raceElements)
                                    {
                                        try
                                        {
                                            //XElement winner = (from el in raceElement.Descendants("ResultPlace")
                                            //                   where (string)el.Attribute("PlaceNo") == "1"
                                            //                   select el).First();

                                            //String winnerNumber = (from el in winner.Descendants("Result")
                                            //                       select el.Attribute("RunnerNo").Value).First();


                                            Race race = new Race()
                                            {
                                                RaceNumber = Convert.ToInt32(raceElement.Attribute("RaceNo").Value),
                                                Distance = Convert.ToInt32(raceElement.Attribute("Distance").Value),
                                                TrackCondition = Convert.ToInt16(raceElement.Attribute("TrackCond").Value),
                                                WeatherCondition = Convert.ToInt16(raceElement.Attribute("WeatherCond").Value),
                                                Start = DateTime.Parse(raceElement.Attribute("RaceTime").Value),
                                                TrackID = trackId
                                            };

                                            db.AddRace(race);

                                            IEnumerable<XElement> runnerElements = from el in raceElement.Descendants("Runner")
                                                                                   select el;

                                            foreach (XElement runnerElement in runnerElements)
                                            {
                                                try
                                                {
                                                    Horse horse = new Horse(); // GetHorse(runnerElement);
                                                    Runner runner = new Runner();
                                                    runner.Race = race;

                                                    String r = runnerElement.Attribute("RunnerName").Value;

                                                    Horse dbHorse = db.GetHorse(r);
                                                    runner.HorseName = dbHorse.Name;
                                                    runner.HorseID = dbHorse.ID;
                                                    runner.Barrier = Convert.ToInt16(runnerElement.Attribute("Barrier").Value);

                                                    //    horse.RunnerName = runner.Attribute("RunnerName").Value;
                                                    //    horse.Rider = runner.Attribute("Rider").Value;
                                                    //    horse.RunnerNo = Convert.ToInt16(runner.Attribute("RunnerNo").Value);

                                                    runner.Weight = Convert.ToDecimal(runnerElement.Attribute("Weight").Value);

                                                    //    if (horse.RunnerNo.ToString() == winnerNumber)
                                                    //    {
                                                    //        horse.Won = true;
                                                    //    }

                                                    Console.WriteLine("Addding {0}", runner.HorseName);

                                                    db.AddRunner(runner);

                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine(ex.Message);
                                                }
                                            }

                                            Console.WriteLine("Adding race {0}", race.RaceNumber);

                                            try
                                            {
                                                //db.SaveChanges();
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine(ex.Message);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //no xml
                    Console.WriteLine(ex.Message);
                }

                startDate = startDate.AddDays(1);

            }

            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"e:\results.csv", true))
            //{
            //    foreach (Model horse in models)
            //    {
            //        if (horse != null)
            //        {
            //            file.WriteLine(horse.ToString());
            //        }
            //    }
            //}
        }



        private static void GetTimes()
        {
            WebClient client = new WebClient();
            String html = client.DownloadString("http://www.racingandsports.com.au/en/form-guide/fullresults.asp?meeting=54007&date=7/02/2015");

            Regex timeRex = new Regex("[0-2]{1}:[0-9]{2}.[0-9]{2}");

            MatchCollection times = timeRex.Matches(html);

            foreach(Match time in times)
            {
                Console.WriteLine(time.Value);
            }
        }
    }
}
