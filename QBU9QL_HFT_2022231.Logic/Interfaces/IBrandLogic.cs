using System.Linq;
using QBU9QL_HFT_2022231.Models;

namespace QBU9QL_HFT_2022231.Logic.Interfaces
{
    internal interface IBrandLogic
    {
        void Create(Brands item);
        void Delete(int id);
        Brands Read(int id);
        IQueryable<Brands> ReadAll();
        void Update(Brands item);
    }
}