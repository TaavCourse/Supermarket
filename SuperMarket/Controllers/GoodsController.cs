using Microsoft.AspNetCore.Mvc;
using SuperMarket.Models;
using SuperMarket.Models.Dtos;
using SuperMarket.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.Controllers
{
    [ApiController,Route("api/goods")]
    public class GoodsController : Controller
    {
        private readonly ApplicationContex _context;
        public GoodsController()
        {
            _context = new  ApplicationContex();
        }

        [HttpPost]
        public void Add([FromBody]AddGoodDto dto)
        {
            if(_context.Goods.Any(_ => _.Code == dto.Code))
            {
                throw new GoodCodeCantBeDuplicateException();
            }

            var good = new Good
            {
                Title = dto.Title,
                Code = dto.Code,
                Count = 0,
                CategoryId = dto.CategoryId
            };

            _context.Goods.Add(good);

            _context.SaveChanges();
        }
    }
}
