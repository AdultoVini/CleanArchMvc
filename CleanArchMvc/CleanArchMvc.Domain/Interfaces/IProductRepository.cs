using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetById(int? id);
        Task<Product> GetProductCategoryById(int? id);
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<Product> Remove(Product product);
    }
}
