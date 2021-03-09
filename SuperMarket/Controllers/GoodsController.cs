using Microsoft.AspNetCore.Mvc;
using Supermarket.Appication.DTOs;
using Supermarket.Appication.Goods;
using Supermarket.Domain.Goods;
using Supermarket.Infa.UOW;
using SuperMarket.Models;
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
        private readonly GoodRepository _goodRepository;
        private readonly UnitOfWork _UOW;
        public GoodsController(GoodRepository goodRepository,UnitOfWork unitOfWork)
        {
            _goodRepository = goodRepository;
            _UOW = unitOfWork;
        }
        //----------------------------------------
        [HttpPost]
        public async Task Add([FromBody]AddGoodDto dto)
        {
            if(await _goodRepository.IsExistGoodByCodeAsync(dto.Code))
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

            await _goodRepository.AddGoodAsync(good);

           await  _UOW.CompleteAsync();
        }
        //----------------------------------------
    }
}
