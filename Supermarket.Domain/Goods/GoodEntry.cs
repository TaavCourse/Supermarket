﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.Domain.Goods
{
    public class GoodEntry
    {
        public int Id { get; set; }
        public string GoodCode { get; set; }
        public DateTime EntryDate { get; set; }
        public int GoodCount { get; set; }
    }
}
