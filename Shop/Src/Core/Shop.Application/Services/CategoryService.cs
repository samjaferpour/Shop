using Shop.Contract.Dtos;
using Shop.Contract.Interfaces.Repositories;
using Shop.Contract.Interfaces.Services;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository repository, IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<CategoryResponse> AddCategoryAsync(CategoryRequest request)
        {
            var category = new Category
            {
                Name = request.Name,
            };
            await _repository.InsertAsync(category);
            await _unitOfWork.CommitChangesAsync();
            var categoryResponse = new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
            };
            return categoryResponse;
        }

        public async Task<CategoryResponse> EditCategoryAsync(Guid id, CategoryRequest request)
        {
            var category = new Category
            {
                Id = id,
                Name = request.Name,
            };
            var result = await _repository.UpdateAsync(id, category);
            if (result == null)
            {
                return null!;
            }
            await _unitOfWork.CommitChangesAsync();
            var categoryResponse = new CategoryResponse
            {
                Id = result.Id,
                Name = result.Name,
            };
            return categoryResponse;
        }

        public async Task<CategoryResponse> FindCategoryByIdAsync(Guid id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null)
            {
                return null!;
            }
            var categoryResponse = new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
            };
            return categoryResponse;
        }

        public async Task<CategoryResponse> RemoveCategoryAsync(Guid id)
        {
            var category = await _repository.DeleteAsync(id);
            if (category == null)
            {
                return null!;
            }
            await _unitOfWork.CommitChangesAsync();
            var categoryResponse = new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
            };
            return categoryResponse;
        }

        public async Task<IEnumerable<CategoryResponse>> ShowAllCategoriesAsync()
        {
            var categories = await _repository.GetAllAsync();
            if (categories == null)
            {
                return null!;
            }
            var categoryResponses = new List<CategoryResponse>();
            foreach (var item in categories)
            {
                categoryResponses.Add(new CategoryResponse { Id = item.Id, Name = item.Name});
            }
            return categoryResponses;
        }
    }
}
