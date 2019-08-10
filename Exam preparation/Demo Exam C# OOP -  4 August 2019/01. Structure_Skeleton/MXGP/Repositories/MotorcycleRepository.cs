using MXGP.Models.Motorcycles.Contracts;
using System.Linq;

namespace MXGP.Repositories
{
    public class MotorcycleRepository: Repository<IMotorcycle>
    {
        public MotorcycleRepository()
            :base()
        {

        }

        public override IMotorcycle GetByName(string name)
        {
            IMotorcycle toReturn = this.Models.FirstOrDefault(m => m.Model == name);

            return toReturn;
        }
    }
}
