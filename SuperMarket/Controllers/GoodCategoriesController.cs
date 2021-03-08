using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Controllers.Repository;
using SuperMarket.Models;
using SuperMarket.Models.Dtos;
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
        private readonly ApplicationContex _context;
        private readonly UnitOfWork _unitOfWork;
        private GoodCategoryRepository _Repository;

        public GoodCategoriesController(UnitOfWork unitOfWork, GoodCategoryRepository repository)
        {
            _Repository = repository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public void Add([Required][FromBody] string title)
        {
            if (_Repository.IsGoodCategoryDuplicated(title))
            {
                throw new GoodCategoryTitleCantBeDuplicatedExcption();
            }

            var goodCategory = new GoodCategory
            {
                Title = title
            };

            _Repository.Add(goodCategory);
            _unitOfWork.Complete();
        }

        [HttpGet]
        public IList<GetGoodCategoryDto> GetAll()
        {
            return _context.GoodCategories.Select
                  (_ => new GetGoodCategoryDto
                  {
                      Id = _.Id,
                      Title = _.Title
                  }).ToList();
        }

        [HttpPut("{id}")]
        public void Update(int id, UpdateGoodCategoryDto dto)
        {
            var category = _context.GoodCategories.Find(id);

            category.Title = dto.Title;

            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var category = _context.GoodCategories.Find(id);
            _context.GoodCategories.Remove(category);

            /* var goodCategory = new GoodCategory { Id = id };
             _context.Entry(goodCategory).State = EntityState.Deleted;*/

            _context.SaveChanges();
        }
    }
}
