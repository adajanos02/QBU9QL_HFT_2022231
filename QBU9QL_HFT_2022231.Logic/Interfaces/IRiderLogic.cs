using System.Linq;
using QBU9QL_HFT_2022231.Models;

namespace QBU9QL_HFT_2022231.Logic.Interfaces
{
    internal interface IRiderLogic
    {
        void Create(Riders item);
        void Delete(int id);
        Riders Read(int id);
        IQueryable<Riders> ReadAll();
        void Update(Riders item);
    }
}