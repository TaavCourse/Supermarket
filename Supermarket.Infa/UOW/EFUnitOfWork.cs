
using System;
using System.Threading.Tasks;

namespace Supermarket.Infa.UOW
{

    public interface UnitOfWork
    {
        Task CompleteAsync();
    }
    //////////////////////////////////////////////////////
    internal class EFUnitOfWork : UnitOfWork
    {
        private readonly dbAppication _context;

        public EFUnitOfWork()
        {
            _context = new dbAppication();
        }
        //---------------------------------------
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        //---------------------------------------
    }
}