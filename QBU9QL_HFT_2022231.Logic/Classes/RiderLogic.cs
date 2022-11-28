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
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Riders Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Riders> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Riders item)
        {
            this.repo.Update(item);
        }

        public IEnumerable<object> HasMoreThan800ccmMoto()
        {
            return this.repo.ReadAll().Where(r => r.Motorcycle.EngineCapacity > 800);
        }
        public IEnumerable<object> HasAprilia()
        {
            return this.repo.ReadAll().Where(r => r.Motorcycle.Brands.Name == "Aprilia");
        }
        public IEnumerable<object> HasThisModel()
        {
            return this.repo.ReadAll().Where(r => r.Motorcycle.Model == "ETZ");
        }

        
    }
}
