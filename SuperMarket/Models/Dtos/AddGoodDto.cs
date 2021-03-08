using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.Models.Dtos
{
    public class AddGoodDto
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
    }
}
