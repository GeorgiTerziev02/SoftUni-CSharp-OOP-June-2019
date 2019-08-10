using MXGP.Models.Races.Contracts;
using System.Linq;

namespace MXGP.Repositories
{
    public class RaceRepository : Repository<IRace>
    {
        public RaceRepository()
            :base()
        {
        }

        public override IRace GetByName(string name)
        {
            IRace toReturn = this.Models.FirstOrDefault(m => m.Name == name);

            return toReturn;
        }
    }
}
