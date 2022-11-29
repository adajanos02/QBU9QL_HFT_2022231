using System;
using System.Linq;
using System.Collections.Generic;
using QBU9QL_HFT_2022231.Logic.Interfaces;
using QBU9QL_HFT_2022231.Models;
using QBU9QL_HFT_2022231.Repository;
using QBU9QL_HFT_2022231.Repository.Interfaces;

namespace QBU9QL_HFT_2022231.Logic.Classes
{
    public class MotoLogic : IMotoLogic
    {
        IRepository<Motorcycle> repo;
        public MotoLogic(IRepository<Motorcycle> repo)
        {
            this.repo = repo;
        }

        public void Create(Motorcycle item)
        {
            if (item.Model.Length > 10)
            {
                throw new ArgumentException("Model name too short...");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Motorcycle Read(int id)
        {
            var moto = this.repo.Read(id);
            if (moto == null)
            {
                throw new ArgumentException("Moto not exists");
            }
            return moto;
        }

        public IQueryable<Motorcycle> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Motorcycle item)
        {
            this.repo.Update(item);
        }

        public IEnumerable<object> ThisModelHasTheBestBrand()
        {
            return this.repo.ReadAll().Where(m => m.Brands.NumbOfSoldProd == repo.ReadAll().Max(k => k.Brands.NumbOfSoldProd)).Select(m => m.Model);
        }
        public IEnumerable<object> CompanyOlderThan70()
        {
            return this.repo.ReadAll().Where(m => m.Brands.EstablishmentYear < 1952).Select(m => m.Brands.Name).Distinct();
        }





    }
}
