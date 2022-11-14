using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QBU9QL_HFT_2021222.Models;
using QBU9QL_HFT_2021222.Repository.Interfaces;
using QBU9QL_HFT_2021222.Repository.Data;

namespace QBU9QL_HFT_2021222.Repository.Repositories
{
    public class BrandRepository : Repository<Brands>, IRepository<Brands>
    {
        public BrandRepository(MotoDbContext ctx) : base(ctx)
        {
        }

        public override Brands Read(int id)
        {
            return ctx.Brands.FirstOrDefault(t => t.BrandId == id);
        }

        public override void Update(Brands item)
        {
            var old = Read(item.BrandId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
