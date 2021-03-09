using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Supermarket.Appication.DTOs;
using Supermarket.Appication.Goods;
using Supermarket.Domain.Goods;
using Supermarket.Infa.UOW;
using SuperMarket.Models;
using SuperMarket.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.Controllers
{
    [ApiController]
    [Route("api/good-categories")]
    public class GoodCategoriesController : Controller
    {
        
        private readonly UnitOfWork _unitOfWork;
        private GoodCategoryRepository _GoodCategoryRepository;

        public GoodCategoriesController(UnitOfWork unitOfWork, GoodCategoryRepository goodCategoryRepository)
        {
            _GoodCategoryRepository = goodCategoryRepository;
            _unitOfWork = unitOfWork;
        }
        //-----------------------------------------
        [HttpPost]
        public async Task Add([Required][FromBody] string title)
        {
            if (await _GoodCategoryRepository.IsGoodCategoryDuplicatedAsync(title))
            {
                throw new GoodCategoryTitleCantBeDuplicatedExcption();
            }

            var goodCategory = new GoodCategory
            {
                Title = title
            };

            await _GoodCategoryRepository.AddAsync(goodCategory);
           await  _unitOfWork.CompleteAsync();
        }
        //----------------------------------------
        [HttpGet]
        public async Task<IEnumerable<GetGoodCategoryDto>> GetAll()
        {
            return await _GoodCategoryRepository.GetAll();
        }
        //----------------------------------------
        [HttpPut("{id}")]
        public async Task Update(int id, UpdateGoodCategoryDto dto)
        {
            var category =await _GoodCategoryRepository.GetGoodCategoryByIdAsync(id);

            category.Title = dto.Title;

            await _unitOfWork.CompleteAsync();
        }
        //----------------------------------------
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var goodCategory =await _GoodCategoryRepository.GetGoodCategoryByIdAsync(id);
            _GoodCategoryRepository.RemoveGoodCategory(goodCategory);
            await _unitOfWork.CompleteAsync();
        }
        //----------------------------------------
    }
}
