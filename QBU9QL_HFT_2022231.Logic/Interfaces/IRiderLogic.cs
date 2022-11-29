using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using QBU9QL_HFT_2022231.Models;

namespace QBU9QL_HFT_2022231.Logic.Interfaces
{
    public interface IRiderLogic
    {
        void Create(Riders item);
        void Delete(int id);
        Riders Read(int id);
        IQueryable<Riders> ReadAll();
        void Update(Riders item);
        IEnumerable<object> HasMoreThan800ccmMoto();
        IEnumerable<object> HasAprilia();
        IEnumerable<object> HasETZModel();
    }
}