using MXGP.Models.Riders.Contracts;
using System.Linq;

namespace MXGP.Repositories
{
    public class RiderRepository : Repository<IRider>
    {
        public RiderRepository()
            : base()
        {
        }

        public override IRider GetByName(string name)
        {
            IRider toReturn = this.Models.FirstOrDefault(m => m.Name == name);

            return toReturn;
        }
    }
}
