using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QBU9QL_HFT_2022231.Logic.Interfaces;
using QBU9QL_HFT_2022231.Models;
using QBU9QL_HFT_2022231.Repository.Interfaces;

namespace QBU9QL_HFT_2022231.Logic.Classes
{
    public class BrandLogic : IBrandLogic
    {
        IRepository<Brands> repo;

        public BrandLogic(IRepository<Brands> repo)
        {
            this.repo = repo;
        }

        public void Create(Brands item)
        {
            Create(item);
        }

        public void Delete(int id)
        {
            Delete(id);
        }

        public Brands Read(int id)
        {
            return Read(id);
        }

        public IQueryable<Brands> ReadAll()
        {
            return ReadAll();
        }

        public void Update(Brands item)
        {
            Update(item);
        }
    }
}
