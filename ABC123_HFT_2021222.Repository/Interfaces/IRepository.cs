﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QBU9QL_HFT_2021222.Models;

namespace QBU9QL_HFT_2021222.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> ReadAll();
        T Read(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
