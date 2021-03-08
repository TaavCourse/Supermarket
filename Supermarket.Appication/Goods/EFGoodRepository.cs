using Microsoft.EntityFrameworkCore;
using Supermarket.Domain;
using Supermarket.Domain.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.Appication.Goods
{
    public interface GoodRepository
    {
        Task<Good> AddGoodAsync(Good good);
        Task<List<Good>> GetAllAsync();
    }
    //////////////////////////////////////////////////////////////////////
    public class EFGoodRepository : GoodRepository
    {
        //------------------------------------------------------
        private readonly dbApplication _context;
        //------------------------------------------------------
        public EFGoodRepository(dbApplication contex)
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
        
    }
}
