using System;
using System.Linq;
using QBU9QL_HFT_2021222.Logic.Interfaces;
using QBU9QL_HFT_2021222.Models;
using QBU9QL_HFT_2021222.Repository;
using QBU9QL_HFT_2021222.Repository.Interfaces;

namespace QBU9QL_HFT_2021222.Logic.Classes
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
            if (item.Model.Length < 2)
            {
                throw new ArgumentException("Model name too short...");
            }
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Motorcycle Read(int id)
        {
            var moto = repo.Read(id);
            if (moto == null)
            {
                throw new ArgumentException("Moto not exists");
            }
            return moto;
        }

        public IQueryable<Motorcycle> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Motorcycle item)
        {
            repo.Update(item);
        }


    }
}
