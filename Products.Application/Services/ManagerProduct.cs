using Products.Application.Interfaces;
using Products.Domain.Entities;
using Products.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Services
{
    public class ManagerProduct : IManagerProduct
    {
        private readonly IRepositoryProduct _repositoryProduct;

        public ManagerProduct(IRepositoryProduct repositoryProduct)
        {
            this._repositoryProduct = repositoryProduct;
        }

        public async Task<int> InsertProductAsync(Product product) 
        {
            var id = await this._repositoryProduct.InsertProductAsync(product);
            return id;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await this._repositoryProduct.GetProductByIdAsync(id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await this._repositoryProduct.GetAllProductsAsync();
        }
        
    }
}
