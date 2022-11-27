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
    public class RiderLogic : IRiderLogic
    {
        IRepository<Riders> repo;

        public RiderLogic(IRepository<Riders> repo)
        {
            this.repo = repo;
        }

        public void Create(Riders item)
        {
            Create(item);
        }

        public void Delete(int id)
        {
            Delete(id);
        }

        public Riders Read(int id)
        {
            return Read(id);
        }

        public IQueryable<Riders> ReadAll()
        {
            return ReadAll();
        }

        public void Update(Riders item)
        {
            Update(item);
        }

        public IEnumerable<Riders> HasMoreThan800ccmMoto()
        {
            return repo.ReadAll().Where(r => r.Motorcycle.EngineCapacity > 800);
        }
        public IEnumerable<Riders> HasAprilia()
        {
            return repo.ReadAll().Where(r => r.Motorcycle.Brands.Name == "Aprilia");
        }
        public IEnumerable<Riders> HasThisModel()
        {
            return repo.ReadAll().Where(r => r.Motorcycle.Model == "ETZ");
        }

    }
}
