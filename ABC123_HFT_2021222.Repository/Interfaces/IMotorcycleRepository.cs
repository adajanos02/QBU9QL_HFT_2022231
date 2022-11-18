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
        public void Create(Motorcycle item)
        {
            this.Create(item);
        }

        public void Delete(int id)
        {
            this.Delete(id);
        }

        public Motorcycle Read(int id)
        {
            return this.Read(id);
        }

        public IQueryable<Motorcycle> ReadAll()
        {
            return this.ReadAll();
        }

        public void Update(Motorcycle item)
        {
            this.Update(item);
        }
    }
}
