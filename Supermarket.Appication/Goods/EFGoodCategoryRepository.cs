using Supermarket;
using Supermarket.Domain;
using Supermarket.Domain.Goods;
using System;
using System.Linq;

namespace Supermarket.Appication.Goods
{

    public interface GoodCategoryRepository
    {
        public bool IsGoodCategoryDuplicated(string title);
        public void Add(GoodCategory goodCategory);

    }
    //////////////////////////////////////////////////////////////////////
    public class EFGoodCategoryRepository : GoodCategoryRepository
    {
        private readonly dbApplication _context;
        //--------------------------------------------------
        public EFGoodCategoryRepository(dbApplication context)
        {
            _context = context;
        }
        //--------------------------------------------------
        public bool IsGoodCategoryDuplicated(string title)
        {
            return _context.GoodCategories.Any(_ => _.Title == title);
        }
        //--------------------------------------------------
        public void Add(GoodCategory goodCategory)
        {
            _context.GoodCategories.Add(goodCategory);
        }
        //--------------------------------------------------
    }
}