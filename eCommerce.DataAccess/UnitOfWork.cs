using eCommerce.Domain.Core;
using System.Threading.Tasks;

namespace eCommerce.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductRepository ProductRepository { get; }
        private readonly ProductContext _context;

        public UnitOfWork(ProductContext context)
        {
            _context = context;
            ProductRepository = new ProductRepository(_context);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}