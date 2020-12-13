using MyProductStore.Core.Interfaces;
using MyProductStore.Core.Repositories;
using MyProductStore.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace MyProductStore.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ProductStoreDbContext _context;
        private readonly IProductRepository _productRepository;

        public UnitOfWork(ProductStoreDbContext context)
        {
            _context = context;
        }

        public IProductRepository Products => _productRepository ?? new ProductRepository(_context);

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
