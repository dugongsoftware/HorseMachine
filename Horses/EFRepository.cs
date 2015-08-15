using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horses
{
    public class EFRepository : IRepository
    {
        public EFRepository()
        {

        }

        public void Add(Horse horse)
        {
            using (HorseEntities db = new HorseEntities())
            {
                db.Horses.Add(horse);
                db.SaveChanges();
            }
        }

        private Horse GetHorse(String name)
        {
            using (HorseEntities db = new HorseEntities())
            {
                Horse horse = db.Horses.FirstOrDefault(h => h.Name == name);

                if (horse == null)
                {
                    horse = new Horse();
                    horse.Name = name;
                    db.Horses.Add(horse);
                    db.SaveChanges();

                    return horse;
                }
                else
                {
                    return horse;
                }
            }
        }

        public void AddRace(Race race)
        {
            using (HorseEntities db = new HorseEntities())
            {
                db.Races.Add(race);
                db.SaveChanges();
            }
        }
    }
}
