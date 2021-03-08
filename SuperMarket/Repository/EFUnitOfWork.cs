using SuperMarket.Models;
using System;

namespace SuperMarket.Controllers.Repository
{
    internal class EFUnitOfWork : UnitOfWork
    {
        private readonly ApplicationContex _context;

        public EFUnitOfWork()
        {
            _context = new ApplicationContex();
        }
        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}