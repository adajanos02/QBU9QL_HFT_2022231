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
        IRepository<Rider> repo;

        public RiderLogic(IRepository<Rider> repo)
        {
            this.repo = repo;
        }

        public void Create(Rider item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Rider Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Rider> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Rider item)
        {
            this.repo.Update(item);
        }

        public IEnumerable<object> HasMoreThan800ccmMoto()
        {
            return this.repo.ReadAll().Where(r => r.Motorcycle.EngineCapacity > 800).Select(r => r.Name);
        }
        public IEnumerable<object> HasAprilia()
        {
            return this.repo.ReadAll().Where(r => r.Motorcycle.Brands.Name == "Aprilia").Select(r => r.Name);
        }
        public IEnumerable<object> HasETZModel()
        {
            return this.repo.ReadAll().Where(r => r.Motorcycle.Model == "ETZ").Select(r => r.Name);
        }

        
    }
}
