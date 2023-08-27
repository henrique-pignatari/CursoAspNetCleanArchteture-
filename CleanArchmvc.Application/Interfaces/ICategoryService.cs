using CleanArchmvc.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchmvc.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
        Task<CategoryDTO> GetByIdAsync(int? id);
        Task AddAsync(CategoryDTO categoryDTO);
        Task UpdateAsync(CategoryDTO categoryDTO);
        Task RemoveAsync(int? id);

    }
}
