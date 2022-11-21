using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QBU9QL_HFT_2021222.Models;
using QBU9QL_HFT_2021222.Repository.Interfaces;

namespace QBU9QL_HFT_2021222.Logic
{
    internal class BrandLogic 
    {
        IRepository<Brands> repo;

        public BrandLogic(IRepository<Brands> repo)
        {
            this.repo = repo;
        }

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
