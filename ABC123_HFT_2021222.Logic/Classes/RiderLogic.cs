using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QBU9QL_HFT_2021222.Logic.Interfaces;
using QBU9QL_HFT_2021222.Models;
using QBU9QL_HFT_2021222.Repository.Interfaces;

namespace QBU9QL_HFT_2021222.Logic.Classes
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
    }
}
