using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using QBU9QL_HFT_2022231.Models;

namespace QBU9QL_HFT_2022231.Logic.Interfaces
{
    public interface IRiderLogic
    {
        void Create(Rider item);
        void Delete(int id);
        Rider Read(int id);
        IQueryable<Rider> ReadAll();
        void Update(Rider item);
        IEnumerable<object> HasMoreThan800ccmMoto();
        IEnumerable<object> HasAprilia();
        IEnumerable<object> HasETZModel();
    }
}