using AutoMapper;
using Shop.Contract.Dtos;
using Shop.Contract.Interfaces.Repositories;
using Shop.Contract.Interfaces.Services;
using Shop.Domain.Entities;
using Shop.Framework.MessageBrokers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRabbitMqPublisher _publisher;

        public CategoryService(
            IMapper mapper,
            ICategoryRepository repository,
            IUnitOfWork unitOfWork,
            IRabbitMqPublisher publisher
            )
        {
            this._mapper = mapper;
            this._repository = repository;
            this._unitOfWork = unitOfWork;
            this._publisher = publisher;
        }

        public async Task<AddBulkCategoryResponse> AddBulkCategoryAsync(BulkCategoryRequest request)
        {
             List<AddBulkCategoryRequest> requests = new List<AddBulkCategoryRequest>();
            foreach (var item in request.Names)
            {
                requests.Add(new AddBulkCategoryRequest
                {
                    Name = item
                });
                
            }
            await _publisher.SendMessagesAsync(requests);

            return new AddBulkCategoryResponse { TraceNo = Guid.NewGuid().ToString() };
        }

        public async Task<CategoryResponse> AddCategoryAsync(CategoryRequest request)
        {
            //var category = new Category
            //{
            //    Name = request.Name,
            //};
            var category = _mapper.Map<Category>(request);
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
                categoryResponses.Add(new CategoryResponse { Id = item.Id, Name = item.Name });
            }
            return categoryResponses;
        }
    }
}
