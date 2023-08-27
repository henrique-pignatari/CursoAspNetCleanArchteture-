using CleanArchmvc.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchmvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task<ProductDTO> GetByIdAsync(int? id);
        Task<ProductDTO> GetProductCategoryAsync(int? id);
        Task AddAsync(ProductDTO productDTO);
        Task UpdateAsync(ProductDTO productDTO);
        Task RemoveAsync(int? id);
    }
}
