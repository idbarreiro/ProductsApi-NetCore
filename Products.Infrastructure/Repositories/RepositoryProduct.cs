using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;
using Products.Infrastructure.Context;
using Products.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Infrastructure.Repositories
{
    public class RepositoryProduct : IRepositoryProduct
    {
        private readonly AppDbContext _appDbContext;

        public RepositoryProduct( AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<int> InsertProductAsync(Product product) { 
            
            var parameterId = new SqlParameter("@Id", SqlDbType.Int);
            parameterId.Direction = ParameterDirection.Output;          

            await _appDbContext.Database
                .ExecuteSqlInterpolatedAsync($@"EXEC dbo.InsertProduct @Name={product.Name} , @Description={product.Description}, @Price={product.Price}, @Stock={product.Stock}, @Id={parameterId} OUTPUT");

            var id = (int)parameterId.Value;
            return id;
        }

        
        public async Task<Product> GetProductByIdAsync(int id)
        {
            var products = _appDbContext.Products
                .FromSqlInterpolated($"EXEC dbo.GetProductById @Id={id}")
                .AsAsyncEnumerable();

            await foreach (var product in products)
            {
                return product;
            }

            throw new KeyNotFoundException("No se encontro producto con el ID {id}");
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _appDbContext.Products
                .FromSqlInterpolated($"EXEC dbo.GetAllProducts")
                .ToListAsync();
        }
        
    }
}
