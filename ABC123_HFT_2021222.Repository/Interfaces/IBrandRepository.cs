using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QBU9QL_HFT_2021222.Models;

namespace QBU9QL_HFT_2021222.Repository.Interfaces
{
    public class IBrandRepository : IRepository<Brands>
    {
        public void Create(Brands item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Brands Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Brands> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Brands item)
        {
            throw new NotImplementedException();
        }
    }
}
