﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBU9QL_HFT_2021222.Models
{
    internal interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}