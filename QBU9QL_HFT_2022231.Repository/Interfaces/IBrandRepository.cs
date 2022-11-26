using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QBU9QL_HFT_2022231.Models;

namespace QBU9QL_HFT_2022231.Repository.Interfaces
{
    public interface IBrandRepository : IRepository<Brands>
    {
        public void Create(Brands item)
        {
            this.Create(item);
        }

        public void Delete(int id)
        {
            this.Delete(id);
        }

        public Brands Read(int id)
        {
            return this.Read(id);
        }

        public IQueryable<Brands> ReadAll()
        {
            return this.ReadAll();
        }

        public void Update(Brands item)
        {
            this.Update(item);
        }
    }
}
