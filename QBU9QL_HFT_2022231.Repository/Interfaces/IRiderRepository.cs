using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QBU9QL_HFT_2022231.Models;

namespace QBU9QL_HFT_2022231.Repository.Interfaces
{
    public interface IRiderRepository : IRepository<Riders>
    {
        public void Create(Riders item)
        {
            this.Create(item);
        }

        public void Delete(int id)
        {
            this.Delete(id);
        }

        public Riders Read(int id)
        {
            
            return this.Read(id);
        }

        public IQueryable<Riders> ReadAll()
        {
            return this.ReadAll();
        }

        public void Update(Riders item)
        {
            this.Update(item);
        }
    }
}
