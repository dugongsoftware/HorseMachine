using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horses
{
    public class CSVRepository : IRepository
    {
        public String Path { get; set; }

        public CSVRepository(String path)
        {
            this.Path = path;
        }

        public void Add(Horse horse)
        {
            throw new NotImplementedException();
        }

        public void AddRace(Race race)
        {
            throw new NotImplementedException();
        }
    }
}
