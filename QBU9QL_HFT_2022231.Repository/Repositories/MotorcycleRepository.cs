using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QBU9QL_HFT_2022231.Models;
using QBU9QL_HFT_2022231.Repository.Data;
using QBU9QL_HFT_2022231.Repository.Interfaces;

namespace QBU9QL_HFT_2022231.Repository.Repositories
{
    public class MotorcycleRepository : Repository<Motorcycle>, IRepository<Motorcycle>
    {
        public MotorcycleRepository(MotoDbContext ctx) : base(ctx)
        {
        }

        public override Motorcycle Read(int id)
        {
            return ctx.Motorcycless.FirstOrDefault(t => t.MotoId == id);
        }

        public override void Update(Motorcycle item)
        {
            var old = Read(item.MotoId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
