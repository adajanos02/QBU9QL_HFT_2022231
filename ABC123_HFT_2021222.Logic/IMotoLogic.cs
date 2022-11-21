using System.Linq;
using QBU9QL_HFT_2021222.Models;

namespace ABC123_HFT_2021222.Logic
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