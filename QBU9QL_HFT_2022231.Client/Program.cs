using System.Linq;
using QBU9QL_HFT_2022231.Logic;
using QBU9QL_HFT_2022231.Logic.Classes;
using QBU9QL_HFT_2022231.Models;
using QBU9QL_HFT_2022231.Repository;
using QBU9QL_HFT_2022231.Repository.Data;
using QBU9QL_HFT_2022231.Repository.Interfaces;
using QBU9QL_HFT_2022231.Repository.Repositories;

namespace QBU9QL_HFT_2022231.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ctx = new MotoDbContext();

            var motoRepo = new MotorcycleRepository(ctx);
            var riderRepo = new RiderRepository(ctx);
            var brandRepo = new BrandRepository(ctx);

            var motoLogic = new MotoLogic(motoRepo);
            var riderLogic = new RiderLogic(riderRepo);
            var brandLogic = new BrandLogic(brandRepo);

            
            ;
        }
    }
}
