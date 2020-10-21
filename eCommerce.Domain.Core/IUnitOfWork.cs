using System;
using System.Threading.Tasks;

namespace eCommerce.Domain.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }

        int Commit();
        Task<int> CommitAsync();
    }
}