using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Appication.DTOs
{
    public class AddGoodDto
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
    }
}
