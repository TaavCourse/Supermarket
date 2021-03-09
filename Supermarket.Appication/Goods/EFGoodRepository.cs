using Supermarket.Infa;
using Supermarket.Domain.Goods;
using Supermarket.Infa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.Appication.Goods
{
    public interface GoodRepository
    {
        Task<Good> AddGoodAsync(Good good);
        Task<List<Good>> GetAllAsync();
        Task<bool> IsExistGoodByCodeAsync(string code);
    }
    //////////////////////////////////////////////////////////////////////
    public class EFGoodRepository : GoodRepository
    {
        //------------------------------------------------------
        private readonly dbAppication _context;
        //------------------------------------------------------
        public EFGoodRepository(dbAppication contex)
        {
            _context = contex;
        }
        //------------------------------------------------------
        public async Task<Good> AddGoodAsync(Good good)
        {
            var newGood= await _context.Goods.AddAsync(good);
            return newGood.Entity;
        }
        //------------------------------------------------------
        public async Task<List<Good>> GetAllAsync()
        {
            return await  _context.Goods.ToListAsync();
        }
        //------------------------------------------------------
        public async Task<bool> IsExistGoodByCodeAsync(string code)
        {
            return await _context.Goods.AnyAsync(_ => _.Code == code);
        }
        //------------------------------------------------------

    }
}
