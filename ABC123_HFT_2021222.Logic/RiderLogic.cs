using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QBU9QL_HFT_2021222.Models;
using QBU9QL_HFT_2021222.Repository.Interfaces;

namespace QBU9QL_HFT_2021222.Logic
{
    internal class RiderLogic 
    {
        IRepository<Riders> repo;

        public RiderLogic(IRepository<Riders> repo)
        {
            this.repo = repo;
        }

        public void Create(Riders item)
        {
            this.Create(item);
        }

        public void Delete(int id)
        {
            this.Delete(id);
        }

        public Riders Read(int id)
        {
            return this.Read(id);
        }

        public IQueryable<Riders> ReadAll()
        {
            return this.ReadAll();
        }

        public void Update(Riders item)
        {
            this.Update(item);
        }
    }
}
