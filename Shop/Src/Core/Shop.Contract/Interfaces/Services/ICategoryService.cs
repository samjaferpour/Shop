using Shop.Contract.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Contract.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<CategoryResponse> AddCategoryAsync(CategoryRequest request);
        Task<CategoryResponse> EditCategoryAsync(Guid id, CategoryRequest request);
        Task<CategoryResponse> RemoveCategoryAsync(Guid id);
        Task<CategoryResponse> FindCategoryByIdAsync(Guid id);
        Task<IEnumerable<CategoryResponse>> ShowAllCategoriesAsync();
    }
}
