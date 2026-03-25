using ApiProduct.Domain.Entities;

namespace ApiProduct.Domain.Repository
{
    public interface IProductRepository
    {
        public Task<Product> GetById(int id);
        public Task<int> AddProduct(Product request);
        public Task<int> UpdateProduct(Product request);
    }
}
