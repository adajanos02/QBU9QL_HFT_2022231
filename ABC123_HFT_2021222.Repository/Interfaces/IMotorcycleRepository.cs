using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QBU9QL_HFT_2021222.Models;

namespace QBU9QL_HFT_2021222.Repository.Interfaces
{
    public interface IMotorcycleRepository : IRepository<Motorcycle>
    {
        void UpdatePrice(int id, int newPrice);
    }
}
