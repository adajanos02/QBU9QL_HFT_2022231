using System.Linq;
using QBU9QL_HFT_2022231.Models;

namespace QBU9QL_HFT_2022231.Logic.Interfaces
{
    public interface IMotoLogic
    {
        void Create(Motorcycle item);
        void Delete(int id);
        Motorcycle Read(int id);
        IQueryable<Motorcycle> ReadAll();
        void Update(Motorcycle item);
    }
}