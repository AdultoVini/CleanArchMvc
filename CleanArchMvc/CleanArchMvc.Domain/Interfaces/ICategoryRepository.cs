using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetById(int? id);
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<Category> Remove(Category category);
    }
}
