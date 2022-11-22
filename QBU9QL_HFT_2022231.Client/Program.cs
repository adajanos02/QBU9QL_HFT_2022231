using System.Linq;
using ABC123_HFT_2021222.Logic;
using QBU9QL_HFT_2021222.Logic.Classes;
using QBU9QL_HFT_2021222.Models;
using QBU9QL_HFT_2021222.Repository;
using QBU9QL_HFT_2021222.Repository.Data;
using QBU9QL_HFT_2021222.Repository.Interfaces;
using QBU9QL_HFT_2021222.Repository.Repositories;

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
            
        }
    }
}
