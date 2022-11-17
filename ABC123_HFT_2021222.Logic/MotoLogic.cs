using System;
using System.Linq;
using QBU9QL_HFT_2021222.Models;
using QBU9QL_HFT_2021222.Repository;
using QBU9QL_HFT_2021222.Repository.Interfaces;

namespace ABC123_HFT_2021222.Logic
{
    public class MotoLogic 
    {
        IRepository<Motorcycle> repo;
        public MotoLogic(IRepository<Motorcycle> repo)
        {
            this.repo = repo;
        }

        public void Create(Motorcycle item)
        {
            if (item.Model.Length < 2)
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
    }
}
