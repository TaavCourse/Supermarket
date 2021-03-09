using Supermarket;
using Supermarket.Infa;
using Supermarket.Domain;
using Supermarket.Domain.Goods;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Supermarket.Appication.DTOs;

namespace Supermarket.Appication.Goods
{

    public interface GoodCategoryRepository
    {
        public Task<bool> IsGoodCategoryDuplicatedAsync(string title);
        public Task<GoodCategory> AddAsync(GoodCategory goodCategory);
        Task<IEnumerable<GetGoodCategoryDto>> GetAll();
        Task<GoodCategory> GetGoodCategoryByIdAsync(int id);
        void RemoveGoodCategory(GoodCategory goodCategory);
    }
    //////////////////////////////////////////////////////////////////////
    public class EFGoodCategoryRepository : GoodCategoryRepository
    {
        private readonly dbAppication _context;
        //--------------------------------------------------
        public EFGoodCategoryRepository(dbAppication context)
        {
            _context = context;
        }
        //--------------------------------------------------
        public async Task<bool> IsGoodCategoryDuplicatedAsync(string title)
        {
            return await _context.GoodCategories.AnyAsync(_ => _.Title == title);
        }
        //--------------------------------------------------
        public async Task<GoodCategory> AddAsync(GoodCategory goodCategory)
        {
            var newGoodCategory=await _context.GoodCategories.AddAsync(goodCategory);
            return newGoodCategory.Entity;
        }
        //--------------------------------------------------
        public async Task<IEnumerable<GetGoodCategoryDto>> GetAll()
        {
            return await _context.GoodCategories.Select
                 (_ => new GetGoodCategoryDto
                 {
                     Id = _.Id,
                     Title = _.Title
                 }).ToListAsync();
        }
        //--------------------------------------------------
        public async Task<GoodCategory> GetGoodCategoryByIdAsync(int id)
        {
           return await _context.GoodCategories.FindAsync(id);
        }
        //--------------------------------------------------
        public void RemoveGoodCategory(GoodCategory goodCategory)
        {
            _context.Remove(goodCategory);
        }
        //--------------------------------------------------
    }
}