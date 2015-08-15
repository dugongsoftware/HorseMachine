using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horses
{
    public interface IRepository
    {
        void Add(Horse horse);

        Horse GetHorse(String name);

        void AddRace(Race race);

        void AddRunner(Runner runner);
    }

    public interface ITrackRepository
    {
        Track GetTrack(String id);
    }
}
