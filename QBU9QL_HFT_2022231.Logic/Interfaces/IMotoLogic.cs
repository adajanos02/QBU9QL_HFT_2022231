using System.Collections;
using System.Collections.Generic;
using System.Linq;
using QBU9QL_HFT_2022231.Models;

namespace QBU9QL_HFT_2022231.Logic.Interfaces
{
    public interface IMotoLogic
    {
        void Create(Moto item);
        void Delete(int id);
        Moto Read(int id);
        IQueryable<Moto> ReadAll();
        void Update(Moto item);
        IEnumerable<object> ThisModelHasTheBestBrand();
        IEnumerable<object> CompanyOlderThan70();
    }
}