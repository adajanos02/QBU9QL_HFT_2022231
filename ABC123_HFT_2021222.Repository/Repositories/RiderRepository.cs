using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QBU9QL_HFT_2021222.Models;
using QBU9QL_HFT_2021222.Repository.Data;
using QBU9QL_HFT_2021222.Repository.Interfaces;

namespace QBU9QL_HFT_2021222.Repository.Repositories
{
    public class RiderRepository : Repository<Riders>, IRepository<Riders>
    {
        public RiderRepository(MotoDbContext ctx) : base(ctx)
        {
        }

        public override Riders Read(int id)
        {
            return ctx.Riders.FirstOrDefault(t => t.RiderId == id);
        }

        public override void Update(Riders item)
        {
            var old = Read(item.RiderId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
        
    }
}
